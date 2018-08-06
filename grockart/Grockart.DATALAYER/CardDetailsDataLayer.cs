using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.DATALAYER
{
    public class CardDetailsDataLayer : CRUDTemplate<ICardDetails>
    {
        private readonly ICommands Commands = MySQLCommands.Instance();
        private readonly IUserProfile UserProfileObj;
        private string Source;
        public CardDetailsDataLayer(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public override List<ICardDetails> Select()
        {
            Source = "sp_FetchCardDetails ";
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", UserProfileObj.GetToken())
                };
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                List<ICardDetails> CardDetail = new List<ICardDetails>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    ICardDetails CardObj = new CardDetails();
                    CardObj.SetCardID(Int32.Parse(dr["caID"].ToString()));
                    CardObj.SetName(dr["CardNameEncrypt"].ToString());
                    CardObj.SetCardNumber(dr["CardNumberEncrypt"].ToString());
                    CardObj.SetExpiryMonth(dr["ExpiryMonthEncrypt"].ToString());
                    CardObj.SetExpiryYear((dr["ExpiryYearEncrypt"].ToString()));
                    CardObj.SetCvv((dr["CvvEncrypt"].ToString()));
                    CardObj.SetIV(dr["Salt"].ToString());
                    CardObj.SetDecryptionKey(dr["DecryptionKey"].ToString());
                    CardDetail.Add(CardObj);
                }
                return CardDetail;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Delete(ICardDetails CardDetailsObj)
        {
            Source = "sp_RemoveCard";
            int CardID = CardDetailsObj.GetCardID();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@cardID", CardID),
                    new MySqlParameter("@paramToken", UserProfileObj.GetToken())
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
        public override int Insert(ICardDetails CardDetailsObj)
        {
            Source = "sp_AddCard";
            string Token = UserProfileObj.GetToken();
            string IV = CardDetailsObj.GetIV();
            string DecryptionKey = CardDetailsObj.GetDecryptionKey();
            string CardName = CardDetailsObj.GetName();
            string CardNum = CardDetailsObj.GetCardNumber();
            string ExpiryMonth = CardDetailsObj.GetExpiryMonth();
            string ExpiryYear = CardDetailsObj.GetExpiryYear();
            string CvvNum = CardDetailsObj.GetCvv();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramIV", IV),
                    new MySqlParameter("@paramDecryptionKey", DecryptionKey),
                    new MySqlParameter("@paramCardName", CardName),
                    new MySqlParameter("@paramCardNum", CardNum),
                    new MySqlParameter("@paramExpiryMonth", ExpiryMonth),
                    new MySqlParameter("@paramExpiryYear", ExpiryYear),
                    new MySqlParameter("@paramCvvNum", CvvNum)
                };
                return Commands.ExecuteNonQuery(Source, System.Data.CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Update(ICardDetails CardDetailsObj)
        {
            Source = "sp_ModifyCard";
            string Token = UserProfileObj.GetToken();
            string IV = CardDetailsObj.GetIV();
            string DecryptionKey = CardDetailsObj.GetDecryptionKey();
            int CardID = CardDetailsObj.GetCardID();
            string CardName = CardDetailsObj.GetName();
            string CardNum = CardDetailsObj.GetCardNumber();
            string ExpiryMonth = CardDetailsObj.GetExpiryMonth();
            string ExpiryYear = CardDetailsObj.GetExpiryYear();
            string CvvNum = CardDetailsObj.GetCvv();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramIV", IV),
                    new MySqlParameter("@paramDecryptionKey", DecryptionKey),
                    new MySqlParameter("@paramCaID", CardID),
                    new MySqlParameter("@paramCardName", CardName),
                    new MySqlParameter("@paramCardNum", CardNum),
                    new MySqlParameter("@paramExpiryMonth", ExpiryMonth),
                    new MySqlParameter("@paramExpiryYear", ExpiryYear),
                    new MySqlParameter("@paramCvvNum", CvvNum)
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
