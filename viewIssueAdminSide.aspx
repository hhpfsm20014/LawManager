<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="viewIssueAdminSide.aspx.cs" Inherits="viewIssueAdminSide" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .Background {
            background-color: Gray;
            filter: alpha(opacity='0');
            opacity: 0.7;
            padding: 10px;
            border: 3px solid #dedede;
        }

        .Panel {
            background: url(images/modelpopup.png);
            width: 600px;
            height: 500px;
        }

        .style8 {
            text-align: center;
        }
    </style>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<div>--%>
    <%--background:#dedede;"--%>
    <%--<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel"
            CancelControlID="btnCancel" BackgroundCssClass="Background" TargetControlID="HyperLink1">
        </asp:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" CssClass="Panel">
            <table style="width: 100%; margin-top: 40px;">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;--%>
    <%--Project :<asp:DropDownList ID="ddlProject" runat="server" AppendDataBoundItems="True"
                            AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="project_name"
                            DataValueField="project_id" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                            <asp:ListItem Selected="True">--Select--</asp:ListItem>
                        </asp:DropDownList>--%>
    <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                            SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>--%>
    <%--</td>
                    <td>
                        Issue&nbsp;
                        <asp:DropDownList ID="ddlIssue" runat="server" DataTextField="issue_name" DataValueField="issue_id"
                            OnSelectedIndexChanged="DDLIssue_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">--Select Project--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        Issue ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtissueid" runat="server"></asp:TextBox>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="height: 22px" class="style8">
                        Issue Status
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Selected="True">--Select--</asp:ListItem>
                            <asp:ListItem>Unassigned</asp:ListItem>
                            <asp:ListItem>Assigned</asp:ListItem>
                            <asp:ListItem>Resolved</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8" style="height: 22px">
                        Issue Type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIssueType" runat="server" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True">--Select--</asp:ListItem>
                            <asp:ListItem>Programming</asp:ListItem>
                            <asp:ListItem>Design</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 22px">
                    </td>
                    <td class="style8">
                        Issue Description*
                    </td>
                    <td style="height: 22px">
                        <asp:TextBox ID="txtissuedesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        Priority
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPriority" runat="server">
                            <asp:ListItem Selected="True">-Select--</asp:ListItem>
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem>Low</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem>Urgent</asp:ListItem>
                            <asp:ListItem>Immediate</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        Reproducibility
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlReproducibility" runat="server">
                            <asp:ListItem Selected="True">--Select--</asp:ListItem>
                            <asp:ListItem>Always</asp:ListItem>
                            <asp:ListItem>Sometimes</asp:ListItem>
                            <asp:ListItem>Random</asp:ListItem>
                            <asp:ListItem>Have not tried</asp:ListItem>
                            <asp:ListItem>Unable to reproduce</asp:ListItem>
                            <asp:ListItem>Not available</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        Steps to reproduce
                    </td>
                    <td>
                        <asp:TextBox ID="txtSteps" runat="server" Height="60px" TextMode="MultiLine" Width="300px"
                            EnableTheming="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        Notes:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        &nbsp;
                    </td>
                    <td>
                        <asp:ImageButton ID="btnUpdateIssues" runat="server" OnClick="btnUpdateIssues_Click"
                            ImageUrl="~/images/updatebtnfinal.png" />
                        &nbsp &nbsp
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/closebtn.png" />--%>
    <%--<asp:Button ID="btnUpdateIssues" runat="server" Text="Update Issues" OnClick="btnUpdateIssues_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Close" />--%>
    <%--</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style8">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>--%>
    <h1>Add Next Date:</h1>
    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0">
        <tr>
            <td><h3>
                <a href="ManageIssues.aspx">
                    <img src="images/file_add.png" alt="Add" height="14px" width="16px" />
                    New Date</a></h3>
                <%--<img src="images/file_add.png" alt="Add" height="14px" width="16px" /></a>&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/assignissues.aspx">Assign User</asp:HyperLink>--%>
            </td>
            <%--<td style="text-align: right">
                <a href="#" style="display: block; text-align: right;" runat="server" id="HyperLink1">
                    Click here to Edit</a>--%>
            <%-- <asp:HyperLink ID="HyperLink1" runat="server">Click here to Edit</asp:HyperLink>--%><%--<label style="display:block; text-align:right;">Click here to Edit</label>--%>
            <%--</td>--%>
        </tr>
    </table>
    <br />
    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0">
        <tr align="left" style="background-color: #111111; color: White;">
            <td width="30%">Next Date
            </td>
            <td width="40%">Description
            </td>
            <td width="15%">Edit
            </td>

        </tr>
        <%--Need the while output into here bgcolor="#EAEAEA" <%=getWhileLoopData()%>  --%>
        <asp:GridView ID="gridIssues" runat="server" Width="100%" AutoGenerateColumns="False"
            ForeColor="Brown" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="Issue Name" ItemStyle-Width="30%" />
                <asp:BoundField DataField="Description" ItemStyle-Width="40%" />
                <%--<asp:HyperLinkField Text="Details" DataNavigateUrlFields="Issue ID" DataNavigateUrlFormatString="~\Issuedetails.aspx?IssueID={0}"
                    Target="_self"   ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Issue ID" DataNavigateUrlFormatString="~\ManageIssues.aspx?IssueId={0}"
                    Target="_self" ItemStyle-Width="15%">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </table>
</asp:Content>
