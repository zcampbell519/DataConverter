internal class RIPSpecificData : SpecificData
{
    public string TableName => "loan_rip";
    public RIPSpecificData(int id, decimal propertyLiens, string otherFunding, DateTime requestedDate, decimal requestedAmount)
    {
        Id = id;
        PropertyLiens = propertyLiens;
        OtherFunding = otherFunding;
        RequestedAmount = requestedAmount;
        RequestedDate=requestedDate;
    }

    [LasSqlField("id")]
    [LasIdentifierField]
    public int Id { get; set; }
    [LasSqlField("property_liens")]
    public decimal PropertyLiens { get; set; }
    [LasSqlField("other_funding")]
    public string OtherFunding { get; set; }
    [LasSqlField("requested_date")]
    public DateTime RequestedDate { get; set; }
    [LasSqlField("requested_amount")]
    public decimal RequestedAmount { get; set; }
}