<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="Files.aspx.cs" Inherits="Files" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Case Files:</h1>
    <table style="width: 100%;">
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>Select Case:
                <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                    DataTextField="project_name" DataValueField="project_id" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"
                    AppendDataBoundItems="True" Width="300px">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>
            </td>
            <td>Hearing Date:
                <asp:DropDownList ID="ddlIssue" runat="server" AutoPostBack="True">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:GridView ID="gridFiles" runat="server" Width="100%" AutoGenerateColumns="False"
                    OnRowDataBound="gridFiles_RowDataBound" OnSorting="gridView_Sorting" Style="margin-left: 0px" AllowSorting="true">
                    <Columns>
                        <%-- <asp:TemplateField HeaderText="Issue ID">
                <ItemTemplate>
                <%#Eval("i_id") %>
                </ItemTemplate>
                </asp:TemplateField>--%>
                        <asp:HyperLinkField DataTextField="f_id" DataNavigateUrlFields="f_id" DataNavigateUrlFormatString="~\FileInfo.aspx?FileID={0}"
                            HeaderText="File ID" Target="_self" ItemStyle-Width="25%">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="f_name" HeaderText="FileName" />
                        <%-- <asp:BoundField DataField="i_id" HeaderText="Issue ID" />--%>
                        <%--<asp:BoundField DataField="i_name" HeaderText="Issue Name" />--%>
                        <asp:BoundField DataField="f_date" HeaderText="Submit Date" SortExpression="f_date" />
                    </Columns>
                </asp:GridView>
            </td>
            <td></td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="margin-left: 160px; width: 696px;">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>
            </td>
            <td style="width: 224px; margin-left: 160px">&nbsp;
            </td>
            <td style="width: 224px; margin-left: 160px">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="margin-left: 160px; width: 696px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:Panel ID="Panel2" runat="server">
                            &nbsp;&nbsp;<asp:ImageButton ID="imgToggle" runat="server"
                                ImageUrl="~/images/minus.png" Height="12px" Style="margin-top: 0px"
                                Width="12px" />
                            &nbsp;Upload Files
                        </asp:Panel>
                        </td>
            <td style="width: 224px; margin-left: 160px">&nbsp;
            </td>
                        <td style="width: 224px; margin-left: 160px">&nbsp;
                        </td>
                        </tr>
        <tr>
            <td style="margin-left: 160px">
                <asp:Panel ID="Panel3" runat="server" BackColor="White"
                    Width="600px" BorderStyle="Solid">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 11px; height: 68px;">&nbsp;
                            </td>
                            <td style="width: 217px; height: 68px">Case:
                <asp:DropDownList ID="ddlProject1" runat="server" AutoPostBack="True"
                    DataSourceID="SqlDataSource1" DataTextField="project_name"
                    DataValueField="project_id"
                    OnSelectedIndexChanged="ddlProject1_SelectedIndexChanged" AppendDataBoundItems="True" Width="300px">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                                &nbsp;&nbsp;
                            </td>
                            <td style="height: 68px">Hearing Date:
                <asp:DropDownList ID="ddlIssue1" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px" class="style7">&nbsp;
                            </td>
                            <td style="width: 217px">Upload File:
                
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload" runat="server" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px" class="style7">&nbsp;
                            </td>
                            <td style="width: 217px">&nbsp;</td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px" class="style7">&nbsp;</td>
                            <td style="width: 217px">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                                    Text="Submit" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="Panel3_CollapsiblePanelExtender"
                    runat="server" CollapseControlID="Panel2" Collapsed="True"
                    CollapsedImage="~/images/plus.png" CollapsedText="Show Details" Enabled="True"
                    ExpandControlID="Panel2" ExpandedImage="~/images/minus.png" ExpandedText="Hide Details"
                    ImageControlID="imgToggle" SuppressPostBack="True" TargetControlID="Panel3">
                </asp:CollapsiblePanelExtender>
            </td>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <td style="width: 224px; margin-left: 160px">&nbsp;
                </td>
                <td style="width: 224px; margin-left: 160px">&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
