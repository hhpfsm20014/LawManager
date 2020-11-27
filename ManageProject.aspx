<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="ManageProject.aspx.cs" Inherits="ManageProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function validate() {
            var doc = document.getElementById('FreeTextBox1');
            if (doc.value.length == 0) {
                alert('Please Enter data in Richtextbox');
                return false;
            }
        }
        function PopupCategoryWindow() {

            window.open("Categories.aspx", "PopUp", "Center,width=450,height=350");
        }
        function PopupCourtWindow() {

            window.open("Court.aspx", "PopUp", "Center,width=450,height=350");
        }
    </script>
    <script type="text/javascript">
        Sys.Application.add_load(LoadScript);
    </script>
    <script type="text/javascript">
        function HearingWindow(name) {
            var projectid = getParameterByName(name)
            testwindow = window.open("CaseHearings.aspx?projectid=" + projectid + "", "HearingWindow", "location=1,status=1,scrollbars=1,width=500,height=320");
            testwindow.moveTo(0, auto);
        }
    </script>
    <style>
        .watermark {
            color =gray;
        }
    </style>
    <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>

    <table style="width: 100%;" align="center">
        <tr><td colspan="3" style="font-size:25px; color:red;"><asp:Label ID="lblerrmgs" runat="server"></asp:Label></td></tr>
        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">
                <h1>Add / Edit Case:</h1>
            </td>
            <td style="width: 234px"></td>
        </tr>
        <tr>
            <td style="width: 151px">&nbsp;</td>
            <td style="width: 196px">District</td>
            <td style="width: 234px" colspan="2">

                <div style="float: left">
                    <asp:DropDownList ID="ddlDistrict" runat="server" Style="width: 234px" DataSourceID="SelectDistrict" DataTextField="DistrictName"
                        DataValueField="DistrictId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SelectDistrict" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                        SelectCommand="SELECT * FROM District"></asp:SqlDataSource>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 151px">&nbsp;</td>
            <td style="width: 196px">Categories</td>
            <td style="width: 234px" colspan="2">

                <div style="float: left">
                    <asp:DropDownList ID="ddlCategory" runat="server" Style="width: 234px" DataSourceID="SelectCategory" DataTextField="CategoryName"
                        DataValueField="CategoryId" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SelectCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                        SelectCommand="SELECT [CategoryName], [CategoryId] FROM [CaseCategory]"></asp:SqlDataSource>

                    <asp:LinkButton ID="lnkCategory" runat="server" OnClientClick="PopupCategoryWindow();return false;">Add New</asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr style="display: none">
            <td style="width: 151px">&nbsp;</td>
            <td style="width: 196px">Court</td>
            <td style="width: 234px" colspan="2">

                <div style="float: left">
                    <asp:DropDownList ID="ddlCourt" runat="server" Style="width: 234px" DataSourceID="SelectCourt" DataTextField="CourtName"
                        DataValueField="CourtId" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SelectCourt" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                        SelectCommand="SELECT [CourtName], [CourtId] FROM [Court]"></asp:SqlDataSource>

                    <asp:LinkButton ID="lnkCourt" runat="server" OnClientClick="PopupCourtWindow();return false;">Add New</asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 151px">&nbsp;</td>
            <td style="width: 196px">Case No.&nbsp;
            </td>
            <td style="width: 234px" colspan="2">
                <asp:TextBox ID="txtCaseId" runat="server"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                    runat="server" Enabled="True" TargetControlID="txtCaseId"
                    WatermarkText="*Required" WatermarkCssClass="watermark">
                </asp:TextBoxWatermarkExtender>
                &nbsp;
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtCaseId" ErrorMessage="Please enter Case ID"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 151px">&nbsp;</td>
            <td style="width: 196px">Case Name&nbsp;
            </td>
            <td style="width: 234px" colspan="2">
                <asp:TextBox ID="txtPname" runat="server"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="txtPname_TextBoxWatermarkExtender"
                    runat="server" Enabled="True" TargetControlID="txtPname"
                    WatermarkText="*Required" WatermarkCssClass="watermark">
                </asp:TextBoxWatermarkExtender>
                &nbsp;
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtPname" ErrorMessage="Please enter Case Name"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">Name of The Parties&nbsp;
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtNameOfParty" runat="server" Style="resize: none"></asp:TextBox><span style="text-align: center; margin-left: 70px;"><b>V/S</b></span>
                &nbsp;
            </td>

            <%--<td style="width: 10px; text-align:center;">
             
            </td>--%>

            <td style="width: 150px">
                <asp:TextBox ID="txtOppositions" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
        </tr>

        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">Contact Details:&nbsp;
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtContactDetails" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtOppoContactDetails" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">Lawyer:&nbsp;
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtLawer" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtOppoLawer" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">Lawyer Contact Details:&nbsp;
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtLawyerContact" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="txtOppoLawyerContact" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">Case Status:&nbsp;
            </td>
            <td style="width: 234px" colspan="2">
                <asp:TextBox ID="txtNatureOfCase" runat="server" Style="resize: none"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">Case Summary:&nbsp;
            </td>
            <td style="width: 234px" colspan="2">
                <FTB:FreeTextBox ID="txtSummary" runat="server" Width="550px" Height="200px">
                </FTB:FreeTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 151px"></td>
            <td style="width: 196px">Attachment:&nbsp;
            </td>
            <td style="width: 234px" colspan="2">
                <asp:FileUpload ID="txtFileUpload" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 119px; width: 151px">&nbsp;</td>
            <td style="width: 196px; height: 119px">Case Start Date:&nbsp;
            </td>
            <td style="height: 119px; width: 234px" colspan="2">
                <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="txtStart" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtStart" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2"
                    runat="server" Enabled="True" TargetControlID="txtStart"
                    WatermarkText="*Required" WatermarkCssClass="watermark">
                </asp:TextBoxWatermarkExtender>
                &nbsp;
                <br />

            </td>
        </tr>
        <%--<tr>
            <td style="width: 151px">
                &nbsp;</td>
            <td style="width: 196px">
                Next Date</td>
            <td style="width: 234px">
                <asp:TextBox ID="txtEnd" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                  TargetControlID="txtEnd" Format="dd/MM/yyyy">
                </asp:CalendarExtender> 
                <br />
   
            </td>
        </tr>--%>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblHearing" runat="server" Text="Add Next Date:"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnHearing" runat="server" Text="Add" OnClientClick="HearingWindow('ProjectId')" /></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
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
            </td>

        </tr>
        <tr>
            <td></td>
            <td></td>
            <td style="padding-top: 50px;">
                <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" Text="Submit" Style="height: 26px" />
            </td>
        </tr>
    </table>

</asp:Content>

