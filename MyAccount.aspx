<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="login-box.css" rel="stylesheet" type="text/css" />

    <div>
        <h1 style="margin-left:230px;">Account Details:</h1>
        <table style="border-style: none; border-color: inherit; border-width: 100px; width: 77%;
            margin-left: 110px; height: 408px;" class="myaccount-box">
            <tr>
                <td style="width: 180px; height: 34px;">
                    &nbsp;
                </td>
                <td style="height: 34px; width: 310px;">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MyAccount.aspx">[My Account]</asp:HyperLink>
                    &nbsp;
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Preferences.aspx">[Preferences]</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td style="width: 180px; height: 34px;">
                    &nbsp; Email_ID:</td>
                <td style="height: 34px; width: 310px;">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 180px; height: 34px;">
                    &nbsp; Password:</td>
                <td style="height: 34px; width: 310px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="166px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="You can't leave this empty." ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 180px">
                    &nbsp;&nbsp;Confirm Password:</td>
                <td style="width: 310px">
                    <asp:TextBox ID="TextBox2"  runat="server" Width="166px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ErrorMessage="Passwords don't match" ControlToCompare="TextBox2" 
                        ControlToValidate="TextBox1"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 180px">
                    &nbsp;&nbsp;Contact_No:</td>
                <td style="width: 310px">
                    <asp:TextBox ID="TextBox3" runat="server" Width="166px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 180px">
                    &nbsp; Name:</td>
                <td style="width: 310px">
                    <asp:TextBox ID="txtName" runat="server" Width="166px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 180px; height: 34px;">
                    &nbsp;&nbsp;Access Level:</td>
                <td style="height: 34px; width: 310px;">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 180px; height: 34px;">
                    Last Visited</td>
                <td style="height: 34px; width: 310px;">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 180px; height: 13px;">
                    </td>
                <td style="height: 13px; width: 310px;">
                    <asp:Label ID="lblReply" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 180px">
                    &nbsp;
                </td>
                <td style="width: 310px">
                    &nbsp; &nbsp;<asp:ImageButton ID="imgUpdate" runat="server" 
                        ImageUrl="~/images/updatebtnfinal.png" onclick="imgUpdate_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
