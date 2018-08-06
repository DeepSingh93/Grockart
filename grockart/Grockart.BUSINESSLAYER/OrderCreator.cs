using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public class OrderCreator
    {
        public IOrderCreaterStatus CreateOrder(IAddress AddressObj, ICardDetails CardObj, IUserProfile UserProfileObj, ICart CartObj)
        {
            try
            {
                TaxManagement TaxManagementObj = new TaxManagement();
                int orderID = int.Parse(new OrderCreatorDataLayer().CreateOrderID(AddressObj, CardObj, UserProfileObj).Tables[0].Rows[0]["OrderID"].ToString());
                List<ITaxProducts> ProductList = TaxManagementObj.CalculateTaxByProduct(CartObj, AddressObj, UserProfileObj);
                // insert all the values to the database
                OrderCreatorDataLayer OrderDataLayerObj = new OrderCreatorDataLayer();
                foreach (CartItems Items in CartObj.GetCartItems())
                {
                    OrderDataLayerObj.InsertValuesToDatabase(orderID, Items.ProductObj.pbsID, Items.ProductObj.Quantity, Items.ProductObj.Price, TaxManagementObj.GetTaxAmount(Items.ProductObj.pbsID, ProductList));
                }

                IOrderCreaterStatus ResponseObj = new OrderCreaterStatus(true, orderID);
                return ResponseObj;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }


      
    }

    public class OrderCreaterStatus : IOrderCreaterStatus
    {
        public readonly bool IsOrderCreated;
        public readonly int OrderID;
        public OrderCreaterStatus(bool IsOrderCreated, int OrderID)
        {
            this.IsOrderCreated = IsOrderCreated;
            this.OrderID = OrderID;
        }

        public bool GetIsOrderCreated()
        {
            return IsOrderCreated;
        }

        public int GetOrderID()
        {
            return OrderID;
        }
    }

    public interface IOrderCreaterStatus
    {
        bool GetIsOrderCreated();
        int GetOrderID();
    }
}
