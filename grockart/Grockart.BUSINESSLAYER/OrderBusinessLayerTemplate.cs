using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    public class OrderBusinessLayerTemplate : CRUDBusinessLayerTemplate<IOrder>
    {
        private readonly CRUDTemplate<IOrder> OrderDataLayerObj;
        private readonly IUserProfile UserProfileObj;
        public OrderBusinessLayerTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
            this.OrderDataLayerObj = new OrderDataLayer(UserProfileObj);
        }
        public override List<IOrder> Select()
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    return OrderDataLayerObj.Select();
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while fetching order (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Delete(IOrder StatusObj)
        {
            try
            {
                bool AuthUserResponseObj = new Security(UserProfileObj).AuthenticateAdmin();
                if (AuthUserResponseObj == true)
                {
                    if (0 == OrderDataLayerObj.Delete(StatusObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while removing order (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
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
        public override APIResponse Insert(IOrder StatusObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == OrderDataLayerObj.Insert(StatusObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while adding order (Routine : AuthenticateAdmin), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Update(IOrder StatusObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateAdmin();
                if (Response == true)
                {
                    if (0 == OrderDataLayerObj.Update(StatusObj))
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

        public APIResponse Cancel(IOrder StatusObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    if (0 == new OrderDataLayer(UserProfileObj).Cancel(StatusObj))
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
