using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface ICategory
    {
        void SetCategoryId(int CategoryId);
        int GetCategoryId();
        void SetCategoryName(string CategoryName);
        string GetCategoryName();
    }
}
