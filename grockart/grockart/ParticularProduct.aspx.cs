using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class ParticularProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int RouteValue = int.Parse(Page.RouteData.Values["ProductID"].ToString());
            if (!Page.IsPostBack)
            {
                ErrorProduct.Visible = false;
                resultsTable.Visible = false;

                IProductByStore ProductByStoreObj = new ProductByStore();
                ProductByStoreObj.SetProductByStoreID(RouteValue);

                // build the product
                AbstractProductBuilder<ProductBuilderResponse> Builder = new ConcreteProductBuilder(ProductByStoreObj);
                Builder.BuildProductDetails();
                Builder.BuildProductImage();
                Builder.BuildLowestPriceStoreImage();
                Builder.BuildOtherStoreDetails();

                ProductBuilderResponse Response = Builder.GetFinalProduct();
                ProductButtons.InnerHtml = " <table><tr><td><div class='row no-margin ProductAction-AddCart' id='cart_"+ Response.GetProductByStoreID() + "' onclick='AddToCart(event, " + Response.GetProductByStoreID() + ", this);'><span class='pos-abs'><i class='material-icons'>add_shopping_cart</i></span><span class='pos-add-cart'>ADD TO CART</span></div></td><td><div class='row no-margin ProductAction-BuyNow' onclick='BuyNow(event, " + Response.GetProductByStoreID() + ");'><span class='pos-abs'><i class='material-icons'>shopping_cart</i></span><span class='pos-add-cart'>BUY NOW</span></div></td></tr></table>";
                Breadcrumb_Product_Name.InnerText = Response.GetProductName();
                ProductImage.InnerHtml = " <img class='productImage' src='/assets/" + Response.GetProductImage() + "' />";
                ProductName.InnerText = Response.GetProductName();
                ProductPriceClass.InnerHtml = "<span>$" + Response.GetPrice().ToString() + " / " + Response.GetQuantityPerUnit() + "</span><span><img class='ProductSuperStoreImage' src='/assets/" + Response.GetStoreImage() + "' /></span>";
                ProductResult.InnerHtml = "<a href='/Products?k=" + Response.GetCategoryName() + "'>" + Response.GetCategoryName().ToUpper() + "</a></span>";

                if (Response.GetQuantity() < 1)
                {
                    NotOutOfStockLabel.Visible = false;
                    OutOfStockLabel.Visible = true;
                }
                else
                {
                    NotOutOfStockLabel.Visible = true;
                    OutOfStockLabel.Visible = false;
                    ProductQuantityDropdown.InnerHtml = GenerateDropdown(Response.GetProductByStoreID(), Response.GetQuantity());
                }

                OtherStoresProducts.InnerHtml = GenerateOtherStoreHTML(Response);
                resultsTable.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(new Fatal(), ex);
            ErrorProduct.Visible = true;
            resultsTable.Visible = false;
        }
    }

    private string GenerateOtherStoreHTML(ProductBuilderResponse response)
    {
        string HTML = "<table>";
        if (response.GetHasOtherStores())
        {
            OtherStores.Visible = true;
            List<Grockart.CUSTOM_RESPONSE_CLASSES.Products> StoresList = response.GetOtherStoresList();
            foreach (Grockart.CUSTOM_RESPONSE_CLASSES.Products ProductObj in StoresList)
            {
                HTML += "<tr class='other-superstore-product-row'>";
                HTML += "<td><img class='ProductOtherStoreImage' src='/assets/" + ProductObj.StoreLogo + "' /></td>";
                HTML += "<td><div class='select-dropdown-other-stores'>$ " + ProductObj.Price.ToString() + " / " + ProductObj.QuantityType.ToString() + "</div></td>";
                if (ProductObj.Quantity == 0)
                {
                    HTML += "<td colspan=3> <div class='otherStoresOutOfStockLabel'> Out Of Stock</div></td>";
                }
                else
                {
                    HTML += "<td>" + GenerateOtherStoresDropdown(ProductObj.pbsID, ProductObj.Quantity) + "</td>";
                    HTML += "<td><div class='row no-margin ProductAction-OtherStores-AddCart' id='cart_"+ ProductObj.pbsID.ToString() + "' onclick='AddToCart(event, " + int.Parse(ProductObj.pbsID.ToString()) + ", this);'><span class='pos-abs'><i class='material-icons'>add_shopping_cart</i></span><span class='pos-add-cart'>ADD TO CART</span></div></td>";
                    HTML += "<td><div class='row no-margin ProductAction-OtherStores-BuyNow' onclick='BuyNow(event, " + int.Parse(ProductObj.pbsID.ToString()) + ");'><span class='pos-abs'><i class='material-icons'>shopping_cart</i></span><span class='pos-add-cart'>BUY NOW</span></div></td>";

                }
                HTML += "</tr>";
            }
        }
        else
        {
            OtherStores.Visible = false;
        }
        HTML += "</table>";
        return HTML;
    }

    private string GenerateDropdown(int PBSId, int Quantity)
    {
        string HTML = "<select id=" + PBSId.ToString() + "_dropdown>";
        for (int i = 1; i <= Quantity; i++)
        {
            HTML += "<option value=" + i.ToString() + ">" + i.ToString() + "</option>";
        }
        HTML += "</select>";
        return HTML;
    }
    private string GenerateOtherStoresDropdown(int PBSId, int Quantity)
    {
        string HTML = "<select id=" + PBSId.ToString() + "_dropdown class='select-dropdown-other-stores'>";
        for (int i = 1; i <= Quantity; i++)
        {
            HTML += "<option value=" + i.ToString() + ">" + i.ToString() + "</option>";
        }
        HTML += "</select>";
        return HTML;
    }
}