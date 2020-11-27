<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="EditModule.aspx.cs" Inherits="EditModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="login-box.css" rel="stylesheet" type="text/css" />
    <br />
    <br />
    <table style="width: 89%; margin-right: 0px; margin-bottom: 0px;" class="editmodule-box">
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 286px">
            <%--    Project<asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                    DataTextField="project_name" DataValueField="project_id" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                </asp:DropDownList>--%>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>
            </td>
            <td>
                Module&nbsp;
                <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" DataTextField="module_name"
                    DataValueField="module_id" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                </asp:DropDownList>
                <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                    SelectCommand="SELECT [module_id],[module_id], [module_name] FROM [Project_Module]">
                </asp:SqlDataSource>--%>
            </td>
        </tr>
        <tr>
            <td style="height: 19px">
            </td>
            <td style="height: 19px; width: 286px;">
            </td>
            <td style="height: 19px">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 286px">
                &nbsp;</td>
            <td>
                &nbsp;
                <asp:TextBox ID="txtModuleID" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 286px">
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 286px">
                Module Name
            </td>
            <td>
                <asp:TextBox ID="txtModuleName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtModuleName" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 286px">
                Module Description
            </td>
            <td>
                <asp:TextBox ID="txtModuledesc" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtModuledesc" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 286px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 286px">
                &nbsp;
            </td>
            <td>
                <%--<asp:Button ID="btnUpdate" runat="server" Text="Update Module" 
                    onclick="btnUpdate_Click" />--%>
                <asp:ImageButton ID="imgUpdate" runat="server" ImageUrl="~/images/updatebtnfinal.png"
                    OnClick="imgUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
