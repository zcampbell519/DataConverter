public class PaymentCheck:ILasModel<PaymentCheck>{
    public string TableName => "payment_check";

    public int Id { get; set; }
    [LasSqlField("payment")]
    [LasIdentifierField]
    public int PaymentId { get; set; }
    [LasSqlField("check_number")]
    [LasIdentifierField]
    public int CheckNumber { get; set; }
    public PaymentCheck(int paymentId, int checkNumber)
    {
        PaymentId = paymentId;
        CheckNumber = checkNumber;
    }
}