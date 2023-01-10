public static class ObjectExtensions{
    public static object ConvertTo(this object obj, string type){
        var s = obj.ToString();
        try
        {
            switch (type)
            {
                case "decimal":
                    return Decimal.Parse(s);
                case "float":
                    return float.Parse(s);
                case "int":
                    return int.Parse(s);
                case "DateTime":
                    return DateTime.Parse(s);
                default:
                    return s;
            }
        }catch(Exception ex){
            throw ex;
        }
    }
}