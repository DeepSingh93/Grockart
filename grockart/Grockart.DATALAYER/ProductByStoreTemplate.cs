using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.DATALAYER
{
    public class ProductByStoreTemplate : CRUDTemplate<IProductByStore>
    {
        private readonly ICommands Commands = MySQLCommands.Instance();
        private string Source;

        public override List<IProductByStore> Select()
        {
            Source = "sp_FetchProductByStore";
            // Product fetching stored procedure
            try
            {
                Object[] param = null;
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                List<IProductByStore> ProductList = new List<IProductByStore>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    IProductByStore Product = new ProductByStore();
                    Product.SetProductByStoreID(Int32.Parse(dr["pbsID"].ToString()));
                    Product.SetStoreID(Int32.Parse(dr["sID"].ToString()));
                    Product.SetCategoryID(Int32.Parse(dr["cID"].ToString()));
                    Product.SetProductID(Int32.Parse(dr["pID"].ToString()));
                    Product.SetStoreName(dr["storeName"].ToString());
                    Product.SetCategoryName(dr["categoryName"].ToString());
                    Product.SetProductName(dr["productName"].ToString());
                    Product.SetPrice((double)dr["price"]);
                    Product.SetQuantity(Int32.Parse(dr["Quantity"].ToString()));
                    Product.SetQuantityPerUnit(dr["QuantityPerUnit"].ToString());
                    ProductList.Add(Product);
                }
                return ProductList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Delete(IProductByStore ProductByStoreObj)
        {
            Source = "sp_RemoveProduct";
            int ProductByStoreID = ProductByStoreObj.GetProductByStoreID();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramPbsID", ProductByStoreID)
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
        public override int Insert(IProductByStore ProductByStoreObj)
        {
            Source = "sp_AddProduct";
            int StoreID = ProductByStoreObj.GetStoreID();
            int CategoryID = ProductByStoreObj.GetCategoryID();
            int ProductID = ProductByStoreObj.GetProductID();
            double Price = ProductByStoreObj.GetPrice();
            string QuantityPerUnit = ProductByStoreObj.GetQuantityPerUnit();
            int Quantity = ProductByStoreObj.GetQuantity();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramSID", StoreID),
                    new MySqlParameter("@paramCID", CategoryID),
                    new MySqlParameter("@paramPID", ProductID),
                    new MySqlParameter("@paramPrice", Price),
                    new MySqlParameter("@paramQuantityPerUnit", QuantityPerUnit),
                    new MySqlParameter("@paramQuantity", Quantity)
                };
                return Commands.ExecuteNonQuery(Source, System.Data.CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Update(IProductByStore ProductByStoreObj)
        {
            Source = "sp_ModifyProduct";
            int StoreID = ProductByStoreObj.GetStoreID();
            int CategoryID = ProductByStoreObj.GetCategoryID();
            int ProductByStoreID = ProductByStoreObj.GetProductByStoreID();
            int ProductID = ProductByStoreObj.GetProductID();
            double Price = ProductByStoreObj.GetPrice();
            string QuantityPerUnit = ProductByStoreObj.GetQuantityPerUnit();
            int Quantity = ProductByStoreObj.GetQuantity();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramSID", StoreID),
                    new MySqlParameter("@paramCID", CategoryID),
                    new MySqlParameter("@paramPbsID", ProductByStoreID),
                     new MySqlParameter("@paramPID", ProductID),
                    new MySqlParameter("@paramPrice", Price),
                    new MySqlParameter("@paramQuantityPerUnit", QuantityPerUnit),
                    new MySqlParameter("@paramQuantity", Quantity)
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
