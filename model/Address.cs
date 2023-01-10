using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;
using System.Data.SqlClient;

public class Address :ILasModel<Address>{
    public string TableName => "address";
    [Key]
    public int Id { get; set; }
    [LasSqlField("line_one")]
    [LasIdentifierField]
    public string LineOne { get; set; }
    [LasSqlField("line_two")]
    public string LineTwo { get; set; }
    [LasSqlField("city")]
    [LasIdentifierField]
    public string City { get; set; }
    [LasSqlField("state")]
    [LasIdentifierField]
    public string State { get; set; }
    [LasSqlField("postal_code")]
    [LasIdentifierField]
    public string PostalCode { get; set; }

    public Address( string addr, string city, string state, string postalCode)
    {
        LineOne = addr;
        LineTwo = "";
        City = city;
        State = state;
        PostalCode = postalCode;
    }

}