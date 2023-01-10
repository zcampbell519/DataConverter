public class LoanChangeItem: ILasModel<LoanChangeItem>{
    public string TableName => "loan_change_item";
    public int Id { get; set; }
    [LasIdentifierField]
    [LasSqlField("loan_change_id")]
    public int ChangeId { get; set; }
    [LasSqlField("property")]
    public string Property { get; set; }
    [LasSqlField("before")]
    public String? Before { get; set; }
    [LasSqlField("after")]
    public string After { get; set; }
    [LasSqlField("change_type")]
    public string ChangeType { get; set; }

    public LoanChangeItem(int changeId)
    {
        ChangeId = changeId;
        Property = "Loan";
        Before = "";
        After = "Exists";
        ChangeType = "IMPORTED";
    }

}