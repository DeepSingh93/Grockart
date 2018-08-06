<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_product.aspx.cs" Inherits="Admin_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPageName" Runat="Server">
    Product Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="admin_general_Settings_header">
        PRODUCT MANAGEMENT
    </div>
    <div id="notificationArea" runat="server" class="shadowAroundBox admin-management-notification hideElement">
        Unable to fetch the data this time.
    </div>
    <div id="resultsLoader">
        <div class="admin-results-loader" id="admin-store-loader-area">
            <div class="linear-activity showLoader adminLoader-background-color" id="loginPageLoader">
                <div class="indeterminate adminLoader-background-color-intermediate"></div>
            </div>
            <div class="admin-content-area shadowBox" id="admin-result-area-01">
                <div id="admin-management-loader-area">
                    <div class="row admin-names admin-loader">
                        <div class="admin-overflow-loader" style="height: 115px;">
                        </div>
                        <div class="col-lg-4">
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                            <div class="fs10">
                                <div class="loader-names"></div>
                            </div>
                            <div class="bold">
                                <div class="loader-names"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modifyCategoryBackground hideElement" id="admin_modifyBackground" onclick="admin_hide_modifyCategory()">
    </div>
    <div class="modifyCategoryBackgroundContent shadowBox hideElement" id="admin_modifyContainer" style="margin-top: 100px;">
        <div class="linear-activity showLoader adminLoader-background-color" id="admin_modifystoreBox">
            <div class="indeterminate adminLoader-background-color-intermediate"></div>
        </div>
        <div class="primary-admin-background-color text-center bold color-white p5px hideElement" id="admin_modifyErrorMessage">
            Unable to modify Store, please check logs
        </div>
        <div class="p10px">
            <div class="primary-admin-color bold">
                MODIFY PRODUCT
            </div>
            <div class="pb10px pt10px">
                <span class="">Product ID : 
                </span>
                <span class="bold" id="admin_store_ProductID"></span>
            </div>
            <div class="pb10px">
                <span class="">Product Name : 
                </span>
                <span class="bold" id="admin_store_ProductName"></span>
            </div>
            <div class="pb10px">
                <span class="">Product Image : 
                </span>
                <span class="bold" id="admin_store_productImage"></span>
            </div>
            <div class="pb10px">
                <span class="">New Product Name : 
                </span>
                <span class="bold">
                    <input id="newProductName" class="admin-product-modify-input-text" value="" placeholder="Enter new product name" />
                </span>
            </div>
            <div class="pb10px">
                <span class="">New Product Image : 
                </span>
                <span class="bold">
                    <asp:FileUpload ID="ModifyProductImage" runat="server" />
                </span>
            </div>
            <div class="admin-modify-store-controls pb10px">
                <span class="primary-admin-color bold admin-modify-category-modify-text" onclick="admin_confirm_productstore()">MODIFY PRODUCT
                </span>
                <span class="bold admin-modify-category-modify-text" onclick="admin_hide_modifyproduct()">CANCEL
                </span>
            </div>
        </div>
    </div>
    <div id="admin-stores-results-area-content">
        <div id="admin-stores-results-area-content_ADDProduct" class="admin-content-area shadowBox content ">
            <div class="bold primary-admin-color p5px">
                Add Product
            </div>
            <div class="p5px">
                <span>Product Name : 
                </span>
                <span>
                    <asp:TextBox CssClass="admin-store-modify-input-text bold" ID="txt_ProductName" runat="server"></asp:TextBox>
                </span>
            </div>
            <div class="p5px">
                <span>Product Image : 
                </span>
                <span>
                    <asp:FileUpload ID="ProductImageAdminHOME" runat="server" />
                </span>
            </div>
            <div class="bold primary-admin-color p5px">
                <asp:Button ID="btn_AddProduct" class="addBtnAdmin shadowAroundBox" runat="server" Text="Add Product" />
            </div>
        </div>
        <div id="admin-stores-results-area-content_Results" class="admin-content-area shadowBox content">
        </div>
    </div>

    <input type="hidden" value="" id="ModifyStoreLogoName_Old" />
    <input type="hidden" value="" id="ModifyStoreName_Old_01" />
    <script>
        fetchProducts();
    </script>
</asp:Content>

