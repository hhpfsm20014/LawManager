<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="createUsers.aspx.cs" Inherits="createUsers" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Create New User:</h1>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Name&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="txtName_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtName" 
                    WatermarkText="*Required">
                </asp:TextBoxWatermarkExtender>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="Name Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Type
            </td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem Selected="True">Developer</asp:ListItem>
                    <asp:ListItem>Viewer</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Email_Id
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="txtEmail_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtEmail" 
                    WatermarkText="*Required">
                </asp:TextBoxWatermarkExtender>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Contact Number
            </td>
            <td>
                <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Status
            </td>
            <td>
                <asp:RadioButtonList ID="radioStatus" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="active">Active</asp:ListItem>
                    <asp:ListItem Value="inactive">Inactive</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="txtPassword" type="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtPasswordConfirm" type="password" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mismatch Password" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="Create User" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
