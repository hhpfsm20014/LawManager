<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="assignissues.aspx.cs" Inherits="assignissues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                Project:&nbsp;&nbsp;
                <asp:DropDownList ID="ddlProject" runat="server" DataSourceID="SqlDataSource1" DataTextField="project_name"
                    DataValueField="project_id" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"
                    AutoPostBack="True" AppendDataBoundItems="True">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>
            </td>
            <td>
                Module:&nbsp;&nbsp;
                <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Issue:&nbsp;&nbsp;
                <asp:DropDownList ID="ddlIssue" runat="server" AutoPostBack="True" AppendDataBoundItems="True" >
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 100%;">
        <tr>
            <td>
                Issue Assignment ID&nbsp;
            </td>
            <td>
                <asp:Label ID="lblIssueId" runat="server"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Priority
            </td>
            <td>
                <asp:RadioButtonList ID="RblPriority" runat="server" 
                    RepeatDirection="Horizontal" Visible="False">
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem Selected="True">Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Start Date
            </td>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                End Date
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Issue Notes
            </td>
            <td>
                <asp:TextBox ID="txtIssueNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <table style="width: 100%;">
        <tr>
            <td style="text-align: center">
                Add Users:
            </td>
            <td style="margin-left: 40px">
                <asp:DropDownList ID="ddlAddUsers" runat="server" DataSourceID="SqlDataSource2" 
                    DataTextField="user_name" DataValueField="user_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                    SelectCommand="SELECT [user_id], [user_name] FROM [User_Master] WHERE ([status] = @status)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="active" Name="status" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnAddUser" runat="server" onclick="btnAddUser_Click" 
                    style="text-align: right" Text="Add User" />
&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <table>
        
    
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
    </table>
</asp:Content>
