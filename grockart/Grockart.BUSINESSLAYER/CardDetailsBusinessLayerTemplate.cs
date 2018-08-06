using Grockart.CRYPTOGRAPHY;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    public class CardDetailsBusinessLayerTemplate : CRUDBusinessLayerTemplate<ICardDetails>
    {
        private readonly IUserProfile UserProfileObj;
        private readonly IEncrypt AESObj = new AES256();
        CRUDTemplate<ICardDetails> CardDetailsDataLayerObj;
        public CardDetailsBusinessLayerTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
            this.CardDetailsDataLayerObj = new CardDetailsDataLayer(UserProfileObj);
        }
        public override List<ICardDetails> Select()
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    List<ICardDetails> DecryptedCardDetailsList = new List<ICardDetails>();
                    foreach (ICardDetails EncryptedCardObj in CardDetailsDataLayerObj.Select())
                    {
                        ICardDetails DecryptedCardDetails = new CardDetails();
                        AESObj.SetIV(EncryptedCardObj.GetIV());
                        AESObj.SetKey(EncryptedCardObj.GetDecryptionKey());
                        DecryptedCardDetails.SetCardID(EncryptedCardObj.GetCardID());
                        DecryptedCardDetails.SetName(AESObj.Decrypt(EncryptedCardObj.GetName()));
                        DecryptedCardDetails.SetCardNumber(AESObj.Decrypt(EncryptedCardObj.GetCardNumber()).ToString());
                        DecryptedCardDetails.SetExpiryMonth(AESObj.Decrypt(EncryptedCardObj.GetExpiryMonth()));
                        DecryptedCardDetails.SetExpiryYear(AESObj.Decrypt(EncryptedCardObj.GetExpiryYear()));
                        DecryptedCardDetails.SetCvv(AESObj.Decrypt(EncryptedCardObj.GetCvv()));
                        DecryptedCardDetailsList.Add(DecryptedCardDetails);
                    }
                    return DecryptedCardDetailsList;
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while fetching card details (Routine : AuthenticateUser), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public ICardDetails Select(ICardDetails InputCardObj)
        {
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    foreach (ICardDetails EncryptedCardObj in CardDetailsDataLayerObj.Select())
                    {
                        if (EncryptedCardObj.GetCardID() == InputCardObj.GetCardID())
                        {
                            ICardDetails DecryptedCardDetails = new CardDetails();
                            AESObj.SetIV(EncryptedCardObj.GetIV());
                            AESObj.SetKey(EncryptedCardObj.GetDecryptionKey());
                            DecryptedCardDetails.SetCardID(EncryptedCardObj.GetCardID());
                            DecryptedCardDetails.SetName(AESObj.Decrypt(EncryptedCardObj.GetName()));
                            DecryptedCardDetails.SetCardNumber(AESObj.Decrypt(EncryptedCardObj.GetCardNumber()).ToString());
                            DecryptedCardDetails.SetExpiryMonth(AESObj.Decrypt(EncryptedCardObj.GetExpiryMonth()));
                            DecryptedCardDetails.SetExpiryYear(AESObj.Decrypt(EncryptedCardObj.GetExpiryYear()));
                            DecryptedCardDetails.SetCvv(AESObj.Decrypt(EncryptedCardObj.GetCvv()));
                            return DecryptedCardDetails;
                        }
                    }
                }
                return null;
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while fetching card details (Routine : AuthenticateUser), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Delete(ICardDetails CardDetailsObj)
        {
            try
            {
                bool AuthUserResponseObj = new Security(UserProfileObj).AuthenticateUser();
                if (AuthUserResponseObj == true)
                {
                    if (0 == CardDetailsDataLayerObj.Delete(CardDetailsObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while removing card (Routine : AuthenticateUser), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
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
        public override APIResponse Insert(ICardDetails CardDetailsObj)
        {
            try
            {
                AESObj.GenerateKey();
                CardDetailsObj.SetIV(AESObj.GetIV());
                CardDetailsObj.SetDecryptionKey(AESObj.GetKey());
                CardDetailsObj.SetName(AESObj.Encrypt(CardDetailsObj.GetName()));
                CardDetailsObj.SetCardNumber(AESObj.Encrypt(CardDetailsObj.GetCardNumber()));
                CardDetailsObj.SetExpiryMonth(AESObj.Encrypt(CardDetailsObj.GetExpiryMonth()));
                CardDetailsObj.SetExpiryYear(AESObj.Encrypt(CardDetailsObj.GetExpiryYear()));
                CardDetailsObj.SetCvv(AESObj.Encrypt(CardDetailsObj.GetCvv()));
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    if (0 == CardDetailsDataLayerObj.Insert(CardDetailsObj))
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
                Logger.Instance().Log(Warn.Instance(), new LogInfo("Received null reference while adding card (Routine : AuthenticateUser), might be token manipulation. Check token : " + UserProfileObj.GetToken()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Update(ICardDetails CardDetailsObj)
        {
            CardDetailsObj.SetCardNumber(AESObj.Encrypt(CardDetailsObj.GetName()));
            CardDetailsObj.SetCardNumber(AESObj.Encrypt(CardDetailsObj.GetCardNumber()));
            CardDetailsObj.SetExpiryMonth(AESObj.Encrypt(CardDetailsObj.GetExpiryMonth()));
            CardDetailsObj.SetExpiryYear(AESObj.Encrypt(CardDetailsObj.GetExpiryYear()));
            CardDetailsObj.SetCvv(AESObj.Encrypt(CardDetailsObj.GetCvv()));
            try
            {
                bool Response = new Security(UserProfileObj).AuthenticateUser();
                if (Response == true)
                {
                    if (0 == CardDetailsDataLayerObj.Update(CardDetailsObj))
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
