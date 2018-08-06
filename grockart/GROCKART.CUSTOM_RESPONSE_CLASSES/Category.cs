using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class Category : ICategory
    {
        public int CategoryId;
        public string CategoryName;
        public List<Products> Product = new List<Products>();
        public Category()
        {
        }
        public void SetCategoryId(int CategoryId)
        {
            this.CategoryId = CategoryId;
        }
        public int GetCategoryId()
        {
            return CategoryId;
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

        private void CheckNulls(string Input, object InputType)
        {
            if (Input == null || Input.Length == 0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = null");
            }
        }

    }
}
