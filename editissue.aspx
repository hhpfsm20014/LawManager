<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="editissue.aspx.cs" Inherits="editissue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;Issue&nbsp;
                <asp:DropDownList ID="DDLIssue" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="issue_name" DataValueField="issue_id" 
                    onselectedindexchanged="DDLIssue_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                    SelectCommand="SELECT [issue_id], [issue_name] FROM [Issue_Master]">
                </asp:SqlDataSource>
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
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Issue ID</td>
            <td>
                <asp:TextBox ID="txtissueid" runat="server"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="height: 22px">
                Issue Type</td>
            <td>
                <asp:DropDownList ID="txtissuetype" runat="server">
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem>Programming</asp:ListItem>
                    <asp:ListItem>Design</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 22px">
                </td>
            <td>
                Issue Description*</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtissuedesc" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <%--<td>
                <asp:Button ID="btnUpdateIssues" runat="server" Text="Update Issues" onclick="btnUpdateIssues_Click"/> 
                     
            </td>--%>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

