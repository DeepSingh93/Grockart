$(document).ready(function () {
    InitiateCheckout();
});
addressIDSelected = 0;
cardIDSelected = 0;
function InitiateCheckout() {
    addressIDSelected = 0;
    $('#master_cart').addClass('hideElement');
    $('#userProfile').removeClass('col-lg-8').addClass('col-lg-12');
    $('.MasterProfile').css('left', '38px');
    $.ajax({
        url: '/api/GetCart.aspx',
        method: 'GET',
        cache: false,
        success: function (parameter) {
            totalCost = 0;
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
                $('#cart__status').addClass('hideElement');
                totalItemCount = 0;
                if (JSON.parse(data.Cart).HasValidationErrors == true) {
                    $('#cart_page_warn').html("REDIRECTING TO CART");
                    $('#cart_page_warn').removeClass('hideElement');
                    location.href = '/Cart';
                } else {
                    $('#cart_page_warn').addClass('hideElement');
                    $('#cart_page_checkout, #cart_page_groupSplit').removeClass('checkout-disabled');
                    if (data.Quantity == 0) {
                        $('#cart_page_emptyCart').removeClass('hideElement')
                        $('#cart_page_notEmptyCart').addClass('hideElement')
                    } else {
                        LoadAddress();
                        LoadCardDetails();
                        $('#totalUniqueItems').html(data.Quantity);
                        for (ProductIndex in Cart) {
                            HTMLTOAdd = "";
                            if (Cart[ProductIndex].HasQuantity) {
                                HTMLTOAdd = '<div class="row no-margin p10px pb20px cart-menu-item">';
                            } else {
                                HTMLTOAdd = '<div class="row no-margin p10px pb20px cart-warning">';
                            }
                            totalItemCount += Cart[ProductIndex].ProductObj.Quantity;
                            HTMLTOAdd +=
                                '<div class="col-lg-2 text-center no-margin">' +
                                '<img class="cart_page_img" src="/assets/' + Cart[ProductIndex].ProductObj.ProductImage + '" />' +
                                '</div>' +
                                '<div class="col-lg-5">' +
                                '<div class="row no-margin cart_page_product_name">' +
                                '<span>' + Cart[ProductIndex].ProductObj.ProductName + '</span>' +
                                '<span class="cart_page_product_store_image_span"><img class="cart_page_product_store_image" src="/assets/' + Cart[ProductIndex].ProductObj.StoreLogo + '" /></span></div>' +
                                '<div class="row no-margin cart_page_product_quantity">';
                            HTMLTOAdd +=
                                '<span>Quantity : </span>' +
                                '<span> <b>' +
                                Cart[ProductIndex].ProductObj.Quantity +
                                '</b></span>';
                            HTMLTOAdd += '</div></div>';
                            totalCost += Cart[ProductIndex].ProductObj.Price * Cart[ProductIndex].ProductObj.Quantity;
                            HTMLTOAdd += ' <div class="col-lg-5">' +
                                '<div class="row no-margin cart_page_product_price primary-color">$ ' + Cart[ProductIndex].ProductObj.Price * Cart[ProductIndex].ProductObj.Quantity + '</div></div></div>';
                            HTMLString = HTMLTOAdd + HTMLString;

                        }
                        $('#totalCost, #totalAmount').html('$ ' + totalCost);
                        $('#cart_page_products_list').html(HTMLString);
                        $('#cart_page_emptyCart').addClass('hideElement')
                        $('#cart_page_notEmptyCart').removeClass('hideElement');
                        $('.checkout_placeorder_button').removeClass('hideElement');
                    }
                }
                $('#totalItems').html(totalItemCount);
            } else {
                $('#cart__status').html('UNABLE TO UPDATE THE CART');
            }
        }
    });
}

function LoadAddress() {
    $('#checkout_page_address_list').html('');
    $('#checkout_page_address_list').removeClass("slick-initialized slick-slider");
    $.ajax({
        url: '/api/GetUserAddress.aspx',
        method: 'GET',
        cache: false,
        success: function (data) {
            var JSONObj = JSON.parse(data);
            console.log(JSONObj);
            HTML_Address = '';
            if (JSONObj.isAuthenticated == true) {
                Address_Count = JSONObj.AddressList.length;
                for (i = 0; i < Address_Count; i++) {
                    console.log(JSONObj.AddressList[i])
                    HTML_Address += '<div class="col-lg-3  addressBox_outer" >';
                    //addressBox_selected
                    if (addressIDSelected != 0) {
                        if (addressIDSelected == JSONObj.AddressList[i].AddressID) {
                            HTML_Address += '<div class="addressBox_inner shadowAroundBox addressBox_selected" id="addressBOX_' + JSONObj.AddressList[i].AddressID + '">';
                        } else {
                            HTML_Address += '<div class="addressBox_inner shadowAroundBox " id="addressBOX_' + JSONObj.AddressList[i].AddressID + '">';
                        }
                    } else {
                        HTML_Address += '<div class="addressBox_inner shadowAroundBox " id="addressBOX_' + JSONObj.AddressList[i].AddressID + '">';
                    }

                    HTML_Address += '<div class="row no-margin">';
                    HTML_Address += '<div class="col-lg-12">';
                    HTML_Address += '<div class="checkout_address_row_name">';
                    HTML_Address += JSONObj.AddressList[i].AddressName.toString();
                    HTML_Address += '</div>';
                    HTML_Address += '<div class="checkout_street_row_name">';
                    HTML_Address += JSONObj.AddressList[i].StreetName;
                    HTML_Address += '</div>';
                    HTML_Address += '<div class="checkout_appt_row_name">';
                    HTML_Address += JSONObj.AddressList[i].AptNum;
                    HTML_Address += '</div>';
                    HTML_Address += '<div class="checkout_province">';
                    HTML_Address += JSONObj.AddressList[i].Province + ' - ' + JSONObj.AddressList[i].City;
                    HTML_Address += '</div>';
                    HTML_Address += '<div class="checkout_province">';
                    HTML_Address += JSONObj.AddressList[i].PostalCode;
                    HTML_Address += '</div>';
                    HTML_Address += '</div>';
                    HTML_Address += '</div>';
                    if (addressIDSelected != 0) {
                        if (addressIDSelected == JSONObj.AddressList[i].AddressID) {
                            HTML_Address += '<div class="row no-margin checkout_selection_row hideElement" id="checkout_selection_row_' + JSONObj.AddressList[i].AddressID + '">';
                        } else {
                            HTML_Address += '<div class="row no-margin checkout_selection_row" id="checkout_selection_row_' + JSONObj.AddressList[i].AddressID + '">';
                        }
                    } else {
                        HTML_Address += '<div class="row no-margin checkout_selection_row" id="checkout_selection_row_' + JSONObj.AddressList[i].AddressID + '">';
                    }

                    HTML_Address += '<div class="col-lg-6 text-center primary-color cursor-pointer" onclick="selectAddress(\'' + JSONObj.AddressList[i].AddressID + '\')">SELECT</div>';
                    HTML_Address += '<div class="col-lg-6 text-center primary-admin-color cursor-pointer" onclick="deleteAddress(\'' + JSONObj.AddressList[i].AddressID + '\')">DELETE</div>';
                    HTML_Address += '</div>';
                    HTML_Address += '</div>';
                    HTML_Address += '</div>';

                }
                HTML_Address += '<div class="col-lg-3 cursor-pointer addressBox_outer" onclick="AddAddressHover()">' +
                    '<div class="addressBox_inner shadowAroundBox">' +
                    '<div class="row no-margin">' +
                    '<div class="col-lg-12 checkout_add">' +
                    '<img src="assets/images/checkout_add.png" />' +
                    '</div>' +
                    '</div>' +
                    '<div class="row no-margin checkout_selection_row">' +
                    '<div class="col-lg-12 text-center">' +
                    'ADD NEW ADDRESS' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';

                $('#checkout_page_address_list').append(HTML_Address);
                $('#checkout_address_loader').addClass('hideElement');
                if (Address_Count > 3) {
                    $('#checkout_page_address_list').slick({
                        dots: true,
                        infinite: true,
                        speed: 300,
                        slidesToShow: 4,
                        slidesToScroll: 3
                    });
                }
            } else {
                console.log("Unable to fetch address");
            }
        }
    })
}

function selectAddress(aid) {
    var selectedAddressID = "#addressBOX_" + aid;
    if (addressIDSelected != 0) {
        $("#addressBOX_" + addressIDSelected).removeClass('addressBox_selected');
        $("#checkout_selection_row_" + addressIDSelected).removeClass('hideElement');
    }
    $(selectedAddressID).addClass('addressBox_selected');
    $("#checkout_selection_row_" + aid).addClass('hideElement');
    addressIDSelected = aid;
    $("html, body").animate({ scrollTop: 0 }, "slow");
    $('#checkout_add_address_hover_finalize, #cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').removeClass('hideElement');

    $.ajax({
        url: '/api/GetTaxValue.aspx',
        method: 'POST',
        data: {
            "aid": aid
        },
        success: function (data) {
            $('#cart_page_address_finalize_loader').addClass('hideElement');
            JObj = JSON.parse(data).Response;
            console.log(JObj);
            if (JObj.HasResult == true) {
                $('#cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').addClass('hideElement');
                $('#cart_taxes').html('Taxes (' + JObj.TaxType + ') :  $ ' + JObj.TaxAmount + ' (' + JObj.TaxPercentage + '%)');
                $('#totalCost').html('$ ' + JObj.PreTaxAmount);
                $('#totalAmount').html('$ ' + JObj.FinalAmount);
                $('#checkout_add_address_hover_finalize, #checkout_fixed_background').addClass('hideElement');
            } else {
                $('#checkout_address_add_hover_inner_finalize_text').html('Unable to update the cart, please try again later');
            }
        }
    });
}


function AddAddressHover() {
    $('.checkout-field-validator').addClass('hideElement');
    $('.checkout_hover_box_input_values').removeClass('checkout-input-hover-validator');
    $('#checkout_fixed_background, #checkout_add_address_hover').removeClass('hideElement');
}

function LoadCardDetails() {
    $('#checkout_page_card_list_results').html('');
    $('#checkout_page_card_list_results').removeClass("slick-initialized slick-slider");
    $('#checkout_card_loader').removeClass('hideElement');
    $.ajax({
        url: '/api/GetCardList.aspx',
        method: 'GET',
        cache: false,
        success: function (data) {
            var JSONObj = JSON.parse(data);
            console.log(JSONObj);
            HTML_Address = '';
            if (JSONObj.isAuthenticated == true) {
                Card_Count = JSONObj.CardList.length;
                for (i = 0; i < Card_Count; i++) {
                    HTML_Address += '<div class="col-lg-3  addressBox_outer" >';
                    //addressBox_selected
                    if (addressIDSelected != 0) {
                        if (addressIDSelected == JSONObj.CardList[i].CardID) {
                            HTML_Address += '<div class="addressBox_inner shadowAroundBox addressBox_selected" id="cardBOX_' + JSONObj.CardList[i].CardID + '">';
                        } else {
                            HTML_Address += '<div class="addressBox_inner shadowAroundBox " id="cardBOX_' + JSONObj.CardList[i].CardID + '">';
                        }
                    } else {
                        HTML_Address += '<div class="addressBox_inner shadowAroundBox " id="cardBOX_' + JSONObj.CardList[i].CardID + '">';
                    }

                    HTML_Address += '<div class="row no-margin">';
                    HTML_Address += '<div class="col-lg-12">';
                    HTML_Address += '<div class="checkout_address_row_name">';
                    HTML_Address += JSONObj.CardList[i].Name;
                    HTML_Address += '</div>';
                    HTML_Address += '<div class="checkout_street_row_name">';
                    HTML_Address += '**** ' + JSONObj.CardList[i].CardNumber.substring(12, 16);
                    HTML_Address += '</div>';

                    HTML_Address += '</div>';
                    HTML_Address += '</div>';
                    if (addressIDSelected != 0) {
                        if (addressIDSelected == JSONObj.AddressList[i].AddressID) {
                            HTML_Address += '<div class="row no-margin checkout_selection_row hideElement" id="checkout_card_selection_row_' + JSONObj.CardList[i].CardID + '">';
                        } else {
                            HTML_Address += '<div class="row no-margin checkout_selection_row" id="checkout_card_selection_row_' + JSONObj.CardList[i].CardID + '">';
                        }
                    } else {
                        HTML_Address += '<div class="row no-margin checkout_selection_row" id="checkout_card_selection_row_' + JSONObj.CardList[i].CardID + '">';
                    }

                    HTML_Address += '<div class="col-lg-6 text-center primary-color cursor-pointer" onclick="selectCard(\'' + JSONObj.CardList[i].CardID + '\')">SELECT</div>';
                    HTML_Address += '<div class="col-lg-6 text-center primary-admin-color cursor-pointer" onclick="deleteCard(\'' + JSONObj.CardList[i].CardID + '\')">DELETE</div>';
                    HTML_Address += '</div>';
                    HTML_Address += '</div>';
                    HTML_Address += '</div>';

                }
                HTML_Address += '<div class="col-lg-3 cursor-pointer addressBox_outer" onclick="AddCard()">' +
                    '<div class="addressBox_inner shadowAroundBox">' +
                    '<div class="row no-margin">' +
                    '<div class="col-lg-12  text-center">' +
                    '<img class="checkout_card" src="assets/images/checkout_add.png" />' +
                    '</div>' +
                    '</div>' +
                    '<div class="row no-margin checkout_selection_row">' +
                    '<div class="col-lg-12 text-center">' +
                    'ADD NEW CARD' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';

                $('#checkout_page_card_list_results').append(HTML_Address);
                $('#checkout_card_loader').addClass('hideElement');
                if (JSONObj.CardList.length > 3) {
                    $('#checkout_page_card_list_results').slick({
                        dots: true,
                        infinite: true,
                        speed: 300,
                        slidesToShow: 4,
                        slidesToScroll: 3
                    });
                }

            } else {
                console.log("Unable to fetch card details");
            }
        }
    })
}

function deleteCard(cid) {
    $('#checkout_add_address_hover_finalize, #cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').removeClass('hideElement');

    $.ajax({
        url: '/api/DeleteCard.aspx',
        method: 'POST',
        data: {
            "cid": cid
        },
        success: function (data) {
            $('#cart_page_add_address_loader').addClass('hideElement');
            JSONObj = JSON.parse(data);
            if (JSONObj.Response == "OK") {

                LoadCardDetails();
                $('#cart_page_address_finalize_loader,#checkout_add_address_hover_finalize, #checkout_fixed_background_cart_update').addClass('hideElement');
            } else {
                if (JSONObj.Response == "NOT_AUTHENTICATED") {
                    location.href = "/signout";
                } else {
                    $('#cart_page_address_finalize_loader').addClass('hideElement');
                    $('#checkout_address_add_hover_inner_finalize_text').html('Unable to update the card, please try again later');
                }
            }
        }
    });
}

function selectCard(cardID) {
    var selectedcardIDID = "#cardBOX_" + cardID;
    if (cardIDSelected != 0) {
        $("#cardBOX_" + cardIDSelected).removeClass('addressBox_selected');
        $("#checkout_card_selection_row_" + cardIDSelected).removeClass('hideElement');
    }
    $(selectedcardIDID).addClass('addressBox_selected');
    $("#checkout_card_selection_row_" + cardID).addClass('hideElement');
    cardIDSelected = cardID;


}

function close_hover() {
    $('#checkout_fixed_background, #checkout_add_address_hover').addClass('hideElement');
    ResetValue();
}

function ResetValue() {
    $('.checkout-field-validator-textbox').val('');
    $('.checkout-field-validator-ddl')[0].selectedIndex = 0;
}

function AddCard() {
    $('#checkout_add_card_hover, #cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').removeClass('hideElement');
    $('.checkout-field-validator, #cart_page_card_finalize_loader').addClass('hideElement');
    $('.checkout-field-validator-textbox').removeClass('checkout-input-hover-validator');

}

function CardInsert() {
    everythingValidated = true;
    validateCardName();
    validateCardNumber();
    validateMonth();
    valiateYear();
    validateCVV();
    if (everythingValidated) {
        $.ajax({
            url: '/api/AddCardDetails.aspx',
            method: 'POST',
            data: {
                "name": $('#checkout_card_name').val(),
                "cardNumber": $('#checkout_card_number').val(),
                "expiryMonth": $('#checkout_expiry_month').val(),
                "expiryYear": $('#checkout_expiry_year').val(),
                "Cvv": $('#checkout_expiry_cvv').val()
            },
            success: function (data) {
                $('#cart_page_add_address_loader').addClass('hideElement');
                JSONObj = JSON.parse(data);
                console.log(JSONObj);
                if (JSONObj.Response == "OK") {
                    LoadCardDetails();
                    $('#checkout_add_card_hover, #cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').addClass('hideElement');
                    $('.checkout-field-validator, #cart_page_card_finalize_loader').removeClass('hideElement');
                    $('.checkout-field-validator-textbox').addClass('checkout-input-hover-validator');
                } else {
                    if (JSONObj.Response == "NOT_AUTHENTICATED") {
                        location.href = "/signout";
                    } else {
                        $('#checkout_card_page_hover_text').html('Unable to add the card, please try again later');
                        $('#checkout_card_page_hover_text').addClass('checkout_card_error')
                    }
                }
            }
        });
        $('#cart_page_card_finalize_loader').removeClass('hideElement');
    }
}

function showCardValidator(htmlElement) {
    $(htmlElement).addClass('checkout-input-hover-validator');
    $(htmlElement + '_validator').removeClass('hideElement');
}

function hideCardValidator(htmlElement) {
    $(htmlElement).removeClass('checkout-input-hover-validator');
    $(htmlElement + '_validator').addClass('hideElement');
}

function validateCardName() {
    value = $('#checkout_card_name').val();
    if (value.trim().length == 0) {
        $('#checkout_card_name_validator').html('This field cannot be blank');
        showCardValidator('#checkout_card_name');
        everythingValidated = false;
    } else {
        hideCardValidator('#checkout_card_name')
    }
}

function validateCardNumber() {
    value = $('#checkout_card_number').val();
    if (value.trim().length == 0) {
        $('#checkout_card_number_validator').html('This field cannot be blank');
        everythingValidated = false;
        showCardValidator('#checkout_card_number');
    }

    var re16digit = /^\d{16}$/
    var re = new RegExp(re16digit)
    if (re.test(value) == false) {
        $('#checkout_card_number_validator').html('Invalid Card Number');
        showCardValidator('#checkout_card_number');
        everythingValidated = false;
    } else {
        hideCardValidator('#checkout_card_number')
    }
}

function validateMonth() {
    value = $('#checkout_expiry_month').val();
    if (value.trim().length == 0) {
        $('#checkout_expiry_month_validator').html('This field cannot be blank');
        everythingValidated = false;
        showCardValidator('#checkout_expiry_month');
    }
    try {
        month = parseInt(value);
        if (month >= 1 && month <= 12) {
            hideCardValidator('#checkout_expiry_month');
        } else {
            showCardValidator('#checkout_expiry_month');
            $('#checkout_expiry_month_validator').html('Invalid Month');
            everythingValidated = false;
        }
    } catch (Exception) {
        showCardValidator('#checkout_expiry_month');
        $('#checkout_expiry_month_validator').html('Invalid Month');
        everythingValidated = false;
    }
}

function valiateYear() {
    value = $('#checkout_expiry_year').val();
    if (value.trim().length == 0) {
        $('#checkout_expiry_year_validator').html('This field cannot be blank');
        everythingValidated = false;
        showCardValidator('#checkout_expiry_year');
    }
    try {
        month = parseInt(value);
        if (month >= 0 && month <= 99) {
            hideCardValidator('#checkout_expiry_year');
        } else {
            $('#checkout_expiry_year_validator').html('Invalid Year');
            showCardValidator('#checkout_expiry_year');
            everythingValidated = false;
        }
    } catch (Exception) {
        $('#checkout_expiry_year_validator').html('Invalid Year');
        showCardValidator('#checkout_expiry_year');
        everythingValidated = false;
    }
}

function validateCVV() {
    value = $('#checkout_expiry_cvv').val();
    if (value.trim().length == 0) {
        $('#checkout_expiry_cvv_validator').html('This field cannot be blank');
        showCardValidator('#checkout_expiry_cvv');
        everythingValidated = false;
    }
    try {
        if (value.trim().length != 3) {
            $('#checkout_expiry_cvv_validator').html('Invalid CVV (CVV must be of 3 digits)');
            everythingValidated = false;
            showCardValidator('#checkout_expiry_cvv');
        } else {
            cvv = parseInt(value);
            if (cvv >= 0 && cvv <= 999) {
                hideCardValidator('#checkout_expiry_cvv');
            } else {
                $('#checkout_expiry_cvv_validator').html('Invalid CVV (CVV must be of 3 digits)');
                everythingValidated = false;
                showCardValidator('#checkout_expiry_cvv');
            }
        }

    } catch (Exception) {
        $('#checkout_expiry_cvv_validator').html('Invalid Year');
        everythingValidated = false;
        showCardValidator('#checkout_expiry_cvv');
    }
}
function CancelCard() {
    $('#checkout_add_card_hover, #cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').addClass('hideElement');
}

function deleteAddress(aid) {
    $('#checkout_add_address_hover_finalize, #cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').removeClass('hideElement');

    $.ajax({
        url: '/api/DeleteUserAddress.aspx',
        method: 'POST',
        data: {
            "aid": aid
        },
        success: function (data) {
            $('#cart_page_add_address_loader').addClass('hideElement');
            JSONObj = JSON.parse(data);
            if (JSONObj.Response == "OK") {
                if (addressIDSelected == aid) {
                    location.href = location.href;
                }
                close_hover();
                LoadAddress();
                $('#cart_page_address_finalize_loader,#checkout_add_address_hover_finalize, #checkout_fixed_background_cart_update').addClass('hideElement');
            } else {
                if (JSONObj.Response == "NOT_AUTHENTICATED") {
                    location.href = "/signout";
                } else {
                    $('#checkout_address_add_hover_inner_finalize_text').html('Unable to update the address, please try again later');
                }
            }
        }
    });
}

function AddAddress() {
    $('.checkout-field-validator').addClass('hideElement');
    $('.checkout_hover_box_input_values').removeClass('checkout-input-hover-validator');
    everythingValidated = true;
    var itemsToCheck = ['name', 'street_name', 'appt_number', 'postal_code', 'phone_number'];
    for (items in itemsToCheck) {
        ValidateEmptyness('checkout_' + itemsToCheck[items]);
    }
    validatePostalCode();
    validatePhoneNumber();
    validateDropdown();
    console.log(everythingValidated);
    if (everythingValidated == true) {
        $('#cart_page_add_address_loader').removeClass('hideElement');
        $.ajax({
            url: '/api/AddUserAddress.aspx',
            method: 'POST',
            data: {
                "Name": $("#checkout_name").val(),
                "Street": $("#checkout_street_name").val(),
                "Appt": $("#checkout_appt_number").val(),
                "PostalCode": $('#checkout_postal_code').val(),
                "PhoneNumber": $('#checkout_phone_number').val(),
                "c": $('#ddl_city').val()
            },
            cache: false,
            success: function (data) {
                $('#cart_page_add_address_loader').addClass('hideElement');
                JSONObj = JSON.parse(data);
                if (JSONObj.Response == "OK") {
                    close_hover();
                    LoadAddress();
                } else {
                    if (JSONObj.Response == "NOT_AUTHENTICATED") {
                        location.href = "/signout";
                    } else {
                        $('#AbleToAddAddress').html('<div class="unableToAddAddress primary-admin-background-color color-white bold">Unable to add address this time, please try again later<div class="floatRight cursor-pointer" onclick = "close_hover();" ><i class="material-icons">clear</i></div ></div >');
                    }
                }
            }
        });
    }
}

function ValidateEmptyness(objectHTML) {
    console.log(objectHTML);
    if ($('#' + objectHTML).val().trim().length == 0) {
        $('#' + objectHTML).addClass('checkout-input-hover-validator');
        $('#' + objectHTML + '_validator').removeClass('hideElement');
        $('#' + objectHTML + '_validator').html('This field cannot be blank');
        everythingValidated = false;
    }

}

function validatePostalCode() {
    console.log($('#REGEX_POSTAL_CODE').val());
    console.log(RegExp($('#REGEX_POSTAL_CODE').val()).test($('#checkout_postal_code').val().trim()));
    if (RegExp($('#REGEX_POSTAL_CODE').val()).test($('#checkout_postal_code').val().trim()) == false) {
        $('#checkout_postal_code_validator').html('Postal code is not in correct format');
        $('#checkout_postal_code').addClass('checkout-input-hover-validator');
        $('#checkout_postal_code_validator').removeClass('hideElement');
        everythingValidated = false;
    }
}

function populateCity() {
    if ($('#ddl_province')[0].selectedIndex == 0) {
        $('#ddl_city').empty();
        $('#ddl_city').append(new Option('Select City (Please select province first)'));
        $('#ddl_city').prop('disabled', true);
        $('#ddl_city').css('opacity', 0.3);
    } else {
        $('#ddl_city').empty();
        $('#ddl_city').append(new Option('Select City (Please select province first)'));
        $('#ddl_city').prop('disabled', true);
        $('#ddl_city').css('opacity', 0.3);
        $('#cart_page_add_address_loader').removeClass('hideElement');
        $.ajax({
            url: '/api/GetCityList.aspx',
            method: 'POST',
            data: { 'province': $('#ddl_province').val() },
            success: function (data) {
                $('#cart_page_add_address_loader').addClass('hideElement');
                $('#ddl_city').empty();
                $('#ddl_city').append(new Option('Select City'));
                var JSONObj = JSON.parse(data);
                if (JSONObj.HasCityList == true) {
                    for (i = 0; i < JSONObj.ListOfCities.ListOfCities.length; i++) {
                        $('#ddl_city').append(new Option(JSONObj.ListOfCities.ListOfCities[i].CityName, JSONObj.ListOfCities.ListOfCities[i].CityID));
                    }
                    $('#ddl_city').prop('disabled', false);
                    $('#ddl_city').css('opacity', 1);
                } else {
                    $('#AbleToAddAddress').html('<div class="unableToAddAddress primary-admin-background-color color-white bold">Unable to fetch city list this time, please try again later<div class="floatRight cursor-pointer" onclick = "close_hover();" ><i class="material-icons">clear</i></div ></div >');
                }
            }
        })

    }
}

function validatePhoneNumber() {
    if ($('#checkout_phone_number').val().trim().length != 10) {
        $('#checkout_phone_number_validator').html('Please enter a valid phone number');
        $('#checkout_phone_number').addClass('checkout-input-hover-validator');
        $('#checkout_phone_number_validator').removeClass('hideElement');
        everythingValidated = false;
    }
}

function validateDropdown() {
    if ($('#ddl_province')[0].selectedIndex == 0) {
        $('#ddl_province_validator').html('Please select a province');
        $('#ddl_province').addClass('checkout-input-hover-validator');
        $('#ddl_province_validator').removeClass('hideElement');
        everythingValidated = false;
    } else {
        $('#ddl_province').removeClass('checkout-input-hover-validator');
        $('#ddl_province_validator').addClass('hideElement');
    }

    if ($('#ddl_city')[0].selectedIndex == 0) {
        $('#ddl_city_validator').html('Please select a city');
        $('#ddl_city').addClass('checkout-input-hover-validator');
        $('#ddl_city_validator').removeClass('hideElement');
        everythingValidated = false;
    } else {
        $('#ddl_city').removeClass('checkout-input-hover-validator');
        $('#ddl_city_validator').addClass('hideElement');
    }
}

function InitiateOrderPipeline() {
    console.log(addressIDSelected);
    if (addressIDSelected == 0) {
        alert('No address selected, please select the address');
        $('#checkout_page_address_list').addClass('checkout_address_not_selected');
        return false;
    }

    if (cardIDSelected == 0) {
        alert('No card selected, please select the card');
        $('#checkout_page_card_list_results').addClass('checkout_address_not_selected');
        return false;
    }

    $('#checkout_add_address_hover_finalize, #cart_page_address_finalize_loader, #checkout_fixed_background_cart_update').removeClass('hideElement');
    $('#checkout_address_add_hover_inner_finalize_text').html('Placing Order, Please wait <br> Validating Session');
    UserValidationPipelineFlow();
}

function UserValidationPipelineFlow() {
    $.ajax({
        url: '/api/AuthenticateUser.aspx',
        method: 'GET',
        cache: false,
        success: function (parameter) {
            JSONObj = JSON.parse(parameter);
            if (JSONObj.IsAuthenticated == true) {
                $('#checkout_address_add_hover_inner_finalize_text').html('Placing Order, Please wait <br> Validating Cart');
                CartValidationPipelineFlow();
            } else {
                location.href = 'Signin?r=/checkout';
            }
        }
    });
}

function CartValidationPipelineFlow() {
    $.ajax({
        url: '/api/GetCart.aspx',
        method: 'GET',
        cache: false,
        success: function (parameter) {
            totalCost = 0;
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
                $('#cart__status').addClass('hideElement');
                totalItemCount = 0;
                if (JSON.parse(data.Cart).HasValidationErrors == true) {
                    location.href = "/cart";
                } else {
                    $('#checkout_address_add_hover_inner_finalize_text').html('Placing Order, Please wait');
                    FinalizeOrderPipeline();
                }
            } else {
                location.href = "/cart";
            }
        }
    });
}

function FinalizeOrderPipeline() {
    $.ajax({
        url: '/api/PlaceOrder.aspx',
        method: 'POST',
        data: { "aid": addressIDSelected, "cid": cardIDSelected},
        cache: false,
        success: function (parameter) {
            console.log(parameter);
            JSONObj = JSON.parse(parameter);
            console.log(JSONObj);
            if (JSONObj.Response == 'OK') {
                location.href = '/orders/' + JSONObj.data.OrderID + '?firstTimeView=true';
            } else {
                $('#cart_page_address_finalize_loader').addClass('hideElement');
                $('#checkout_address_add_hover_inner_finalize_text').html('Unable to create an order this time, please try again later');
            }
        }
    });
}