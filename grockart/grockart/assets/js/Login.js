class Login {
    constructor() {
        this.email = $('#Email').val().trim();
        this.password = $('#password').val().trim();
    }

    validate() {
        this.validated = true;
        this.validateTextBox(this.email, "#Email", "Email is required");
        this.validateTextBox(this.password, "#password", "Password is required");
        this.checkEmailFormat();
        this.validatePassword();
        if (this.validated) {
            Loader.startLoginPageLoader();
        }
        return this.validated;
    }
    checkEmailFormat() {

        if (RegExp($('#REGEX_EMAIL').val()).test(this.email.trim().toLowerCase()) == false) {
            this.validated = false;
            this.showWarningLabel("#Email", 'Email address is not in correct format');
        } else {
            this.hideWarningLabel("#Email");
        }
    }

    validatePassword() {
        if (RegExp($('#REGEX_PASSWORD').val()).test(this.password) == false) {
            this.validated = false;
            this.showWarningLabel("#password", $('#REGEX_PASSWORD_ERROR_TEXT').val());
        } else {
            this.hideWarningLabel("#password");
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

    hideWarningLabel(param1) {
        $(param1).removeClass('login-warning-color ');
        $(param1 + 'Validation').fadeOut();
    }

    showWarningLabel(param1, param2) {
        $(param1).addClass('login-warning-color ');
        $(param1 + 'Validation').html(param2 + '<i class="material-icons floatRight">warning</i>');
        $(param1 + 'Validation').fadeIn();
    }

}