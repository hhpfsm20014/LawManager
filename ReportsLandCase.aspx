<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportsLandCase.aspx.cs" Inherits="ReportsLandCase" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <link href="bootstrap/cs/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="bootstrap/js/bootstrap-datepicker.js"></script>
    <link href="bootstrap/cs/datepicker3.css" rel="stylesheet" />
    <link href="bootstrap/cs/custom.css" rel="stylesheet" />
</head>
<body>
    <div style="width:90%; margin-left:5%; margin-top:5%">
        <form id="form1" runat="server">
        <%--<div class="row">
            <div class="col-md-2" style="text-align:right;">Court No : </div>
            <div class="col-md-4"><asp:TextBox ID="txtCourtNo" runat="server" CssClass="form-control" ></asp:TextBox></div>
            <div class="col-md-2" style="text-align:right;">Case No : </div>
            <div class="col-md-4"><asp:TextBox ID="txtCaseNo" runat="server" CssClass="form-control" ></asp:TextBox></div>
        </div>--%>
            <div class="row" style="height:5px;"></div>
        <%--<div class="row">
            <div class="col-md-2" style="text-align:right;">Nxt Hearing Start Date: </div>
            <div class="col-md-4"><asp:TextBox ID="NxtHearingStartDate" runat="server" CssClass="form-control"></asp:TextBox></div>
            <div class="col-md-2" style="text-align:right;">Nxt Hearing End Date: </div>
            <div class="col-md-4"><asp:TextBox ID="NxtHearingEndDate" runat="server" CssClass="form-control"></asp:TextBox></div>
        </div>--%>
        <div class="row">
            <div class="col-md-12" style="overflow: auto;">
                    <%--<asp:Button  Height="33px" runat="server" CssClass="btn btn-success btn-sm text-shadow" Font-Bold="true" Text="Search" OnClick="btnSearch_Click" />--%>
                    <asp:Button ID="btnExport" Height="33px" runat="server" CssClass="btn btn-success btn-sm text-shadow" Font-Bold="true" Text="Export" OnClick="btnExport_Click" />
                    <asp:GridView ID="CaseGrid" runat="server" HeaderStyle-CssClass="headestyle" RowStyle-CssClass="headestyle" CssClass="display nowrap dataTable dtr-inline" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Results Found..." DataKeyNames="LandCaseId" Width="100%"  AllowPaging="True" OnPageIndexChanging="gvOrder_PageIndexChanging">
                    <%--<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <PagerStyle CssClass="pgr"></PagerStyle>--%>
                    <Columns>
                        <asp:TemplateField HeaderText="District">
                            <ItemTemplate>
                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Court Name And Case No">
                            <ItemTemplate>
                                <asp:Label ID="lblCourtAndCase" runat="server" Text='<%# Eval("CourtAndCase") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Case Nature">
                            <ItemTemplate>
                                <asp:Label ID="lblCaseNature" runat="server" Text='<%# Eval("CaseNature") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Parties">
                            <ItemTemplate>
                                <asp:Label ID="lblParties" runat="server" Text='<%# Eval("Parties") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Land Schedule">
                            <ItemTemplate>
                                <asp:Label ID="lblLandSchedule" runat="server" Text='<%# Eval("LandSchedule") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Plaint Description">
                            <ItemTemplate>
                                <asp:Label ID="lblPlaintDescription" runat="server" Text='<%# Eval("PlaintDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Next Date And Reason">
                            <ItemTemplate>
                                <asp:Label ID="lblNextDateAndReason" runat="server" Text='<%# Eval("NextDateAndReason") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Case Outcome And Date">
                            <ItemTemplate>
                                <asp:Label ID="lblCaseOutcomeAndDate" runat="server" Text='<%# Eval("CaseOutcomeAndDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appeal Or Revision No And Date">
                            <ItemTemplate>
                                <asp:Label ID="lblAppealOrRevisionNoAndDate" runat="server" Text='<%# Eval("AppealOrRevisionNoAndDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appeal Court And Plaint WS Date">
                            <ItemTemplate>
                                <asp:Label ID="lblAppealCourtAndPlaintWSDate" runat="server" Text='<%# Eval("AppealCourtAndPlaintWSDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Advocate Name">
                            <ItemTemplate>
                                <asp:Label ID="lblAdvocateName" runat="server" Text='<%# Eval("AdvocateName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DocumentHandover Date And List">
                            <ItemTemplate>
                                <asp:Label ID="lblDocumentHandoverDateAndList" runat="server" Text='<%# Eval("DocumentHandoverDateAndList") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Court Submitted Document Note">
                            <ItemTemplate>
                                <asp:Label ID="lblCourtSubmittedDocumentNote" runat="server" Text='<%# Eval("CourtSubmittedDocumentNote") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Next Appeal Date And Reason">
                            <ItemTemplate>
                                <asp:Label ID="lblNextAppealDateAndReason" runat="server" Text='<%# Eval("NextAppealDateAndReason") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appeal Or Revision Result">
                            <ItemTemplate>
                                <asp:Label ID="lblAppealOrRevisionResult" runat="server" Text='<%# Eval("AppealOrRevisionResult") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
         </form>
    </div>
</body>
</html>


