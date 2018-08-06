
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public class ProductByStoreBusinessLayerTemplate : CRUDBusinessLayerTemplate<IProductByStore>
    {
        // datalayer Template obj
        private readonly CRUDTemplate<IProductByStore> ProductByStoreTemplateObj = new ProductByStoreTemplate();
        private readonly IUserProfile UserProfileObj;
        public ProductByStoreBusinessLayerTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public ProductByStoreBusinessLayerTemplate()
        {

        }
        public override List<IProductByStore> Select()
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    return ProductByStoreTemplateObj.Select();
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while fetching category (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public Products Select(IProductByStore ProductObj)
        {
            try
            {
                if(new MaintenanceMode().IsMaintenanceModeEnabled() == APIResponse.OK)
                {
                    return null;
                }
                int PBSId = ProductObj.GetProductByStoreID();
                DataRow DrPBSData = new ProductTemplate().FetchAllProductByStoreID(PBSId);
                Products ProductReponseObj = new Products();
                if (DrPBSData != null)
                {
                    ProductReponseObj.ProductName = DrPBSData["productName"].ToString();
                    ProductReponseObj.Quantity = int.Parse(DrPBSData["Quantity"].ToString());
                    ProductReponseObj.StoreLogo = DrPBSData["storeLogo"].ToString();
                    ProductReponseObj.ProductImage = DrPBSData["productImage"].ToString();
                    ProductReponseObj.Price = double.Parse(DrPBSData["price"].ToString());
                    ProductReponseObj.pbsID = PBSId;
                }
                return ProductReponseObj;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Delete(IProductByStore ProductByStoreObj)
        {
            try
            {
                bool AuthAdminResponseObj = new Security(UserProfileObj).AuthenticateAdmin();
                if (AuthAdminResponseObj == true)
                {
                    if (0 == ProductByStoreTemplateObj.Delete(ProductByStoreObj))
                    {
                        return APIResponse.NOT_OK;
                    }
                    else
                    {
                        return APIResponse.OK;
                    }
                }
                else
                {
                    return APIResponse.NOT_AUTHENTICATED;
                }
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while removing category (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Warn.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Insert(IProductByStore ProductByStoreObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == ProductByStoreTemplateObj.Insert(ProductByStoreObj))
                    {
                        return APIResponse.NOT_OK;
                    }
                    else
                    {
                        return APIResponse.OK;
                    }
                }
                else
                {
                    return APIResponse.NOT_AUTHENTICATED;
                }

            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while adding category (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Update(IProductByStore ProductByStoreObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == ProductByStoreTemplateObj.Update(ProductByStoreObj))
                    {
                        return APIResponse.NOT_OK;
                    }
                    else
                    {
                        return APIResponse.OK;
                    }
                }
                else
                {
                    return APIResponse.NOT_AUTHENTICATED;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
