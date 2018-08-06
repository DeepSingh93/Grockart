using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grockart.LOGGER;

namespace Grockart.BUSINESSLAYER
{
    public class TaxManagement
    {
        public ITaxResult CalculateTaxFromCartItems(ICart CartObj, IAddress AddressObj, IUserProfile UserProfile)
        {
            try
            {
                ISecurity Security = new Security(UserProfile);
                if (Security.AuthenticateUser() == true)
                {
                    double PreTaxAmount = CalculateCartPrice(CartObj);
                    DataSet TaxResultFromDB = new TaxManagementDataLayer().GetTaxDetailsFromDB(AddressObj.GetAddressID());
                    double FinalAmount = PreTaxAmount + CalculateCartTax(PreTaxAmount, TaxResultFromDB);
                    return new TaxResult(true, TaxResultFromDB.Tables[0].Rows[0]["tax_type"].ToString(), double.Parse(TaxResultFromDB.Tables[0].Rows[0]["tax"].ToString()), CalculateCartTax(PreTaxAmount, TaxResultFromDB), FinalAmount, PreTaxAmount);
                }
                return new TaxResult(false);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        internal double GetTaxAmount(int pbsID, List<ITaxProducts> productList)
        {
            foreach (TaxProduct Product in productList)
            {
                if (Product.GetProductID() == pbsID)
                {
                    return Product.GetTaxAmount();
                }
            }
            return 0;
        }

        public List<ITaxProducts> CalculateTaxByProduct(ICart cartObj, IAddress AddressObj, IUserProfile UserProfile)
        {
            try
            {
                List<ITaxProducts> ProductList = new List<ITaxProducts>();
                ISecurity Security = new Security(UserProfile);
                if (Security.AuthenticateUser() == true)
                {
                    DataSet TaxDS = new TaxManagementDataLayer().GetTaxDetailsFromDB(AddressObj.GetAddressID());
                    double TaxFromDB = Math.Round(double.Parse(TaxDS.Tables[0].Rows[0]["Tax"].ToString()), 2);
                    foreach (CartItems Items in cartObj.GetCartItems())
                    {
                        double TotalAmount = Math.Round(Items.ProductObj.Price * Items.ProductObj.Quantity * 0.01 * TaxFromDB, 2);
                        ProductList.Add(new TaxProduct(Items.ProductObj.pbsID, TotalAmount));
                    }
                }
                return ProductList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        private double CalculateCartTax(double TotalItemsPreTAX, DataSet TaxResultFromDB)
        {
            double TaxPercentage = double.Parse(TaxResultFromDB.Tables[0].Rows[0]["tax"].ToString());
            return Math.Round(TotalItemsPreTAX * TaxPercentage / 100, 2);
        }

        private double CalculateCartPrice(ICart cartObj)
        {
            double TotalAmount = 0;
            foreach (CartItems Items in cartObj.GetCartItems())
            {
                TotalAmount += Items.ProductObj.Price * Items.ProductObj.Quantity;
            }
            return TotalAmount;
        }
    }
    public class TaxProduct : ITaxProducts
    {
        private readonly int ProductID;
        private readonly double TaxAmount;

        public TaxProduct(int ProductID, double TaxAmount)
        {
            this.ProductID = ProductID;
            this.TaxAmount = TaxAmount;
        }
        public int GetProductID()
        {
            return ProductID;
        }

        public double GetTaxAmount()
        {
            return TaxAmount;
        }
    }
    public interface ITaxProducts
    {
        int GetProductID();
        double GetTaxAmount();
    }

    public interface ITaxResult
    {
        bool GetHasResult();
        string GetTaxType();
        double GetTaxPercentage();
        double GetTaxAmount();

    }
    public class TaxResult : ITaxResult
    {
        public readonly bool HasResult;
        public readonly string TaxType;
        public readonly double TaxPercentage;
        public readonly double TaxAmount;
        public readonly double FinalAmount;
        public readonly double PreTaxAmount;
        public TaxResult(bool HasResult, string TaxType, double TaxPercentage, double TaxAmount, double FinalAmount, double PreTaxAmount)
        {
            this.HasResult = HasResult;
            this.TaxType = TaxType;
            this.TaxPercentage = TaxPercentage;
            this.TaxAmount = TaxAmount;
            this.FinalAmount = FinalAmount;
            this.PreTaxAmount = PreTaxAmount;
        }

        public TaxResult(bool HasResult)
        {
            this.HasResult = HasResult;
        }

        public double GetPreTaxAmount()
        {
            return PreTaxAmount;
        }

        public bool GetHasResult()
        {
            return HasResult;
        }

        public double GetTaxAmount()
        {
            return TaxAmount;
        }

        public double GetTaxPercentage()
        {
            return TaxPercentage;
        }

        public string GetTaxType()
        {
            return TaxType;
        }
    }
}
