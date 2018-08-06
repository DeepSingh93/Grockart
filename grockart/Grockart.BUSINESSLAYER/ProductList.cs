using System;
using System.Collections.Generic;
using Grockart.DATALAYER;
using System.Data;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;

namespace Grockart.BUSINESSLAYER
{
    public class ProductsByCategory : Category
    {
        public List<Products> Product { get; set; }

        internal void SetProductList(List<Products> ProductList)
        {
            this.Product = ProductList;
        }
    }
    public class ProductsList
    {
        public ProductResponse FetchProducts()
        {
            // Instance the response
            ProductResponse response = new ProductResponse();

            try
            {
                DataSet output = new ProductTemplate().FetchAllProducts();
                // check the row count
                if (output.Tables[0].Rows.Count == 0)
                {
                    response.HasProducts = false;
                    response.responseString = "No products available".ToString(); ;
                }
                else
                {
                    // we have the products
                    // get the unique list of categories
                    DataView dv = new DataView(output.Tables[0]);
                    DataTable UniqueCategories = dv.ToTable(true, "CategoryName");
                    response.HasProducts = true;
                    response.responseString = "SUCCESS";
                    response.TotalCategories = UniqueCategories.Rows.Count;
                    // we have the unique categories
                    response.productsByCategory = new List<Category>();
                    foreach (DataRow dr in UniqueCategories.Rows)
                    {
                        string CategoryName = dr["CategoryName"].ToString();
                        ProductsByCategory ProductsByCategoryObj = new ProductsByCategory();
                        ProductsByCategoryObj.SetCategoryName(CategoryName);
                        DataView dvFiltered = new DataView(output.Tables[0])
                        {
                            RowFilter = "CategoryName = '" + CategoryName + "'"
                        };

                        List<Products> ProductList = new List<Products>();
                        // from dv filtered, get all the product details
                        foreach (DataRowView FilteredRow in dvFiltered)
                        {
                            Products ProdObj = new Products
                            {
                                pbsID = int.Parse(FilteredRow["pbsID"].ToString()),
                                ProductName = FilteredRow["productName"].ToString(),
                                Price = Double.Parse(FilteredRow["Price"].ToString()),
                                StoreLogo = FilteredRow["storeLogo"].ToString(),
                                QuantityType = FilteredRow["quantityperunit"].ToString(),
                                ProductImage = FilteredRow["productImage"].ToString()
                            };
                            ProductList.Add(ProdObj);
                        }
                        ProductsByCategoryObj.SetProductList(ProductList);
                        response.productsByCategory.Add(ProductsByCategoryObj);
                    }
                }
            }
            catch (Exception ex)
            {
                // log the event
                Logger.Instance().Log(Fatal.Instance(), ex);
                response.HasProducts = false;
                response.responseString = " Unable to fetch products this time, please try again later. This event has been logged".ToString();
            }
            return response;
        }

        public ProductResponse FetchProducts(string Query)
        {
            // Instance the response
            ProductResponse response = new ProductResponse();
            try
            {
                response.KeywordSearch = Query;
                // replace spaces by | for regexp to process multiple keywords in MYSQL
                Query = Query.Replace(' ', '|');
                DataSet output = new ProductTemplate().FetchAllProducts(Query);
                // check the row count
                if (output.Tables[0].Rows.Count == 0)
                {
                    response.HasProducts = false;
                    response.responseString = "No products available with Query : " + Query;
                }
                else
                {
                    // we have the products
                    // get the unique list of categories
                    DataView dv = new DataView(output.Tables[0]);
                    DataTable UniqueCategories = dv.ToTable(true, "CategoryName");
                    response.HasProducts = true;
                    response.responseString = "SUCCESS";
                    response.TotalCategories = UniqueCategories.Rows.Count;
                    // we have the unique categories
                    response.productsByCategory = new List<Category>();
                    foreach (DataRow dr in UniqueCategories.Rows)
                    {
                        string CategoryName = dr["CategoryName"].ToString();
                        ProductsByCategory ProductsByCategoryObj = new ProductsByCategory();
                        ProductsByCategoryObj.SetCategoryName(CategoryName);
                        DataView dvFiltered = new DataView(output.Tables[0])
                        {
                            RowFilter = "CategoryName = '" + CategoryName + "'"
                        };

                        List<Products> ProductList = new List<Products>();
                        // from dv filtered, get all the product details
                        foreach (DataRowView FilteredRow in dvFiltered)
                        {
                            Products ProdObj = new Products
                            {
                                pbsID = int.Parse(FilteredRow["pbsID"].ToString()),
                                ProductName = FilteredRow["productName"].ToString(),
                                Price = Double.Parse(FilteredRow["Price"].ToString()),
                                StoreLogo = FilteredRow["storeLogo"].ToString(),
                                QuantityType = FilteredRow["quantityperunit"].ToString(),
                                ProductImage = FilteredRow["productImage"].ToString()
                            };
                            ProductList.Add(ProdObj);
                        }
                        ProductsByCategoryObj.SetProductList(ProductList);
                        response.productsByCategory.Add(ProductsByCategoryObj);
                    }
                }
            }
            catch (Exception ex)
            {
                // log the event
                Logger.Instance().Log(Fatal.Instance(), ex);
                response.HasProducts = false;
                response.responseString = " Unable to fetch products this time, please try again later. This event has been logged".ToString();
                throw ex;
            }
            return response;
        }
    }
}
