<%@ Page Title="" Language="C#" MasterPageFile="~/outsideView.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link id="theme" rel="stylesheet" type="text/css" href="style.css" title="theme" />
    <link href="login-box.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/addon.js"></script>
    <script type="text/javascript" language="javascript" src="js/custom.js"></script>
    <div style="padding: 100px 0 0 250px;">
        <div class="login-box">
            <h2>
                Please Sign in</h2>
            <div class="login-box-name" style="margin-top: 20px; height: 15px;">
                Email:</div>
            <div class="login-box-field" style="margin-top: 20px;">
                <asp:TextBox ID="txtEmail" class="form-login" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Invalid EMAIL ID " 
                    SetFocusOnError="True" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Email ID Required" 
                    ValidationGroup="abc" Visible="False"></asp:RequiredFieldValidator>
            </div>
            <div class="login-box-name">
                Password:</div>
            <div class="login-box-field">
                <asp:TextBox ID="txtPassword" type="password" class="form-login" runat="server" 
                    TextMode="Password"></asp:TextBox></div>
            <br />
            <span class="login-box-options">
                <asp:CheckBox ID="cbRemember" runat="server" />
                Remember Me
                <%--<asp:HyperLink ID="HyperLink3" Style="margin-left: 30px;" runat="server" 
                NavigateUrl="~/forgetPassword.aspx">Forgot Password?</asp:HyperLink>--%></span>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ValidationGroup="abc" />
            <br />
            <br />
            <asp:ImageButton ID="imgLogin" Style="margin-left: 90px;" runat="server" ImageUrl="~/images/login-btn.png"
                OnClick="ImageButton1_Click" />
            <%--<asp:HyperLink Style="font-size: 11px;" runat="server" ForeColor="White" NavigateUrl="~/registration.aspx">Not a Member yet?</asp:HyperLink>--%>
        </div>
    </div>
</asp:Content>
