function CancelOrder(orderID) {
    $('#checkout_fixed_background_cart_update,#checkout_add_address_hover_finalize').removeClass('hideElement');
    $.ajax({
        url: '/api/CancelOrder.aspx',
        method: 'POST',
        data: {
            "oid": orderID
        },
        success: function (data) {

            JSONObj = JSON.parse(data);
            if (JSONObj.Response == "OK") {
                location.href = location.href;

            } else {
                if (JSONObj.Response == "NOT_AUTHENTICATED") {
                    location.href = "/signout";
                } else {
                    $('#cart_page_address_finalize_loader').addClass('hideElement');
                    $('#checkout_address_add_hover_inner_finalize_text').html('Unable to update the order, please try again later');
                }
            }
        }
    });
}

$(document).ready(function () {
    if ($('#checkout_fixed_background_cart_update').length) {

    } else {
        $('body').prepend('<div class="checkout_background_hover_css hideElement" id="checkout_fixed_background_cart_update"></div >');
        $('body').prepend(' <div class="checkout_address_add_hover_outer hideElement" id="checkout_add_address_hover_finalize"><div class="checkout_address_add_hover_inner_finalize shadowAroundBox"><div class="linear-activity showLoader" id="cart_page_address_finalize_loader"><div class="indeterminate"></div></div><img class="checkout_address_add_hover_inner_finalize_img" src="/assets/images/logoWithoutText.png" /><div class="checkout_address_add_hover_inner_finalize_text" id="checkout_address_add_hover_inner_finalize_text">YOUR ORDER IS UPDATING. PLEASE WAIT</div></div></div>');
    }
})