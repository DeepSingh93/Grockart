
$(document).ready(function () {
    $('.responsiveElement-lazyloader, .responsiveElement').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 3
    });

    var parsed_qs = new URL(window.location.href);
    if (parsed_qs.searchParams.get("k") != null) {
        $('#input-search').val(parsed_qs.searchParams.get("k"));
        CurrentKeywordSearch = parsed_qs.searchParams.get("k");
        InitProductSearch();
    } else {
        FetchProducts();
    }

});

function FetchProducts() {

    $.ajax({
        url: '/api/FetchProducts.aspx',
        method: 'GET',
        cache: false,
        success: function (parameter) {
            $('#productsPage').html('');
            let data = JSON.parse(parameter);
            if (data.HasProducts) {
                let CategoryCount = data.TotalCategories;
                console.log(data);
                for (i = 0; i < CategoryCount; i++) {
                    html = '<div class="row col-lg-12 item-header" > ' + data.productsByCategory[i].CategoryName + '</div > <div class="row responsiveElement category_' + data.productsByCategory[i].CategoryName.replace(' ', '_') + '">';
                    for (j = 0; j < data.productsByCategory[i].Product.length; j++) {
                        html += '    <div>' +
                            '<div class="items-box shadowAroundBox" onclick="RedirectProductPage(\'' + data.productsByCategory[i].Product[j].pbsID + '\');">' +
                            '<div class="row product-header">' +
                            data.productsByCategory[i].Product[j].ProductName +
                            '</div>' +
                            '<div class="row no-margin">' +
                            '<img class="product-image" src="assets/' + data.productsByCategory[i].Product[j].ProductImage + '" />' +
                            '</div>' +
                            '<div class="row no-margin">' +
                            '<img class="product-store" src="assets/' + data.productsByCategory[i].Product[j].StoreLogo + '" />' +
                            '</div>' +
                            '<div class="row no-margin product-price">' +
                            data.productsByCategory[i].Product[j].Price + '$ / ' + data.productsByCategory[i].Product[j].QuantityType +
                            '</div>' +
                            '<div class="row no-margin product-add-cart-button" id="cart_' + data.productsByCategory[i].Product[j].pbsID + '" onclick="AddToCart(event, \'' + data.productsByCategory[i].Product[j].pbsID + '\', this);">' +
                            '<span class="pos-abs">' +
                            '<i class="material-icons">add_shopping_cart</i>' +
                            '</span>' +
                            '<span class="pos-add-cart">ADD TO CART' +
                            '</span>' +
                            '</div>' +
                            '<div class="row no-margin product-add-button" id="buyNow_' + data.productsByCategory[i].Product[j].pbsID+'  onclick="BuyNow(event, \'' + data.productsByCategory[i].Product[j].pbsID + '\');">' +
                            '<span class="pos-abs">' +
                            '<i class="material-icons">shopping_cart</i>' +
                            '</span>' +
                            '<span class="pos-add-cart">BUY NOW' +
                            '</span>' +
                            '</div>' +
                            '</div>' +
                            '</div>';
                    }
                    html += '</div>';
                    $('#productsPage').append(html);
                    $('.category_' + data.productsByCategory[i].CategoryName.replace(' ', '_')).slick({
                        dots: true,
                        infinite: false,
                        speed: 300,
                        slidesToShow: 4,
                        slidesToScroll: 3,
                        responsive: [
                            {
                                breakpoint: 1024,
                                settings: {
                                    slidesToShow: 4,
                                    slidesToScroll: 3,
                                    infinite: true,
                                    dots: true
                                }
                            },
                            {
                                breakpoint: 600,
                                settings: {
                                    slidesToShow: 3,
                                    slidesToScroll: 2
                                }
                            },
                            {
                                breakpoint: 480,
                                settings: {
                                    slidesToShow: 2,
                                    slidesToScroll: 1
                                }
                            }
                        ]
                    });
                }
                $('#productsPage-lazyloader, #productsErrorPage').addClass('hideElement');
                $('#productSearchBox, #productsPage').removeClass('hideElement');
            } else {

                $('#productsPage-lazyloader, #productSearchBox').addClass('hideElement');
                $('#productsErrorPage').removeClass('hideElement');
            }

        }
    });



}

function RedirectProductPage(id) {
    location.href = 'Products/' + id;
}


function BuyNow(e, product) {
    var evt = e ? e : window.event;
    if (evt.stopPropagation) evt.stopPropagation();
    if (evt.cancelBubble != null) evt.cancelBubble = true;
    let PreviousStateHTML = $('#' + product).html();
    $('#buyNow_' + product).html("<div class='loader-cart'></div>");
    $.ajax({
        url: '/api/ClearCart.aspx',
        method: 'POST',
        cache: false,
        success: function (parameter) {
            data = JSON.parse(parameter);
            console.log(data.Response);
            if (data.Response == 'OK') {
                $.ajax({
                    url: '/api/AddToCart.aspx',
                    method: 'POST',
                    data: { 'pbsid': object.id.split('_')[1] },
                    cache: false,
                    success: function (parameter) {
                        console.log(parameter);

                        let data = JSON.parse(parameter);
                        if (data.Response == 'OK') {
                            location.href = '/cart';
                        } else {
                            $('#cart_warn_status').html(data.ResponseString);
                            $('#cart_warn_status').removeClass('hideElement');
                        }
                        $('#master_page_CART').slideDown('fast');
                        $('#' + object.id).html(PreviousStateHTML);
                    }
                });
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
stopAJAXSearch = false;
CurrentKeywordSearch = '';
// source : https://stackoverflow.com/a/5926782
function RegisterProductSearch() {
    //setup before functions
    var typingTimer;                //timer identifier
    var doneTypingInterval = 1000;  //time in ms (5 seconds)
    alreadySlicked = false;
    //on keyup, start the countdown
    $('#input-search').keyup(function () {
        $('#productsErrorPage').addClass('hideElement');
        if (alreadySlicked == false) {
            $('.responsiveElement-lazyloader').slick('unslick');
            $('.responsiveElement-lazyloader').slick({
                dots: false,
                infinite: true,
                speed: 300,
                slidesToShow: 4,
                slidesToScroll: 3,
            });
            alreadySlicked = true;
        }
        $('#productsPage').addClass('hideElement');
        $('#productsPage-lazyloader').removeClass('hideElement');
        if ($('#input-search').val().trim().length == 0) {
            $('#productsPage').removeClass('hideElement');
            $('#productsPage-lazyloader').removeClass('hideElement');
            $('#productsPageSearch').addClass('hideElement');
            $('#productsPage').html('');
            $('.responsiveElement-lazyloader').slick('unslick');
            alreadySlicked = false;
            FetchProducts();
        }
        if ($('#input-search').val().trim().length > 0) {
            CurrentKeywordSearch = $('#input-search').val().trim();
            $('#productsPage, #productsPageSearch').addClass('hideElement');
            $('#productsPage-lazyloader').removeClass('hideElement');
            if (stopAJAXSearch == false) {
                stopAJAXSearch = true;
                typingTimer = setTimeout(InitProductSearch, doneTypingInterval);
            }
        } else {
            $('#productsPage').removeClass('hideElement');
            $('#productsPage-lazyloader').addClass('hideElement');
        }
    });
}

function InitProductSearch() {
    $('#productsPageSearch').html('');
    $.ajax({
        url: '/api/FetchProducts.aspx?k=' + encodeURI($('#input-search').val().trim()),
        method: 'GET',
        success: function (parameter) {
            stopAJAXSearch = false;
            let data = JSON.parse(parameter);
            console.log(data);
            if (data.HasProducts) {
                if (data.KeywordSearch == CurrentKeywordSearch) {
                    let CategoryCount = data.TotalCategories;
                    console.log(data);
                    for (i = 0; i < CategoryCount; i++) {
                        html = '<div class="row col-lg-12 item-header" > ' + data.productsByCategory[i].CategoryName + '</div > <div class="row responsiveElement category_search' + data.productsByCategory[i].CategoryName.replace(' ', '_') + '">';
                        for (j = 0; j < data.productsByCategory[i].Product.length; j++) {
                            html += '    <div>' +
                                '<div class="items-box shadowAroundBox" onclick="RedirectProductPage(\'' + data.productsByCategory[i].Product[j].pbsID + '\');">' +
                                '<div class="row product-header">' +
                                data.productsByCategory[i].Product[j].ProductName +
                                '</div>' +
                                '<div class="row no-margin">' +
                                '<img class="product-image" src="assets/' + data.productsByCategory[i].Product[j].ProductImage + '" />' +
                                '</div>' +
                                '<div class="row no-margin">' +
                                '<img class="product-store" src="assets/' + data.productsByCategory[i].Product[j].StoreLogo + '" />' +
                                '</div>' +
                                '<div class="row no-margin product-price">' +
                                data.productsByCategory[i].Product[j].Price + '$ / ' + data.productsByCategory[i].Product[j].QuantityType +
                                '</div>' +
                                '<div class="row no-margin product-add-cart-button" id="cart_' + data.productsByCategory[i].Product[j].pbsID + '" onclick="AddToCart(event, \'' + data.productsByCategory[i].Product[j].pbsID + '\', this);">' +
                                '<span class="pos-abs">' +
                                '<i class="material-icons">add_shopping_cart</i>' +
                                '</span>' +
                                '<span class="pos-add-cart">ADD TO CART' +
                                '</span>' +
                                '</div>' +
                                '<div class="row no-margin product-add-button" id="buyProduct_' + data.productsByCategory[i].Product[j].pbsID + ' onclick="BuyNow(event, \'' + data.productsByCategory[i].Product[j].pbsID + '\');">' +
                                '<span class="pos-abs">' +
                                '<i class="material-icons">shopping_cart</i>' +
                                '</span>' +
                                '<span class="pos-add-cart">BUY NOW' +
                                '</span>' +
                                '</div>' +
                                '</div>' +
                                '</div>';
                        }
                        html += '</div>';
                        $('#productsPageSearch').append(html);
                        $('.category_search' + data.productsByCategory[i].CategoryName.replace(' ', '_')).slick({
                            dots: true,
                            infinite: false,
                            speed: 300,
                            slidesToShow: 4,
                            slidesToScroll: 3,
                            responsive: [
                                {
                                    breakpoint: 1024,
                                    settings: {
                                        slidesToShow: 4,
                                        slidesToScroll: 3,
                                        infinite: true,
                                        dots: true
                                    }
                                },
                                {
                                    breakpoint: 600,
                                    settings: {
                                        slidesToShow: 3,
                                        slidesToScroll: 2
                                    }
                                },
                                {
                                    breakpoint: 480,
                                    settings: {
                                        slidesToShow: 2,
                                        slidesToScroll: 1
                                    }
                                }
                            ]
                        });
                    }
                    $('#productsPage-lazyloader, #productsErrorPage').addClass('hideElement');
                    $('#productSearchBox,#productsPageSearch').removeClass('hideElement');
                }
            } else {
                $('#productsPage-lazyloader, #productsPageSearch').addClass('hideElement');
                $('#productsErrorPage').removeClass('hideElement');
                $('#productsErrorPageheaderText').html(data.responseString);
            }
        }
    });

}

