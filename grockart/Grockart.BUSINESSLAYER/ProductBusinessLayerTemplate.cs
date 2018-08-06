
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.BUSINESSLAYER
{
    public class ProductBusinessLayerTemplate : CRUDBusinessLayerTemplate<IProduct>
    {
        private readonly CRUDTemplate<IProduct> ProductTemplateObj = new ProductTemplate();
        private readonly IUserProfile UserProfileObj;
        public ProductBusinessLayerTemplate()
        {
          
        }
        public ProductBusinessLayerTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public override List<IProduct> Select()
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    return ProductTemplateObj.Select();
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
        public override APIResponse Delete(IProduct ProductObj)
        {
            try
            {
                bool AuthAdminResponseObj = new Security(UserProfileObj).AuthenticateAdmin();
                if (AuthAdminResponseObj == true)
                {
                    if (0 == ProductTemplateObj.Delete(ProductObj))
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
        public override APIResponse Insert(IProduct ProductObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == ProductTemplateObj.Insert(ProductObj))
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
        public override APIResponse Update(IProduct ProductObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == ProductTemplateObj.Update(ProductObj))
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
