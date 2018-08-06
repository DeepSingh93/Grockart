<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" ClientIDMode="Static" CodeFile="Admin_Settings.aspx.cs" Inherits="Admin_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPageName" runat="Server">
    General Settings
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="p10px">
        <asp:Label runat="server" Width="100%" ID="TextStatus"></asp:Label>
    </div>
    <div class="admin_general_Settings_header">
        MAINTENANCE SETTINGS
    </div>
    <div class="p10px">
        Maintenance Mode: 
        <asp:DropDownList runat="server" CssClass="Dropdown_Admin" ID="dropdown_maintenance_mode"></asp:DropDownList>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Btn_Update_maintenance_Click" ID="btn_Update_maintenance" Text="UPDATE" />

    </div>
    <div class="p10px">
        Maintenance Mode Text : 
        <asp:TextBox ID="txt_Maintenance_text" CssClass="TextBox_Admin" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Btn_Update_maintenance_text_Click_Click" ID="Btn_Update_maintenance_text_Click" Text="UPDATE" />
    </div>

    <div class="admin_general_Settings_header">
        GROCERY SETTINGS
    </div>

    <div class="p10px">
        Maximum Quantity User Can Buy : 
        <asp:TextBox ID="txt_max_qty" CssClass="TextBox_Admin" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Btn_max_qty_Click" ID="Btn_max_qty" Text="UPDATE" />
    </div>

    <div class="admin_general_Settings_header">
        REGEX SETTINGS
    </div>
    <div class="p10px">
        REGEX For Password Registration : 
        <asp:TextBox ID="txt_regex_password" CssClass="TextBox_Admin" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Update_Regex_Password_Click" ID="Update_Regex_Password" Text="UPDATE" />
    </div>
    <div class="p10px">
        REGEX Text For Invalid Password : 
        <asp:TextBox ID="txt_regex_invalid_password_text" CssClass="TextBox_Admin" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Btn_update_txt_Regex_invalid_password_Click" ID="Btn_update_txt_Regex_invalid_password" Text="UPDATE" />
    </div>
    <div class="p10px">
        REGEX Email : 
        <asp:TextBox ID="txt_regex_email" CssClass="TextBox_Admin" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Btn_update_regex_email_Click" ID="Btn_update_regex_email" Text="UPDATE" />
    </div>
    <div class="p10px">
        REGEX Postal Code : 
        <asp:TextBox ID="txt_regex_postalcode" CssClass="TextBox_Admin" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Btn_update_regex_postalcode_Click" ID="Btn_update_regex_postalcode" Text="UPDATE" />
    </div>
    <div class="admin_general_Settings_header">
        HOME PAGE SETTINGS
    </div>
     <div class="p10px">
        Enable Home Page: 
        <asp:DropDownList runat="server" CssClass="Dropdown_Admin"  ID="DropDownEnableHomePage"></asp:DropDownList>
        <asp:Button runat="server" CssClass="Btn_Admin" OnClick="Btn_Update_Home_Page_Click" ID="Btn_Update_Home_Page" Text="UPDATE" />
    </div>
</asp:Content>

