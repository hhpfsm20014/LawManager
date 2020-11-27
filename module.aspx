<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="module.aspx.cs" Inherits="module" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 63px">
                &nbsp;
            </td>
            <td style="width: 312px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 63px">
                &nbsp;
                
            </td>
            <td style="width: 312px">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
        </tr>
        <tr>
            <td style="width: 63px">
                &nbsp;
            </td>
            <td style="width: 312px">
               
            </td>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <%--<asp:DropDownList ID="ddlProject" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="project_name" DataValueField="project_id" 
                    AppendDataBoundItems="true" AutoPostBack="True" 
                    onselectedindexchanged="ddlProject_SelectedIndexChanged">
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                </asp:DropDownList>--%>
              
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
                    SelectCommand="SELECT [project_id], [project_name] FROM [Project_Master]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 63px">
                &nbsp;
            </td>
            <td style="width: 312px">
                Module Name
            </td>
            <td>
                <asp:TextBox ID="txtModuleName" runat="server"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="txtModuleName_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtModuleName" 
                    WatermarkText="*Required">
                </asp:TextBoxWatermarkExtender>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Module Name Required" ControlToValidate="txtModuleName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 63px">
                &nbsp;
            </td>
            <td style="width: 312px">
                Module Description
            </td>
            <td>
                <asp:TextBox ID="txtModuleDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 63px">
                &nbsp;
            </td>
            <td style="width: 312px">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 63px">
                &nbsp;
            </td>
            <td style="width: 312px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 63px">
                &nbsp;
            </td>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                 <%--   <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>--%>
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />   
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
