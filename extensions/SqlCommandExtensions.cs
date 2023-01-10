using System.Data.SqlClient;
using System.Reflection;
public static class SqlCommandExtensions{

    public static SqlCommand BuildInsertCommand<T>(this SqlCommand cmd, ILasModel<T> model)
    {
        PropertyInfo[] props = model.GetType().GetProperties().Where(p=>Attribute.IsDefined(p,typeof(LasSqlField))).ToArray();
        string commandText = $"INSERT INTO {model.TableName} (";
        foreach(PropertyInfo prop in props){
                commandText += prop.GetCustomAttribute<LasSqlField>().FieldName;
                commandText += ",";
        }
        commandText = commandText.TrimEnd(',');
        commandText += ") VALUES (";
        foreach(PropertyInfo prop in props){
            if(Attribute.IsDefined(prop,typeof(LasSqlField))){
                if(prop.PropertyType==typeof(DateTime)){
                    DateTime time = (DateTime)prop.GetValue(model);
                    if(time==DateTime.MinValue)
                        commandText += "null";
                    else
                        commandText += $"'{prop.GetValue(model).ToString().ToSqlSafeString()}'";
                }else if(prop.PropertyType==typeof(string)||prop.PropertyType==typeof(AmortizationType)){
                    if(prop.GetValue(model)!=null)
                        commandText += $"'{prop.GetValue(model).ToString().ToSqlSafeString()}'";
                    else
                        commandText += "null";
                }else if(prop.PropertyType==typeof(bool)){
                    if((bool)prop.GetValue(model))
                        commandText += 1;
                    else
                        commandText += 0;
                }else if(prop.PropertyType==typeof(Nullable<decimal>)){
                    if(((decimal?)prop.GetValue(model)).HasValue)
                        commandText += $"{((decimal?)prop.GetValue(model)).Value}";
                    else{
                        commandText += "null";
                    }
                }
                else{
                    commandText += prop.GetValue(model);
                }
                commandText += ",";
            }
        }
        commandText = commandText.TrimEnd(',');
        commandText += ")";
        cmd.CommandText = commandText;
        return cmd;

    }

    public static SqlCommand BuildSelectCommand<T>(this SqlCommand cmd, ILasModel<T> model){
        string commandText = $"Select * from {model.TableName} where ";
        PropertyInfo[] props = model.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(LasIdentifierField))).ToArray();
        for(var i=0;i<props.Count();i++){
            PropertyInfo prop = props[i];
            commandText += prop.GetCustomAttribute<LasSqlField>().FieldName + "=";
            if(prop.GetValue(model)==null){
                commandText = commandText.Substring(0, commandText.Length - 1);
                commandText += " IS NULL ";
            }
            else if(prop.PropertyType==typeof(string))
                commandText += $"'{prop.GetValue(model).ToString().ToSqlSafeString()}'";
            else if(prop.PropertyType==typeof(DateTime)){
                if((DateTime)prop.GetValue(model)==DateTime.MinValue){
                    commandText = commandText.Substring(0, commandText.Length - 1);
                    commandText += " IS NULL ";
                }
                else
                    commandText += $"'{prop.GetValue(model).ToString().ToSqlSafeString()}'";
            } else if (prop.PropertyType==typeof(bool)){
                if(!(bool)prop.GetValue(model))
                    commandText += 0;
                else
                    commandText += 1;
            } else if(prop.PropertyType==typeof(Nullable<decimal>))
                if(((decimal?)prop.GetValue(model)).HasValue)
                    commandText += $"{((decimal?)prop.GetValue(model)).Value}'";
                else
                {
                    commandText = commandText.Substring(0, commandText.Length - 1);
                    commandText += " IS NULL ";
                }
            else{
                commandText += prop.GetValue(model);
            }
            if(i<props.Count()-1){
                commandText += " AND ";
            }
        }
        cmd.CommandText = commandText;
        return cmd;
    }
}