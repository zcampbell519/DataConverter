using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;

public class ContactMethod : ILasModel<ContactMethod>{
    public string TableName => "contact_method";
    [Key]
    public int Id { get; set; }
    [LasSqlField("is_email")]
    public bool IsEmail { get; set; }
    [LasSqlField("is_phone")]
    public bool IsPhone { get; set; }
    [LasSqlField("is_fax")]
    public bool IsFax { get; set; }
    [LasSqlField("method_string")]
    [LasIdentifierField]
    public string MethodString { get; set; }
    public ContactMethod(string methodString)
    {
        IsEmail = false;
        IsPhone = true;
        IsFax = false;
        MethodString = methodString;
    }

}