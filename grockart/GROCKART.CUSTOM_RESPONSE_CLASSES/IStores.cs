using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface IStores
    {
        void SetStoreID(int StoreID);
        int GetStoreID();
        void SetStoreName(string StoreName);
        string GetStoreName();
        void SetStoreLogo(string StoreLogo);
        string GetStoreLogo();
    }
}
