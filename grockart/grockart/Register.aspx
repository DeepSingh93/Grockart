<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" MasterPageFile="~/main.master" ClientIDMode="Static" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="assets/js/register.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-12 RegistrationBoxImage">
        <img src="assets/images/logoWithoutText.png" />
    </div>
    <div class="container">
        <div class="col-lg-3"></div>
        <div class="col-lg-6 signupRegistrationPage RegistrationBox">
            <div class="warning-tab-register-home hideElement" id="validationIssuesBox" runat="server">
                THERE ARE SOME VALIDATION ISSUES, PLEASE RECHECK YOUR FORM
            </div>
            <div class="RegistrationBoxText primary-color">
                SIGN UP
            </div>
            <div class="inputElementsRegistrationBox" id="firstNameWrapper">
                <input placeholder="First Name" id="firstName" runat="server" />
                <div id="firstNameValidation" runat="server" class="warningRegister hideElement">First Name is required <i class="material-icons floatRight">warning</i></div>
            </div>
            <div class="inputElementsRegistrationBox" id="lastNameWrapper">
                <input placeholder="Last Name" id="lastName" runat="server" />
                <div id="lastNameValidation" runat="server" class="warningRegister hideElement">Last Name is required <i class="material-icons floatRight">warning</i></div>
            </div>
            <div class="inputElementsRegistrationBox" id="emailWrapper">
                <input placeholder="Email" id="email" runat="server" />
                <div id="emailValidation" runat="server" class="warningRegister hideElement">Email is required <i class="material-icons floatRight">warning</i></div>
            </div>
            <div class="inputElementsRegistrationBox" id="passwordWrapper">
                <input placeholder="Password" id="password" type="password" runat="server" />
                <div id="passwordValidation" runat="server" class="warningRegister hideElement">Password is required <i class="material-icons floatRight">warning</i></div>
            </div>
            <div class="inputElementsRegistrationBox" id="confirmPasswordWrapper">
                <input placeholder="Confirm Password" id="confirmPassword" type="password" />
                <div id="confirmPasswordValidation" runat="server" class="warningRegister hideElement">Confirm password is required <i class="material-icons floatRight">warning</i></div>
            </div>
            <div class="inputElementsRegisterButtonHome">
                <div class="cursor-pointer" id="registerHomeButton">
                    <asp:Button ID="registerButton" CssClass="homeRegisterButton" runat="server" Text="REGISTER" OnClientClick="return new register().inputValidation()" OnClick="RegisterButton_Click" />
                </div>
                <div class="hideElement" id="registerHomeButtonLoader">
                    <div class="lds-ellipsis">
                        <div></div>
                        <div></div>
                        <div></div>
                        <div></div>
                    </div>
                </div>
            </div>
            <div class="row text-center MB10px ">
                <a href="/Login" class="primary-color">Already Registered ? Login here
                </a>
            </div>
        </div>
    </div>
    <input type="hidden" id="REGEX_EMAIL" runat="server" />
    <input type="hidden" id="REGEX_PASSWORD" runat="server" />
    <input type="hidden" id="REGEX_PASSWORD_ERROR_TEXT" runat="server" />
</asp:Content>
