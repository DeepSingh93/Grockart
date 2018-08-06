ChangesToCart = true;
OnCartPage = false;
CurrentORDERType = 'INDIVIDUAL';
function AddToCart(e, product, object) {
    var evt = e ? e : window.event;
    if (evt.stopPropagation) evt.stopPropagation();
    if (evt.cancelBubble != null) evt.cancelBubble = true;
    let PreviousStateHTML = $('#' + object.id).html();
    $('#' + object.id).html("<div class='loader-cart'></div>");

    $.ajax({
        url: '/api/AddToCart.aspx',
        method: 'POST',
        data: { 'pbsid': object.id.split('_')[1] },
        cache: false,
        success: function (parameter) {
            console.log(parameter);

            let data = JSON.parse(parameter);
            if (data.Response == 'OK') {
                ChangesToCart = true;
                LoadCart();
            } else {
                $('#cart_warn_status').html(data.ResponseString);
                $('#cart_warn_status').removeClass('hideElement');
            }
            $('#master_page_CART').slideDown('fast');
            $('#' + object.id).html(PreviousStateHTML);
        }
    });
}

$(document).ready(function () {
    LoadCart();
    ChangesToCart = true;
});

function UpdateCartValues() {
    ChangesToCart = true;
}

function LoadCart() {
    console.log('Loading cart');
    if (!OnCartPage) {
        if (ChangesToCart == true) {
            $('#cart_warn_status').addClass('hideElement');
            $('#cartLoader').removeClass('hideElement')
            $('#cart__status').val('UPDATING CART');
            $('#cart__status').removeClass('hideElement')
            $.ajax({
                url: '/api/GetCart.aspx',
                method: 'GET',
                cache: false,
                success: function (parameter) {
                    HTMLString = "";
                    ChangesToCart = false;
                    $('#cartLoader').addClass('hideElement')
                    let data = JSON.parse(parameter);
                    let Cart = JSON.parse(data.Cart).CartItems;
                    console.log(data);
                    console.log(Cart);
                    if (data.Response == 'OK') {
                        $('#cart__status').addClass('hideElement')
                        if (JSON.parse(data.Cart).HasValidationErrors == true) {
                            $('#cart_warn_status').html("SOME ITEMS ARE OUT OF STOCK/UNAVAILABLE, PLEASE CHECK YOUR CART");
                            $('#cart_warn_status').removeClass('hideElement');
                            $('#Master_MENU_Checkout').addClass('checkout-disabled');
                            $('#Master_MENU_Checkout').prop("onclick", null);
                        } else {
                            $('#cart_warn_status').addClass('hideElement');
                            $('#Master_MENU_Checkout').removeClass('checkout-disabled');
                            $('#Master_MENU_Checkout').click(function () {
                                window.location.href = '/Cart';
                            });
                        }
                        if (data.Quantity == 0) {
                            $('#emptyCartMenu').removeClass('hideElement')
                            $('#notEmptyCartMenu').addClass('hideElement')
                        } else {

                            for (ProductIndex in Cart) {
                                HTMLTOAdd = "";
                                if (Cart[ProductIndex].HasQuantity) {
                                    HTMLTOAdd = '<div class="row no-margin p10px cart-menu-item">';
                                } else {
                                    HTMLTOAdd = '<div class="row no-margin p10px cart-warning">';
                                }
                                HTMLTOAdd +=
                                    '<div class="col-lg-5">' +
                                    '<img class="cart-product-img" src="/assets/' + Cart[ProductIndex].ProductObj.ProductImage + '" />' +
                                    '</div>' +
                                    '<div class="col-lg-7">' +
                                    '<div class="cart-product-name bold">' +
                                    Cart[ProductIndex].ProductObj.ProductName +
                                    '</div>' +
                                    '<div>' +
                                    '<img class="store-cart-img" src="/assets/' + Cart[ProductIndex].ProductObj.StoreLogo + '" />' +
                                    '</div>';

                                if (Cart[ProductIndex].HasQuantity) {
                                    HTMLTOAdd +=
                                        '<div class="p5px pl0px">' +
                                        '<select id="cart_' + Cart[ProductIndex].ProductObj.pbsID + '" class="item-count">' +
                                        GenerateDropdownQTY(Cart[ProductIndex].DBQuantity, Cart[ProductIndex].ProductObj.Quantity) +
                                        '</select>' +
                                        '</div>' +
                                        '<div class="no-margin">' +
                                        '<div class="col-lg-6 text-left no-padding bold primary-color cart-update" onclick="UpdateCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">UPDATE</div>' +
                                        '<div class="col-lg-6 text-left no-padding bold primary-admin-color cart-delete" onclick="DeleteCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">DELETE</div>' +
                                        '</div>';

                                } else {
                                    if (Cart[ProductIndex].DBQuantity <= 0) {
                                        HTMLTOAdd +=
                                            '<div class="p5px pl0px row no-margin">' +
                                            '<div class="text-center no-padding bold primary-admin-background-color text-center p5px color-white">OUT OF STOCK</div>' +
                                            '</div>' +
                                            '<div class="no-margin row">' +
                                            '<div class="col-lg-6 text-left no-padding bold primary-admin-color cart-delete" onclick="DeleteCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">DELETE</div>' +
                                            '</div>';
                                    } else {
                                        HTMLTOAdd +=
                                            '<div class="p5px pl0px"> <div class="row no-margin cart-qty-not-available"> Quantity is not available, please reselect the quantity </div>' +
                                            '<select id="cart_' + Cart[ProductIndex].ProductObj.pbsID + '" class="item-count">' +
                                            GenerateDropdownQTY(Cart[ProductIndex].DBQuantity, 1) +
                                            '</select>' +
                                            '</div>' +
                                            '<div class="no-margin">' +
                                            '<div class="col-lg-6 text-left no-padding bold primary-color cart-update" onclick="UpdateCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">UPDATE</div>' +
                                            '<div class="col-lg-6 text-left no-padding bold primary-admin-color cart-delete" onclick="DeleteCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">DELETE</div>' +
                                            '</div>';
                                    }

                                }
                                HTMLTOAdd += '</div></div>';
                                HTMLString = HTMLTOAdd + HTMLString;

                            }
                            $('#Cart_Master_ITEMS').html(HTMLString);
                            $('#emptyCartMenu').addClass('hideElement')
                            $('#notEmptyCartMenu').removeClass('hideElement')
                        }
                    } else {
                        $('#cart__status').html('UNABLE TO UPDATE THE CART');
                    }
                }
            });
        }
    }

}

function UpdateCart(value) {
    $('#cart_warn_status').addClass('hideElement');
    $('#cartLoader').removeClass('hideElement');
    $('#cart__status').val('UPDATING CART');

    $('#cart__status').removeClass('hideElement');
    if (OnCartPage) {
        $('#cart_page_loader_above_box').removeClass('hideElement');
    }
    $.ajax({
        url: '/api/ModifyCart.aspx',
        method: 'POST',
        data: { 'pbsid': value, 'qty': $('#cart_' + value).val() },
        cache: false,
        success: function (parameter) {

            let data = JSON.parse(parameter);
            console.log(data);
            $('#master_page_CART').slideDown('fast');
            if (data.Response == 'OK') {
                ChangesToCart = true;
                LoadCart();
            } else {
                $('#cartLoader').addClass('hideElement')
                $('#cart_warn_status').html(data.ResponseString);
                $('#cart_warn_status').removeClass('hideElement');
            }
            if (OnCartPage) {
                if (data.Response == 'OK') {
                    LoadCartFromCartPage();
                } else {
                    $('#cart_page_warn').html(data.ResponseString);
                    $('#cart_page_warn').removeClass('hideElement');
                }
            }
        }
    });
}

function ClearCart() {
    $('#cart_warn_status').addClass('hideElement');
    $('#cartLoader').removeClass('hideElement')
    $('#cart__status').val('UPDATING CART');
    $('#cart__status').removeClass('hideElement');
    if (OnCartPage) {
        $('#cart_page_loader_above_box').removeClass('hideElement');
    }
    $.ajax({
        url: '/api/ClearCart.aspx',
        method: 'POST',
        cache: false,
        success: function (parameter) {
            data = JSON.parse(parameter);
            console.log(data.Response);
            if (data.Response == 'OK') {
                ChangesToCart = true;
                LoadCart();
            } else {
                $('#cartLoader').addClass('hideElement')
                $('#cart_warn_status').html(data.ResponseString);
                $('#cart_warn_status').removeClass('hideElement');
            }
            if (OnCartPage) {
                if (data.Response == 'OK') {
                    LoadCartFromCartPage();
                } else {
                    $('#cart_page_warn').html(data.ResponseString);
                    $('#cart_page_warn').removeClass('hideElement');
                }
            }
        }
    });
}

function DeleteCart(value) {
    $('#cart_warn_status').addClass('hideElement');
    $('#cartLoader').removeClass('hideElement')
    $('#cart__status').val('UPDATING CART');
    $('#cart__status').removeClass('hideElement');
    if (OnCartPage) {
        $('#cart_page_loader_above_box').removeClass('hideElement');
    }
    $.ajax({
        url: '/api/DeleteCart.aspx',
        method: 'POST',
        data: { 'pbsid': value },
        cache: false,
        success: function (parameter) {
            let data = JSON.parse(parameter);
            console.log(data);
            $('#master_page_CART').slideDown('fast');
            if (data.Response == 'OK') {
                ChangesToCart = true;
                LoadCart();
            } else {
                $('#cart_warn_status').html(data.ResponseString);
                $('#cart_warn_status').removeClass('hideElement');
            }
            if (OnCartPage) {

                if (data.Response == 'OK') {
                    LoadCartFromCartPage();
                } else {
                    $('#cart_page_warn').html(data.ResponseString);
                    $('#cart_page_warn').removeClass('hideElement');
                }
            }
        }
    });
}

function GenerateDropdownQTY(Qty, SelectedQty) {
    HTMLDropdown = "";
    for (i = 1; i <= Qty; i++) {
        if (i == SelectedQty) {
            HTMLDropdown += "<option selected value = '" + i + "'>" + i + "</option>";
        } else {
            HTMLDropdown += "<option value = '" + i + "'>" + i + "</option>";
        }

    }
    return HTMLDropdown;
}

function LoadCartFromCartPage() {
    $('#master_cart').addClass('hideElement');
    $.ajax({
        url: '/api/GetCart.aspx',
        method: 'GET',
        cache: false,
        success: function (parameter) {
            $('#cart_page_loader_above_box').addClass('hideElement');
            $('#cart_page_loader').addClass('hideElement');
            HTMLString = "";
            ChangesToCart = false;
            $('#cartLoader').addClass('hideElement')
            let data = JSON.parse(parameter);
            let Cart = JSON.parse(data.Cart).CartItems;
            console.log(data);
            console.log(Cart);
            if (data.Response == 'OK') {
                $('#cart__status').addClass('hideElement')
                if (JSON.parse(data.Cart).HasValidationErrors == true) {
                    $('#cart_page_warn').html("SOME ITEMS ARE OUT OF STOCK/UNAVAILABLE, PLEASE UPDATE YOUR CART");
                    $('#cart_page_warn').removeClass('hideElement');
                    $('#cart_page_checkout, #cart_page_groupSplit').addClass('checkout-disabled'); // checkout button disabled
                } else {
                    $('#cart_page_warn').addClass('hideElement');
                    $('#cart_page_checkout, #cart_page_groupSplit').removeClass('checkout-disabled');
                }
                if (data.Quantity == 0) {
                    $('#cart_page_emptyCart').removeClass('hideElement')
                    $('#cart_page_notEmptyCart').addClass('hideElement')
                } else {

                    for (ProductIndex in Cart) {
                        HTMLTOAdd = "";
                        if (Cart[ProductIndex].HasQuantity) {
                            HTMLTOAdd = '<div class="row no-margin p10px pb20px cart-menu-item">';
                        } else {
                            HTMLTOAdd = '<div class="row no-margin p10px pb20px cart-warning">';
                        }
                        HTMLTOAdd +=
                            '<div class="col-lg-2 text-center no-margin">' +
                            '<img class="cart_page_img" src="/assets/' + Cart[ProductIndex].ProductObj.ProductImage + '" />' +
                            '</div>' +
                            '<div class="col-lg-5">' +
                            '<div class="row no-margin cart_page_product_name">' +
                            '<span>' + Cart[ProductIndex].ProductObj.ProductName + '</span>' +
                            '<span class="cart_page_product_store_image_span"><img class="cart_page_product_store_image" src="/assets/' + Cart[ProductIndex].ProductObj.StoreLogo + '" /></span></div>' +
                            '<div class="row no-margin cart_page_product_quantity">';
                        var price = Cart[ProductIndex].ProductObj.Price;
                        if (Cart[ProductIndex].HasQuantity) {
                            HTMLTOAdd +=
                                '<span>Quantity</span>' +
                                '<span>' +
                                '<select onchange="updatePrice(\'' + Cart[ProductIndex].ProductObj.pbsID + '\',\'' + Cart[ProductIndex].ProductObj.Price + '\');"  id="cart_' + Cart[ProductIndex].ProductObj.pbsID + '" class="cart_page_dropdown_select">' +
                                GenerateDropdownQTY(Cart[ProductIndex].DBQuantity, Cart[ProductIndex].ProductObj.Quantity) +
                                '</select></span>';
                            price = price * Cart[ProductIndex].ProductObj.Quantity;
                        } else {
                            if (Cart[ProductIndex].DBQuantity <= 0) {
                                HTMLTOAdd +=
                                    '<div class="text-center no-padding bold primary-admin-background-color text-center p5px color-white cart_page_out_of_stock_label">OUT OF STOCK</div>';

                            } else {
                                HTMLTOAdd +=
                                    '<span>Quantity</span>' +
                                    '<span>' +
                                    '<select id="cart_' + Cart[ProductIndex].ProductObj.pbsID + '" class="cart_page_dropdown_select">' +
                                    GenerateDropdownQTY(Cart[ProductIndex].DBQuantity, 1) +
                                    '</select></span><div class="cart_page_quantity_not_available primary-admin-color">The required quantity is not available, please reselect the available quantity</div>';
                            }

                        }
                        HTMLTOAdd += '</div></div>';
                        HTMLTOAdd += ' <div class="col-lg-5">' +
                            '<div class="row no-margin cart_page_product_price primary-color" id="price_' + Cart[ProductIndex].ProductObj.pbsID + '">$' + price + '</div>' +
                            '<div class="row text-right">';

                        if (Cart[ProductIndex].HasQuantity) {
                            HTMLTOAdd +=
                                '<span class="cart_page_product_update primary-color" onclick="UpdateCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">UPDATE</span>';
                        } else {
                            if (Cart[ProductIndex].DBQuantity > 0) {
                                HTMLTOAdd +=
                                    '<span class="cart_page_product_update primary-color" onclick="UpdateCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">UPDATE</span>'
                            }
                        }

                        HTMLTOAdd += '<span class="cart_page_product_delete primary-admin-color" onclick="DeleteCart(' + Cart[ProductIndex].ProductObj.pbsID + ')">DELETE</span></div></div>' +
                            '</div>';
                        HTMLString = HTMLTOAdd + HTMLString;

                    }
                    $('#cart_page_products_list').html(HTMLString);
                    $('#cart_page_emptyCart').addClass('hideElement')
                    $('#cart_page_notEmptyCart').removeClass('hideElement')
                }
            } else {
                $('#cart__status').html('UNABLE TO UPDATE THE CART');
            }
        }
    });
}

function updatePrice(pbsid, price) {
    var dropdown = parseInt($('#cart_' + pbsid).val());
    $('#price_' + pbsid).html('$' + (price * dropdown));
    //$('#price_' + pbsid).html('$' + ($('cart_' + pbsid).val() * )
}

function LoadAllOrders() {

    if (CurrentORDERType == 'INDIVIDUAL') {
        URLToHIT = '/api/orders/AllIndividualOrders.aspx';
    } else {
        URLToHIT = 'api/orders/AllGroupOrders.aspx';
    }


    console.log('Loading all orders');
    HTMLOutput = '';
    $('#MyOrder_details_Result').html('');
    $('#MyOrder_details_loader').removeClass('hideElement');
    $('#MyOrder_details_Result').addClass('hideElement');

    $('#orders_placed_orders_sub_heading, #order_all_orders_sub_heading, #orders_cancelled_orders_sub_heading, #orders_shipped_orders_sub_heading').removeClass('orders_text_selected');
    $('#order_all_orders_sub_heading').addClass('orders_text_selected');

    $.ajax({
        url: URLToHIT,
        method: 'GET',
        cache: false,
        success: function (parameter) {
            console.log('Cart loaded');
            let data = JSON.parse(parameter);
            if (data.HasOrders) {
                for (order of data.ListOfOrders) {
                    HTMLOutput = '';
                    HTMLOutput += '<div class="shadowAroundBox order_details_row">';
                    if (order.StoreLogo.length > 0) {
                        HTMLOutput += '<div class="row no-margin superStoreRow">';
                        for (storelogo of order.StoreLogo) {
                            HTMLOutput += '<img class="myorders_superstore_row_image" src="assets/' + storelogo + '" />';
                        }
                        HTMLOutput += '</div>';
                    }
                    HTMLOutput += ' <div class="row no-margin order_details_order_fulldetails">';
                    HTMLOutput += '<div class="col-lg-6 no-padding">';
                    HTMLOutput += '<div class="row no-margin">ORDER ID : ' + order.OrderID + '</div>';
                    HTMLOutput += '<div class="row no-margin">DATE OF ORDER : ' + formatDate(new Date(order.OrderDate.match(/\d+/)[0] * 1)) + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL ITEMS : ' + order.OrderItemCount + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL AMOUNT : <span class="primary-color"> $ ' + order.OrderAmount + '</span></div>';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 text-center"><div class="row no-margin order_details_row_status">STATUS</div >';
                    HTMLOutput += '<div class="row no-margin order_details_row_status"> <span class="primary-admin-color">' + order.OrderStatus + '</span></div >';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 no-margin">';
                    HTMLOutput += '<div class="row no-margin order_track_order_button" onclick=redirectToOrdersPage(\'' + order.OrderID+'\')>ORDER DETAILS</div>';
                    if (order.OrderStatus == 'Order_Created') {
                        HTMLOutput += '<div class="row no-margin order_track_order_button primary-admin-background-color mt10px" onclick=CancelOrder(\'' + order.OrderID +'\')>CANCEL ORDER</div></div></div>';
                    }
                    HTMLOutput += '</div>';
                    $('#MyOrder_details_Result').append(HTMLOutput);
                }
            } else {
                if (data.IsAuthenticated == false) {
                    window.location.href = "/Signout";
                } else {
                    $('#MyOrder_details_Result').append('<div class="orders_no_orders_placed">There are currently no Individual orders placed</div><div class="text-center">Please note : For Group orders, please click on group order tab</div>');
                }
            }

            $('#MyOrder_details_loader').addClass('hideElement');
            $('#MyOrder_details_Result').removeClass('hideElement');

        }
    });

}
function redirectToOrdersPage(orderid) {
    location.href = "/orders/" + orderid;
}
function formatDate(value) {
    return value.toUTCString().split(' ').slice(0, 4).join(' ');
}

function SetIndividualOrders() {
    CurrentORDERType = 'INDIVIDUAL';
    $('#myorders_individual_heading, #myorders_group_heading').removeClass('orders_text_selected');
    $('#myorders_individual_heading').addClass('orders_text_selected');
    LoadAllOrders();
}

function SetGroupOrders() {
    CurrentORDERType = 'GROUP';
    $('#myorders_individual_heading, #myorders_group_heading').removeClass('orders_text_selected');
    $('#myorders_group_heading').addClass('orders_text_selected');
    LoadAllOrders();
}


function loadOrder_CreatedOrders() {
    if (CurrentORDERType == 'INDIVIDUAL') {
        URLToHIT = '/api/orders/AllIndividualOrders.aspx';
    } else {
        URLToHIT = 'api/orders/AllGroupOrders.aspx';
    }

    $('#MyOrder_details_Result').html('');
    $('#MyOrder_details_loader').removeClass('hideElement');
    $('#MyOrder_details_Result').addClass('hideElement');
    $('#orders_placed_orders_sub_heading, #order_all_orders_sub_heading, #orders_cancelled_orders_sub_heading, #orders_shipped_orders_sub_heading').removeClass('orders_text_selected');
    $('#orders_placed_orders_sub_heading').addClass('orders_text_selected');

    $.ajax({
        url: URLToHIT,
        method: 'GET',
        cache: false,
        success: function (parameter) {
            console.log('Cart loaded');
            let data = JSON.parse(parameter);
            if (data.HasOrders) {
                for (order of data.ListOfOrders) {
                    HTMLOutput = '';
                    HTMLOutput += '<div class="shadowAroundBox order_details_row">';
                    if (order.StoreLogo.length > 0) {
                        HTMLOutput += '<div class="row no-margin superStoreRow">';
                        for (storelogo of order.StoreLogo) {
                            HTMLOutput += '<img class="myorders_superstore_row_image" src="assets/' + storelogo + '" />';
                        }
                        HTMLOutput += '</div>';
                    }
                    HTMLOutput += ' <div class="row no-margin order_details_order_fulldetails">';
                    HTMLOutput += '<div class="col-lg-6 no-padding">';
                    HTMLOutput += '<div class="row no-margin">ORDER ID : ' + order.OrderID + '</div>';
                    HTMLOutput += '<div class="row no-margin">DATE OF ORDER : ' + formatDate(new Date(order.OrderDate.match(/\d+/)[0] * 1)) + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL ITEMS : ' + order.OrderItemCount + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL AMOUNT : <span class="primary-color"> $ ' + order.OrderAmount + '</span></div>';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 text-center"><div class="row no-margin order_details_row_status">STATUS</div >';
                    HTMLOutput += '<div class="row no-margin order_details_row_status"> <span class="primary-admin-color">' + order.OrderStatus + '</span></div >';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 no-margin">';
                    HTMLOutput += '<div class="row no-margin order_track_order_button">ORDER DETAILS</div>';
                    if (order.OrderStatus == 'Order_Created') {
                        HTMLOutput += '<div class="row no-margin order_track_order_button primary-admin-background-color mt10px">CANCEL ORDER</div></div></div>';
                    }
                    HTMLOutput += '</div>';
                    $('#MyOrder_details_Result').append(HTMLOutput);
                }
            } else {
                if (data.IsAuthenticated == false) {
                    window.location.href = "/Signout";
                } else {
                    $('#MyOrder_details_Result').append('<div class="orders_no_orders_placed">There are currently no Individual orders placed</div><div class="text-center">Please note : For Group orders, please click on group order tab</div>');
                }
            }

            $('#MyOrder_details_loader').addClass('hideElement');
            $('#MyOrder_details_Result').removeClass('hideElement');

        }
    });
}

function loadCancelledOrders() {
    if (CurrentORDERType == 'INDIVIDUAL') {
        URLToHIT = '/api/orders/CancelledIndividualOrders.aspx';
    } else {
        URLToHIT = 'api/orders/CancelledGroupOrders.aspx';
    }
    $('#MyOrder_details_Result').html('');
    $('#MyOrder_details_loader').removeClass('hideElement');
    $('#MyOrder_details_Result').addClass('hideElement');
    $('#orders_placed_orders_sub_heading, #order_all_orders_sub_heading, #orders_cancelled_orders_sub_heading, #orders_shipped_orders_sub_heading').removeClass('orders_text_selected');
    $('#orders_cancelled_orders_sub_heading').addClass('orders_text_selected');

    $.ajax({
        url: URLToHIT,
        method: 'GET',
        cache: false,
        success: function (parameter) {
            console.log('Cart loaded');
            let data = JSON.parse(parameter);
            if (data.HasOrders) {
                for (order of data.ListOfOrders) {
                    HTMLOutput = '';
                    HTMLOutput += '<div class="shadowAroundBox order_details_row">';
                    if (order.StoreLogo.length > 0) {
                        HTMLOutput += '<div class="row no-margin superStoreRow">';
                        for (storelogo of order.StoreLogo) {
                            HTMLOutput += '<img class="myorders_superstore_row_image" src="assets/' + storelogo + '" />';
                        }
                        HTMLOutput += '</div>';
                    }
                    HTMLOutput += ' <div class="row no-margin order_details_order_fulldetails">';
                    HTMLOutput += '<div class="col-lg-6 no-padding">';
                    HTMLOutput += '<div class="row no-margin">ORDER ID : ' + order.OrderID + '</div>';
                    HTMLOutput += '<div class="row no-margin">DATE OF ORDER : ' + formatDate(new Date(order.OrderDate.match(/\d+/)[0] * 1)) + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL ITEMS : ' + order.OrderItemCount + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL AMOUNT : <span class="primary-color"> $ ' + order.OrderAmount + '</span></div>';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 text-center"><div class="row no-margin order_details_row_status">STATUS</div >';
                    HTMLOutput += '<div class="row no-margin order_details_row_status"> <span class="primary-admin-color">' + order.OrderStatus + '</span></div >';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 no-margin">';
                    HTMLOutput += '<div class="row no-margin order_track_order_button">ORDER DETAILS</div>';

                    if (order.OrderStatus == 'Order_Created') {
                        HTMLOutput += '<div class="row no-margin order_track_order_button primary-admin-background-color mt10px">CANCEL ORDER</div></div></div>';
                    }
                    HTMLOutput += '</div>';
                    $('#MyOrder_details_Result').append(HTMLOutput);
                }
            } else {
                if (data.IsAuthenticated == false) {
                    window.location.href = "/Signout";
                } else {
                    $('#MyOrder_details_Result').append('<div class="orders_no_orders_placed">There are currently no Orders Cancelled for ' + CurrentORDERType + ' orders.</div>');
                }
            }

            $('#MyOrder_details_loader').addClass('hideElement');
            $('#MyOrder_details_Result').removeClass('hideElement');

        }
    });
}

function loadShippedOrders() {

    HTMLOutput = '';
    $('#MyOrder_details_Result').html('');
    $('#MyOrder_details_loader').removeClass('hideElement');
    $('#MyOrder_details_Result').addClass('hideElement');

    $('#orders_placed_orders_sub_heading, #order_all_orders_sub_heading, #orders_cancelled_orders_sub_heading, #orders_shipped_orders_sub_heading').removeClass('orders_text_selected');
    $('#orders_shipped_orders_sub_heading').addClass('orders_text_selected');

    if (CurrentORDERType == 'INDIVIDUAL') {
        URLToHIT = '/api/orders/ShippedIndividualOrders.aspx';
    } else {
        URLToHIT = 'api/orders/ShippedGroupOrders.aspx';
    }

    $.ajax({
        url: URLToHIT,
        method: 'GET',
        cache: false,
        success: function (parameter) {
            console.log('Cart loaded');
            let data = JSON.parse(parameter);
            if (data.HasOrders) {
                for (order of data.ListOfOrders) {
                    HTMLOutput = '';
                    HTMLOutput += '<div class="shadowAroundBox order_details_row">';
                    if (order.StoreLogo.length > 0) {
                        HTMLOutput += '<div class="row no-margin superStoreRow">';
                        for (storelogo of order.StoreLogo) {
                            HTMLOutput += '<img class="myorders_superstore_row_image" src="assets/' + storelogo + '" />';
                        }
                        HTMLOutput += '</div>';
                    }
                    HTMLOutput += ' <div class="row no-margin order_details_order_fulldetails">';
                    HTMLOutput += '<div class="col-lg-6 no-padding">';
                    HTMLOutput += '<div class="row no-margin">ORDER ID : ' + order.OrderID + '</div>';
                    HTMLOutput += '<div class="row no-margin">DATE OF ORDER : ' + formatDate(new Date(order.OrderDate.match(/\d+/)[0] * 1)) + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL ITEMS : ' + order.OrderItemCount + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL AMOUNT : <span class="primary-color"> $ ' + order.OrderAmount + '</span></div>';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 text-center"><div class="row no-margin order_details_row_status">STATUS</div >';
                    HTMLOutput += '<div class="row no-margin order_details_row_status"> <span class="primary-admin-color">' + order.OrderStatus + '</span></div >';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 no-margin">';
                    HTMLOutput += '<div class="row no-margin order_track_order_button">ORDER DETAILS</div>';
                    if (order.OrderStatus == 'Order_Created') {
                        HTMLOutput += '<div class="row no-margin order_track_order_button primary-admin-background-color mt10px">CANCEL ORDER</div></div></div>';
                    }
                    HTMLOutput += '</div>';
                    $('#MyOrder_details_Result').append(HTMLOutput);
                }
            } else {
                if (data.IsAuthenticated == false) {
                    window.location.href = "/Signout";
                } else {
                    $('#MyOrder_details_Result').append('<div class="orders_no_orders_placed">There are currently no orders Shipped for ' + CurrentORDERType + ' orders</div>');
                }
            }

            $('#MyOrder_details_loader').addClass('hideElement');
            $('#MyOrder_details_Result').removeClass('hideElement');

        }
    });
}

function loadOrderPlacedOrders() {
    HTMLOutput = '';
    $('#MyOrder_details_Result').html('');
    $('#MyOrder_details_loader').removeClass('hideElement');
    $('#MyOrder_details_Result').addClass('hideElement');

    $('#orders_placed_orders_sub_heading, #order_all_orders_sub_heading, #orders_cancelled_orders_sub_heading, #orders_shipped_orders_sub_heading').removeClass('orders_text_selected');
    $('#orders_placed_orders_sub_heading').addClass('orders_text_selected');

    if (CurrentORDERType == 'INDIVIDUAL') {
        URLToHIT = '/api/orders/OrderPlacedIndividualOrders.aspx';
    } else {
        URLToHIT = 'api/orders/OrderPlacedGroupOrders.aspx';
    }

    $.ajax({
        url: URLToHIT,
        method: 'GET',
        cache: false,
        success: function (parameter) {
            console.log('Cart loaded');
            let data = JSON.parse(parameter);
            if (data.HasOrders) {
                for (order of data.ListOfOrders) {
                    HTMLOutput = '';
                    HTMLOutput += '<div class="shadowAroundBox order_details_row">';
                    if (order.StoreLogo.length > 0) {
                        HTMLOutput += '<div class="row no-margin superStoreRow">';
                        for (storelogo of order.StoreLogo) {
                            HTMLOutput += '<img class="myorders_superstore_row_image" src="assets/' + storelogo + '" />';
                        }
                        HTMLOutput += '</div>';
                    }
                    HTMLOutput += ' <div class="row no-margin order_details_order_fulldetails">';
                    HTMLOutput += '<div class="col-lg-6 no-padding">';
                    HTMLOutput += '<div class="row no-margin">ORDER ID : ' + order.OrderID + '</div>';
                    HTMLOutput += '<div class="row no-margin">DATE OF ORDER : ' + formatDate(new Date(order.OrderDate.match(/\d+/)[0] * 1)) + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL ITEMS : ' + order.OrderItemCount + '</div>';
                    HTMLOutput += '<div class="row no-margin">TOTAL AMOUNT : <span class="primary-color"> $ ' + order.OrderAmount + '</span></div>';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 text-center"><div class="row no-margin order_details_row_status">STATUS</div >';
                    HTMLOutput += '<div class="row no-margin order_details_row_status"> <span class="primary-admin-color">' + order.OrderStatus + '</span></div >';
                    HTMLOutput += '</div>';
                    HTMLOutput += '<div class="col-lg-3 no-margin">';
                    HTMLOutput += '<div class="row no-margin order_track_order_button">ORDER DETAILS</div>';
                    if (order.OrderStatus == 'Order_Created') {
                        HTMLOutput += '<div class="row no-margin order_track_order_button primary-admin-background-color mt10px">CANCEL ORDER</div></div></div>';
                    }
                    HTMLOutput += '</div>';
                    $('#MyOrder_details_Result').append(HTMLOutput);
                }
            } else {
                if (data.IsAuthenticated == false) {
                    window.location.href = "/Signout";
                } else {
                    $('#MyOrder_details_Result').append('<div class="orders_no_orders_placed">There are currently no orders placed under "Order placed category for ' + CurrentORDERType + ' orders"</div>');
                }
            }

            $('#MyOrder_details_loader').addClass('hideElement');
            $('#MyOrder_details_Result').removeClass('hideElement');

        }
    });
}

function RedirectToCheckout() {
    $('#cart_page_loader_above_box').removeClass('hideElement');
    $.ajax({
        url: '/api/AuthenticateUser.aspx',
        method: 'GET',
        cache: false,
        success: function (parameter) {
            JSONObj = JSON.parse(parameter);
            if (JSONObj.IsAuthenticated == true) {
                location.href = '/checkout';
            } else {
                location.href = 'Signin?r=/checkout';
            }
        }
    });
}