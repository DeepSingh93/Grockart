using System;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
   public class Stores : IStores
    {
        public int StoreID;
        public string StoreName;
        public string StoreLogo;
        public Stores()
        {

        }
        public void SetStoreID(int StoreID)
        {
            this.StoreID = StoreID;
        }
        public int GetStoreID()
        {
            return StoreID;
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
        public void SetStoreLogo(string StoreLogo)
        {
            this.StoreLogo = StoreLogo;
        }
        public string GetStoreLogo()
        {
            CheckNulls(StoreLogo, "Store Logo");
            return StoreLogo;
        }
        public void CheckNulls(string Input, object InputType)
        {
            if (Input == null || Input.Length == 0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = null");
            }
        }
    }
}
