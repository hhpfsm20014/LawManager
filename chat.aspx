<%@ Page Title="" Language="C#" MasterPageFile="~/DashMaster.master" AutoEventWireup="true" CodeFile="chat.aspx.cs" Inherits="chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    



    <asp:Panel ID="Panel1" runat="server" Width="100%" Height="450px">
    <iframe  width="100%" Height="450px" id="iframe1" runat="server"></iframe>

  <%-- src="http://webchat.freenode.net/?nick=username&channels=%23oitpms&prompt=1"
--%>

    </asp:Panel>

</asp:Content>

