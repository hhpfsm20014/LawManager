<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="ManageIssues.aspx.cs" Inherits="ManageIssues" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin: 0 250px;">
        <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
        <table style="width: 100%;">
            <tr>
                <td></td>
                <td>
                    <h1>Add Next Date:</h1>
                </td>
                <td></td>
            </tr>
        </table>
        <br />
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
                <td>Add Next Date:</td>
                <td>
                    <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                        TargetControlID="txtStart" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtStart" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>

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
        <br />
        <h2>
            <asp:Label ID="lblDateSummary" runat="server" Text="Date Summary:"></asp:Label></h2>
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
    </div>
</asp:Content>
