<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container" id="resultsTable" runat="server">
        <div class="row col-lg-12">
            <div class="breadcrumbs">
                <span><a href="/">HOME</a></span>
                <span>
                    <img src="/assets/images/right-arrow.png" />
                </span>
                <span>Cart</span>
            </div>
        </div>
    </div>
    <div class="container " id="cart_page_loader">
        <div class="row no-margin mt10px col-lg-12 shadowAroundBox">
            <div class="cart_page_loader_highlighter"></div>
            <div class="col-lg-2 text-center no-margin">
                <div class="cart_page_loader_image">
                </div>
            </div>
            <div class="col-lg-7">
                <div class="row no-margin cart_page_product_name">
                    <div class="cart_page_loader_text"></div>
                </div>
                <div class="row no-margin cart_page_product_name">
                    <div class="cart_page_loader_text"></div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="row no-margin cart_page_product_name">
                    <div class="cart_page_loader_text"></div>
                </div>
                <div class="row no-margin cart_page_product_name">
                    <div class="cart_page_loader_text"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="container hideElement" id="cart_page_emptyCart">
        <div class="row col-lg-12">
            <div class="text-center exception-image">
                <img src="../assets/images/logoWithoutText.png" class="exception-image-inner" />
            </div>
            <div class="text-center">
                <img class="exception-Grockart-image" src="../assets/images/Grockart_text.PNG" />
            </div>
            <div class="exception-header text-center" id="productsErrorPageheaderText">
                Cart is empty
            </div>
        </div>
    </div>
    <div class="container hideElement" id="cart_page_notEmptyCart">
        <div class="cart_page_clear_all primary-admin-color">
            <div onclick="ClearCart()" class="cursor-pointer">
                CLEAR ALL
            </div>
        </div>
        <div class="linear-activity showLoader" id="cart_page_loader_above_box">
            <div class="indeterminate"></div>
        </div>
        <div id="cart_page_warn" class="row col-lg-12 no-margin primary-admin-background-color">
            <div>
            </div>
        </div>
        <div id="cart_page_products_list" class="row no-margin col-lg-12 shadowAroundBox">
        </div>
        <div class="row col-lg-12" id="cart_page_buttons">
         
            <div class="col-lg-12">
                <div class="cart_page_checkout primary-background-color" onclick="RedirectToCheckout();" id="cart_page_checkout">
                    CHECK OUT
                </div>
            </div>
        </div>
    </div>
    <script>
        $('#master_cart').addClass('hideElement');
        $('#userProfile').removeClass('col-lg-8').addClass('col-lg-12');
        $('.MasterProfile').css('left', '38px');
        $(document).ready(function () {
            LoadCartFromCartPage();
            OnCartPage = true;
        });
    </script>
</asp:Content>

