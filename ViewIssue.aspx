<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="ViewIssue.aspx.cs" Inherits="ViewIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="login-box.css" rel="stylesheet" type="text/css" />

    <table style="width: 100%;">
        <tr>
            <td style="font-family: Arial, Helvetica, sans-serif">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
            <td style="font-family: Arial, Helvetica, sans-serif">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="font-family: Arial, Helvetica, sans-serif">
                &nbsp;
            </td>
            <td style="font-family: Arial, Helvetica, sans-serif">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="font-family: Arial, Helvetica, sans-serif">
                &nbsp;&nbsp; Filter

            </td>
            <td style="font-family: Arial, Helvetica, sans-serif">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Reported By &nbsp;
                <asp:DropDownList ID="ddlReporter" runat="server" AppendDataBoundItems="True" DataSourceID="reporter"
                    DataTextField="user_name" DataValueField="user_id">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="reporter" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                    SelectCommand="SELECT [user_name], [user_id] FROM [User_Master]"></asp:SqlDataSource>
            </td>
            <td>Case No. or Name:<asp:TextBox ID="txtSearchItem" runat="server" Width="267px"></asp:TextBox>
                <%--<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />--%>

            </td>
            <%--<td style="font-family: Arial, Helvetica, sans-serif">
                Status
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem>Unassigned</asp:ListItem>
                    <asp:ListItem>Assigned</asp:ListItem>
                    <asp:ListItem>Resolved</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="font-family: Arial, Helvetica, sans-serif">
                Reproducibility
                <asp:DropDownList ID="ddlReproducability" runat="server" Width="108px">
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem>Not Available</asp:ListItem>
                    <asp:ListItem>Unable to reproduce</asp:ListItem>
                    <asp:ListItem>Sometimes</asp:ListItem>
                    <asp:ListItem>Random</asp:ListItem>
                    <asp:ListItem>Have not tried</asp:ListItem>
                    <asp:ListItem>Always</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
            </td>
            <td style="font-family: Arial, Helvetica, sans-serif">
                Priority
                <asp:DropDownList ID="ddlPriority" runat="server">
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Urgent</asp:ListItem>
                    <asp:ListItem>Immediate</asp:ListItem>
                </asp:DropDownList>
            </td>--%>
        </tr>
        <tr>
            <td>
                From &nbsp;
                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                <asp:PopupControlExtender ID="txtFrom_PopupControlExtender" runat="server" DynamicServicePath=""
                    Enabled="True" ExtenderControlID="" PopupControlID="panel1" TargetControlID="txtFrom">
                </asp:PopupControlExtender>
            </td>
            <td>
                To&nbsp;
                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                <asp:PopupControlExtender ID="txtTo_PopupControlExtender" runat="server" DynamicServicePath=""
                    Enabled="True" ExtenderControlID="" PopupControlID="panel2" TargetControlID="txtTo">
                </asp:PopupControlExtender>
            </td>
            <%--<td>
                <asp:Button ID="Button1" runat="server" Text="Reset" />
                &nbsp;
            </td>--%>
            <td>
                &nbsp;
                <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Width="150px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"
                                BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest"
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="Panel2" runat="server" Width="150px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"
                                BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest"
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <div style="vertical-align: top; height: 400px; overflow: auto; width: 1000px;">
        <asp:GridView ID="gridIssues" runat="server" Width="100%" AutoGenerateColumns="False"
            OnRowDataBound="gridIssues_RowDataBound">
            <Columns>
                <asp:HyperLinkField DataTextField="issue_id" DataNavigateUrlFields="issue_id" DataNavigateUrlFormatString="~\Issuedetails.aspx?IssueID={0}"
                    HeaderText="Hearing ID" Target="_self" ItemStyle-Width="3%">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="nxtHearingDate" HeaderText="Hearing Date" ItemStyle-Wrap="false" />
                <asp:BoundField DataField="prevHearingDes" HeaderText="Previous Result" />
                <asp:BoundField DataField="issue_description" HeaderText="Description" ItemStyle-Width="25%"/>
                <asp:BoundField DataField="issue_notes" HeaderText="Notes" />
                <asp:BoundField DataField="last_modified_date" HeaderText="Updated" ItemStyle-Width="15%" />
                
            </Columns><%--ItemStyle-Wrap="false" --%>
        </asp:GridView>
    </div>
    <table width="100%">
        <tr style="width: 100%">
            <td class="none" style="width: 16.5%">
                None
            </td>
            <td class="low" style="width: 16.5%">
                Low
            </td>
            <td class="normal" style="width: 16.5%">
                Normal
            </td>
            <td class="high" style="width: 16.5%">
                High
            </td>
            <td class="urgent" style="width: 16.5%">
                Urgent
            </td>
            <td class="immediate" style="width: 16.5%">
                Immediate
            </td>
        </tr>
    </table>
</asp:Content>
