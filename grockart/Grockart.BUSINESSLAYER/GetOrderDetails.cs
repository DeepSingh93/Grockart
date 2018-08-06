using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.BUSINESSLAYER
{
    public class GetOrderDetails
    {
        public IOrderDetailsResponse FetchOrderDetailsByOrderID(IOrder OrderObj, IUserProfile UserProfileObj)
        {
            try
            {
                IOrderDetailsResponse Response = null;
                List<ITaxOrderDetailsByProduct> ProductList;
                DataSet OrderDetailsResponse = new OrderDetailsDataLayer(UserProfileObj, OrderObj).FetchOrderDetailsByID();
                if (OrderDetailsResponse.Tables[0].Rows.Count > 0)
                {
                    ProductList = new List<ITaxOrderDetailsByProduct>();
                    IOrderDetailsDateAndStatus OrderDetailsDateAndStatusObj = new OrderDetailsDateAndStatus(DateTime.Parse(OrderDetailsResponse.Tables[0].Rows[0]["date"].ToString()), OrderDetailsResponse.Tables[0].Rows[0]["statusName"].ToString());
                    foreach (DataRow dr in OrderDetailsResponse.Tables[2].Rows)
                    {

                        IStores StoreObj = new Stores();
                        StoreObj.SetStoreLogo(dr["storeLogo"].ToString());
                        IProduct ProductObj = new ProductsOnly();
                        ProductObj.SetProductName(dr["productName"].ToString());
                        ProductObj.SetProductImage(dr["productImage"].ToString());
                        ProductObj.SetProductQuantity(int.Parse(dr["quantity"].ToString()));
                        ITaxOrderDetailsByProduct ProductListObj = new TaxOrderDetailsByProduct(StoreObj, ProductObj, double.Parse(dr["PreTaxProductPrice"].ToString()), double.Parse(dr["PostTaxProductPrice"].ToString()), double.Parse(dr["taxAmount"].ToString()));
                        ProductList.Add(ProductListObj);
                    }
                    DataRow AddressRow = OrderDetailsResponse.Tables[1].Rows[0];
                    IAddress AddressObj = new Address(
                        AddressRow["addressName"].ToString(),
                        AddressRow["appt"].ToString(),
                        AddressRow["postalCode"].ToString(),
                        AddressRow["phone"].ToString(),
                        AddressRow["city"].ToString(),
                        AddressRow["city"].ToString(),
                        AddressRow["Province"].ToString()
                     );
                    DataRow TaxComputedRow = OrderDetailsResponse.Tables[3].Rows[0];
                    IComputedTaxPrice ComputedObj = new ComputedTaxPrice(
                     int.Parse(TaxComputedRow["TotalUniqueQuantity"].ToString()),
                     int.Parse(TaxComputedRow["TotalQuantity"].ToString()),
                     double.Parse(TaxComputedRow["TotalPreTaxProductPrice"].ToString()),
                     double.Parse(TaxComputedRow["TotalPostTaxProductPrice"].ToString()),
                     double.Parse(TaxComputedRow["TotalTaxAmount"].ToString())
                     );
                    ICardDetails CardObj = new CardDetails(int.Parse(OrderDetailsResponse.Tables[0].Rows[0]["caID"].ToString()));
                    ICardDetails OutputCardDecrypted = new CardDetailsBusinessLayerTemplate(UserProfileObj).Select(CardObj);
                    Response = new OrderDetailResponse(true, ProductList, OrderDetailsDateAndStatusObj, AddressObj, ComputedObj, OutputCardDecrypted);
                }
                else
                {
                    Response = new OrderDetailResponse(false);
                }

                return Response;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Warn.Instance(), ex);
                throw ex;
            }
        }
    }

    public interface IComputedTaxPrice
    {
        int GetTotalUniqueQuantity();
        int GetTotalQuantity();
        double GetTotalPreTaxProductPrice();
        double GetTotalPostTaxProductPrice();
        double GetTotalTaxAmount();
    }
    public class ComputedTaxPrice : IComputedTaxPrice
    {
        private readonly int TotalUniqueQuantity;
        private readonly int TotalQuantity;
        private readonly double TotalPreTaxProductPrice;
        private readonly double TotalPostTaxProductPrice;
        private readonly double TotalTaxAmount;

        public ComputedTaxPrice(int TotalUniqueQuantity, int TotalQuantity, double TotalPreTaxProductPrice, double TotalPostTaxProductPrice, double TotalTaxAmount)
        {
            this.TotalUniqueQuantity = TotalUniqueQuantity;
            this.TotalQuantity = TotalQuantity;
            this.TotalPreTaxProductPrice = TotalPreTaxProductPrice;
            this.TotalPostTaxProductPrice = TotalPostTaxProductPrice;
            this.TotalTaxAmount = TotalTaxAmount;
        }

        public double GetTotalPostTaxProductPrice()
        {
            return TotalPostTaxProductPrice;
        }

        public double GetTotalPreTaxProductPrice()
        {
            return TotalPreTaxProductPrice;
        }

        public int GetTotalQuantity()
        {
            return TotalQuantity;
        }

        public double GetTotalTaxAmount()
        {
            return TotalTaxAmount;
        }

        public int GetTotalUniqueQuantity()
        {
            return TotalUniqueQuantity;
        }
    }

    public interface ITaxOrderDetailsByProduct
    {
        IStores GetStoreObj();
        IProduct GetProductObj();
        double GetPreTaxProductPrice();
        double GetPostTaxProductPrice();
        double GetTax();
    }

    public class TaxOrderDetailsByProduct : ITaxOrderDetailsByProduct
    {
        private readonly IStores StoreObj;
        private readonly IProduct ProductObj;
        private readonly double PreTaxProductPrice;
        private readonly double PostTaxProductPrice;
        private readonly double Tax;
        public TaxOrderDetailsByProduct(IStores StoreObj, IProduct ProductObj, double PreTaxProductPrice, double PostTaxProductPrice, double Tax)
        {
            this.StoreObj = StoreObj;
            this.ProductObj = ProductObj;
            this.PreTaxProductPrice = PreTaxProductPrice;
            this.PostTaxProductPrice = PostTaxProductPrice;
            this.Tax = Tax;
        }

        public double GetPostTaxProductPrice()
        {
            return PostTaxProductPrice;
        }

        public double GetPreTaxProductPrice()
        {
            return PreTaxProductPrice;
        }

        public IProduct GetProductObj()
        {
            return ProductObj;
        }

        public IStores GetStoreObj()
        {
            return StoreObj;
        }

        public double GetTax()
        {
            return Tax;
        }
    }

    public interface IOrderDetailsResponse
    {
        bool GetHasOrder();
        List<ITaxOrderDetailsByProduct> GetProductList();
        IOrderDetailsDateAndStatus GetOrderDateAndStatusObj();
        IAddress GetAddressObj();
        IComputedTaxPrice GetComputedObj();
        ICardDetails GetCardDetails();
    }
    public class OrderDetailResponse : IOrderDetailsResponse
    {
        private readonly bool HasOrder;
        private readonly List<ITaxOrderDetailsByProduct> ProductList;
        private readonly IOrderDetailsDateAndStatus OrderDateAndStatusObj;
        private readonly IAddress AddressObj;
        private readonly IComputedTaxPrice ComputedObj;
        private readonly ICardDetails CardDetails;
        public OrderDetailResponse(
           bool HasOrder)
        {
            this.HasOrder = HasOrder;
        }

        public OrderDetailResponse(
            bool HasOrder, 
            List<ITaxOrderDetailsByProduct> ProductList, 
            IOrderDetailsDateAndStatus OrderDateAndStatusObj, 
            IAddress AddressObj, 
            IComputedTaxPrice ComputedObj,
            ICardDetails CardDetails)
        {
            this.HasOrder = HasOrder;
            this.ProductList = ProductList;
            this.OrderDateAndStatusObj = OrderDateAndStatusObj;
            this.AddressObj = AddressObj;
            this.ComputedObj = ComputedObj;
            this.CardDetails = CardDetails;
        }

        public IAddress GetAddressObj()
        {
            return AddressObj;
        }

        public ICardDetails GetCardDetails()
        {
            return CardDetails;
        }

        public IComputedTaxPrice GetComputedObj()
        {
            return ComputedObj;
        }

        public bool GetHasOrder()
        {
            return HasOrder;
        }

        public IOrderDetailsDateAndStatus GetOrderDateAndStatusObj()
        {
            return OrderDateAndStatusObj;
        }

        public List<ITaxOrderDetailsByProduct> GetProductList()
        {
            return ProductList;
        }
    }

    public interface IOrderDetailsDateAndStatus
    {
        DateTime GetDate();
        string GetStatus();
    }

    public class OrderDetailsDateAndStatus : IOrderDetailsDateAndStatus
    {
        private readonly DateTime Date;
        private readonly string Status;
        public OrderDetailsDateAndStatus(DateTime Date, string Status)
        {
            this.Date = Date;
            this.Status = Status;
        }

        public DateTime GetDate()
        {
            return this.Date;
        }

        public string GetStatus()
        {
            return this.Status;
        }
    }
}
