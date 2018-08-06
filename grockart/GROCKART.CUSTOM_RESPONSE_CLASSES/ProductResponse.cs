using System.Collections.Generic;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class ProductResponse
    {
        public string KeywordSearch;
        public bool HasProducts;
        public string responseString;
        public int TotalCategories;
        public List<Category> productsByCategory;
    }
}
