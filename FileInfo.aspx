<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="FileInfo.aspx.cs" Inherits="FileInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Label ID="lblpath" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                ID&nbsp;
            </td>
            <td>
                <asp:Label ID="lblId" runat="server"></asp:Label>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Name
            </td>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Issue ID
            </td>
            <td>
                <asp:Label ID="lblIssueID" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Issue Name
            </td>
            <td>
                <asp:Label ID="lblIssueName" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Download" OnClick="Button2_Click" />
            </td>
            <td>
                &nbsp;
                <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp; </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
    </table>
    <div id="comment section">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server">
                    <asp:ImageButton ID="imgToggle" runat="server"></asp:ImageButton>&nbsp;Comments:
                </asp:Panel>
                <asp:Panel ID="panel3" runat="server">
                    <asp:GridView ID="gridComment" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowHeader="False" RowStyle-BorderColor="White" RowStyle-BorderStyle="Solid"
                        RowStyle-BorderWidth="5px" BorderStyle="None">
                        <Columns>
                            <asp:TemplateField ItemStyle-BackColor="#C8C8E8" ItemStyle-Width="25%">
                                <ItemTemplate>
                                    (<%# Eval("c_id") %>)
                                    <br />
                                    <%# Eval("u_name") %><br />
                                    <%# Eval("c_time") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ImageField DataImageUrlField="u_image" ItemStyle-Width="75px" ControlStyle-Width="75" ControlStyle-Height="75"></asp:ImageField>
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
                    <asp:TextBox runat="server" TextMode="MultiLine" Style="resize: none" ID="tbNote"></asp:TextBox>
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
