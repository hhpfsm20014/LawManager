<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Categories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;text-align:center;">
            <tr>
                <td>Category Name: <asp:TextBox ID="txtCategories" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Style="flex-align:center" onclick="Button1_Click"  />
                    &nbsp;
                </td>                
            </tr>
        </table>
             
    
    </div>
    </form>
</body>
</html>
