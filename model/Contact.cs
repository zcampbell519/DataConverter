using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;

public class Contact:ILasModel<Contact>{
    public string TableName => "contact";
    [Key]
    public int Id { get; set; }
    [LasIdentifierField]
    [LasSqlField("first_name")]
    public string FirstName { get; set; }
    [LasSqlField("middle_name")]
    public string MiddleName { get; set; }
    [LasSqlField("last_name")]
    [LasIdentifierField]
    public string LastName { get; set; }
    [LasSqlField("suffix")]
    public string Suffix { get; set; }

    public Contact(string firstName, string middleName,string lastName,string suffix)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Suffix = suffix;
    }

}