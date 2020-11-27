<%@ Page Title="" Language="C#" MasterPageFile="~/outsideView.master" AutoEventWireup="true"
    CodeFile="registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <style type="text/css">
            .style4
            {
                width: 213px;
            }
            .style9
            {
                width: 118px;
            }
            .style10
            {
                font-family: Arial, Helvetica, sans-serif;
                width: 118px;
            }
            .style11
            {
                width: 79px;
            }
            .style12
            {
                font-family: Arial, Helvetica, sans-serif;
                width: 79px;
            }
            .style13
            {
                width: 79px;
                height: 52px;
            }
            .style14
            {
                width: 118px;
                height: 52px;
            }
            .style15
            {
                width: 213px;
                height: 52px;
            }
        </style>
        <link id="theme" rel="stylesheet" type="text/css" href="style.css" title="theme" />
        <script type="text/javascript" language="javascript" src="js/addon.js"></script>
        <script type="text/javascript" language="javascript" src="js/custom.js"></script>
        <!--  content -->
        <br />
        <br />
        <table style="width: 85%; color: White; margin-left: 62px;" class="bhatti">
            <tr>
                <td style="font-family: 'Times New Roman', Times, serif" class="style11">
                    &nbsp;
                </td>
                <td style="font-family: 'Times New Roman', Times, serif" class="style9">
                    &nbsp;
                </td>
                <td class="style4">
                    &nbsp;
                    <br />
                    * Field Mandatory
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;
                </td>
                <td class="style10">
                    Company Name*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtCompany" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompany"
                        ErrorMessage="Company name Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Industry Type
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtIndustry" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Contact Person*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtPerson" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPerson"
                        ErrorMessage="Person name Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Contact Number*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtContactNo" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtContactNo"
                        ErrorMessage="Invalid Number" MaximumValue="9999999999" MinimumValue="7009999999"
                        SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Address
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtAddress" class="register-boxes" runat="server" TextMode="MultiLine"
                        Height="48px" Width="302px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    City*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtCity" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="City reqiured"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Pincode*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtPincode" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPincode"
                        ErrorMessage="Enter Valid Pincode" MaximumValue="999999" MinimumValue="100000"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    State*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtState" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState"
                        ErrorMessage="State Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Country*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtCountry" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCountry"
                        ErrorMessage="Country Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Email_ID*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtEmail" class="register-boxes" runat="server" Width="301px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Invalid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    Password*
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtPwd" class="register-boxes" runat="server" TextMode="Password"
                        Width="301px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPwd"
                        ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;
                </td>
                <td class="style14">
                    Confirm Password*
                </td>
                <td class="style15">
                    <asp:TextBox ID="txtCPwd" class="register-boxes" runat="server" TextMode="Password"
                        Width="301px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCPwd"
                        ControlToValidate="txtPwd" ErrorMessage="Password not Matched"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    &nbsp;Enter Verification Code
                </td>
                <td class="style4">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Image ID="ImgCaptcha" runat="server" ImageUrl="~/captcha.ashx" 
                                style="position: relative; padding-top:15px; top: -8px; left: 0px; height: 40px;" />
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                ImageUrl="~/images/Refresh.gif" OnClick="ImageButton1_Click" 
                                style="position: relative; padding-top:15px; top: -8px; left: 0px; height: 40px; width: 44px" />
                        </ContentTemplate>

                    </asp:UpdatePanel>
                   
                    <asp:Label ID="lblMessage1" runat="server" Text=""></asp:Label>
                    <%--<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Try For New Code" /> --%>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txtInput" class="register-boxes" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;
                </td>
                <td class="style9">
                    &nbsp;
                </td>
                <td class="style4">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClientClick="this.form.reset();return false;" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <!-- end content -->
    </div>
    <!-- end container -->
</asp:Content>
