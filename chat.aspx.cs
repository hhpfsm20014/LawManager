using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


public partial class chat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbl = (Label)Page.Master.FindControl("lblName");
        string username = lbl.Text;
        
        string a1 = "http://webchat.freenode.net/?nick=";
        string a2 = username;
        string a3 = "&channels=%23oitpms&prompt=1";
        string link = a1 + a2 + a3;
        
        iframe1.Attributes["src"] = link;
    }

}