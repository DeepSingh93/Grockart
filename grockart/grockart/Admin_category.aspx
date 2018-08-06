<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_category.aspx.cs" Inherits="Admin_category" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPageName" runat="Server">
    Category Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="admin_general_Settings_header">
        CATEGORY MANAGEMENT
    </div>
    <div class="modifyCategoryBackground hideElement" id="admin_modifyBackground" onclick="admin_hide_modifyCategory()">
    </div>
    <div class="modifyCategoryBackgroundContent shadowBox hideElement" id="admin_modifyContainer">
        <div class="linear-activity showLoader adminLoader-background-color" id="admin_modifyCategoryBox">
            <div class="indeterminate adminLoader-background-color-intermediate"></div>
        </div>
        <div class="primary-admin-background-color text-center bold color-white p5px hideElement" id="admin_modifyErrorMessage">
            Unable to modify category, please check logs
        </div>
        <div class="p10px">
            <div class="primary-admin-color bold">
                MODIFY CATEGORY
            </div>
            <div class="pb10px pt10px">
                <span class="">Category ID : 
                </span>
                <span class="bold" id="admin_category_categoryID"></span>
            </div>
            <div class="pb10px">
                <span class="">Category Name : 
                </span>
                <span class="bold" id="admin_category_categoryName"></span>
            </div>
            <div>
                <span class="">New Category Name : 
                </span>
                <span class="bold">
                    <input id="newCategoryName" class="admin-category-modify-input-text" value="" placeholder="Enter new category name" />
                </span>
            </div>
            <div class="admin-modify-category-controls ">
                <span class="primary-admin-color bold admin-modify-category-modify-text" onclick="admin_confirm_modifyCategory()">MODIFY CATEGORY
                </span>
                <span class="bold admin-modify-category-modify-text" onclick="admin_hide_modifyCategory()">CANCEL
                </span>
            </div>
        </div>
    </div>
    <div id="notificationArea" class="shadowAroundBox admin-management-notification hideElement">
        Unable to fetch the data this time.
    </div>
    <div id="resultsLoader">
        <div class="admin-results-loader" id="admin-category-loader-area">
            <div class="linear-activity showLoader adminLoader-background-color" id="loginPageLoader">
                <div class="indeterminate adminLoader-background-color-intermediate"></div>
            </div>
            <div class="admin-content-area shadowBox" id="admin-result-area-01">
                <div id="admin-management-loader-area">
                    <div class="row admin-names admin-loader">
                        <div class="admin-overflow-loader" style="height: 115px;">
                        </div>
                        <div class="col-lg-6">
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
                        <div class="col-lg-3">
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
                        <div class="col-lg-3">
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
    <div id="results" class="hideElement">
        <div class="admin-results-loader" id="admin-category-results-area">
            <div class="shadowBox">
                <div class="linear-activity showLoader adminLoader-background-color hideElement" id="Add-Category-Loader">
                    <div class="indeterminate adminLoader-background-color-intermediate"></div>
                </div>
                <div class="bold admin-content-area ">
                    Add Category
                    <div class="row">
                        <div class="col-lg-10">
                            <input class="admin-category-input-text" id="TxtCategoryName" type="text" />
                        </div>
                        <div class="col-lg-2 admin-add-category" onclick="AddCategory();">
                            ADD CATEGORY
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="admin-category-results-area-content" class="admin-content-area shadowBox content">
        </div>
    </div>
    <script>
        FetchCategory();
    </script>
</asp:Content>

