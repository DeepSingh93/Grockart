<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="assets/js/Login.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">

        <div class="col-lg-12 loginBoxImage">
            <img src="assets/images/logoWithoutText.png" />
        </div>
        <div class="col-lg-8 col-lg-offset-2 loginBox primary-color no-padding">
            <div class="linear-activity showLoader hideElement" id="loginPageLoader">
                <div class="indeterminate"></div>
            </div>
            <div class="row loginBoxText">
                LOGIN
            </div>
            <div class="loginMessage" id="LoginMessage" runat="server" visible="false">
            </div>
            <div class="row text-center">
                <input placeholder="Email" class="login_page_loginbox" id="Email" runat="server" />
            </div>
            <div class="row">
                <div id="EmailValidation" runat="server" class="login_email_validation col-lg-6 col-lg-offset-3 hideElement">Email is required <i class="material-icons floatRight">warning</i></div>
            </div>
            <div class="row text-center">
                <input placeholder="Password" type="password" class="login_page_loginbox" id="password" runat="server" />
            </div>
            <div class="row">
                <div id="passwordValidation" runat="server" class="login_email_validation col-lg-6 col-lg-offset-3 hideElement">Password is required <i class="material-icons floatRight">warning</i></div>
            </div>
            <div class="row text-center MT20px">
                <asp:Button ID="login" OnClick="Login_Click" OnClientClick="return new Login().validate();" CssClass="primary-background-color primary-white loginButotn " runat="server" Text="LOGIN" />
            </div>
            <div class="row text-center MB10px ">
                <a href="Register.aspx" class="primary-color">Not Registered ? Register here
                </a>
            </div>
        </div>
    </div>
    <input type="hidden" id="REGEX_EMAIL" runat="server" />
    <input type="hidden" id="REGEX_PASSWORD" runat="server" />
    <input type="hidden" id="REGEX_PASSWORD_ERROR_TEXT" runat="server" />
</asp:Content>

