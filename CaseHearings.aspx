<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaseHearings.aspx.cs" Inherits="CaseHearings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        window.onunload = refreshParent;
        function refreshParent() {
            window.close();
            window.opener.location.href = window.opener.location;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0 auto;">
            <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
            <table style="width: 100%;">


                <tr>
                    <td>&nbsp;</td>
                    <td>Select Case:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProject" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1"
                            DataTextField="project_name" DataValueField="project_id"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" Width="300px">
                            <asp:ListItem Selected="false" Value="-1">---Select Case---</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                            SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]"></asp:SqlDataSource>


                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Case ID:</td>
                    <td>
                        <asp:TextBox ID="txtissuename" runat="server" ReadOnly="true" BackColor="LightGoldenrodYellow"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtissuename" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--<tr>
            <td>
                &nbsp;</td>
            <td>
                Issue Type</td>
            <td>
                <asp:DropDownList ID="txtissuetype" runat="server">
                    <asp:ListItem>Programming</asp:ListItem>
                    <asp:ListItem>Design</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>

                <%-- <tr>
            <td>
                &nbsp;</td>
            <td>
                Priority</td>
            <td>
                <asp:DropDownList ID="ddlPriority" runat="server">
                    <asp:ListItem Selected="True">None</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Urgent</asp:ListItem>
                    <asp:ListItem>Immediate</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
                <%--<tr>
            <td>
                &nbsp;</td>
            <td>
                Reproductibility</td>
            <td>
                <asp:DropDownList ID="ddlReproducibility" runat="server">
                    <asp:ListItem>Always</asp:ListItem>
                    <asp:ListItem>Sometimes</asp:ListItem>
                    <asp:ListItem>Random</asp:ListItem>
                    <asp:ListItem>Have not tried</asp:ListItem>
                    <asp:ListItem>Unable to reproduce</asp:ListItem>
                    <asp:ListItem Selected="True">Not available</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtPrevDesc" runat="server" Height="60px" TextMode="MultiLine"
                            Width="300px" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtissuedesc" runat="server" TextMode="MultiLine"
                            Height="70px" Width="300px" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtissuedesc" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Next Date:</td>
                    <td>
                        <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                            TargetControlID="txtStart" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>


                    </td>

                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Upload file:</td>
                    <td>
                        <asp:FileUpload ID="fuProject" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Notes:</td>
                    <td>
                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
