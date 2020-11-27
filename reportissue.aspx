<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="reportissue.aspx.cs" Inherits="reportissue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%;">
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="font-family: Arial, Helvetica, sans-serif; width: 185px">
                &nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; width: 280px">
                Choose Project
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                Enter Report Details&nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                Category</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                Priority</td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                Summary</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                Description</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                Upload File</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 185px">
                &nbsp;</td>
            <td style="width: 280px">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" />
            </td>
        </tr>
    </table>
</asp:Content>

