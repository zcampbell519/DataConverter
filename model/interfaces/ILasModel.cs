using System.Data.SqlClient;
public interface ILasModel<T>
{
    public int Id { get; set; }
    public string TableName => throw new NotImplementedException();
}