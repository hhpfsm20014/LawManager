<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 41px">
                &nbsp;</td>
            <td style="width: 327px">
                &nbsp;
            </td>
            <td style="width: 204px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 41px">
                &nbsp;</td>
            <td style="width: 327px">
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="233px" 
                    ImageUrl="~/images/modules.jpg" Width="264px" 
                    onclick="ImageButton1_Click" />
            </td>
            <td style="width: 204px">
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:ImageButton ID="ImageButton2" runat="server" Height="233px" 
                    ImageUrl="~/images/users.jpg" Width="264px" onclick="ImageButton2_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 41px">
                &nbsp;</td>
            <td style="width: 327px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; COUNT NUMBER OF MODULES IN PROJECTS</td>
            <td style="width: 204px">
                &nbsp;
            </td>
            <td>
                &nbsp;
                COUNT NUMBERS OF USERS ASSIGN ON THE PROJECTS</td>
        </tr>
        <tr>
            <td style="width: 41px">
                &nbsp;</td>
            <td style="width: 327px">
                &nbsp;</td>
            <td style="width: 204px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 41px">
                &nbsp;</td>
            <td style="width: 327px">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton3" runat="server" Height="233px" 
                    ImageUrl="~/images/Files.jpg" Width="264px" onclick="ImageButton3_Click" />
            </td>
            <td style="width: 204px">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton4" runat="server" 
                    ImageUrl="~/images/Project.jpg" Height="233px" Width="264px" 
                    onclick="ImageButton4_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 41px">
                &nbsp;</td>
            <td style="width: 327px">
                &nbsp;&nbsp;&nbsp; COUNT NUBERS OF FILES ON THE ISSUES&nbsp;</td>
            <td style="width: 204px">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp; COUNT ISSUES/MODULES ON RESPECTIVE PROJECT</td>
        </tr>
    </table>
</asp:Content>

