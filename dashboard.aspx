<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<%@ MasterType VirtualPath="~/DashMaster.master" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="login-box.css" rel="stylesheet" type="text/css" />
    <table width="100%">
        <tr>
            <td align="right">

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <br />
    <b>Search By Case No. / Name:</b><asp:TextBox ID="txtSearchItem" runat="server" Width="267px"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    <b>Sort By Category:</b>
    <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3"
        DataTextField="CategoryName" DataValueField="CategoryId"
        AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
        <asp:ListItem Selected="false" Value="-1">All</asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
        SelectCommand="SELECT [CategoryId], [CategoryName] FROM [CaseCategory]"></asp:SqlDataSource>
    <br /><br /><br /><br />
    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0">
        <tr>
            <td>
                <h1>Case List</h1>
                <hr />
            </td>
            <%=getWhileLoopData()%>
        </tr>
    </table>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"></asp:SqlDataSource>

</asp:Content>
