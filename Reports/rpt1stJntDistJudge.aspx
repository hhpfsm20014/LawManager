<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpt1stJntDistJudge.aspx.cs" Inherits="Reports_rpt1stJntDistJudge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>1st Joint District Judge Cases</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><u>1st Joint District Judge Cases:</u></h1>
            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
            <br />
            <br />
            <asp:GridView ID="gvLawMgt" runat="server" HeaderStyle-CssClass="headestyle" RowStyle-CssClass="headestyle" CssClass="display nowrap dataTable dtr-inline" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Results Found..." DataKeyNames="project_id" Width="100%">                
                <Columns>
                    <asp:TemplateField HeaderText="District">
                        <ItemTemplate>
                            <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("DistrictName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Court Category">
                        <ItemTemplate>
                            <asp:Label ID="lblCourt" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Hearing Dates">
                        <ItemTemplate>
                            <asp:Label ID="lblNextDate" runat="server" Text='<%# Eval("NextDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject Matter">
                        <ItemTemplate>
                            <asp:Label ID="lblSubjectMatter" runat="server" Text='<%# Eval("SubjectMatter") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblLawyer" runat="server" Text='<%# Eval("NatureOfCase") %>'></asp:Label>
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
    </form>
</body>
</html>
