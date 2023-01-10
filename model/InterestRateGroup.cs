public class InterestRateGroup:ILasModel<InterestRateGroup>{
    public string TableName => "interest_rate_group";
    public int Id{ get; set; }
    [LasIdentifierField]
    [LasSqlField("loan")]
    public int LoanId { get; set; }
    [LasSqlField("start_date")]
    public DateTime StartDate { get; set; }
    [LasSqlField("end_date")]
    public DateTime EndDate { get; set; }
    public float BaseRate { get; set; }
    public float LossRate { get; set; }
    public float AdminRate { get; set; }
    public InterestRateGroup(int loanId, DateTime startDate, DateTime endDate, float baseRate, float adminRate, float lossRate)
    {
        LoanId = loanId;
        StartDate = startDate;
        EndDate = endDate;
        BaseRate = baseRate;
        AdminRate = adminRate;
        LossRate = lossRate;
    }

    internal List<InterestRatePair> GetInterestRatePairs(){
        List<InterestRatePair> ret = new List<InterestRatePair>();
        ret.Add(new InterestRatePair(Id, "baseRate", BaseRate));
        if(LossRate>0)
            ret.Add(new InterestRatePair(Id, "lossRate", LossRate));
        if(AdminRate>0)
            ret.Add(new InterestRatePair(Id, "adminRate", AdminRate));
        return ret;
    }
}