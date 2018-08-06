using System.Data;
 

namespace Grockart.DATALAYER
{
    public interface ICommands
    {
        int ExecuteNonQuery(string commandText, object commandType, object[] commandParameters);
        DataSet ExecuteQuery(string commandText, object commandType, object[] commandParameters);
    }
}