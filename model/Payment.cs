using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;
using System.Reflection;

public class Payment:ILasModel<Payment>{
    public string TableName => "payment";
    [Key]
    public int Id { get; set; }
    [RFAccessField(8)]
    [RIPAccessField(7)]
    [WDLAccessField(7)]
    public decimal AmtPd { get; set; }
    [RFAccessField(9)]
    [RIPAccessField(8)]
    [WDLAccessField(8)]
    public decimal PenPd { get; set; }
    [RFAccessField(13)]
    public string FbTyp1 { get; set; }
    [RFAccessField(14)]
    public decimal FbAmt1 { get; set; }
    [RFAccessField(15)]
    public string FbTyp2 { get; set; }
    [RFAccessField(16)]
    public decimal FbAmt2 { get; set; }
    [RFAccessField(17)]
    [RIPAccessField(10)]
    [WDLAccessField(10)]
    public decimal BalDue { get; set; }
    [RFAccessField(18)]
    [RIPAccessField(11)]
    [WDLAccessField(11)]
    public float intrt { get; set; }
    [LasSqlField("amortization_id")]
    [LasIdentifierField]
    public int AmortizationId { get; set; }
    [LasSqlField("principle_due")]
    [RFAccessField(4)]
    [RIPAccessField(5)]
    [WDLAccessField(5)]
    public Decimal PrincipleDue { get; set; }
    [LasSqlField("loan_loss_reserve_due")]
    [RFAccessField(6)]
    public Decimal LoanLossReserveDue { get; set; }
    [LasSqlField("admin_expense_due")]
    [RFAccessField(7)]
    public Decimal AdminExpenseDue { get; set; }
    [LasSqlField("interest_due")]
    [RFAccessField(5)]
    [RIPAccessField(6)]
    [WDLAccessField(6)]
    public Decimal InterestDue { get; set; }
    [LasSqlField("payment_due_date")]
    [RFAccessField(2)]
    [RIPAccessField(2)]
    [WDLAccessField(2)]
    [LasIdentifierField]
    public DateTime PaymentDueDate { get; set; }
    [LasSqlField("principle_paid")]
    public Decimal? PrinciplePaid { get; set; }
    [LasSqlField("loan_loss_reserve_paid")]
    public Decimal? LoanLossReservePaid { get; set; }
    [RFAccessField(11)]
    public decimal LossPd { get; set; }
    [LasSqlField("admin_expense_paid")]
    public Decimal? AdminExpensePaid { get; set; }
    [RFAccessField(12)]
    public decimal AdmPd{ get; set; }
    [LasSqlField("interest_paid")]
    public Decimal? InterestPaid { get; set; }
    [RFAccessField(10)]
    [RIPAccessField(9)]
    [WDLAccessField(9)]
    public decimal IntPd { get; set; }

    [RIPAccessField(13)]
    [WDLAccessField(13)]
    public int ChkNo { get; set; }
    [RIPAccessField(14)]
    [WDLAccessField(14)]
    [LasSqlField("collection_report_number")]
    public int CollNo { get; set; }
    [LasSqlField("payment_paid_date")]
    [RFAccessField(3)]
    [RIPAccessField(3)]
    [WDLAccessField(3)]
    [LasIdentifierField]
    public DateTime PaymentPaidDate { get; set; }
    [LasSqlField("received_by")]
    public string ReceivedBy { get; set; }
    [LasSqlField("received_date")]
    public DateTime ReceivedDate { get; set; }
    public Payment(OdbcDataReader reader, string database)
    {
        Attribute attrType = AttributeFactory.GetAttributeType(database);
        
        var props = typeof(Payment).GetProperties().Where(p => Attribute.IsDefined(p, attrType.GetType()));
        foreach(var p in props){
            AccessFieldAttribute a = (AccessFieldAttribute)(p.GetCustomAttribute(attrType.GetType()));
            try{
                this.GetType().GetProperty(p.Name).SetValue(this, reader.ConvertValueOrDefault(a.Position, p.PropertyType));
            }catch(Exception ex){
                Logger.LogLoanError("error");
                throw ex;
            }
            
        }

        if (AmtPd == 0)
        {
            PrinciplePaid = null;
            InterestPaid = null;
            AdminExpensePaid = null;
            LoanLossReservePaid = null;
        }else{
            PrinciplePaid = AmtPd - IntPd - AdmPd - LossPd;
            InterestPaid = IntPd;
            AdminExpensePaid = AdmPd;
            LoanLossReservePaid = LossPd;
        }

    }

    public PaymentCheck GetPaymentCheck(){
        return new PaymentCheck(Id,ChkNo);
    }

}
