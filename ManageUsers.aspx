<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td><%--onselectedindexchanged="ddlProject_SelectedIndexChanged"--%>
                Project :
                &nbsp;<asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSource1" DataTextField="project_name" 
                    DataValueField="project_id" 
                     AppendDataBoundItems="True">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]">
                </asp:SqlDataSource>
&nbsp;</td>
            <td>
                <%--Issue :
                <asp:DropDownList ID="ddlIssue" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True">
                <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>--%>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Label ID="lblUsers" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False">
                <Columns>
                 <asp:HyperLinkField DataTextField="ID" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~\edituserdetails.aspx?UserID={0}"
                        HeaderText="User ID" Target="_self" ItemStyle-Width="25%">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="Name" HeaderText="User Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="DateCreated" HeaderText="Created Date" />
                    <asp:BoundField DataField="LastVisited" HeaderText="Last Visited" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>

