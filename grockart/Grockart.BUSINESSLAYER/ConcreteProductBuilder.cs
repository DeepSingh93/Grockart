using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grockart.DATALAYER;
using Grockart.LOGGER;

namespace Grockart.BUSINESSLAYER
{
    public class ConcreteProductBuilder : AbstractProductBuilder<ProductBuilderResponse>
    {
        private readonly IProductByStore ProductObj;
        private ProductBuilderResponse ProductBuilderResponseObj;

        // configurable business logic
        private readonly int GetMaxQty = int.Parse(new SettingsFromDB().FetchSettingsFromDB(new Settings(SettingsKey: "MAX_QTY")).GetSettingsValue());
        public ConcreteProductBuilder(IProductByStore ProductObj)
        {
            this.ProductObj = ProductObj;
            ProductBuilderResponseObj = new ProductBuilderResponse();
        }

        public override void BuildLowestPriceStoreImage()
        {
            try
            {
                int ProductByStoreID = ProductObj.GetProductByStoreID();
                ProductBuilderResponseObj.SetStoreImage(new Images().FetchStoreImageByPBSID(ProductByStoreID));
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(new Fatal(), ex);
                throw ex;
            }
        }

        public override void BuildOtherStoreDetails()
        {
            try
            {
                int ProductByStoreID = ProductObj.GetProductByStoreID();
                List<Products> StoreList = new List<Products>();
                DataSet OutputFromDB = new StoresList().FetchOtherStoresList(ProductByStoreID);
                if (OutputFromDB.Tables[0].Rows.Count == 0)
                {
                    ProductBuilderResponseObj.SetHasOtherStores(false);
                }
                else
                {
                    ProductBuilderResponseObj.SetHasOtherStores(true);
                    foreach (DataRow dr in OutputFromDB.Tables[0].Rows)
                    {
                        Products ProductObj = new Products
                        {
                            pbsID = int.Parse(dr["pbsID"].ToString()),
                            StoreLogo = dr["storeLogo"].ToString(),
                            Price = double.Parse(dr["Price"].ToString()),
                            QuantityType = dr["QuantityPerUnit"].ToString(),
                            Quantity = GetQuantity(int.Parse(dr["Quantity"].ToString()))
                        };
                        StoreList.Add(ProductObj);
                    }
                    ProductBuilderResponseObj.SetOtherstoresList(StoreList);

                }

            }
            catch (Exception ex)
            {
                Logger.Instance().Log(new Fatal(), ex);
                throw ex;
            }
        }

        private int GetQuantity(int Quantity)
        {
            try
            {
                if (Quantity > GetMaxQty)
                {
                    Quantity = GetMaxQty;
                }
                return Quantity;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public override void BuildProductDetails()
        {
            try
            {
                int ProductID = ProductObj.GetProductByStoreID();
                ProductBuilderResponseObj.SetProductByStoreID(ProductID);
                DataTable ProductDetails = new ProductTemplate().FetchAllProducts(ProductID).Tables[0];
                ProductBuilderResponseObj.SetCategoryName(ProductDetails.Rows[0]["categoryName"].ToString());
                ProductBuilderResponseObj.SetProductName(ProductDetails.Rows[0]["productName"].ToString());
                ProductBuilderResponseObj.SetQuantity(GetQuantity(ProductDetails));
                ProductBuilderResponseObj.SetQuantityPerUnit(ProductDetails.Rows[0]["quantityperunit"].ToString());
                ProductBuilderResponseObj.SetPrice(double.Parse(ProductDetails.Rows[0]["price"].ToString()));
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(new Fatal(), ex);
                throw ex;
            }
        }

        private int GetQuantity(DataTable ProductDetails)
        {
            try
            {
                int Quantity = 0;
                if (int.Parse(ProductDetails.Rows[0]["Quantity"].ToString()) > GetMaxQty)
                {
                    Quantity = GetMaxQty;
                }
                else
                {
                    Quantity = int.Parse(ProductDetails.Rows[0]["Quantity"].ToString());
                }
                return Quantity;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }

        }

        public override void BuildProductImage()
        {
            try
            {
                ProductBuilderResponseObj.SetProductImage(new Images().FetchProductImage(ProductObj.GetProductByStoreID()));
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(new Fatal(), ex);
                throw ex;
            }
        }

        public override ProductBuilderResponse GetFinalProduct()
        {
            try
            {
                return ProductBuilderResponseObj;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(new Fatal(), ex);
                throw ex;
            }
        }
    }
}
