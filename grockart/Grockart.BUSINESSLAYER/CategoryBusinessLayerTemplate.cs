
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    public class CategoryBusinessLayerTemplate : CRUDBusinessLayerTemplate<ICategory>
    {
        private readonly CRUDTemplate<ICategory> CategoryTemplateObj = new CategoryTemplate();
        private readonly IUserProfile UserProfileObj;
        public CategoryBusinessLayerTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public override List<ICategory> Select()
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    return CategoryTemplateObj.Select();
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
        public override APIResponse Delete(ICategory CategoryObj)
        {
            try
            {
                bool AuthAdminResponseObj = new Security(UserProfileObj).AuthenticateAdmin();
                if (AuthAdminResponseObj == true)
                {
                    if (0 == CategoryTemplateObj.Delete(CategoryObj))
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
        public override APIResponse Insert(ICategory CategoryObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == CategoryTemplateObj.Insert(CategoryObj))
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
        public override APIResponse Update(ICategory CategoryObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == CategoryTemplateObj.Update(CategoryObj))
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
