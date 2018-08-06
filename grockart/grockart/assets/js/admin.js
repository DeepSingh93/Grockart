function GetMenuTree() {
    var Menu = [
        ['ADMIN MANAGEMENT', '/admin'],
        ['GENERAL SETTINGS', '/admin-settings'],
        ['SUPERSTORE', '/admin-store'],
        ['CATEGORY', '/admin-category'],
        //['PRODUCT', '/admin-product'],
        //['PRODUCT BY STORE', '/admin-product-by-store'],
        //['ORDERS', '/admin-orders'],
        ['LOG', '/grockart_log']
    ];

    return Menu;
}

function GetAdminList() {
    startAdminManagementLoader();
    clearNotificationArea();
    $('#admin-management-results-area').addClass('hideElement');
    // this will get the list of admins
    $.ajax({
        url: '/api/FetchAdminList.aspx',
        method: 'GET',
        success: function (parameter) {

            let data = JSON.parse(parameter);
            if (data == null) {
                location.href = "/signout";
            }
            if (data.length > 0) {
                HTMLOutput = '<div class="row">';
                for (i = 0; i < data.length; i++) {
                    if (i == data.lengh - 1) {
                        HTMLOutput += '</div>';
                    }

                    if (i % 2 == 0 && i > 0) {
                        HTMLOutput += '</div><div class="row admin-names">';
                    }

                    HTMLOutput += '<div class="col-lg-6">' +
                        '<div class="bold">' + data[i].FirstName + ' ' + data[i].LastName + '</div>' +
                        '<div class="fs10">' + data[i].Email + '</div>' +
                        '<div onclick=removeAdmin(\'' + data[i].Email + '\'); class="warning-background-color primary-white removeAdminBox">REMOVE ADMIN</div>' +
                        '</div>';
                }
                $('#admin-management-results-area').html(HTMLOutput);
                stopAdminManagementLoader();

            } else {
                showErrorDiv('No results found, if you think this is an error, please check logs');
                stopUserManagementLoader();
                $('#admin-result-area-01').addClass('hideElement');
            }
            console.log(data);
        }
    });
}
function showErrorDiv(value) {
    $('#notificationArea').removeClass('hideElement');
    $('#notificationArea').html(value);
    stopAdminManagementLoader();
}
function clearNotificationArea() {
    if ($('#notificationArea').hasClass('hideElement') == false) {
        $('#notificationArea').addClass('hideElement');
    }
}
function startUserManagementLoader() {
    $('#admin-management-user-list-loader-area, #admin-user-list-area').removeClass('hideElement');
    $('#admin-management-user-list-results-area').addClass('hideElement');
}
function stopUserManagementLoader() {
    $('#admin-management-user-list-loader-area').addClass('hideElement');
    $('#admin-management-user-list-results-area').removeClass('hideElement');
}
function startAdminManagementLoader() {
    $('#loginPageLoader, #admin-management-loader-area, #admin-result-area-01').removeClass('hideElement');
    $('#admin-management-results-area').addClass('hideElement');
}
function stopAdminManagementLoader() {
    $('#loginPageLoader, #admin-management-loader-area').addClass('hideElement');
    $('#admin-management-results-area').removeClass('hideElement');
}
function removeAdmin(Email) {
    clearNotificationArea();
    // confirm from the user first
    confirmation = confirm('Do you really want to remove this email as admin ? All the tokens associated with this email id will be deleted');
    if (confirmation) {
        startAdminManagementLoader();

        $.ajax({
            url: '/api/RemoveAdmin.aspx',
            method: 'POST',
            data: { 'e': Email },
            success: function (parameter) {
                console.log(parameter);
                let data = JSON.parse(parameter);
                if (data == null) {
                    location.href = "/signout";
                }
                if (data.Value == 'OK') {
                    InitSearch();
                    GetAdminList();

                } else {
                    showErrorDiv('Unable to remove the user, please check logs');
                }

            }
        });
    }
}
function addAdmin(Email) {
    clearNotificationArea();
    // confirm from the user first
    confirmation = confirm('Do you really want to add this email as admin ? All the tokens associated with this email id will be deleted');
    if (confirmation) {
        startAdminManagementLoader();

        $.ajax({
            url: '/api/AddAdmin.aspx',
            method: 'POST',
            data: { 'e': Email },
            success: function (parameter) {

                let data = JSON.parse(parameter);
                if (data == null) {
                    location.href = "/signout";
                }
                if (data.Value == 'OK') {
                    InitSearch();
                    GetAdminList();

                } else {
                    showErrorDiv('Unable to add the user, please check logs');
                }

            }
        });
    }
}
// source : https://stackoverflow.com/a/5926782
function RegisterSearch() {
    //setup before functions
    var typingTimer;                //timer identifier
    var doneTypingInterval = 1000;  //time in ms (5 seconds)

    //on keyup, start the countdown
    $('#admin-search-users').keyup(function () {
        clearNotificationArea();
        clearTimeout(typingTimer);
        if ($('#admin-search-users').val().trim().length == 0) {
            $('#admin-user-list-area').addClass('hideElement');
            stopUserManagementLoader();
        }
        if ($('#admin-search-users').val().trim().length > 0) {
            startUserManagementLoader();
            $('#admin-user-list-area').removeClass('hideElement');
            typingTimer = setTimeout(InitSearch, doneTypingInterval);
        } else {
            $('#admin-user-list-area').addClass('hideElement');
            stopUserManagementLoader();
        }
    });
}
function InitSearch() {
    clearNotificationArea();
    if ($('#admin-search-users').val().trim().length > 0) {
        startUserManagementLoader();

        //do something

        $.ajax({
            url: '/api/FetchUserList.aspx',
            method: 'POST',
            data: { 's': $('#admin-search-users').val().trim() },
            success: function (parameter) {

                let data = JSON.parse(parameter);
                if (data == null) {
                    location.href = "/signout";
                }
                console.log(data);
                if (data.length > 0) {
                    HTMLOutput = '<div class="row">';
                    if (data.length == 0) {
                        $('#admin-user-list-area').addClass('hideElement');
                        $('#notificationArea').removeClass('hideElement');
                        $('#notificationArea').text('No user found');
                        stopUserManagementLoader();
                    }

                    for (i = 0; i < data.length; i++) {
                        if (i == data.lengh - 1) {
                            HTMLOutput += '</div>';
                        }

                        if (i % 2 == 0 && i > 0) {
                            HTMLOutput += '</div><div class="row">';
                        }

                        HTMLOutput += '<div class="col-lg-6">' +
                            '<div class="bold">' + data[i].FirstName + ' ' + data[i].LastName + '</div>' +
                            '<div class="fs10">' + data[i].Email + '</div>';

                        console.log(data[i].IsAdmin);
                        if (data[i].IsAdmin == true) {
                            HTMLOutput += '<div onclick=removeAdmin(\'' + data[i].Email + '\'); class="warning-background-color primary-white removeAdminBox resultBox">REMOVE ADMIN</div>';
                        } else {
                            HTMLOutput += '<div onclick=addAdmin(\'' + data[i].Email + '\'); class="addAdmin primary-white removeAdminBox resultBox">ADD ADMIN</div>';
                        }
                        HTMLOutput += '</div>';
                    }

                    $('#admin-management-user-list-results-area').html(HTMLOutput);
                    stopUserManagementLoader();
                } else {
                    showErrorDiv('No results found, if you think this is an error, please check logs');
                    stopUserManagementLoader();
                    $('#admin-user-list-area').addClass('hideElement');
                }
            }
        });
    }
}

$(document).ready(function () {
    // load the menu
    Menu = GetMenuTree();
    outputMenu = '';
    for (i = 0; i < Menu.length; i++) {
        if (Menu[i][1] == window.location.pathname) {
            outputMenu += '<div class="bold warningcolor admin-menu-highlight">';
        } else {
            outputMenu += '<div class="bold admin-categories" onclick="location.href=\'' + Menu[i][1] + '\'">';
        }

        outputMenu += Menu[i][0];

        outputMenu += '</div>';
    }

    $('#admin-menu-items').html(outputMenu);
});

function FetchCategory() {
    startAdminCategoryManagementLoader();
    // Ajax query to fetch list of categories
    $.ajax({
        url: '/api/FetchCategoryList.aspx',
        method: 'GET',
        success: function (parameter) {
            stopAdminCategoryManagementLoader();
            let data = JSON.parse(parameter);
            console.log(data);
            if (data.Code == 'OK') {
                HTMLOutput = '<div class="row admin-category-row admin-category-name"><div class="col-lg-6 bold">Category Name</div><div class="col-lg-3 bold admin-category-delete-icon ">Modify Category</div><div class="col-lg-3 bold admin-category-delete-icon ">Delete Category</div></div><div class="row">';
                if (data.length == 0) {
                    $('#admin-user-list-area').addClass('hideElement');
                    $('#notificationArea').removeClass('hideElement');
                    $('#notificationArea').text('No user found');
                    stopCategoryLoader();
                }

                for (i = 0; i < data.CategoriesList.length; i++) {
                    if (i == data.lengh - 1) {
                        HTMLOutput += '</div>';
                    }
                    HTMLOutput += '</div><div class="row admin-category-row">';
                    console.log(data.CategoriesList[i].CategoryId);
                    HTMLOutput += '<div class="col-lg-6 admin-category-name">' + data.CategoriesList[i].CategoryName + '</div><div class="col-lg-3 admin-category-delete-icon" onclick="modifyCategory(\'' + data.CategoriesList[i].CategoryId + '\',\'' + encodeURI(data.CategoriesList[i].CategoryName) + '\')"><i class="material-icons">edit</i></div><div class="col-lg-3 admin-category-delete-icon" onclick="deleteAdminCategory(\'' + data.CategoriesList[i].CategoryId + '\')"><i class="material-icons">delete</i></div>';

                    HTMLOutput += '</div>';
                }

                $('#admin-category-results-area-content').html(HTMLOutput);
            } else {
                if (data.Response == "NOT_AUTHENTICATED") {
                    location.href = "/signout";
                } else {
                    $('#notificationArea').html(data.Response);
                    showAdminCategoryNotification();
                    $('#admin-category-loader-area').addClass('hideElement');
                }
            }
        }
    });
}
function deleteAdminCategory(categoryID) {
    if (confirm('Are you sure you want to delete the category ? This cannot be undone and this event will be logged')) {
        startAdminCategoryManagementLoader();
        $.ajax({
            url: '/api/DeleteCategory.aspx',
            method: 'POST',
            data: { 'c': categoryID },
            success: function (parameter) {
                stopAdminCategoryManagementLoader();
                let data = JSON.parse(parameter);
                console.log(data);
                if (data.Code == 'OK') {
                    FetchCategory();
                } else {
                    if (data.Response == "NOT_AUTHENTICATED") {
                        location.href = "/signout";
                    } else {
                        $('#notificationArea').html(data.Response);
                        showAdminCategoryNotification();
                    }
                }
            }
        });
    }

}

function modifyCategory(categoryID, categoryName) {
    $('#newCategoryName').val('');
    $('#admin_category_categoryID').html(categoryID);
    $('#admin_category_categoryName').html(decodeURI(categoryName));
    $('#admin_modifyCategoryBox, #admin_modifyErrorMessage').addClass('hideElement');
    $('#admin_modifyBackground, #admin_modifyContainer').fadeIn('fast');
}
function admin_hide_modifyCategory() {
    $('#admin_modifyBackground, #admin_modifyContainer').fadeOut('fast');
}
function admin_confirm_modifyCategory() {
    if ($('#newCategoryName').val().trim().length == 0) {
        $('#admin_modifyErrorMessage').text('New Category is blank, please enter a valid category');
        $('#admin_modifyErrorMessage').removeClass('hideElement');
        $('#newCategoryName').val($('#newCategoryName').val().trim());
    } else {
        $('#admin_modifyErrorMessage').addClass('hideElement');
        $('#admin_modifyCategoryBox').removeClass('hideElement');
        $.ajax({
            url: '/api/ModifyCategory.aspx',
            method: 'POST',
            data: { 'c': $('#admin_category_categoryID').text(), 'cn': $('#newCategoryName').val().trim() },
            success: function (parameter) {
                stopAdminCategoryManagementLoader();
                let data = JSON.parse(parameter);
                console.log(data);
                if (data.Code == 'OK') {
                    $('#admin_modifyBackground, #admin_modifyContainer').fadeOut('fast');
                    FetchCategory();
                } else {
                    if (data.Response == "NOT_AUTHENTICATED") {
                        location.href = "/signout";
                    } else {
                        $('admin_modifyErrorMessage').html(data.Response);
                        $('#admin_modifyErrorMessage').removeClass('hideElement');
                        $('#admin_modifyCategoryBox').addClass('hideElement');
                    }
                }
            }
        });
    }
}
function showAdminCategoryNotification() {
    $('#notificationArea').removeClass('hideElement');
}

function clearCategoryNotificationArea() {
    $('#notificationArea').addClass('hideElement');
}

function startAdminCategoryManagementLoader() {
    $('#results').addClass('hideElement');
    $('#admin-category-loader-area').removeClass('hideElement');
    clearCategoryNotificationArea();
}

function stopAdminCategoryManagementLoader() {
    $('#results').removeClass('hideElement');
    $('#admin-category-loader-area').addClass('hideElement');
}

function AddCategory() {
    $('#TxtCategoryName').val($('#TxtCategoryName').val().trim());
    categoryName = $('#TxtCategoryName').val();
    if (categoryName.trim().length == 0) {
        alert('Category name is empty, please enter a valid category name');
    } else {
        startAdminCategoryManagementLoader();
        $('#Add-Category-Loader').removeClass('hideElement');
        $.ajax({
            url: '/api/AddCategory.aspx',
            method: 'POST',
            data: { 'c': categoryName },
            success: function (parameter) {
                stopAdminCategoryManagementLoader();
                $('#TxtCategoryName').val('');
                $('#Add-Category-Loader').addClass('hideElement');
                let data = JSON.parse(parameter);
                console.log(data);
                if (data.Code == 'OK') {
                    FetchCategory();
                    stopCategoryLoader();
                } else {
                    if (data.Response == "NOT_AUTHENTICATED") {
                        location.href = "/signout";
                    } else {
                        $('#notificationArea').html(data.Response);
                        showAdminCategoryNotification();
                    }
                }
            }
        });
    }
}

function fetchStores() {
    $('#admin-stores-results-area-content').addClass('hideElement');
    $.ajax({
        url: '/api/FetchStoreList.aspx',
        method: 'GET',
        success: function (parameter) {
            $('#admin-store-loader-area').addClass('hideElement');
            let data = JSON.parse(parameter);
            console.log(data);
            if (data.Code == 'OK') {
                HTMLOutput = '<div class="row admin-category-row admin-category-name"><div class="col-lg-3 bold">Store Name</div><div class="col-lg-3 bold">Store Logo</div><div class="col-lg-3 bold admin-category-delete-icon ">Modify Store</div><div class="col-lg-3 bold admin-category-delete-icon ">Delete Store</div></div><div class="row">';
                if (data.StoreList.length == 0) {
                    $('#admin-user-list-area').addClass('hideElement');
                    $('#notificationArea').removeClass('hideElement');
                    $('#notificationArea').text('No store found');
                    $('#admin-stores-results-area-content').addClass('hideElement');
                } else {
                    for (i = 0; i < data.StoreList.length; i++) {
                        if (i == data.lengh - 1) {
                            HTMLOutput += '</div>';
                        }
                        HTMLOutput += '</div><div class="row admin-category-row">';
                        HTMLOutput += '<div class="col-lg-3 admin-category-name">' + data.StoreList[i].StoreName + '</div><div class="col-lg-3 admin-category-name"><img class="admin-store-logo" src=\'assets/' + data.StoreList[i].StoreLogo + '\'></img></div><div class="col-lg-3 admin-category-delete-icon" onclick="modifyStore(\'' + data.StoreList[i].StoreID + '\',\'' + encodeURI(data.StoreList[i].StoreName) + '\',\'' + encodeURI(data.StoreList[i].StoreLogo) + '\')"><i class="material-icons">edit</i></div><div class="col-lg-3 admin-category-delete-icon" onclick="deleteStore(\'' + data.StoreList[i].StoreID + '\')"><i class="material-icons">delete</i></div>';
                        HTMLOutput += '</div>';
                    }
                    $('#admin-stores-results-area-content').removeClass('hideElement');
                    $('#admin-stores-results-area-content_Results').html(HTMLOutput);
                }

            } else {
                if (data.Response == "NOT_AUTHENTICATED") {
                    location.href = "/signout";
                } else {
                    $('#notificationArea').html(data.Response);
                    $('#notificationArea').removeClass('hideElement');
                    $('#admin-store-loader-area').addClass('hideElement');
                }
            }
        }
    });
}

function modifyStore(storeID, storeName, storeImage) {
    $('#ModifyStoreLogo').val('');
    $('#newstoreName').val('');
    $('#ModifyStoreLogoName_Old').val(decodeURI(storeImage));
    $('#ModifyStoreName_Old_01').val(storeName);
    $('#modifyStoreID').val(storeID);
    $('#admin_store_storeID').html(storeID);
    $('#admin_store_storeName').html(decodeURI(storeName));
    $('#admin_store_storeLogo').html('<img class="admin-store-logo" src=\'assets/' + storeImage + '\'></img>');
    $('#admin_modifystoreBox, #admin_modifyErrorMessage').addClass('hideElement');
    $('#admin_modifyBackground, #admin_modifyContainer').fadeIn('fast');
}

function deleteStore(storeID) {
    if (confirm('Are you sure you want to delete the store ? This cannot be undone and this event will be logged')) {
        startAdminCategoryManagementLoader();
        $.ajax({
            url: '/api/DeleteStore.aspx',
            method: 'POST',
            data: { 'sid': storeID },
            success: function (parameter) {
                stopAdminCategoryManagementLoader();
                let data = JSON.parse(parameter);
                console.log(data);
                if (data.Code == 'OK') {
                    $('#notificationArea').html(data.Response);
                    $('#notificationArea').css('display', 'block');
                    fetchStores();
                } else {
                    if (data.Response == "NOT_AUTHENTICATED") {
                        location.href = "/signout";
                    } else {
                        $('#notificationArea').html(data.Response);
                        $('#notificationArea').css('display', 'block');
                    }
                }
            }
        });
    }
}

function admin_hide_modifystore() {
    $('#admin_modifyBackground, #admin_modifyContainer').fadeOut('fast');
}

function fetchProducts() {
    $('#admin-stores-results-area-content').addClass('hideElement');
    $.ajax({
        url: '/api/FetchProductAdminPanel.aspx',
        method: 'GET',
        success: function (parameter) {
            $('#admin-store-loader-area').addClass('hideElement');
            let data = JSON.parse(parameter);
            console.log(data);
            if (data.Code == 'OK') {
                HTMLOutput = '<div class="row admin-category-row admin-category-name"><div class="col-lg-3 bold">Product Name</div><div class="col-lg-3 bold">Product Image</div><div class="col-lg-3 bold admin-category-delete-icon ">Modify Product</div><div class="col-lg-3 bold admin-category-delete-icon ">Delete Product</div></div><div class="row">';
                if (data.ProductList.length == 0) {
                    $('#admin-user-list-area').addClass('hideElement');
                    $('#notificationArea').removeClass('hideElement');
                    $('#notificationArea').text('No Products found');
                    $('#admin-stores-results-area-content').addClass('hideElement');
                } else {
                    for (i = 0; i < data.ProductList.length; i++) {
                        if (i == data.lengh - 1) {
                            HTMLOutput += '</div>';
                        }
                        HTMLOutput += '</div><div class="row admin-category-row">';
                        HTMLOutput += '<div class="col-lg-3 admin-category-name">' + data.ProductList[i].ProductName + '</div><div class="col-lg-3 admin-category-name"><img class="admin-store-logo" src=\'assets/' + data.ProductList[i].ProductImage + '\'></img></div><div class="col-lg-3 admin-category-delete-icon" onclick="modifyStore(\'' + data.ProductList[i].ProductId + '\',\'' + encodeURI(data.ProductList[i].ProductName) + '\',\'' + encodeURI(data.ProductList[i].ProductImage) + '\')"><i class="material-icons">edit</i></div><div class="col-lg-3 admin-category-delete-icon" onclick="deleteStore(\'' + data.ProductList[i].ProductId + '\')"><i class="material-icons">delete</i></div>';
                        HTMLOutput += '</div>';
                    }
                    $('#admin-stores-results-area-content').removeClass('hideElement');
                    $('#admin-stores-results-area-content_Results').html(HTMLOutput);
                }

            } else {
                if (data.Response == "NOT_AUTHENTICATED") {
                    location.href = "/signout";
                } else {
                    $('#notificationArea').html(data.Response);
                    $('#notificationArea').removeClass('hideElement');
                    $('#admin-store-loader-area').addClass('hideElement');
                }
            }
        }
    });
}
function fetchProductByStores() {
    $('#admin-stores-results-area-content').addClass('hideElement');
    $.ajax({
        url: '/api/FetchProductByStore.aspx',
        method: 'GET',
        success: function (parameter) {
            $('#admin-store-loader-area').addClass('hideElement');
            let data = JSON.parse(parameter);
            console.log(data);
            if (data.Code == 'OK') {
                HTMLOutput = '<div class="row admin-category-row admin-category-name"><div class="col-lg-2 bold">Product Name</div><div class="col-lg-2 bold">Category Name</div><div class="col-lg-2 bold">Store Name</div><div class="col-lg-1 bold">Quantity</div><div class="col-lg-1 bold">Price</div><div class="col-lg-1 bold">Unit</div><div class="col-lg-1 bold admin-category-delete-icon ">Modify</div><div class="col-lg-1 bold admin-category-delete-icon ">Delete</div></div><div class="row">';
                if (data.ProductByStoreList.length == 0) {
                    $('#admin-user-list-area').addClass('hideElement');
                    $('#notificationArea').removeClass('hideElement');
                    $('#notificationArea').text('No store found');
                    $('#admin-stores-results-area-content').addClass('hideElement');
                } else {
                    for (i = 0; i < data.ProductByStoreList.length; i++) {
                        if (i == data.lengh - 1) {
                            HTMLOutput += '</div>';
                        }
                        HTMLOutput += '</div><div class="row admin-category-row">';
                        HTMLOutput += '<div class="col-lg-2 admin-category-name">' + data.ProductByStoreList[i].ProductName + '</div><div class="col-lg-2 admin-category-name" > ' + data.ProductByStoreList[i].CategoryName + '</div ><div class="col-lg-2 admin-category-name">' + data.ProductByStoreList[i].StoreName + '</div ><div class="col-lg-1 admin-category-name">' + data.ProductByStoreList[i].Quantity + '</div ><div class="col-lg-1 admin-category-name">' + data.ProductByStoreList[i].Price + '</div ><div class="col-lg-1 admin-category-name">' + data.ProductByStoreList[i].QuantityPerUnit + '</div>';
                        HTMLOutput += '</div>';
                    }
                    $('#admin-stores-results-area-content').removeClass('hideElement');
                    $('#admin-stores-results-area-content_Results').html(HTMLOutput);
                }

            } else {
                if (data.Response == "NOT_AUTHENTICATED") {
                    location.href = "/signout";
                } else {
                    $('#notificationArea').html(data.Response);
                    $('#notificationArea').removeClass('hideElement');
                    $('#admin-store-loader-area').addClass('hideElement');
                }
            }
        }
    });
}

function admin_modify_store() {
    $('#admin_modifyErrorMessage').addClass('hideElement');
    if ($('#ModifyStoreLogo').val() != '' || $('#newstoreName').val() != '') {
        return true;
    }
    $('#admin_modifyErrorMessage').html('Either store name or store logo should contain values, both are empty');
    $('#admin_modifyErrorMessage').removeClass('hideElement');
    return false;
   
}