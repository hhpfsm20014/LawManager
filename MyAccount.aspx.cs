using System.Collections.Generic;
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

public partial class MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();
        string uid = Session["userid"].ToString();
        DataTable dtb = db.userDetail(uid);
        if (dtb != null && dtb.Rows.Count > 0)
        {
            Label3.Text = dtb.Rows[0][4].ToString();
            TextBox3.Text = dtb.Rows[0][5].ToString();
            txtName.Text = dtb.Rows[0][1].ToString();
            Label1.Text = dtb.Rows[0][3].ToString();
            Label2.Text = dtb.Rows[0][11].ToString();


        }
    }
    protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
    {
        DBActivity db = new DBActivity();
        bool reply = db.updateOwn(Session["userid"].ToString(), txtName.Text, TextBox2.Text, TextBox3.Text);
        if (reply == true)
        {
            lblReply.Text = "Successfully Updated";
            
            Response.Redirect("MyAccount.aspx");
        }
        else
        {
            lblReply.Text = "Oops! something went wrong, please try again later!";
        }
    }
}