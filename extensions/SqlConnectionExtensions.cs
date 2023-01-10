using System.Data.SqlClient;

public static class SqlConnectionExtensions{
    public static T FindOrInsert<T>(this SqlConnection conn,T obj) where T:ILasModel<T>{
        conn.Open();
        while (true)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.BuildSelectCommand(obj);
            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        reader.Read();
                        var id = reader.GetValue(0);
                        if (id.GetType() == typeof(Int16))
                        {
                            obj.Id = (Int32)id.ConvertTo("int");
                        }
                        else
                        {
                            obj.Id = (Int32)id;
                        }
                        conn.Close();
                        return obj;
                    }

                }
            }catch(Exception ex){
                throw ex;
            }
            cmd.BuildInsertCommand(obj);
            try{
                cmd.ExecuteNonQuery();
            }catch(Exception ex){
                throw ex;
            }
            
        }
    }

}