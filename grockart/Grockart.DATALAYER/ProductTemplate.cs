using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.DATALAYER
{

    public class ProductTemplate : CRUDTemplate<IProduct>
    {
        private readonly ICommands Commands = MySQLCommands.Instance();
        private string Source;

        public override List<IProduct> Select()
        {
            Source = "sp_FetchProductOnly";
            // Product fetching stored procedure
            try
            {
                Object[] param = null;
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                List<IProduct> ProductList = new List<IProduct>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    IProduct Product = new ProductsOnly();
                    Product.SetProductId(Int32.Parse(dr["pID"].ToString()));
                    Product.SetProductName(dr["productName"].ToString());
                    Product.SetProductImage(dr["productImage"].ToString());
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
        public override int Delete(IProduct ProductsOnlyObj)
        {
            Source = "sp_RemoveProductOnly";
            int ProductId = ProductsOnlyObj.GetProductId();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramPID", ProductId)
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
        public override int Insert(IProduct ProductsOnlyObj)
        {
            Source = "sp_AddProductOnly";
            int ProductId = ProductsOnlyObj.GetProductId();
            string ProductName = ProductsOnlyObj.GetProductName();
            string ProductImage = ProductsOnlyObj.GetProductImage();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramPID", ProductId),
                    new MySqlParameter("@paramProductName", ProductName),
                    new MySqlParameter("@paramProductImage", ProductImage)
                };
                return Commands.ExecuteNonQuery(Source, System.Data.CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Update(IProduct ProductsOnlyObj)
        {
            Source = "sp_ModifyProductOnly";
            int ProductId = ProductsOnlyObj.GetProductId();
            string ProductNewName = ProductsOnlyObj.GetProductName();
            string ProductNewImage = ProductsOnlyObj.GetProductImage();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramPID", ProductId),
                    new MySqlParameter("@paramProductNewName", ProductNewName),
                    new MySqlParameter("@paramProductNewImage", ProductNewImage)
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public DataSet FetchAllProducts()
        {
            string Source = "sp_fetchProducts";
            try
            {
                Object[] param = null;
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public DataSet FetchAllProducts(string Query)
        {
            string Source = "sp_FetchProductsByQuery";
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramQuery", Query)
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public DataSet FetchAllProducts(int ProductID)
        {
            string Source = "sp_FetchProductsByID";
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramProductID", ProductID)
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public DataRow FetchAllProductByStoreID(int PBSId)
        {
            string Source = "sp_FetchProductByPBSID";
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramPBSID", PBSId)
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, param).Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}