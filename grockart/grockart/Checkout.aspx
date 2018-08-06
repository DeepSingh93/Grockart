<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/css/slick.css" rel="stylesheet" />
    <link href="assets/css/slick-theme.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="checkout_background_hover_css hideElement" onclick="close_hover();" id="checkout_fixed_background">
    </div>
    <div class="checkout_background_hover_css hideElement" id="checkout_fixed_background_cart_update">
    </div>
    <div class="checkout_address_add_hover_outer hideElement" id="checkout_add_address_hover_finalize">
        <div class="checkout_address_add_hover_inner_finalize shadowAroundBox">
            <div class="linear-activity showLoader" id="cart_page_address_finalize_loader">
                <div class="indeterminate"></div>
            </div>
            <img class="checkout_address_add_hover_inner_finalize_img" src="assets/images/logoWithoutText.png" />
            <div class="checkout_address_add_hover_inner_finalize_text" id="checkout_address_add_hover_inner_finalize_text">
                YOUR CART IS UPDATING. PLEASE WAIT
            </div>
        </div>
    </div>
    <div class="checkout_address_add_hover_outer hideElement" id="checkout_add_card_hover">
        <div class="checkout_address_add_hover_inner shadowAroundBox" id="checkout_card_page_hover_text">
            <div class="linear-activity showLoader" id="cart_page_card_finalize_loader">
                <div class="indeterminate"></div>
            </div>
            <div class="cart_page_card_finalize_Add">
                <div class="row no-margin">
                    <div class="checkout_address_add_rows">
                        <input id="checkout_card_name" class="checkout_hover_box_input_values  checkout-field-validator-textbox  checkout-input-hover-validator" type="text" placeholder="Enter the name of the card holder" />
                    </div>
                    <div class="primary-admin-color checkout-field-validator" id="checkout_card_name_validator">
                        This field cannot be blank
                    </div>
                </div>
                <div class="row no-margin">
                    <div class="checkout_address_add_rows">
                        <input id="checkout_card_number" class="checkout_hover_box_input_values  checkout-field-validator-textbox  checkout-input-hover-validator" type="text" placeholder="Enter the card number (16 digit)" />
                    </div>
                    <div class="primary-admin-color checkout-field-validator" id="checkout_card_number_validator">
                        This field cannot be blank
                    </div>
                </div>
                <div class="row no-margin">
                    <div class="col-lg-4 pl0px">
                        <div class="checkout_address_add_rows">
                            <input id="checkout_expiry_month" class="checkout_hover_box_input_values  checkout-field-validator-textbox  checkout-input-hover-validator" type="text" placeholder="Expiry Month (MM)" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_expiry_month_validator">
                            This field cannot be blank
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="checkout_address_add_rows">
                            <input id="checkout_expiry_year" class="checkout_hover_box_input_values  checkout-field-validator-textbox  checkout-input-hover-validator" type="text" placeholder="Expiry Year (YY)" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_expiry_year_validator">
                            This field cannot be blank
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="checkout_address_add_rows">
                            <input id="checkout_expiry_cvv" class="checkout_hover_box_input_values  checkout-field-validator-textbox  checkout-input-hover-validator" type="text" placeholder="CVV" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_expiry_cvv_validator">
                            This field cannot be blank
                        </div>
                    </div>
                </div>
                <div class="checkout_address_add_rows checkout_address_add_address_text primary-color">
                    <span class="cursor-pointer primary-admin-color pr15px" onclick="return CancelCard();">CANCEL</span>
                    <span class="cursor-pointer" onclick="return CardInsert();">ADD CARD</span>
                </div>

            </div>
        </div>
    </div>
    <div class="checkout_address_add_hover_outer hideElement" id="checkout_add_address_hover">
        <div class=" ">
            <div class="checkout_address_add_hover_inner shadowAroundBox">
                <div class="linear-activity showLoader hideElement" id="cart_page_add_address_loader">
                    <div class="indeterminate"></div>
                </div>
                <div class="checkout_address_add_hover_inner_padding">
                    <div class="unableToAddAddress primary-admin-background-color color-white bold" id="unableToAddAddress" visible="false" runat="server">
                        Unable to add address this time, please try again later
                <div class="floatRight cursor-pointer" onclick="close_hover();">
                    <i class="material-icons">clear
                    </i>
                </div>
                    </div>
                    <div id="AbleToAddAddress" runat="server">
                        <div class="checkout_address_add_header">
                            Add Address
                            <div class="floatRight cursor-pointer" onclick="close_hover();">
                                <i class="material-icons">clear
                                </i>
                            </div>
                        </div>
                        <div>
                            Please enter your address
                        </div>
                        <div class="checkout_address_add_rows">
                            <input id="checkout_name" class="checkout_hover_box_input_values  checkout-field-validator-textbox  checkout-input-hover-validator" type="text" placeholder="Enter the name of the address (Example : Deep Singh Home Address)" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_name_validator">
                            This field cannot be blank
                        </div>
                        <div class="checkout_address_add_rows">
                            <input id="checkout_street_name" class="checkout_hover_box_input_values  checkout-field-validator-textbox " type="text" placeholder="Enter the street name" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_street_name_validator">
                            This field cannot be blank
                        </div>
                        <div class="checkout_address_add_rows">
                            <input id="checkout_appt_number" class="checkout_hover_box_input_values checkout-field-validator-textbox " type="text" placeholder="Enter the appartment number" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_appt_number_validator">
                            This field cannot be blank
                        </div>
                        <div class="checkout_address_add_rows">
                            <input id="checkout_postal_code" class="checkout_hover_box_input_values checkout-field-validator-textbox " type="text" placeholder="Enter the postal code (A0A 0A0)" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_postal_code_validator">
                            This field cannot be blank
                        </div>
                        <div class="checkout_address_add_rows">
                            <input id="checkout_phone_number" class="checkout_hover_box_input_values checkout-field-validator-textbox " type="text" placeholder="Enter the phone number (10 digit integers)" />
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="checkout_phone_number_validator">
                            This field cannot be blank
                        </div>
                        <div class="checkout_address_add_rows">
                            <select class="checkout_hover_box_input_values  checkout-field-validator-ddl" onchange="populateCity();" id="ddl_province" runat="server"></select>
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="ddl_province_validator">
                            Please select a valid province
                        </div>
                        <div class="checkout_address_add_rows">
                            <select class="checkout_hover_box_input_values checkout-field-validator-ddl" id="ddl_city" runat="server"></select>
                        </div>
                        <div class="primary-admin-color checkout-field-validator" id="ddl_city_validator">
                            Please select a valid city
                        </div>
                        <div class="checkout_address_add_rows checkout_address_add_address_text primary-color">
                            <span class="cursor-pointer" onclick="return AddAddress();">ADD ADDRESS</span>
                        </div>
                    </div>
                </div>
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
                <span><a href="/orders">My Orders</a></span>
                <span>
                    <img src="/assets/images/right-arrow.png" />
                </span>
                <span>Order</span>
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
    <div class="container">
        <div id="cart_page_warn" class="row col-lg-12 no-margin primary-admin-background-color hideElement">
            <div>
            </div>
        </div>
    </div>
    <div class="container hideElement" id="cart_page_notEmptyCart">

        <div class="checkout_header">
            Your Items
        </div>
        <div class="linear-activity showLoader" id="cart_page_loader_above_box">
            <div class="indeterminate"></div>
        </div>
        <div id="cart_page_products_list" class="row no-margin col-lg-12 shadowAroundBox checkout_page_product_list">
        </div>
        <div>
            <div class="cart_stats" id="checkout_total_item_count">
                Total Item count : <span id="totalItems"></span>
            </div>
            <div class="cart_stats" id="checkout_total_unique_item_count">
                Total Unique Item(s) : <span id="totalUniqueItems"></span>
            </div>
            <div class="cart_taxes" id="checkout_total_item_cost">
                Total Item Cost : <span id="totalCost"></span>
            </div>
            <div class="cart_taxes" id="cart_taxes">
                Taxes : -
            </div>
            <div class="cart_total_amount">
                Total Amount : <span id="totalAmount"></span>
            </div>

        </div>
        <div class="checkout_header">
            Your Address
        </div>
        <div class=" col-lg-12 no-padding checkout_address_loader" id="checkout_address_loader">
            <div class="row no-margin addressBoxList">
                <div class="addressBox_loader"></div>
                <div class="col-lg-3  addressBox_outer">
                    <div class="addressBox_inner shadowAroundBox">
                        <div class="row no-margin">
                            <div class="col-lg-12">
                                <div class="checkout_address_loader_row">
                                </div>
                                <div class="checkout_address_loader_row">
                                </div>
                                <div class="checkout_address_loader_row">
                                </div>
                                <div class="checkout_address_loader_row">
                                </div>
                                <div class="checkout_address_loader_row">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="checkout_page_address_list" class="col-lg-12 no-padding">
        </div>
        <div id="checkout_page_card_list" class="checkout_header">
            Your Card Details
        </div>
        <div class=" col-lg-12 no-padding checkout_address_loader" id="checkout_card_loader">
            <div class="row no-margin addressBoxList">
                <div class="addressBox_loader"></div>
                <div class="col-lg-3  addressBox_outer">
                    <div class="addressBox_inner shadowAroundBox">
                        <div class="row no-margin">
                            <div class="col-lg-12">
                                <div class="checkout_address_loader_row">
                                </div>
                                <div class="checkout_address_loader_row">
                                </div>
                                <div class="checkout_address_loader_row">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="checkout_page_card_list_results" class="col-lg-12 no-padding">
        </div>

    </div>
    <div>
        <div class="primary-background-color checkout_placeorder_button hideElement" onclick="InitiateOrderPipeline();">Place Order</div>
    </div>
    <script src="assets/js/checkout.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.js"></script>
    <input type="hidden" id="REGEX_POSTAL_CODE" runat="server" />
</asp:Content>

