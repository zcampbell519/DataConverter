using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Reflection;

string userId = AppConfig.ImportUserId;

// SqlConnection sqlConnection = new SqlConnection();
// SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
// sqlConnectionString.DataSource = "DNRHLNIT5TS5X33";
// sqlConnectionString.InitialCatalog = "DEVLAS";
// sqlConnectionString.IntegratedSecurity = true;
// sqlConnectionString.UserID = "LASUser";
// sqlConnectionString.Password = "AccountingIsFun!1";
// sqlConnection.ConnectionString = sqlConnectionString.ToString();
SqlConnection sqlConnection = AppConfig.SqlConnection;
Logger.Location = AppConfig.ImportErrorLog;
sqlConnection.FindOrInsert<Customer>(new Customer("UNKNOWN", ""));
sqlConnection.FindOrInsert<Customer>(new Customer("UNKNOWN", null));
AppConfig.AccessDataSources.ForEach(database =>
{
    int totalLoans = 0;
    Logger.CurrentDb = database;
    Logger.ReadingDb();
    System.Console.WriteLine($"Reading from {database.Name} at {database.Location}");
    string accessDatabase = AppConfig.Location + database.Location;
    string accessConnectionString = $"Driver={{Microsoft Access Driver (*.mdb, *.accdb)}}; Dbq={accessDatabase}; ";
    using (OdbcConnection odbcConnection = new OdbcConnection(accessConnectionString))
    {
        totalLoans = 0;
        odbcConnection.Open();
        OdbcCommand loanCommand = new OdbcCommand("SELECT * FROM loan");
        loanCommand.Connection = odbcConnection;
        using OdbcDataReader loanReader = loanCommand.ExecuteReader();

        while (loanReader.Read())
        {
            Logger.CurrentLoan = loanReader.GetString(0);
            Loan loan = new Loan(loanReader, database.Name);
            if (loan.GetCustomer().FederalTaxId == null || loan.GetCustomer().FederalTaxId=="")
                Logger.LogLoanError($"Customer {loan.GetCustomer().Name} does not have a tax id");
            Customer customer = sqlConnection.FindOrInsert<Customer>(loan.GetCustomer());
            Address address = sqlConnection.FindOrInsert<Address>(loan.GetAddress());
            Contact contact = sqlConnection.FindOrInsert<Contact>(loan.GetContactCreater().GetContact());
            ContactMethod contactMethod = sqlConnection.FindOrInsert<ContactMethod>(loan.GetContactMethod());
            CustomerContact customerContact = loan.GetContactCreater().GetCustomerContact();
            customerContact.Id = customer.Id;
            customerContact.ContactId = contact.Id;
            sqlConnection.FindOrInsert<CustomerContact>(customerContact);
            sqlConnection.FindOrInsert<CustomerAddress>(new CustomerAddress(customer.Id, address.Id));
            sqlConnection.FindOrInsert<CustomerContactContactMethod>(customerContact.GetContactMethod(contactMethod.Id));
            loan.CustomerId = customer.Id;
            loan.SetTypeId(database.Name);
            loan.ModifiedBy = userId;
            loan.ModifiedDate = DateTime.Now;

            List<Disbursement> disbursements = new List<Disbursement>();
            OdbcCommand paymentCmd = new OdbcCommand($"SELECT * FROM receipt where idno='{loan.LoanKey}'");
            OdbcCommand disbursementCmd = new OdbcCommand($"SELECT * FROM disbursement where idno='{loan.LoanKey}'");
            paymentCmd.Connection = disbursementCmd.Connection = odbcConnection;

            List<Payment> payments = new List<Payment>();

            using (OdbcDataReader paymentReader = paymentCmd.ExecuteReader())
            {
                while (paymentReader.Read())
                {
                    Payment payment = new Payment(paymentReader, database.Name);
                    payments.Add(payment);
                }
            }

            using (OdbcDataReader disbReader = disbursementCmd.ExecuteReader())
            {
                while (disbReader.Read())
                {
                    Disbursement disb = new Disbursement(disbReader, database.Name);
                    disbursements.Add(disb);
                }
            }
            decimal totalDisbursed = 0;
            disbursements.ForEach(d => totalDisbursed += d.DisbursementAmount);
            decimal totalPaid = 0;
            payments.ForEach(p => totalPaid += p.AmtPd);
            loan.setState(totalDisbursed, totalPaid, payments.Count);

            payments.Sort((a, b) => a.PaymentDueDate.CompareTo(b.PaymentDueDate));
            loan.FirstPaymentDate = payments.Count > 0 ? payments[0].PaymentDueDate : loan.GetDefaultPaymentDate(database.Name);
            loan.TerminationDate = payments.Count > 0 ? payments.Last().PaymentDueDate : loan.GetDefaultPaymentDate(database.Name);

            if (loan.Validate())
            {

                loan = sqlConnection.FindOrInsert<Loan>(loan);
            }
            else
            {
                Logger.LogLoanError("Loan failed validation");
                continue;
            }

            Amortization amortization = sqlConnection.FindOrInsert<Amortization>(loan.CreateAmortization());
            payments.ForEach(p =>
            {
                p.AmortizationId = amortization.Id;
                p.ReceivedBy = userId;
                sqlConnection.FindOrInsert<Payment>(p);
                if (p.ChkNo > 0)
                    sqlConnection.FindOrInsert<PaymentCheck>(p.GetPaymentCheck());
            });
            disbursements.ForEach(d =>
            {
                d.LoanId = loan.Id;
                d.DisbursedBy = userId;
                sqlConnection.FindOrInsert<Disbursement>(d);
            });
            InterestRateGroup rateGroup = sqlConnection.FindOrInsert(loan.GetInterestRateGroup());
            rateGroup.GetInterestRatePairs().FindOrInsertAll(sqlConnection);
            sqlConnection.FindOrInsert(loan.GetSpecificData(database.Name));
            LoanChange change = sqlConnection.FindOrInsert(loan.GetLoanChange());
            sqlConnection.FindOrInsert(change.GetChangeItem());
            totalLoans++;
        }
        Logger.LogInfo($"Wrote {totalLoans} {database.Name} loans to the database");
        System.Console.WriteLine($"Wrote {totalLoans} {database.Name} loans to the database");
    }
});
