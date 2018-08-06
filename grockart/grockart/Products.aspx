<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/css/slick.css" rel="stylesheet" />
    <link href="assets/css/slick-theme.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="container">
        <div class="row col-lg-12">
            <div class="breadcrumbs">
                <span><a href="Default_home.aspx">HOME</a></span>
                <span>
                    <img src="assets/images/right-arrow.png" />
                </span>
                <span>Todays Best Deals</span>
            </div>
        </div>
        <div class="row col-lg-12 hideElement" id="productSearchBox">
            <div class="searchBox ">
                <span class="spanSearchIconProductPage">
                    <i class="material-icons">search</i>
                </span>
                <span class="spanSearchBox">
                    <input class="input-search" id="input-search" type="text" placeholder="Search Grocery" />
                </span>
            </div>
        </div>
        <div class="row col-lg-12 hideElement" id="productsPageSearch">
        </div>
        <div class="row col-lg-12 products-page" id="productsPage-lazyloader">
            <div class="row col-lg-12 item-header">
                <div class="item-header-loader">
                    <div class="inner-item-loader">
                    </div>
                </div>
            </div>
            <div class="row responsiveElement-lazyloader">
                <div>
                    <div class="items-box shadowAroundBox">
                        <div class="row product-header">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin height100px">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin mt10px">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin product-price">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="items-box shadowAroundBox">
                        <div class="row product-header">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin height100px">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin mt10px">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin product-price">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="items-box shadowAroundBox">
                        <div class="row product-header">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin height100px">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin mt10px">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin product-price">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="items-box shadowAroundBox">
                        <div class="row product-header">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin height100px">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin mt10px">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin product-price">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                        <div class="row no-margin">
                            <div class="item-header-loader center-margin">
                                <div class="inner-item-loader">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row col-lg-12 hideElement" id="productsErrorPage">
            <div class="text-center exception-image">
                <img src="../assets/images/logoWithoutText.png" class="exception-image-inner" />
            </div>
            <div class="text-center">
                <img class="exception-Grockart-image" src="../assets/images/Grockart_text.PNG" />
            </div>
            <div class="exception-header text-center" id="productsErrorPageheaderText">
            </div>
        </div>
        <div class="row col-lg-12 products-page " id="productsPage">
        </div>
    </div>
    <%--include carousel library--%>

    <script type="text/javascript" src="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>
    <script src="/assets/js/Products.js"></script>
   
    <script>
        RegisterProductSearch();
    </script>
</asp:Content>

