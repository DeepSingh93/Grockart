using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using Grockart.credentials;
/// <summary>
/// Summary description for MySQLCommands
/// </summary>
namespace Grockart.DATALAYER
{
    public class MySQLCommands : ICommands
    {
        // singleton pattern
        // for thread safety and gurantee object calling Source : http://www.dofactory.com/net/singleton-design-pattern
        private static readonly MySQLCommands mySQLCommandsObj = new MySQLCommands();
        public static MySQLCommands Instance()
        {
            return mySQLCommandsObj;
        }
        public int ExecuteNonQuery(string commandText, Object commandType, Object[] commandParameters)
        {
            using (var connection = new MySqlConnection(GrockartCredentails.fetchCredentails))
            {
                using (var command = new MySqlCommand(commandText, connection))
                {
                    try
                    {
                        connection.Open();
                        int affectedRows = 0;
                        command.CommandType = (CommandType)commandType;
                        if (commandParameters != null)
                        {
                            command.Parameters.AddRange(commandParameters);
                        }
                        affectedRows = command.ExecuteNonQuery();
                        return affectedRows;
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance().Log(Fatal.Instance(), ex);
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                        command.Dispose();
                    }
                }
            }
        }

        public DataSet ExecuteQuery(string commandText, Object commandType, Object[] commandParameters)
        {
            using (var connection = new MySqlConnection(GrockartCredentails.fetchCredentails))
            {
                using (var command = new MySqlCommand(commandText, connection))
                {
                    try
                    {
                        connection.Open();
                        DataSet ds = new DataSet();
                        command.CommandType = (CommandType)commandType;
                        if (commandParameters != null)
                        {
                            command.Parameters.AddRange(commandParameters);
                        }
                        using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance().Log(Fatal.Instance(), ex);
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                        command.Dispose();
                    }
                }
            }
        }
    }
}