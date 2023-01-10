using System.Data.SqlClient;

public static class ListExtensions
{
    public static void FindOrInsertAll<T>(this List<T> list,SqlConnection conn) where T : ILasModel<T> {
        list.ForEach(item => conn.FindOrInsert<T>(item));
    }
}