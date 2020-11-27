<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportsNew.aspx.cs" Inherits="ReportsNew" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Case Reports</title>
    
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
        <div class="row">
            <div class="col-md-2" style="text-align:right;">Court No : </div>
            <div class="col-md-4"><asp:TextBox ID="txtCourtNo" runat="server" CssClass="form-control" ></asp:TextBox></div>
            <div class="col-md-2" style="text-align:right;">Case No : </div>
            <div class="col-md-4"><asp:TextBox ID="txtCaseNo" runat="server" CssClass="form-control" ></asp:TextBox></div>
        </div>
            <div class="row" style="height:5px;"></div>
        <div class="row">
            <div class="col-md-2" style="text-align:right;">Nxt Hearing Start Date: </div>
            <div class="col-md-4"><asp:TextBox ID="NxtHearingStartDate" runat="server" CssClass="form-control"></asp:TextBox></div>
            <div class="col-md-2" style="text-align:right;">Nxt Hearing End Date: </div>
            <div class="col-md-4"><asp:TextBox ID="NxtHearingEndDate" runat="server" CssClass="form-control"></asp:TextBox></div>
        </div>
        <div class="row">
            <div class="col-md-12" style="overflow: auto;">
                    <asp:Button  Height="33px" runat="server" CssClass="btn btn-success btn-sm text-shadow" Font-Bold="true" Text="Search" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnExport" Height="33px" runat="server" CssClass="btn btn-success btn-sm text-shadow" Font-Bold="true" Text="Export" OnClick="btnExport_Click" />
                    <asp:GridView ID="gvLawMgt" runat="server" HeaderStyle-CssClass="headestyle" RowStyle-CssClass="headestyle" CssClass="display nowrap dataTable dtr-inline" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Results Found..." DataKeyNames="project_id" Width="100%"  AllowPaging="True" OnPageIndexChanging="gvOrder_PageIndexChanging">
                    <%--<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <PagerStyle CssClass="pgr"></PagerStyle>--%>
                    <Columns>
                        <asp:TemplateField HeaderText="District">
                            <ItemTemplate>
                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("DistrictName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name Of The Court">
                            <ItemTemplate>
                                <asp:Label ID="lblCourt" runat="server" Text='<%# Eval("Court") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Case No">
                            <ItemTemplate>
                                <asp:Label ID="lblCaseId" runat="server" Text='<%# Eval("CaseId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Parties">
                            <ItemTemplate>
                                <asp:Label ID="lblParties" runat="server" Text='<%# Eval("Parties") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Next Date">
                            <ItemTemplate>
                                <asp:Label ID="lblNextDate" runat="server" Text='<%# Eval("NextDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subject Matter">
                            <ItemTemplate>
                                <asp:Label ID="lblSubjectMatter" runat="server" Text='<%# Eval("SubjectMatter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conducting Lawyer">
                            <ItemTemplate>
                                <asp:Label ID="lblLawyer" runat="server" Text='<%# Eval("Lawyer") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
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

<script type="text/javascript">
    $(function () {
        $('#<%=NxtHearingStartDate.ClientID%>').datepicker({
            format: "dd-MM-yyyy",
            autoclose: true,
            todayHighlight: true
        });

        $('#<%=NxtHearingEndDate.ClientID%>').datepicker({
            format: "dd-MM-yyyy",
            autoclose: true,
            todayHighlight: true
        });
    });
</script>
