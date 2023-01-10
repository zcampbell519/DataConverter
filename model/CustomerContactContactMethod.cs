using System.Data.Odbc;

public class CustomerContactContactMethod:ILasModel<CustomerContactContactMethod>{
    public string TableName => "customer_contact_contact_method";
    [LasIdentifierField]
    [LasSqlField("customer_id")]
    public int Id { get; set; }
    [LasIdentifierField]
    [LasSqlField("contact_id")]
    public int ContactId { get; set; }
    [LasIdentifierField]
    [LasSqlField("contact_method_id")]
    public int ContactMethodId { get; set; }
    [LasSqlField("priority")]
    public int Priority { get; set; }

    public CustomerContactContactMethod(int customerId,int contactId, int contactMethodId)
    {
        Id = customerId;
        ContactId = contactId;
        ContactMethodId = contactMethodId;
        Priority = 1;
    }
}