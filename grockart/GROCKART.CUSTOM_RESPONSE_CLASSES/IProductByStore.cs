using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface IProductByStore
    {
        void SetProductByStoreID(int ProductByStoreID);
        int GetProductByStoreID();
        void SetStoreID(int StoreID);
        int GetStoreID();
        void SetCategoryID(int CategoryID);
        int GetCategoryID();
        void SetProductID(int ProductID);
        int GetProductID();
        void SetStoreName(string StoreName);
        string GetStoreName();
        void SetCategoryName(string CategoryName);
        string GetCategoryName();
        void SetProductName(string ProductName);
        string GetProductName();
        void SetPrice(double Price);
        double GetPrice();
        void SetQuantity(int Quantity);
        int GetQuantity();
        void SetQuantityPerUnit(string QuantityPerUnit);
        string GetQuantityPerUnit();
    }
}