class register {
    constructor() {
        this.validated = true;
        this.firstName = $('#firstName').val().trim();
        this.lastname = $('#lastName').val().trim();
        this.email = $('#email').val().trim();
        this.password = $('#password').val().trim();
        this.confirmPassword = $('#confirmPassword').val().trim();
    }

    inputValidation() {
        Loader.startLoad();
        Loader.startHomeRegistrationLoad();
        this.validateTextBox(this.firstName, "#firstName", "First Name is required");
        this.validateTextBox(this.lastname, "#lastName", "Last Name is required");
        this.validateTextBox(this.email, "#email", "Email is required");
        this.validateTextBox(this.password, "#password", "Password is required");
        this.validateTextBox(this.confirmPassword, "#confirmPassword", "Confirm Password is required");
        this.checkEmailFormat();
        this.validatePassword();
        this.checkConfirmPassword();
        console.log(this.validated);
        if (this.validated == false) {
            Loader.stopLoad();
            Loader.stopHomeRegistrationLoad();
        }
        return this.validated;
    }

    checkEmailFormat() {

        if (RegExp($('#REGEX_EMAIL').val()).test($('#email').val().trim().toLowerCase()) == false) {
            this.validated = false;
            this.showWarningLabel("#email", 'Email address is not in correct format');
        } else {
            this.hideWarningLabel("#email");
        }
    }

    validatePassword() {
        if (RegExp($('#REGEX_PASSWORD').val()).test(this.password) == false) {
            this.validated = false;
            this.showWarningLabel("#password", 'Password should be minimum 8 characters (alteast 1 lower case, 1 upper case 1 special character and 1 number)');
        } else {
            this.hideWarningLabel("#password");
        }
    }

    checkConfirmPassword() {
        if (this.password != this.confirmPassword) {
            this.validated = false;
            this.showWarningLabel("#confirmPassword", 'Password and confirm password doesn\'t match');
        }
    }

    validateTextBox(param1, param2, param3) {
        if (param1.trim().length == 0) {
            this.validated = false;
            this.showWarningLabel(param2, param3);
        } else {
            this.hideWarningLabel(param2);
        }
    }
    showWarningLabel(param1, param2) {
        $(param1).addClass('warning-color');
        $(param1 + 'Validation').html(param2 + '<i class="material-icons floatRight">warning</i>');
        $(param1 + 'Validation').fadeIn();
    }

    hideWarningLabel(param1) {
        $(param1).removeClass('warning-color');
        $(param1 + 'Validation').fadeOut();
    }

    reset() {
        this.hideWarningLabel("#firstName");
        this.hideWarningLabel("#lastName");
        this.hideWarningLabel("#email");
        this.hideWarningLabel("#password");
        this.hideWarningLabel("#confirmPassword");
    }
}

//$(document).ready(function () {
//    // register the event
//    const registerObj = new register();
//    $('#registerHomeButton').on('click', function () {
//        registerObj.reset();
//        registerObj.getInputValues();
//        registerObj.register();
//    });
//});