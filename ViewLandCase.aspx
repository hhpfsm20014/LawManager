<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="ViewLandCase.aspx.cs" Inherits="ViewLandCase" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
    <head>
        <title></title>
        <style type="text/css">
            .Background {
                background-color: Gray;
                filter: alpha(opacity='0');
                opacity: 0.7;
                padding: 10px;
                border: 3px solid #dedede;
            }

            .Panel {
                background: url(images/login-box-backg.png);
                width: 455px;
                height: 410px;
            }

            .style9 {
                text-align: center;
            }
        </style>

    </head>
    <body>
        <div class="container">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
    
            <h1>Add Land Case:</h1>
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <td style="width: 25%">
                        <h3><a href="ViewAddEditLandCase.aspx">
                            <img src="images/file_add.png" alt="Add" height="14px" width="16px" />
                            New Land Case</a></h3>
                    </td>
            
                </tr>
            </table>
            <br />
            <h1>Edit Land Case:</h1>
            <asp:GridView ID="CaseGrid" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="CaseGrid_RowCommand" DataKeyNames="LandCaseId" AutoGenerateColumns="False">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>           
                    <asp:ButtonField Text="Edit" CommandName="CaseEdit" />
                    <asp:ButtonField Text="Delete" CommandName="CaseDelete" />
                        <asp:BoundField DataField="CourtAndCase" HeaderText="Court Name And Case No" />
                        <asp:BoundField DataField="CaseNature" HeaderText="Case Nature" />
                        <asp:BoundField DataField="Parties" HeaderText="Parties" />
                        <asp:BoundField DataField="LandSchedule" HeaderText="Land Schedule" />
                        <asp:BoundField DataField="PlaintDescription" HeaderText="Plaint Description" />
                        <asp:BoundField DataField="WSDescription" HeaderText="WS Description" />
                        <asp:BoundField DataField="PlaintWSDate" HeaderText="Plaint WS Date" />
                        <asp:BoundField DataField="NextDateAndReason" HeaderText="Next Date And Reason" />
                        <asp:BoundField DataField="CaseOutcomeAndDate" HeaderText="Case Result And Date" />
                        <asp:BoundField DataField="AppealOrRevisionNoAndDate" HeaderText="Appeal Or Revision No And Date" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                </Columns>
            </asp:GridView>
        </div>
    </body>
</html>
</asp:Content>
