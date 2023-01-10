using System.Data.Odbc;

public class CustomerAddress : ILasModel<CustomerAddress>{
    public string TableName => "customer_address";
    [LasIdentifierField]
    [LasSqlField("customer_id")]
    public int Id { get; set; }
    [LasIdentifierField]
    [LasSqlField("address_id")]
    public int AddressId { get; set; }
    [LasSqlField("priority")]
    public int Priority { get; set; }
    public CustomerAddress(int customerId, int addressId)
    {
        Id = customerId;
        AddressId = addressId;
        Priority = 1;
    }

}