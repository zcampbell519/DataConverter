internal class LoanChange:ILasModel<LoanChange>
{
    public string TableName => "loan_change";
    public int Id { get; set; }
    [LasIdentifierField]
    [LasSqlField("loan_id")]
    public int LoanId { get; set; }
    [LasSqlField("modified_by")]
    public string ModifiedBy { get; set; }
    [LasSqlField("modified_date")]
    public DateTime ModifiedDate { get; set; }
    public LoanChange(int loanId, string modifiedBy, DateTime modifiedDate)
    {
        LoanId = loanId;
        ModifiedBy = modifiedBy;
        ModifiedDate = modifiedDate;
    }

    internal LoanChangeItem GetChangeItem()
    {
        return new LoanChangeItem(Id);
    }
}