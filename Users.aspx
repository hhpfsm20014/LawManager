<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td>
            &nbsp;Project :
            &nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="project_name" 
                DataValueField="project_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]">
            </asp:SqlDataSource>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;
            &nbsp;
            &nbsp;
            &nbsp;
        </td>
    </tr>
    </table>
</asp:Content>


