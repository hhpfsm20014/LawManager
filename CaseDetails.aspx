<%@ Page Title="Case Details - Law Management Software" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="CaseDetails.aspx.cs" Inherits="CaseDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
    <h1>Case Details:</h1>
    <hr />
    <div class="customBoxforTable" style="width: 700px;">

        <h3>Court:
            <asp:Label ID="lblCourt" runat="server" Text="Label"></asp:Label>
            <br />
            Case No:
            <asp:Label ID="lblCaseNo" runat="server" Text="Label"></asp:Label>
            <br />
            Case Name:
            <asp:Label ID="lblCaseName" runat="server" Text="Label"></asp:Label>
            <br />
            Nature of Case:
            <asp:Label ID="lblNature" runat="server" Text="Label"></asp:Label>
            <br />
            Case Start Date:
            <asp:Label ID="lblCaseStrtDate" runat="server" Text="Label"></asp:Label>
        </h3>

        <br />
        <table style="width: 700px;" class="table">
            
            <tr>

                <td style="width: 150px;">Name of The Parties:
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblNameFrstParty" runat="server" Text="Label"></asp:Label>


                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblNameScndParty" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>

                <td style="width: 150px;">Contact Details:
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblContctFrst" runat="server" Text="Label"></asp:Label>
                </td>


                <td style="width: 150px;">
                    <asp:Label ID="lblContctScnd" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>


            <tr>

                <td style="width: 150px;">Lawyer:
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblLawerFrst" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblLawerScnd" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>

                <td style="width: 150px;">Lawyer Contact Details:
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblLawterContctFrst" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblLawterContctScnd" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>

            <tr>

                <td style="width: 150px;">Case Summary:
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblSummary" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>

        </table>
    </div>
    <h2>Date Summary:</h2>
    <asp:GridView ID="NxtDateGrid" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="300px">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
</asp:Content>

