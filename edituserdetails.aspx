<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="edituserdetails.aspx.cs" Inherits="edituserdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="height: 28px; width: 142px">
                &nbsp;
            </td>
            <td style="height: 28px; width: 201px">
                &nbsp;
            </td>
            <td style="height: 28px; width: 324px">
                <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                &nbsp;
            </td>
            <td style="height: 28px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 22px; width: 142px">
                &nbsp;
            </td>
            <td style="height: 22px; width: 201px">
                Real Name&nbsp;
            </td>
            <td style="height: 22px; width: 324px">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                &nbsp;
            </td>
            <td style="height: 22px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 22px; width: 142px">
                &nbsp;
            </td>
            <td style="height: 22px; width: 201px">
                Email ID
            </td>
            <td style="height: 22px; width: 324px">
                <asp:Label ID="lblEmailID" runat="server" Text="Label"></asp:Label>
                &nbsp;
            </td>
            <td style="height: 22px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                &nbsp;
            </td>
            <td style="width: 201px">
                Access Level
            </td>
            <td style="width: 324px">
                <asp:DropDownList ID="ddlAccess" runat="server">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>Developer</asp:ListItem>
                    <asp:ListItem>Viewer</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                &nbsp;
            </td>
            <td style="width: 201px">
                &nbsp;
            </td>
            <td style="width: 324px">
                <asp:Button ID="btnUpdate" runat="server" Text="Update User" OnClick="btnUpdate_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel2" runat="server" BorderColor="Black" BorderStyle="Solid" Width="500px">
                    <table>
                        <tr>
                            <td style="width: 148px">
                                &nbsp;
                            </td>
                            <td style="width: 284px">
                                <asp:Button ID="btnReset" runat="server" Text="Reset Password" 
                                    Visible="False" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style7" style="width: 188px">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete User" 
                                    onclick="btnDelete_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Assigned Projects
            </td>
            <td>
                <asp:ListBox ID="listUpdate" runat="server" Width="89px"></asp:ListBox>
            &nbsp;&nbsp;
                <asp:Button ID="btnRemove" runat="server" onclick="btnRemove_Click" 
                    Text="Remove Project" />
                <br />
                <asp:Label ID="lbl2txt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Unassigned Projects
            </td>
            <td>
                <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="project_name"
                    DataValueField="project_id"></asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnUser" runat="server" OnClick="btnUser_Click" Text="Add User" />
                <br />
                <asp:Label ID="lbltxt" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
