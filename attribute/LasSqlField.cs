public class LasSqlField:System.Attribute
{
    public string FieldName { get; set; }
    public LasSqlField(string fieldName){
        FieldName = fieldName;
    }
}