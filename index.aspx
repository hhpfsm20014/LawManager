<%@ Page Title="" Language="C#" MasterPageFile="~/outsideView.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="banner" class="slideshowContainer">
        <!-- put your slideshow images here -->
        <div class="slideshow">
            <a href="index.aspx" title="Working late" target="_blank" shape="rect">
                <img src="images/dash.jpg" alt="image" />
            </a>
            <a href="index.aspx" title="Working late" target="_blank" shape="rect">
                <img src="images/IRC_cover.png" alt="image" />
            </a>
            <a href="index.aspx" title="Facade" target="_blank" shape="rect">
                <img src="images/fs.jpg" alt="image" />
            </a>
            <a href="index.aspx" title="Twisted building" target="_blank" shape="rect">
                <img src="images/chat1.jpg" alt="image" />
            </a>
        </div>
        <div class="slideshowLeftCorner">
        </div>
        <div class="slideshowRightCorner">
        </div>
        <div class="slideshowBottom">
        </div>
    </div>
    <!--  content -->
    <div id="content">
        <div style="margin-top: 20px;">
            <div class="one_fourth">
                <div class="bloc rounded">
                    <h3>
                        Project Management</h3>
                    <p class="style2">
                        <img src="images/chart_bar.png" style="float: right; margin: 0 0 0 8px" />
                        REXPMS is a perfect Project Management solution. Keep a track of your projects in
                        its clean interface.
                    </p>
                </div>
            </div>
            <div class="one_fourth">
                <div class="bloc rounded">
                    <h3>
                        Issue Track</h3>
                    <p>
                        <img src="images/folder.png" style="float: right; margin: 0 0 0 8px" />
                        Bugs, Features, Tickets, Tasks, Test Cases. Everything you'll ever need for issue
                        tracking.</p>
                </div>
            </div>
            <div class="one_fourth">
                <div class="bloc rounded">
                    <h3>
                        File Sharing</h3>
                    <p>
                        <img src="images/link.png" style="float: right; margin: 0 0 0 8px" />
                        File sharing is the practice of distributing or providing access to digitally stored
                        information.
                    </p>
                </div>
            </div>
            <div class="one_fourth last">
                <div class="bloc rounded">
                    <h3>
                        Team Chat</h3>
                    <p>
                        <img src="images/rss2.png" style="float: right; margin: 0 0 0 8px" />
                        Create real-time conversations with your colleagues, label and find them in one
                        click.
                    </p>
                </div>
            </div>
            <div class="clear">
            </div>
            <div>
                <h1>
                    What’s Issue Tracking all about?</h1>
                <p>
                    Issue Tracking(also known as bug tracking, defect tracking, problem tracking and
                    ticket management) is an approach of keeping and tracking all your items in one
                    single place(system). This approach allows you to save a lot of time if compared
                    to text/excel file item reporting because you’re always able to find, edit, assign
                    and comment everything extremely easy.
                </p>
            </div>
            <div class="half">
                <h3>
                    <strong>REXPMS</strong></h3>
                <p>
                    <strong>REXPMS</strong> is a user-friendly issue tracking and project management
                    system.</p>
            </div>
            <div class="half last">
                <h3>
                    Need Of Having <strong>REXPMS</strong></h3>
                <p>
                    It provides the easiest way to <strong>manage projects, track bugs, add tasks</strong>
                    and <strong>store documentation</strong>.</p>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <!-- end content -->
    <div class="clear" style="height: 40px">
    </div>
</asp:Content>
