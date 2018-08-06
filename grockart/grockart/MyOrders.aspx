<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row col-lg-12">
            <div class="breadcrumbs">
                <span><a href="Default_home.aspx">HOME</a></span>
                <span>
                    <img src="assets/images/right-arrow.png" />
                </span>
                <span>Orders</span>
            </div>
        </div>
    </div>
    <div class="container myorders_heading">
        YOUR ORDERS
    </div>
    <div class="container">
        <div class="shadowAroundBox myorders_box_container">
            <div class="orders_heading">
                <span class="orders_heading orders_text_selected" id="myorders_individual_heading" onclick="SetIndividualOrders();">INDIVIDUAL ORDERS
                </span>
                <span class="orders_heading" id="myorders_group_heading" onclick="SetGroupOrders();">GROUP ORDERS
                </span>
            </div>
            <div class="orders_subheading">
                <span class="orders_heading orders_text_selected" id="order_all_orders_sub_heading" onclick="LoadAllOrders();">ALL
                </span>
                <span class="orders_heading" id="orders_placed_orders_sub_heading" onclick="loadOrderPlacedOrders();">ORDER PLACED
                </span>
                <span class="orders_heading" id="orders_cancelled_orders_sub_heading" onclick="loadCancelledOrders();">CANCELLED
                </span>
                <span class="orders_heading" id="orders_shipped_orders_sub_heading" onclick="loadShippedOrders();">SHIPPED
                </span>
            </div>
            <div class="orders_details">
                <div class="shadowAroundBox order_details_row" id="MyOrder_details_loader">
                    <div class="order-overflow-loader">
                    </div>
                    <div class="row no-margin superStoreRow superStoreRowLoader">
                        <div class="col-lg-12 orders_loader_background ">
                        </div>
                    </div>
                    <div class="row no-margin order_details_order_fulldetails">
                        <div class="col-lg-6 no-padding">
                            <div class="row no-margin orders_loader_background">
                            </div>
                            <div class="row no-margin orders_loader_background">
                            </div>
                            <div class="row no-margin orders_loader_background">
                            </div>
                            <div class="row no-margin orders_loader_background">
                            </div>
                        </div>
                        <div class="col-lg-3 text-center">
                            <div class="row no-margin order_details_row_status">
                                <div class="row no-margin orders_loader_background">
                                </div>
                            </div>
                            <div class="row no-margin order_details_row_status primary-admin-color">
                                <div class="row no-margin orders_loader_background">
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 no-margin">
                            <div class="row no-margin orders_loader_background">
                            </div>
                            <div class="row no-margin orders_loader_background">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="MyOrder_details_Result" class="hideElement">
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            CurrentORDERType == 'INDIVIDUAL';
            LoadAllOrders();
        })

    </script>
    <script src="/assets/js/Orders.js"></script>
</asp:Content>

