<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" ClientIDMode="Static" AutoEventWireup="true" CodeFile="ParticularProduct.aspx.cs" Inherits="ParticularProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" id="ErrorProduct" runat="server">
        <div class="row col-lg-12">
            <div class="text-center exception-image">
                <img src="../assets/images/logoWithoutText.png" class="exception-image-inner" />
            </div>
            <div class="text-center">
                <img class="exception-Grockart-image" src="../assets/images/Grockart_text.PNG" />
            </div>
            <div class="exception-header text-center" id="productsErrorPageheaderText">
                Product not found
            </div>
        </div>
    </div>
    <div class="container" id="resultsTable" runat="server">
        <div class="row col-lg-12">
            <div class="breadcrumbs">
                <span><a href="/">HOME</a></span>
                <span>
                    <img src="/assets/images/right-arrow.png" />
                </span>
                <span><a href="/Products">PRODUCTS</a></span>
                <span>
                    <img src="/assets/images/right-arrow.png" />
                </span>
                <span id="ProductResult" runat="server"></span>
                <span>
                    <img src="/assets/images/right-arrow.png" />
                </span>
                <span id="Breadcrumb_Product_Name" runat="server">Apple</span>
            </div>
        </div>
        <div class="col-lg-12 shadowAroundBox resultBox">
            <div class="col-lg-5 text-center" id="ProductImage" runat="server">
                <img class="productImage" src="/assets/images/apple.png" />
            </div>
            <div class="col-lg-7">
                <div class="ProductNameClass" id="ProductName" runat="server">
                </div>
                <div class="ProductPriceClass" runat="server" id="ProductPriceClass">
                </div>
                <div id="OutOfStockLabel" class="outofstocklabel" runat="server">
                    OUT OF STOCK
                </div>
                <div id="NotOutOfStockLabel" runat="server">
                    <div class="ProductQtyClass">
                        <span>Quantity
                        </span>
                        <span class="ProductPriceClass" id="ProductQuantityDropdown" runat="server"></span>
                    </div>
                    <div class="ProductActionClass" id="ProductButtons" runat="server">
                    </div>
                </div>
                <div id="OtherStores" runat="server">
                    <div class="bold">
                        PRICES FROM OTHER STORES
                    </div>
                    <div id="OtherStoresProducts" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </div>
 
</asp:Content>

