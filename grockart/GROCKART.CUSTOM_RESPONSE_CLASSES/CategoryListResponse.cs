using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
  public class CategoryListResponse
    {
        private static CategoryListResponse CategoryListResponseObj;
        public static CategoryListResponse Instance()
        {
            if (CategoryListResponseObj == null)
            {
                CategoryListResponseObj = new CategoryListResponse();
            }

            return CategoryListResponseObj;
        }
        public bool HasList;
        public bool ShouldRedirectToHomePage;
        public string ResponseString;
        public List<Category> CategoryList;
    }
}
