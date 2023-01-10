public class InterestRatePair:ILasModel<InterestRatePair>{
    public string TableName => "interest_rate_pair";
    public int Id { get; set; }
    [LasIdentifierField]
    [LasSqlField("group_id")]
    public int GroupId { get; set; }
    [LasIdentifierField]
    [LasSqlField("name")]
    public string Name { get; set; }
    [LasSqlField("percentage")]
    public float Percentage { get; set; }
    public InterestRatePair(int groupId, string name, float percentage)
    {
        GroupId = groupId;
        Name = name;
        Percentage = percentage;
    }
}