using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;

public class Amortization : ILasModel<Amortization> {
    public string TableName => "amortization";
    [Key]
    public int Id { get; set; }
    [LasSqlField("loan_id")]
    [LasIdentifierField]
    public int LoanId { get; set; }
    [LasSqlField("amortization_number")]
    public int AmortizationNumber { get; set; }
    [LasSqlField("is_current")]
    public bool IsCurrent  { get; set; }
    [LasSqlField("amortization_type")]
    public AmortizationType AmortizationType { get; set; }
    [LasSqlField("amortization_date")]
    public DateTime AmortizationDate { get; set; }
    [LasSqlField("amortized_by")]
    public string AmortizedBy { get; set; }
    [LasSqlField("amortized_amount")]
    public decimal AmortizedAmount { get; set; }

    public Amortization(int loanId, string type, DateTime amortizationDate, string amortizedby, decimal amortizedAmount)
    {
        LoanId = loanId;
        AmortizationNumber = 1;
        IsCurrent = true;
        switch(type){
            case "PRELIMINARY":
                AmortizationType = AmortizationType.PRELIMINARY;
                break;
            case "CONSTRUCTION":
                AmortizationType = AmortizationType.CONSTRUCTION;
                break;
            default:
                AmortizationType = AmortizationType.FINAL;
                break;
        }
        AmortizedBy = amortizedby;
        AmortizedAmount = amortizedAmount;
        AmortizationDate = amortizationDate;
    }

}