<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="ViewAddEditLandCase.aspx.cs" Inherits="ViewAddEditLandCase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <script type="text/javascript">
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

    </script>--%>
<%--    <script type="text/javascript">
        Sys.Application.add_load(LoadScript);
        $(".select2").select2();
    </script>--%>
<%--    <script type="text/javascript">
        function HearingWindow(name) {
            var projectid = getParameterByName(name)
            testwindow = window.open("CaseHearings.aspx?projectid=" + projectid + "", "HearingWindow", "location=1,status=1,scrollbars=1,width=500,height=320");
            testwindow.moveTo(0, auto);
        }
    </script>--%>

    <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>

    <table style="width: 100%;" align="center">
        <tr><td colspan="3" style="font-size:25px; color:red;"><asp:Label ID="lblerrmgs" runat="server"></asp:Label></td></tr>
        <tr>
            <td style="width: 60px"></td>
            <td colspan="3">
                <h1>Add / Edit Land Case:</h1>
            </td>
            
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">District:</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="select2" Width="390px" Height="30px"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Name Of Court:</td>
            <td colspan="2">
                <asp:TextBox ID="txtNameOfCourt" runat="server" Width="385px" Height="30px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3"
                        runat="server" Enabled="True" TargetControlID="txtNameOfCourt"
                        WatermarkText="*Required">
                    </asp:TextBoxWatermarkExtender>
                    &nbsp;
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtNameOfCourt" ErrorMessage="Please enter Case ID"
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Case No.:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtCaseId" runat="server" Width="385px" Height="30px"></asp:TextBox>
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
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Nature of Case:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtNatureOfCase" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Name of The Parties: &nbsp;
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtNameOfParty" runat="server" Width="170px" Height="30px"></asp:TextBox><span style="text-align: center; margin-left: 10px;"><b>V/S</b></span>
                &nbsp;
                <asp:TextBox ID="txtOppositions" runat="server" Width="170px" Height="30px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Contact Details:&nbsp;
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtContactDetails" runat="server" Width="170px" Height="30px"></asp:TextBox><span style="text-align: center; margin-left: 30px;"></span>
                &nbsp;
                <asp:TextBox ID="txtOppoContactDetails" runat="server" Width="170px" Height="30px"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Lawyer:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtLawyer" runat="server" Width="170px" Height="30px"></asp:TextBox><span style="text-align: center; margin-left: 30px;"></span>
                &nbsp;
                <asp:TextBox ID="txtOppoLawyer" runat="server" Width="170px" Height="30px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Lawyer Contact Details:&nbsp;
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtLawyerContact" runat="server" Width="170px" Height="30px"></asp:TextBox><span style="text-align: center; margin-left: 30px;"></span>
                &nbsp;
                <asp:TextBox ID="txtOppoLawyerContact" runat="server" Width="170px" Height="30px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Schedule of the land:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtScheduleoftheland" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Description of Plaint:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtPlaintDescription" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Description of W. S.:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtDescriptionofWS" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Plaint or W.S. date:</td>
            <td colspan="2">
                <asp:TextBox ID="txtPlaintorWSdate" runat="server" Width="385px" Height="30px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="txtPlaintorWSdate" Format="dd-MMM-yyyy">
                </asp:CalendarExtender>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtPlaintorWSdate" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                <br />
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Next date:</td>
            <td colspan="2">
                <asp:TextBox ID="txtNextDate" runat="server" Width="385px" Height="30px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                    TargetControlID="txtNextDate" Format="dd-MMM-yyyy">
                </asp:CalendarExtender>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtNextDate" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                <br />
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Next date reason:</td>
            <td colspan="2">
                <asp:TextBox ID="txtNextDateReason" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>

        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Case result:</td>
            <td colspan="2">
                <asp:TextBox ID="txtCaseResult" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Case result date:</td>
            <td colspan="2">
                <asp:TextBox ID="txtCaseResultDate" runat="server" Width="385px" Height="30px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server"
                    TargetControlID="txtCaseResultDate" Format="dd-MMM-yyyy">
                </asp:CalendarExtender>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtCaseResultDate" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Appeal/revision No.:</td>
            <td colspan="2">
                <asp:TextBox ID="txtAppealorRevisionNo" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Appeal/revision submission date:</td>
            <td colspan="2">
                <asp:TextBox ID="txtAppealRevisionSubmissiondate" runat="server" Width="385px" Height="30px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender4" runat="server"
                    TargetControlID="txtAppealRevisionSubmissiondate" Format="dd-MMM-yyyy">
                </asp:CalendarExtender>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                    ControlToValidate="txtAppealRevisionSubmissiondate" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Appeal Court Name:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtAppealCourtName" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Appeal submission/reply date:</td>
            <td colspan="2">
                <asp:TextBox ID="txtAppealSubmissionOrReplyDate" runat="server" Width="385px" Height="30px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender5" runat="server"
                    TargetControlID="txtAppealSubmissionOrReplyDate" Format="dd-MMM-yyyy">
                </asp:CalendarExtender>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ControlToValidate="txtAppealSubmissionOrReplyDate" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Advocate Name:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtAdvocateName" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Document handover date to the Advocate:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtDocumentHandoverDate" runat="server" Width="385px" Height="30px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender6" runat="server"
                    TargetControlID="txtDocumentHandoverDate" Format="dd-MMM-yyyy">
                </asp:CalendarExtender>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                    ControlToValidate="txtDocumentHandoverDate" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Handover list:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtHandoverList" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Document submission description:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtDocumentSubmissionDescription" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;"> Submitted document description:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtSubmittedDocumentDescription" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;"> Next date of appeal/revision:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtNextAppealRevisionDate" runat="server" Width="385px" Height="30px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender7" runat="server"
                    TargetControlID="txtNextAppealRevisionDate" Format="dd-MMM-yyyy">
                </asp:CalendarExtender>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                    ControlToValidate="txtNextAppealRevisionDate" ErrorMessage="Please enter Date"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 60px;"></td>
            <td style="width: 150px; font-weight:bold;"> Next date of appeal/revision reason:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtNextAppealRevisionDateReason" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Result of appeal/revision:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtResultAppealRevision" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td style="width: 150px; font-weight:bold;">Remark:&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtRemark" runat="server" Style="resize: none" Width="385px" Height="30px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>

        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td style="padding-top: 50px;">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSave_Click" Text="Submit" Style="height: 26px" />
            </td>
        </tr>
    </table>

</asp:Content>
