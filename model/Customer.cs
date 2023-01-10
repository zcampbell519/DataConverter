using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;

public class Customer: ILasModel<Customer> {
    public string TableName => "customer";
    [Key]
    public int Id { get; set; }
    [LasSqlField("name")]
    public string Name { get; set; }
    [LasIdentifierField]
    [LasSqlField("federal_tax_id")]
    public string FederalTaxId { get; set; }

    public Customer(string name, string tin)
    {
        Name = name;
        FederalTaxId = tin;
    }

}