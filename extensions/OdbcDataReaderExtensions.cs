using System.Data.Odbc;
public static class OdbcDataReaderExtensions {

    public static object ConvertValueOrDefault(this OdbcDataReader reader, int position, Type expected){
        if(reader.IsDBNull(position))
            return GetDefaultValue(expected);
        return OdbcDataReaderExtensions.convert(reader.GetValue(position),expected);
    }

    public static object GetDefaultValue(this OdbcDataReader reader, Type dataType){
        return GetDefaultValue(dataType);
    }

    public static object GetDefaultValue(Type dataType){
        switch(Type.GetTypeCode(dataType)){
            case (TypeCode.DateTime):
                return new DateTime();
            case (TypeCode.Boolean):
                return false;
            case (TypeCode.Int32):
            case (TypeCode.Int16):
            case (TypeCode.Int64):
                return 0;
            case (TypeCode.Decimal):
                return (decimal)0;
            case (TypeCode.Double):
                return 0d;
            case (TypeCode.Single):
                return 0f;
            default:
                return "";
        }
    }
    

    private static object convert(object value, Type expected)
    {
        if(value.GetType()==expected)
            return value;
        switch(Type.GetTypeCode(value.GetType()),Type.GetTypeCode(expected)){
            case (TypeCode.Boolean,TypeCode.Int16):
            case (TypeCode.Boolean,TypeCode.Int32):
            case (TypeCode.Boolean,TypeCode.Int64):
                if((bool)value)
                    return 1;
                return 0;
            case (TypeCode.Int16,TypeCode.Single):
            case (TypeCode.Int32,TypeCode.Single):
            case (TypeCode.Int64,TypeCode.Single):
                return (float)value;
            case (TypeCode.Int16,TypeCode.Double):
            case (TypeCode.Int32,TypeCode.Double):
            case (TypeCode.Int64,TypeCode.Double):
                return (double)value;
            case (TypeCode.Int16,TypeCode.Decimal):
            case (TypeCode.Int32,TypeCode.Decimal):
            case (TypeCode.Int64,TypeCode.Decimal):
                return (decimal)value.ConvertTo("decimal");
            case (TypeCode.Double,TypeCode.Int16):
            case (TypeCode.Double,TypeCode.Int32):
            case (TypeCode.Double,TypeCode.Int64):
                return (int)value.ConvertTo("int");
            case (TypeCode.Double,TypeCode.Single):
                return ((double)value).ConvertTo("float");
            case (TypeCode.Int16,TypeCode.Boolean):
            case (TypeCode.Int32,TypeCode.Boolean):
            case (TypeCode.Int64,TypeCode.Boolean):
                if((int)value>0)
                    return true;
                return false;
            case (TypeCode.Int16,TypeCode.Int32):
                return (Int32)value.ConvertTo("int");
            default:
                return value.ToString();
        }
    }
}