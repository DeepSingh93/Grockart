using System;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class ProductByStore : IProductByStore
    {
        public int ProductByStoreID;
        public int StoreID;
        public int CategoryID;
        public int ProductID;
        public string StoreName;
        public string CategoryName;
        public string ProductName;
        public double Price;
        public int Quantity;
        public string QuantityPerUnit;
        public ProductByStore()
        {
        }
        public void SetProductByStoreID(int ProductByStoreID)
        {
            this.ProductByStoreID = ProductByStoreID;
        }
        public int GetProductByStoreID()
        {
            return ProductByStoreID;
        }
        public void SetStoreID(int StoreID)
        {
            this.StoreID = StoreID;
        }
        public int GetStoreID()
        {
            return StoreID;
        }
        public void SetCategoryID(int CategoryID)
        {
            this.CategoryID = CategoryID;
        }
        public int GetCategoryID()
        {
            return CategoryID;
        }
        public void SetProductID(int ProductID)
        {
            this.ProductID = ProductID;
        }
        public int GetProductID()
        {
            return ProductID;
        }
        public void SetStoreName(string StoreName)
        {
            this.StoreName = StoreName;
        }
        public string GetStoreName()
        {
            CheckNulls(StoreName, "Store Name");
            return StoreName;
        }
        public void SetCategoryName(string CategoryName)
        {
            this.CategoryName = CategoryName;
        }
        public string GetCategoryName()
        {
            CheckNulls(CategoryName, "Category Name");
            return CategoryName;
        }
        public void SetProductName(string ProductName)
        {
            this.ProductName = ProductName;
        }
        public string GetProductName()
        {
            CheckNulls(ProductName, "Product Name");
            return ProductName;
        }
        public void SetPrice(double Price)
        {
            this.Price = Price;
        }
        public double GetPrice()
        {
            CheckNegative(Price, "Price");
            return Price;
        }
        public void SetQuantity(int Quantity)
        {
            this.Quantity = Quantity;
        }
        public int GetQuantity()
        {
            CheckNegative(Quantity, "Quantity");
            return Quantity;
        }
        public void SetQuantityPerUnit(string QuantityPerUnit)
        {
            this.QuantityPerUnit = QuantityPerUnit;
        }
        public string GetQuantityPerUnit()
        {
            CheckNulls(QuantityPerUnit, "Quantity Per Unit");
            return QuantityPerUnit;
        }
        public void CheckNulls(string Input, object InputType)
        {
            if (Input == null || Input.Length == 0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = null");
            }
        }
        public void CheckNegative(double Input, object InputType)
        {
            if (Input<0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = negative");
            }
        }
    }
}
