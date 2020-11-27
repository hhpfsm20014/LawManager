<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="Preferences.aspx.cs" Inherits="Preferences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<link id="theme" rel="stylesheet" type="text/css" href="style.css" title="theme" />
<link href="login-box.css" rel="stylesheet" type="text/css" />
    <table style="width: 85%; margin-left: 62px; border: 100px;" class="preferences-box">
        <tr>
            <td style="width: 180px; height: 48px;">
                &nbsp;</td>
            <td style="height: 48px">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MyAccount.aspx">[My Account]</asp:HyperLink>
&nbsp;
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Preferences.aspx">[Preferences]</asp:HyperLink>
            </td>
        </tr>
        <%--   <tr>
            <td style="width: 180px; height: 34px;">
                &nbsp; Notify ON</td>
            <td style="height: 34px">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="New Issue" />
&nbsp;
                <asp:CheckBox ID="CheckBox2" runat="server" Text="New Project" />
            </td>
        </tr>
        <tr>
            <td style="width: 180px; height: 34px;">
                &nbsp; Notify ON</td>
            <td style="height: 34px">
                <asp:CheckBox ID="CheckBox3" runat="server" Text="File Share" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 180px">
                &nbsp;&nbsp;Language</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
        <td style="width:180px">
        &nbsp;&nbsp;Default Project</td>
        <td><asp:DropDownList ID="ddlProject" runat="server" DataSourceID="ddlProjectidpw" 
                DataTextField="project_name" DataValueField="project_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="ddlProjectidpw" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]">
            </asp:SqlDataSource>
            </td>
            
        </tr>
        <tr>
            <td style="width: 180px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 180px">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblReply" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 180px">
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="imgUpdate" ImageUrl="~/images/updatebtnfinal.png" 
                    runat="server" onclick="imgUpdate_Click" />
                <%--<asp:Image ID="imgUpdate" runat="server" 
                     />--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <%-- <asp:Image ID="imgReset" runat="server" ImageUrl="~/images/resetbtn.png" />--%>
            </td>
        </tr>
        <tr>
            <td style="width: 180px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </asp:Content>


