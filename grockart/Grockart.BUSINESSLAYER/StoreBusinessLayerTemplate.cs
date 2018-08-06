
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Grockart.BUSINESSLAYER
{
    public class StoreBusinessLayerTemplate : CRUDBusinessLayerTemplate<IStores>
    {
        private readonly CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
        private readonly IUserProfile UserProfileObj;
        public StoreBusinessLayerTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public override List<IStores> Select()
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    return StoresTemplateObj.Select();
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while fetching stores list (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Delete(IStores StoreObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == StoresTemplateObj.Delete(StoreObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while removing store (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
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
        public override APIResponse Insert(IStores StoreObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == StoresTemplateObj.Insert(StoreObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while adding store (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Update(IStores StoreObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == StoresTemplateObj.Update(StoreObj))
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
