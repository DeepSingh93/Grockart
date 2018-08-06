using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public class AddressBusinessLayerTemplate : CRUDBusinessLayerTemplate<IAddress>
    {
        private readonly CRUDTemplate<IAddress> AddressDataLayerObj;
        private readonly IUserProfile UserProfileObj;
        public AddressBusinessLayerTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
            AddressDataLayerObj = new AddressDataLayer(UserProfileObj);
        }
        public override List<IAddress> Select()
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    return AddressDataLayerObj.Select();
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while fetching address (Routine : AuthenticateUser), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Delete(IAddress AddressObj)
        {
            try
            {
                bool AuthUserResponseObj = new Security(UserProfileObj).AuthenticateUser();
                if (AuthUserResponseObj == true)
                {
                    if (0 == AddressDataLayerObj.Delete(AddressObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while removing address (Routine : AuthenticateUser), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
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
        public override APIResponse Insert(IAddress AddressObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    if (0 == AddressDataLayerObj.Insert(AddressObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while adding address (Routine : AuthenticateUser), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Update(IAddress AddressObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    if (0 == AddressDataLayerObj.Update(AddressObj))
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
