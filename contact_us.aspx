<%@ Page Title="" Language="C#" MasterPageFile="~/outsideView.master" AutoEventWireup="true"
    CodeFile="contact_us.aspx.cs" Inherits="contact_us" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;&nbsp;&nbsp
    <link id="theme" rel="stylesheet" type="text/css" href="style.css" title="theme" />
    <link href="login-box.css" rel="stylesheet" type="text/css" />

       <div >
        <h2 class="features-label" >Contact Us</h2>
      We welcome your feedback to help us improve <br />
           <asp:Label ID="lblReply" runat="server" ></asp:Label>
    </div>
     &nbsp;&nbsp


    <table style="width:100%;" class="contact-box ">
        <tr>
            <td style="width: 152px">
                Email
            </td>
             <td style="width: 274px">
                <asp:TextBox ID="emailbox" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="email" runat="server" 
                     ControlToValidate="emailbox" ErrorMessage="Invalid Email ID" 
                     ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                     Visible="False"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="margin-left: 40px; width: 152px;">
                Name 
                
            </td>
             <td style="width: 274px">
                <asp:TextBox ID="fnamebox" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="fname" runat="server" 
                     ControlToValidate="fnamebox" ErrorMessage="First Name Required" Visible="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 152px">
                Country</td>
            <td style="width: 274px">
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 152px">
                State</td>
            <td style="width: 274px">
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 152px">
                I have an account</td>
            <td style="width: 274px">
                <asp:RadioButtonList ID="rblAccount" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>yes</asp:ListItem>
                    <asp:ListItem Selected="True">no</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 152px">
                &nbsp;</td>
            <td style="width: 274px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 152px">
                Message</td>
            <td style="width: 274px">
                <asp:TextBox ID="msgbox" runat="server" Height="54px" TextMode="MultiLine" 
                    Width="264px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 152px">
                &nbsp;</td>
            <td style="width: 274px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 152px">
                &nbsp;</td>
            <td style="width: 274px">
                <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                    Text="Submit" />
            </td>
        </tr>
    </table>


</asp:Content>
