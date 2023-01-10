internal class AccessFieldAttribute : Attribute
{
    public int Position { get; set; }

    public AccessFieldAttribute(int pos)
    {
        Position = pos;
    }
}