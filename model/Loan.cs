using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;
using System.Reflection;

public class Loan : ILasModel<Loan>
{
    public string TableName => "loan";
    #region AccessFields
    [LasSqlField("loan_number")]
    [RFAccessField(0)]
    [RIPAccessField(0)]
    [WDLAccessField(1)]
    [LasIdentifierField]
    public string LoanNumber { get; set; }

    [WDLAccessField(0)]
    [RFAccessField(0)]
    public string LoanKey { get; set; }


    [RFAccessField(1)]
    [RIPAccessField(1)]
    [WDLAccessField(2)]
    public string Appl { get; set; }
    [RFAccessField(2)]
    [RIPAccessField(2)]
    [WDLAccessField(3)]
    public string Addr { get; set; }
    [RFAccessField(3)]
    [RIPAccessField(3)]
    [WDLAccessField(4)]
    public string City { get; set; }
    [RFAccessField(4)]
    [RIPAccessField(4)]
    [WDLAccessField(5)]
    public string State { get; set; }
    [RFAccessField(5)]
    [RIPAccessField(5)]
    [WDLAccessField(6)]
    public string ZipCode { get; set; }
    [RFAccessField(6)]
    [WDLAccessField(7)]
    public string ContFrstNm { get; set; }
    [RIPAccessField(6)]
    public string ApplCont { get; set; }
    [RFAccessField(7)]
    [WDLAccessField(8)]
    public string ContLastNm { get; set; }
    [RFAccessField(8)]
    [RIPAccessField(7)]
    [WDLAccessField(9)]
    public string ContPhn { get; set; }
    [RFAccessField(9)]
    [WDLAccessField(10)]
    public string AttnNm { get; set; }
    [RFAccessField(10)]
    [RIPAccessField(8)]
    [WDLAccessField(11)]
    public string StatusCd { get; set; }
    [RFAccessField(11)]
    [WDLAccessField(12)]
    public string CntyCd { get; set; }
    [WDLAccessField(13)]
    public string PrjTyp { get; set; }
    [WDLAccessField(14)]
    public string FndTyp { get; set; }
    [RFAccessField(12)]
    [RIPAccessField(9)]
    [WDLAccessField(15)]
    [LasSqlField("description")]
    public string Description { get; set; }
    [RIPAccessField(10)]
    public decimal PrLiens { get; set; }
    [RIPAccessField(11)]
    public string OthFund { get; set; }
    [RIPAccessField(12)]
    [WDLAccessField(16)]
    public string Security { get; set; }

    [LasSqlField("local_bond")]
    [RFAccessField(13)]
    [WDLAccessField(17)]
    public string LocalBond { get; set; }
    [WDLAccessField(18)]
    public DateTime PrvAprDt { get; set; }
    [WDLAccessField(19)]
    public string RltIdNo { get; set; }
    
    [RIPAccessField(13)]
    public decimal ReqAmt { get; set; }
    [RIPAccessField(14)]
    public DateTime ReqDt { get; set; }
    [RFAccessField(14)]
    [WDLAccessField(19)]
    [RIPAccessField(-1)]
    public string FedIdNo { get; set; }
    [RFAccessField(15)]
    [WDLAccessField(20)]
    public decimal LegAppr { get; set; }
    [RFAccessField(16)]
    [RIPAccessField(15)]
    [WDLAccessField(21)]
    [LasSqlField("dollar_amount")]
    public decimal DollarAmount { get; set; }
    [LasSqlField("auth_date")]
    [RFAccessField(17)]
    [RIPAccessField(16)]
    [WDLAccessField(22)]
    public DateTime AuthDate { get; set; }
    [RIPAccessField(17)]
    public DateTime EndDsbDt { get; set; }
    [RIPAccessField(18)]
    public string SchTyp { get; set; }

    [RFAccessField(18)]
    [WDLAccessField(23)]
    [LasSqlField("close_date")]
    public DateTime CloseDate { get; set; }
    [RFAccessField(19)]
    [WDLAccessField(24)]
    [LasSqlField("termination_date")]
    public DateTime TerminationDate { get; set; }
    [WDLAccessField(25)]
    public string LnTyp { get; set; }
    [RFAccessField(20)]
    public string FbTyp1 { get; set; }
    [RFAccessField(21)]
    public float FbPct1 { get; set; }
    [RFAccessField(22)]
    public string FbTyp2 { get; set; }
    [RFAccessField(23)]
    public float FbPct2 { get; set; }
    [LasSqlField("payment_frequency")]
    [RFAccessField(24)]
    [WDLAccessField(26)]
    public int PaymentFrequency { get; set; }
    [WDLAccessField(27)]
    public string RdbIntRt { get; set; }
    [RFAccessField(26)]
    [RIPAccessField(19)]
    [WDLAccessField(28)]
    public float IntRt { get; set; }
    [RFAccessField(27)]
    public float AdminRt { get; set; }
    [RFAccessField(28)]
    public float LossRt { get; set; }
    [RFAccessField(29)]
    [RIPAccessField(20)]
    [WDLAccessField(29)]
    public int Lngth { get; set; }
    [RFAccessField(30)]
    [WDLAccessField(30)]
    public string DActEnt { get; set; }
    [WDLAccessField(31)]
    [LasSqlField("principle_receiving_fund")]
    public string RActEnt { get; set; }
    [RFAccessField(31)]
    [RIPAccessField(21)]
    [WDLAccessField(32)]
    [LasSqlField("distributed_total")]
    public decimal DistributedTotal { get; set; }
    [RFAccessField(32)]
    [RIPAccessField(22)]
    [WDLAccessField(33)]
    public decimal OrgFee { get; set; }
    [RFAccessField(33)]
    [RIPAccessField(23)]
    [WDLAccessField(34)]
    public decimal BalDue { get; set; }
    [RFAccessField(34)]
    [RIPAccessField(24)]
    [WDLAccessField(35)]
    [LasSqlField("grace_period")]
    public int GracePeriod { get; set; }
    [LasSqlField("penalty_percent")]
    [RFAccessField(35)]
    [RIPAccessField(25)]
    [WDLAccessField(36)]
    public float PenaltyPercent { get; set; }
    [RFAccessField(36)]
    [RIPAccessField(26)]
    [WDLAccessField(37)]
    [LasSqlField("penalty_method")]
    public string PenaltyMethod { get; set; }
    [RFAccessField(37)]
    [RIPAccessField(27)]
    [WDLAccessField(38)]
    [LasSqlField("foreclosure_notice")]
    public int ForeclosureNotice { get; set; }
    [RFAccessField(38)]
    [RIPAccessField(28)]
    [WDLAccessField(39)]
    [LasSqlField("foreclosure_days")]
    public int ForeclosureDays { get; set; }
    #endregion

    [Key]
    
    public int Id { get; set; }
    [LasSqlField("first_payment_date")]
    public DateTime FirstPaymentDate { get; set; }
    [LasSqlField("loan_status")]
    public string LoanStatus { get; set; }
    [LasSqlField("customer_id")]
    public int CustomerId { get; set; }
    [LasSqlField("type_id")]
    public int TypeId { get; set; }
    [LasSqlField("modified_by")]
    public string ModifiedBy { get; set; }
    [LasSqlField("modified_date")]
    public DateTime ModifiedDate { get; set; }
    [LasSqlField("final_loan_amount")]
    public decimal FinalLoanAmount{ get; set; }

    public Loan(OdbcDataReader reader, string db)
    {
        Attribute attrType = AttributeFactory.GetAttributeType(db);
        var props = typeof(Loan).GetProperties().Where(p => Attribute.IsDefined(p, attrType.GetType()));
        foreach (var p in props)
        {
            AccessFieldAttribute a = (AccessFieldAttribute)(p.GetCustomAttribute(attrType.GetType()));
            try
            {
                if(a.Position==-1)
                    this.GetType().GetProperty(p.Name).SetValue(this, "");
                else
                    this.GetType().GetProperty(p.Name).SetValue(this, reader.ConvertValueOrDefault(a.Position, p.PropertyType));
            }
            catch (ArgumentException ex)
            {
                Logger.LogLoanWarn($"Cannot process field {p.Name} because {ex.InnerException}. Continuing without field.");
                this.GetType().GetProperty(p.Name).SetValue(this, reader.GetDefaultValue(p.PropertyType));
            }
        }
        if(Description.Length>255){
            Logger.LogLoanWarn("Description longer than 255 characters. Truncating.");
            Description = Description.Truncate(255);
        }
        
        if (IntRt > 10 || LossRt > 10 || AdminRt > 10 )
        {
            if (IntRt > 10)
            {
                Logger.LogLoanWarn("Base interest rate is greater than 10. Setting value to zero");
                IntRt = 0;
            }

            if (LossRt > 10)
            {
                Logger.LogLoanWarn("Loss rate is greater than 10. Setting value to zero");
                LossRt = 0;
            }

            if (AdminRt > 10)
            {
                Logger.LogLoanWarn("Admin rate is greater than 10. Setting value to zero");
                AdminRt = 0;
            }

        }
        
        IntRt /= 100;
        LossRt /= 100;
        AdminRt /= 100;
        PenaltyPercent /= 100;
    }

    public Customer GetCustomer()
    {
        return new Customer(Appl, FedIdNo.Encrypt());
    }

    public void SetTypeId(string type)
    {
        switch (type)
        {
            case "RIP":
                TypeId = 1;
                break;
            case "SRF":
                TypeId = 2;
                break;
            case "WDL":
                TypeId = 3;
                break;
            case "WRF":
                TypeId = 4;
                break;
        }
    }

    public Address GetAddress()
    {
        return new Address(Addr, City, State, ZipCode);
    }

    public ContactCreater GetContactCreater()
    {
        if(ApplCont!=null)
            return new ContactCreater(ApplCont);
        return new ContactCreater(ContFrstNm, ContLastNm, AttnNm);
    }

    public ContactMethod GetContactMethod()
    {
        return new ContactMethod(ContPhn);
    }

    internal void setState(decimal totalDisbursed, decimal totalPaid, int totalPayments)
    {
        if((totalDisbursed==totalPaid&&totalDisbursed==DollarAmount)){
            if(totalPayments==0)
                Logger.LogLoanInfo("Loan possibly forgiven.");
            LoanStatus = "TERMINATED";
            FinalLoanAmount = totalDisbursed;
        }
        else if (totalDisbursed == DollarAmount)
        {
            LoanStatus = "FINAL";
            FinalLoanAmount = DollarAmount;
        }
        else if (totalDisbursed > 0)
            LoanStatus = "CONSTRUCTION";
        else
            LoanStatus = "CLOSED";
    }

    internal Amortization CreateAmortization()
    {
        return new Amortization(Id, LoanStatus, ModifiedDate, ModifiedBy, DollarAmount);
    }

    internal DateTime GetDefaultPaymentDate(string db)
    {
        switch (db)
        {
            case "SRF":
            case "WRF":
                if (CloseDate.Month > 6)
                    return new DateTime(CloseDate.Year + 1, 1, 1);
                return new DateTime(CloseDate.Year, 7, 1);

        }
        return CloseDate.AddYears(1);
    }

    internal InterestRateGroup GetInterestRateGroup()
    {
        return new InterestRateGroup(Id, CloseDate, TerminationDate, IntRt, AdminRt, LossRt);
    }

    internal SpecificData GetSpecificData(string db)
    {
        switch (db)
        {
            case "SRF":
            case "WRF":
                return new RFSpecificData(Id);
            case "RIP":
                return new RIPSpecificData(Id,PrLiens,OthFund,ReqDt,ReqAmt);
            case "WDL":
                return new WDLSpecificData(Id, Security, RltIdNo, RdbIntRt, true, OrgFee);
        }
        throw new NotImplementedException();
    }

    internal LoanChange GetLoanChange()
    {
        return new LoanChange(Id, ModifiedBy, ModifiedDate);
    }

    internal bool Validate(){
        if(LoanNumber!=null)
            LoanNumber.Trim();
        if(Description!=null)
            Description.Trim();
        if(LocalBond!=null)
            LocalBond.Trim();
        if (RActEnt != null)
        {
            RActEnt.Trim();
            if(RActEnt=="")
                RActEnt = null;
        }
        if(PenaltyMethod!=null)
            PenaltyMethod.Trim();
        if(CloseDate==AuthDate&&CloseDate==DateTime.MinValue)
                return false;
            else if(CloseDate==DateTime.MinValue||AuthDate==DateTime.MinValue)
        if (TerminationDate == DateTime.MinValue || CloseDate == DateTime.MinValue || AuthDate == DateTime.MinValue || FirstPaymentDate == DateTime.MinValue)
                if(CloseDate==DateTime.MinValue)
                    CloseDate = AuthDate;
                else
                    AuthDate = CloseDate;
            if(TerminationDate==DateTime.MinValue && FirstPaymentDate!=DateTime.MinValue)
                if(Lngth==0)
                    TerminationDate = FirstPaymentDate;
                else if(Lngth<=50)
                    TerminationDate = FirstPaymentDate.AddYears(Lngth);
                else
                    TerminationDate = FirstPaymentDate.AddMonths(Lngth);
            else if(FirstPaymentDate==DateTime.MinValue && TerminationDate!=DateTime.MinValue){
                if(Lngth==0)
                    FirstPaymentDate = TerminationDate;
                else if(Lngth<=50)
                    FirstPaymentDate = TerminationDate.AddYears(-Lngth);
                else
                    FirstPaymentDate = TerminationDate.AddMonths(-Lngth);
            }
            else if(TerminationDate==DateTime.MinValue && TerminationDate==FirstPaymentDate)
                return false;
        
        
        return true;
    }
}