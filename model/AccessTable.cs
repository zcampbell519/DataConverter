public class AccessTable{
    public string Name { get; set; }
    // public List<AccessField> Fields { get; set; }

    public AccessTable(string name)
    {
        Name = name;
        // Fields = new List<AccessField>();
    }
}