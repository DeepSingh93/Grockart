using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewOrderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            OrderLabel.Text = int.Parse(Page.RouteData.Values["orderID"].ToString()).ToString();
            BuildOrderDetails();
            if (Request.QueryString["firstTimeView"] != null)
            {
                if (Request.QueryString["firstTimeView"].ToString() == "true")
                {
                    OrderPlacedSuccessfully.Visible = true;
                }
                else
                {
                    OrderPlacedSuccessfully.Visible = false;
                }
            }
            else
            {
                OrderPlacedSuccessfully.Visible = false;
            }
        }
        catch (Exception)
        {
            Response.Redirect("/Orders");
        }
    }

    private void BuildOrderDetails()
    {
        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                IUserProfile UserProfileObj = new UserProfile();
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                int OrderID = int.Parse(Page.RouteData.Values["orderID"].ToString());
                IOrder OrderObj = new Order();
                OrderObj.SetOrderID(OrderID);
                IOrderDetailsResponse OrderDetails = new GetOrderDetails().FetchOrderDetailsByOrderID(OrderObj, UserProfileObj);
                txt_ordernumber.Text = OrderID.ToString();
                
                if (OrderDetails.GetHasOrder())
                {
                    txt_status.Text = OrderDetails.GetOrderDateAndStatusObj().GetStatus();
                    order_invalid.Visible = false;
                    order_valid.Visible = true;
                    string HTMLContent = "";
                    foreach (ITaxOrderDetailsByProduct Product in OrderDetails.GetProductList())
                    {
                        HTMLContent += " <div class='row no-margin p10px pb20px cart-menu-item'><div class='col-lg-2 text-center no-margin'><img class='cart_page_img' src='/assets/" + Product.GetProductObj().GetProductImage() + "'></div><div class='col-lg-5'><div class='row no-margin cart_page_product_name'><span>" + Product.GetProductObj().GetProductName() + "</span><span class='cart_page_product_store_image_span'><img class='cart_page_product_store_image' src='/assets/" + Product.GetStoreObj().GetStoreLogo() + "'></span></div><div class='row no-margin cart_page_product_quantity'><span>Quantity : </span><span><b>" + Product.GetProductObj().GetProductQuantity() + "</b></span></div></div><div class='col-lg-5'><div class='row no-margin cart_page_product_price primary-color'>$ " + Product.GetPostTaxProductPrice() + "</div></div></div>";
                    }
                    if(OrderDetails.GetOrderDateAndStatusObj().GetStatus() == "Order_Created")
                    {
                        cancelOrderButton.Visible = true;
                        cancelOrderButton.InnerHtml = "<div onclick=CancelOrder(\'" + OrderID.ToString() + "\');>CANCEL ORDER</div>";
                    }
                    else
                    {
                        cancelOrderButton.Visible = false;
                    }
                   

                    cart_page_products_list.InnerHtml = HTMLContent;
                    txt_totalItems.Text = OrderDetails.GetComputedObj().GetTotalQuantity().ToString();
                    txt_totalUniqueItems.Text = OrderDetails.GetComputedObj().GetTotalUniqueQuantity().ToString();
                    txt_totalCost.Text = OrderDetails.GetComputedObj().GetTotalPreTaxProductPrice().ToString();
                    txt_totalTaxes.Text = OrderDetails.GetComputedObj().GetTotalTaxAmount().ToString();
                    txt_totalAmount.Text = OrderDetails.GetComputedObj().GetTotalPostTaxProductPrice().ToString();

                    txt_address_name.Text = OrderDetails.GetAddressObj().GetAddresstName();
                    txt_address_street.Text = OrderDetails.GetAddressObj().GetStreetName();
                    txt_address_appt.Text = OrderDetails.GetAddressObj().GetAptNum();
                    txt_address_province.Text = OrderDetails.GetAddressObj().GetCity() + " - " + OrderDetails.GetAddressObj().GetProvince();
                    txt_address_postalCode.Text = OrderDetails.GetAddressObj().GetPostalCode();

                    txt_card_name.Text = OrderDetails.GetCardDetails().GetName();
                    txt_card_last_4_digits.Text = OrderDetails.GetCardDetails().GetCardNumber().ToString().Substring(11, 5);

                    txt_order_time.Text = OrderDetails.GetOrderDateAndStatusObj().GetDate().ToString();
                }
                else
                {
                    order_invalid.Visible = true;
                    order_valid.Visible = false;
                    productsErrorPageheaderText.InnerText = "No order found.";
                }
            }
            else
            {
                Response.Redirect("/signout");
            }

        }
        catch (Exception)
        {
            order_invalid.Visible = true;
            order_valid.Visible = false;
            productsErrorPageheaderText.InnerText = "An error occured while processing the request, please try again later";
        }
    }


}