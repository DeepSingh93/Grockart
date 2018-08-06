<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="Default_home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="home-background">
        <div class="container">
            <div class="col-lg-5">
                <div class="Grockart-text mistral-font">
                    <img src="assets/images/grockart_text_white_transparent.PNG" />
                </div>
                <div class="grocery-subheader-1">
                    COMPARE GROCERIES FROM THE BEST AND GET DELIVERED ON TIME
                </div>
                <div class="grocery-subheader-2">
                    3 SUPERSTORES
                    <br />
                    50+ PRODUCTS<br />
                    HOME DELIVERED
                </div>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-6 signupHomePageBox">
                <div class="warning-tab-register-home hideElement" id="validationIssuesBox" runat="server">
                    THERE ARE SOME VALIDATION ISSUES, PLEASE RECHECK YOUR FORM
                </div>
                <div class="signupTextHomeBox">
                    SIGN UP
                </div>
                <div class="inputElementsLoginBox" id="firstNameWrapper">
                    <input placeholder="First Name" id="firstName" runat="server" />
                    <div id="firstNameValidation" runat="server" class="warningRegister hideElement">First Name is required <i class="material-icons floatRight">warning</i></div>
                </div>
                <div class="inputElementsLoginBox" id="lastNameWrapper">
                    <input placeholder="Last Name" id="lastName" runat="server" />
                    <div id="lastNameValidation" runat="server" class="warningRegister hideElement">Last Name is required <i class="material-icons floatRight">warning</i></div>
                </div>
                <div class="inputElementsLoginBox" id="emailWrapper">
                    <input placeholder="Email" id="email" runat="server" />
                    <div id="emailValidation" runat="server" class="warningRegister hideElement">Email is required <i class="material-icons floatRight">warning</i></div>
                </div>
                <div class="inputElementsLoginBox" id="passwordWrapper">
                    <input placeholder="Password" id="password" type="password" runat="server" />
                    <div id="passwordValidation" runat="server" class="warningRegister hideElement">Password is required <i class="material-icons floatRight">warning</i></div>
                </div>
                <div class="inputElementsLoginBox" id="confirmPasswordWrapper">
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
    </div>
    <script src="assets/js/register.js"></script>
    <input type="hidden" id="REGEX_EMAIL" runat="server" />
    <input type="hidden" id="REGEX_PASSWORD" runat="server" />
    <input type="hidden" id="REGEX_PASSWORD_ERROR_TEXT" runat="server" />
</asp:Content>

