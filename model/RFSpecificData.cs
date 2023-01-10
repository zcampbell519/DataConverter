public class RFSpecificData:ILasModel<RFSpecificData>,SpecificData{
    public string TableName => "loan_revolving";
    [LasSqlField("id")]
    [LasIdentifierField]
    public int Id { get; set; }
    public RFSpecificData(int id)
    {
        Id = id;
    }
}