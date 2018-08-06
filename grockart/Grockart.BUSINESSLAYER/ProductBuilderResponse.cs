using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public class ProductBuilderResponse
    {
        private string CategoryName;
        private string ProductName;
        private string QuantityPerUnit;
        private int Quantity;
        private double Price;
        private bool HasProducts;
        private bool HasOtherStores;
        private string ProductImageURL;
        private List<Products> OtherProductStoresList;
        private string StoreImage;
        private int ProductByStoreID;
        public void SetStoreImage(string StoreImage)
        {
            this.StoreImage = StoreImage;
        }
        public string GetStoreImage()
        {
            return StoreImage;
        }
        public void SetOtherstoresList(List<Products> OtherProductStoresList)
        {
            this.OtherProductStoresList = OtherProductStoresList;
        }
        public List<Products> GetOtherStoresList()
        {
            return OtherProductStoresList;
        }
        public void SetHasOtherStores(bool HasOtherStores)
        {
            this.HasOtherStores = HasOtherStores;
        }
        public bool GetHasOtherStores()
        {
            return HasOtherStores;
        }
        public void SetHasProducts(bool HasProducts)
        {
            this.HasProducts = HasProducts;
        }
        public bool GetHasProducts()
        {
            return HasProducts;
        }
        public void SetCategoryName(string CategoryName)
        {
            this.CategoryName = CategoryName;
        }
        public void SetProductName(string ProductName)
        {
            this.ProductName = ProductName;
        }
        public void SetQuantityPerUnit(string QuantityPerUnit)
        {
            this.QuantityPerUnit = QuantityPerUnit;
        }
        public void SetPrice(double Price)
        {
            this.Price = Price;
        }

        public void SetProductByStoreID(int ProductByStoreID)
        {
            this.ProductByStoreID = ProductByStoreID;
        }

        public int GetProductByStoreID()
        {
            return ProductByStoreID;
        }

        internal void SetProductImage(string ProductImageURL)
        {
            this.ProductImageURL = ProductImageURL;
        }

        public string GetProductImage()
        {
            return ProductImageURL;
        }

        public string GetCategoryName()
        {
            return CategoryName;
        }

        public string GetProductName()
        {
            return ProductName;
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetQuantity(int Quantity)
        {
            this.Quantity = Quantity;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public string GetQuantityPerUnit()
        {
            return QuantityPerUnit;
        }
    }
}
