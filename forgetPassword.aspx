<%@ Page Title="" Language="C#" MasterPageFile="~/outsideView.master" AutoEventWireup="true"
    CodeFile="forgetPassword.aspx.cs" Inherits="forgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="login-box.css" rel="stylesheet" type="text/css" />
    <table style="width: 485px; height: 410px; margin-left: 260px; background-image: url(images/forgetpw.png);">
        <tr>
            <td style="padding-left: 80px; padding-bottom: 30px; height: 201px;" class="forget-box"
                valign="bottom">
                E-mail ID:
                <asp:TextBox ID="txtEmail" class="form-login" runat="server" Style="margin-left: 8px"
                    Width="179px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 180px; padding-top: 20px;" valign="top">
                <asp:Button ID="btnForget" runat="server" OnClick="btnForget_Click" Text="Submit" />
                <br />
                <br />
                <asp:Label ID="lblMessage" runat="server" ForeColor="White"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You can't leave this empty."
                    ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Invalid Email" ControlToValidate="txtEmail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
</asp:Content>
