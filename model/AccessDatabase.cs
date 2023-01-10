public class AccessDatabase{
    public string Name { get; set; }
    public string Location { get; set; }

    public AccessDatabase(string name, string location)
    {
        Name = name;
        Location = location;
    }
}