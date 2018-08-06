using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.DATALAYER
{
    public class CategoryTemplate : CRUDTemplate<ICategory>
    {
        private readonly ICommands Commands = MySQLCommands.Instance();
        private string Source;
        public override List<ICategory> Select()
        {
            Source = "sp_FetchCategory";
            // Category fetching stored procedure
            try
            {
                Object[] param = null;
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                List<ICategory> CategoryList = new List<ICategory>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    ICategory Category = new Category();
                    Category.SetCategoryId(Int32.Parse(dr["cID"].ToString()));
                    Category.SetCategoryName(dr["categoryName"].ToString());
                    CategoryList.Add(Category);
                }
                return CategoryList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Delete(ICategory CategoryObj)
        {
            Source = "sp_RemoveCategory";
            int CategoryID = CategoryObj.GetCategoryId();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramCID", CategoryID)
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);

            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Fatal.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Insert(ICategory CategoryObj)
        {
            Source = "sp_AddCategory";
            string CategoryName = CategoryObj.GetCategoryName();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramCategoryName", CategoryName)
                };
                return Commands.ExecuteNonQuery(Source, System.Data.CommandType.StoredProcedure, param);

            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Update(ICategory CategoryObj)
        {
            Source = "sp_ModifyCategory";
            int CategoryID = CategoryObj.GetCategoryId();
            string CategoryNewName = CategoryObj.GetCategoryName();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramCID", CategoryID),
                    new MySqlParameter("@paramCategoryNewName", CategoryNewName)
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
