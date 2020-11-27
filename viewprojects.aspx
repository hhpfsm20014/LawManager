<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true"
    CodeFile="viewprojects.aspx.cs" Inherits="view_projects" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
    <head>
        <title></title>
        <style type="text/css">
            .Background {
                background-color: Gray;
                filter: alpha(opacity='0');
                opacity: 0.7;
                padding: 10px;
                border: 3px solid #dedede;
            }

            .Panel {
                background: url(images/login-box-backg.png);
                width: 455px;
                height: 410px;
            }

            .style9 {
                text-align: center;
            }

        .txtbox
        {
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
        }

        </style>
<%--        <link href="bootstrap/cs/bootstrap.min.css" rel="stylesheet" />
        <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>--%>
    </head>
    <body>
        <div class="container">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
    
            <div style="float:right;">
            <b>Sort By Category:</b>
            <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3"
                DataTextField="CategoryName" DataValueField="CategoryId"
                AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                <asp:ListItem Selected="false" Value="-1">All</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                SelectCommand="SELECT [CategoryId], [CategoryName] FROM [CaseCategory]"></asp:SqlDataSource>
            </div>
            <h1>Add Case:</h1>
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <td style="width: 25%">
                        <h3><a href="ManageProject.aspx">
                            <img src="images/file_add.png" alt="Add" height="14px" width="16px" />
                            New case</a></h3>
                    </td>
            
                </tr>
            </table>
            <br />
            <h1>Edit Case:</h1>
            <div style="width:100%">
                 <%--<div style="width:40%; float:left">
                     <asp:TextBox ID="txtCaseId" runat="server" CssClass="form-control" Height="33px" ></asp:TextBox>
                 </div>
                 <div style="width:60%; float:left">
                     <asp:Button  Height="33px" runat="server" CssClass="btn btn-success btn-sm text-shadow" Font-Bold="true" Text="Search" OnClick="btnSearch_Click" />
                 </div>--%>
                <table style="width:100%">
                    <tr>
                        <td style="width:40%;">
                            <asp:TextBox ID="txtCaseId" runat="server" CssClass="txtbox" Height="30px"></asp:TextBox>
                        </td>
                        <td style="width:60%;">
                            &nbsp;<asp:Button  Height="33px" runat="server" CssClass="btn btn-success btn-sm text-shadow" Font-Bold="true" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="CaseGrid" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="CaseGrid_RowCommand" DataKeyNames="project_id" AutoGenerateColumns="False">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>           
                    <asp:ButtonField Text="Edit" CommandName="CaseEdit" />
                    <asp:ButtonField Text="Delete" CommandName="CaseDelete" />
                        <asp:BoundField DataField="CaseName" HeaderText="Case Name" />
                        <asp:BoundField DataField="CaseId" HeaderText="Case Id" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                </Columns>
            </asp:GridView>
        </div>
    </body>
</html>
</asp:Content>

