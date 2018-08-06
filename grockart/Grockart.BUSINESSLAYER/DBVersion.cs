using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Data;

/// <summary>
/// Summary description for DBConnect
/// </summary>
namespace Grockart.BUSINESSLAYER
{
    public class DBVersion
    {
        public static string GetDBVersion
        {
            get
            {
                string dbVersion = null;
                try
                {
                    DataSet output = MySQLCommands.Instance().ExecuteQuery("sp_getDBVersion", CommandType.StoredProcedure, null);
                    dbVersion = output.Tables[0].Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    Logger.Instance().Log(Fatal.Instance(), ex);
                    dbVersion = null;
                }
                return dbVersion;
            }
        }
    }
}