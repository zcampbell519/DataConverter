public class CustomerContact : ILasModel<CustomerContact>{
    public string TableName => "customer_contact";
    [LasIdentifierField]
    [LasSqlField("contact_id")]
    public int ContactId { get; set; }
    [LasIdentifierField]
    [LasSqlField("customer_id")]
    public int Id { get; set; }
    [LasSqlField("salutation")]
    public string Salutation { get; set; }
    [LasSqlField("title")]
    public string Title { get; set; }
    [LasSqlField("priority")]
    public int Priority { get; set; }

    public CustomerContact(string salutation, string title)
    {
        Salutation = salutation;
        Title = title;
        Priority = 1;
    }

    internal CustomerContactContactMethod GetContactMethod(int contactMethodId)
    {
        return new CustomerContactContactMethod(Id, ContactId, contactMethodId);
    }
}