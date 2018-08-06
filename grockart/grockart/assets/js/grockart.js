class Loader {
    static stopLoad() {
        if ($('#headerLoader').hasClass("showLoader")) {
            $('#headerLoader').removeClass("showLoader");
            $('#headerLoader').addClass("hideLoader");
        }
    }

    static startLoad() {
        if ($('#headerLoader').hasClass("showLoader") == false) {
            $('#headerLoader').addClass("showLoader");
            $('#headerLoader').removeClass("hideLoader");
        }
    }

    static startHomeRegistrationLoad() {
        $('#registerHomeButton').addClass("hideElement");
        $('#registerHomeButtonLoader').removeClass("hideElement");
    }

    static stopHomeRegistrationLoad() {
        $('#registerHomeButton').removeClass("hideElement");
        $('#registerHomeButtonLoader').addClass("hideElement");
    }

    static startLoginPageLoader() {
        $('#loginPageLoader').removeClass("hideElement");
    }

    static stopLoginPageLoader() {
        $('#loginPageLoader').addClass("hideElement");
    }

    static stopUserMenuLoad() {
        $('#ProfileMenuLoader').addClass("hideElement");
    }

    static startUserMenuLoad() {
        $('#ProfileMenuLoader').removeClass("hideElement");
    }

   

}

$(document).ready(function () {
    Loader.stopLoad();

    LoadUserMenu();
    RegisterUserMenu();
    $('#menu').on('mouseleave', function (mouse) {
        var edge = closestEdge(mouse, this);
        if (edge != 'right') {
            $('.masterMenu').addClass('hideElement');
        }
    });

    $('#subMenu').on('mouseleave', function (mouse) {
        var edge = closestEdge(mouse, this);
        if (edge == 'right' || edge === 'bottom' || edge == 'top') {
            $('.masterMenu').addClass('hideElement');
        }
    });

    $('#menuMaster').on('mouseenter', function () {
        $('.masterMenu').removeClass('hideElement');
        $('#subMenu').addClass('hideElement');
        insideSubMenu = true;
    });

    
});

function RegisterUserMenu() {
    $('#rightMenu').on('click', function () {
        $('#MasterProfile').slideDown('fast');
        $('#master_page_CART').slideUp('fast');
        //$('#MasterProfile').removeClass('hideElement');
    });

    $('#MasterProfile').on('mouseleave', function () {
        $('#MasterProfile').slideUp('fast');
    })
}

// source : https://stackoverflow.com/a/44884770
function closestEdge(mouse, elem) {
    var elemBounding = elem.getBoundingClientRect();

    var elementLeftEdge = elemBounding.left;
    var elementTopEdge = elemBounding.top;
    var elementRightEdge = elemBounding.right;
    var elementBottomEdge = elemBounding.bottom;

    var mouseX = mouse.pageX;
    var mouseY = mouse.pageY;

    var topEdgeDist = Math.abs(elementTopEdge - mouseY);
    var bottomEdgeDist = Math.abs(elementBottomEdge - mouseY);
    var leftEdgeDist = Math.abs(elementLeftEdge - mouseX);
    var rightEdgeDist = Math.abs(elementRightEdge - mouseX);

    var min = Math.min(topEdgeDist, bottomEdgeDist, leftEdgeDist, rightEdgeDist);

    switch (min) {
        case leftEdgeDist:
            return "left";
        case rightEdgeDist:
            return "right";
        case topEdgeDist:
            return "top";
        case bottomEdgeDist:
            return "bottom";
    }
}

function LoadMenu(Menu) {
    var _this = JSON.parse(Menu);
    console.log(_this);
    TotalCategory = _this.CategoryCount;
    $('#subMenu').addClass('hideElement');
    Html = "";
    for (i = 0; i < TotalCategory; i++) {
        id = 'Menu_E_' + i;
        Html = "<div id=" + id + " class='items'>" + _this.menu[i].CategoryName + "<img class='floatRight' src='/assets/images/right-arrow.png' /></div >";
        $('#menu').append(Html);
        LoadSubMenu(id, _this.menu[i].SubCategoryList)

    }

}

function LoadSubMenu(id, submenu) {
    
    $('#' + id).on('mouseenter', function () {
        $('#subMenu').html("");
        totalCategories = submenu.length;
        _Html = "";
        for (keys of Object.keys(submenu)) {
            _Html = "<a style='color: black' href='/products/" + keys + "'><div id=" + id + " class='items'>" + submenu[keys] + "</div></a>";
            $('#subMenu').append(_Html);
            $('#subMenu').removeClass('hideElement');
        }
    });
}

function LoadUserMenu() {
    $.ajax({
        url: '/api/UserProfile.aspx',
        method: 'GET',
        success: function (parameter) {
            Loader.stopUserMenuLoad();
            var data = JSON.parse(parameter);
            console.log(data);
            if (data.IsProfileAvailable) {
                if (data.UserProfile.IsAdmin == true) {
                    $('#adminRow').removeClass('hideElement');
                } else {
                    $('#adminRow').addClass('hideElement');
                }

                $('#UserMenu_Paid_Amount').html(data.UserProfile.AmountPaid + '$');
                $('#UserMenu_Owe_Amount').html(data.UserProfile.AmountOwe + '$');
                $('#loaderRow').addClass('hideElement');
                $('#menuRows').removeClass('hideElement');
            } else {
                $('#MenuLoader').text('UNABLE TO LOAD THE MENU')
            }
        }
    });
}