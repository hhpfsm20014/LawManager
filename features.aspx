<%@ Page Title="" Language="C#" MasterPageFile="~/outsideView.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;&nbsp;&nbsp
    <link id="theme" rel="stylesheet" type="text/css" href="style.css" title="theme" />
    <link href="login-box.css" rel="stylesheet" type="text/css" />
    <%--  <div style="padding: 100px 0 0 150px;">--%>
    <h2>
        Learn more about Hameem Project Management Features</h2>
    <%--</div>--%>
    <table style="width: 100%; color: White;" class="features-box ">
        <tr>
            <td width="50%">
                <a href="#a1">Nothing to install on Client Machine</a>
            </td>
            <td width="50%">
                <a href="#a2">Customizable</a>
            </td>
        </tr>
        <tr>
            <td width="50%">
                <a href="#a3">24X7 access from any Computer</a>
            </td>
            <td width="50%">
                <a href="#a4">Email Notifications</a>
            </td>
        </tr>
        <tr>
            <td width="50%">
                <a href="#a5">Custom Priorities and Labels</a>
            </td>
            <td width="50%">
                <a href="#a6">Reports Generation</a>
            </td>
        </tr>
        <tr>
            <td width="50%">
                <a href="#a7">Define custom web views for different type of User </a>
            </td>
            <td width="50%">
                <a href="#a8"> Companies </a>
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp

    <div>
    <h2>Online project management software features videos, Working with projects, adding tasks, comments and tickets, Manage follow up list </h2>
    </div>

    <div id="a1" class="features-label-div">
        <h2 class="features-label">
            Nothing to install on Client Machine</h2>
        REXPMS can be accessed directly through internet. It doesn't need to be installed
        on Clients Machine.
    </div>

    <div id="a2"  class="features-label-div">
        <h2 class="features-label">
            Customizable</h2>
        Create as many custom fields as you want. Define the validation rules as per your
        needs. This gives extreme flexibility to accommodate any kind of team needs.
    </div>

    <div id="a3"  class="features-label-div">
        <h2 class="features-label">
            24X7 access from any Computer</h2>
        REXPMS provides it's services 24x7 from any computer from any corner of the world.
    </div>

    <div id="a4"  class="features-label-div">
        <h2 class="features-label">
            Email Notifications</h2>
        Even the smallest event will be emailed to you. We track all the changes and send
        them by email in real-time. You won’t miss anything from your work process.
    </div>

    <div id="a5"  class="features-label-div">
        <h2 class="features-label">
            Custom Priorities and Labels</h2>
        In your account settings you can customize priorities and labels, their order, titles
        and even colors in items that have them by default. (Bugs, Feature Requests, Test
        Cases)
    </div>

    <div id="a6"  class="features-label-div">
        <h2 class="features-label">
            Reports Generation</h2>
        Generate and customize detailed reports. See the progress of your team within a
        certain period of time. Use the "advanced filters" to specify exactly what you need.
        "Print View" and "CSV Export" are available out-of-the-box.
    </div> 

    <div id="a7"  class="features-label-div">
        <h2 class="features-label">
            Define custom web views for different type of User</h2>
        
    </div>

    <div id="a8"  class="features-label-div">
        <h2 class="features-label"> Companies</h2>
        An unlimited number of companies can be created in REXPMS. Each company contains
        projects, items inside projects and users related to those projects and items.
    </div>
    <br /><br /><br />
</asp:Content>
