public class WDLSpecificData : SpecificData{
    public string TableName => "loan_wd";
    [LasSqlField("id")]
    [LasIdentifierField]
    public int Id { get; set; }
    [LasSqlField("security")]
    public string Security { get; set; }
    [LasSqlField("rdb_id")]
    public string RdbId { get; set; }
    [LasSqlField("rdb_interest_rate")]
    public decimal RdbInterestRate { get; set; }
    [LasSqlField("is_public")]
    public bool IsPublic { get; set; }
    [LasSqlField("origination_fee")]
    public decimal OriginationFee { get; set; }
    public WDLSpecificData(int id, string security, string rdbId, object rdbInterestRate, bool isPublic, decimal originationFee)
    {
        Id = id;
        Security = security;
        RdbId = rdbId;
        try{
            RdbInterestRate = (decimal)rdbInterestRate.ConvertTo("decimal");
        }catch(Exception){
            RdbInterestRate = 0;
        }
        if(originationFee==0)
            IsPublic = true;
        else    
            IsPublic = false;
        OriginationFee = originationFee;
    }
}