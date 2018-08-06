<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPageName" runat="Server">
    Admin Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="admin_general_Settings_header">
        ADMIN MANAGEMENT
    </div>
    <div id="notificationArea" class="shadowAroundBox admin-management-notification hideElement">
        Unable to fetch the data this time.
    </div>
    <div class="searchBox shadowAroundBox MB20">
        <span class="spanSearchIconProductPage">
            <i class="material-icons">search</i>
        </span>
        <span class="spanSearchBox">
            <input class="input-search" id="admin-search-users" type="text" placeholder="Search Users (by email or by firstname or by keywords without spaces)">
        </span>
    </div>
    <div id="">
        <div class="admin-content-area shadowBox MB20 hideElement" id="admin-user-list-area">
            <div id="admin-management-user-list-loader-area">
                <div class="row admin-names admin-loader">
                    <div class="admin-overflow-loader">
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                </div>
                <div class="row admin-names">
                    <div class="admin-overflow-loader">
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                </div>
                <div class="row admin-names">
                    <div class="admin-overflow-loader">
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                </div>
            </div>
            <div id="admin-management-user-list-results-area" class="hideElement">
                <div class="row admin-names">
                    <div class="col-lg-6">
                        <div class="bold">Name</div>
                        <div class="fs10">Email ID</div>
                        <div class="primary-background-color primary-white removeAdminBox text-center">ADD ADMIN</div>
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">Name</div>
                        <div class="fs10">Email ID</div>
                        <div class="warning-background-color primary-white removeAdminBox text-center">REMOVE ADMIN</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="linear-activity showLoader adminLoader-background-color" id="loginPageLoader">
            <div class="indeterminate adminLoader-background-color-intermediate"></div>
        </div>
        <div class="admin-content-area shadowBox" id="admin-result-area-01">

            <div id="admin-management-loader-area">
                <div class="row admin-names admin-loader">
                    <div class="admin-overflow-loader">
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                </div>
                <div class="row admin-names">
                    <div class="admin-overflow-loader">
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                </div>
                <div class="row admin-names">
                    <div class="admin-overflow-loader">
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                    <div class="col-lg-6">
                        <div class="bold">
                            <div class="loader-names"></div>
                        </div>
                        <div class="fs10">
                            <div class="loader-names"></div>
                        </div>
                        <div class="loader-names loader-button"></div>
                    </div>
                </div>
            </div>

            <div id="admin-management-results-area" class="hideElement">
            </div>
        </div>
    </div>
    <script>
        GetAdminList();
        RegisterSearch();
    </script>
</asp:Content>

