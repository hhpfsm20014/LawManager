<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="Issuedetails.aspx.cs" Inherits="Issuedetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link id="theme" rel="stylesheet" type="text/css" href="style.css" title="theme" />
    <style>
        .cellHeight
        {
            height: 30px;
        }
    </style>
    <div id="issue details">
        <table style="width: 100%;" cellspacing="2px">
            <asp:Label ID="lblissueid" Visible="false" runat="server"></asp:Label>
            <tr>
                <td class="issuedetailsa" style="width: 15%;">
                    Case Name
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblProject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp; &nbsp;
                </td>
            </tr>

             <tr>
                <td class="issuedetailsa"  style="width: 15%;">
                    Case Id
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp; &nbsp;
                </td>
            </tr>

            <tr>
                <td class="issuedetailsa" style="width: 15%;">
                    Hearing Date
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblNextHearingDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp; &nbsp;
                </td>
            </tr>

            <tr>
                <td class="issuedetailsa" style="width: 15%;">
                    Last Update
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblLastUpdate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp; &nbsp;
                </td>
            </tr>

            <tr>
                <td class="issuedetailsa" style="width: 15%;">
                    Previous result
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblPrevDesc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp; &nbsp;
                </td>
            </tr>

            <tr>
                <td class="issuedetailsa" style="width: 15%;">
                    Description
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td class="issuedetailsa" style="vertical-align: top;width: 15%;">
                    Attached Files
                </td>
                <td colspan="3" class="issuedetailsb">
                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                    SelectCommand="SELECT [file_name] FROM [File_Sharing_Info]">
                </asp:SqlDataSource>--%>
                    <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" ShowHeader="false">
                        <Columns>
                            <asp:HyperLinkField DataTextField="actualname" DataNavigateUrlFields="file_name"
                                DataNavigateUrlFormatString="uploadedFiles/{0}" Target="_self"
                                ShowHeader="False" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td class="issuedetailsa" style="width: 15%;">
                    Notes
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblNotes" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td class="issuedetailsa" style="width: 15%;">
                    Reported By
                </td>
                <td colspan="3" class="issuedetailsb">
                    <asp:Label ID="lblReportedBy" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td colspan="5" class="issuedetailsc">
                    <asp:GridView ID="gridIssues" runat="server" Width="100%" AutoGenerateColumns="False"
                        ForeColor="Brown" ShowHeader="False">
                        <Columns>                            
                            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="issue_id" DataNavigateUrlFormatString="~\ManageIssues.aspx?IssueId={0}"
                                Target="_self">
                                <ItemStyle HorizontalAlign="left" />
                            </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <%--<tr>
                <td class="issuedetailsa">
                    Issue History
                </td>
                <td colspan="4" class="issuedetailsb">
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td colspan="4" class="issuedetailsc">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="comment section">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server">
                    <asp:ImageButton ID="imgToggle" runat="server"></asp:ImageButton>Comment:
                </asp:Panel>
                <asp:Panel ID="panel3" runat="server">
                    <asp:GridView ID="gridComment" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowHeader="False" RowStyle-BorderColor="White" RowStyle-BorderStyle="Solid"
                        RowStyle-BorderWidth="5px" BorderStyle="None">
                        <Columns>
                            <asp:TemplateField ItemStyle-BackColor="#C8C8E8" ItemStyle-Width="15%">
                                <ItemTemplate>
                                    <%--(<%# Eval("c_id") %>)
                                    <br />--%>
                                    <%# Eval("u_name") %><br />
                                    <%# Eval("c_time") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:ImageField DataImageUrlField="u_image" ItemStyle-Width="75px" ControlStyle-Width="75" ControlStyle-Height="75"></asp:ImageField>--%>
                            <asp:BoundField DataField="c_state" ItemStyle-BackColor="#E8E8E8" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="panel3_CollapsiblePanelExtender" runat="server"
                    CollapseControlID="Panel2" Collapsed="True" CollapsedImage="~/images/plus.png"
                    CollapsedText="Show Details" Enabled="True" ExpandControlID="Panel2" ExpandedImage="~/images/minus.png"
                    ExpandedText="Hide Details" ImageControlID="imgToggle" SuppressPostBack="True"
                    TargetControlID="panel3">
                </asp:CollapsiblePanelExtender>


            </ContentTemplate>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td>
                    Note:
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="MultiLine" Style="resize: none" ID="tbNote" Width="208px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbNote" ErrorMessage="You cannot leave this empty."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Note" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
