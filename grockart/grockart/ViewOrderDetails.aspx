<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="ViewOrderDetails.aspx.cs" Inherits="ViewOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" runat="server" id="order_invalid">
        <div class="row col-lg-12">
            <div class="text-center exception-image">
                <img src="../assets/images/logoWithoutText.png" class="exception-image-inner" />
            </div>
            <div class="text-center">
                <img class="exception-Grockart-image" src="../assets/images/Grockart_text.PNG" />
            </div>
            <div class="exception-header text-center" id="productsErrorPageheaderText" runat="server">
                Cart is empty
            </div>
        </div>
    </div>
    <div class="container" runat="server" id="order_valid">
        <div class="container" id="resultsTable" runat="server">
            <div class="row col-lg-12">
                <div class="breadcrumbs">
                    <span><a href="/">HOME</a></span>
                    <span>
                        <img src="/assets/images/right-arrow.png" />
                    </span>
                    <span><a href="/Orders">My Orders</a></span>
                    <span>
                        <img src="/assets/images/right-arrow.png" />
                    </span>
                    <span>Order #<asp:Label ID="OrderLabel" runat="server" Text="Label"></asp:Label></span>
                </div>
            </div>
        </div>
        <div>
            <div class="checkout_background_hover_css hideElement" id="checkout_fixed_background_cart_update">
            </div>
            <div class="checkout_address_add_hover_outer hideElement" id="checkout_add_address_hover_finalize">
                <div class="checkout_address_add_hover_inner_finalize shadowAroundBox">
                    <div class="linear-activity showLoader" id="cart_page_address_finalize_loader">
                        <div class="indeterminate"></div>
                    </div>
                    <img class="checkout_address_add_hover_inner_finalize_img" src="/assets/images/logoWithoutText.png" />
                    <div class="checkout_address_add_hover_inner_finalize_text" id="checkout_address_add_hover_inner_finalize_text">
                        YOUR ORDER IS UPDATING. PLEASE WAIT
                    </div>
                </div>
            </div>
            <div class="container">

                <div class="col-lg-12 loginBoxImage">
                    <img src="/assets/images/logoWithoutText.png">
                </div>
                <div class="col-lg-10 no-padding col-lg-offset-1 loginBox">
                    <div class="linear-activity showLoader hideElement" id="loginPageLoader">
                        <div class="indeterminate"></div>
                    </div>
                    <div class="row loginBoxText">
                        Your Order Details
                    </div>
                    <div class="primary-background-color statusColor">
                        <asp:Label ID="txt_status" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="p10px">

                        <div id="OrderPlacedSuccessfully" runat="server" class="vieworderdetails_successful_ordertext">
                            YOUR ORDER HAS BEEN PLACED SUCCESSFULLY
                        </div>
                        <div class="vieworderdetails_successful_orderdetails">
                            <div>
                                ORDER NUMBER :
                    <asp:Label ID="txt_ordernumber" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div>
                                ORDER PLACED TIME :
                    <asp:Label ID="txt_order_time" CssClass="primary-admin-color" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="checkout_header">
                            Your Items
                        </div>
                        <div id="orderProducts" class="row no-margin" runat="server">
                            <div id='cart_page_products_list' runat="server" class='row no-margin col-lg-12 shadowAroundBox checkout_page_product_list'>
                            </div>
                            <div>
                                <div class="cart_stats" id="checkout_total_item_count">
                                    Total Item count : <span id="totalItems">
                                        <asp:Label ID="txt_totalItems" runat="server" Text="Label"></asp:Label></span>
                                </div>
                                <div class="cart_stats" id="checkout_total_unique_item_count">
                                    Total Unique Item(s) : <span id="totalUniqueItems">
                                        <asp:Label ID="txt_totalUniqueItems" runat="server" Text="Label"></asp:Label></span>
                                </div>
                                <div class="cart_taxes" id="checkout_total_item_cost">
                                    Total Item Cost : <span id="totalCost">$
                            <asp:Label ID="txt_totalCost" runat="server" Text="Label"></asp:Label></span>
                                </div>
                                <div class="cart_taxes" id="cart_taxes">
                                    Taxes :
                        <asp:Label ID="txt_totalTaxes" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="cart_total_amount">
                                    Total Amount : <span id="totalAmount">$
                            <asp:Label ID="txt_totalAmount" runat="server" Text="Label"></asp:Label></span>
                                </div>
                            </div>
                        </div>
                        <div class="checkout_header">
                            Your Address where it will be delivered
                        </div>
                        <div class="row no-margin">
                            <div class="col-lg-12 no-padding addressBox_outer">
                                <div class="addressBox_inner shadowAroundBox ">
                                    <div class="row no-margin">
                                        <div class="col-lg-12">
                                            <div class="checkout_address_row_name">
                                                <asp:Label ID="txt_address_name" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="checkout_street_row_name">
                                                <asp:Label ID="txt_address_street" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="checkout_appt_row_name">
                                                <asp:Label ID="txt_address_appt" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="checkout_province">
                                                <asp:Label ID="txt_address_province" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="checkout_province">
                                                <asp:Label ID="txt_address_postalCode" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="checkout_header">
                            Your Card details
                        </div>
                        <div class="row no-margin">
                            <div class="col-lg-12 no-padding addressBox_outer">
                                <div class="addressBox_inner shadowAroundBox " id="cardBOX_5">
                                    <div class="row no-margin">
                                        <div class="col-lg-12">
                                            <div class="checkout_address_row_name">
                                                <asp:Label ID="txt_card_name" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="checkout_street_row_name">
                                                **** 
                                    <asp:Label ID="txt_card_last_4_digits" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="primary-admin-background-color order_details_cancel" id="cancelOrderButton" runat="server">
                                CANCEL ORDER
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="/assets/js/Orders.js"></script>
</asp:Content>

