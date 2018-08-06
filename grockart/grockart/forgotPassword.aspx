<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="forgotPassword.aspx.cs" Inherits="forgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/css/slick.css" rel="stylesheet" />
    <link href="assets/css/slick-theme.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container text-center">
        <h2>Forgot your password ??</h2>
         <h4>Enter your Email</h4>
        
            <div class="loginMessage" style="float:left" id="LoginMessage" runat="server" visible="false">
            </div>
            <div class="row text-center">
                <input placeholder="Email" class="login_page_loginbox" id="TxtEmail" runat="server" />
            </div>
        <div class="row text-center MT20px">
                <asp:Button ID="submit"  CssClass="primary-background-color primary-white loginButotn" OnClick="Submit_Click" runat="server" Text="Submit" />
            </div>        
    </div>
</asp:Content>
