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

public partial class contact_us : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ClsDBConnection cn = new ClsDBConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn.OpenConnection();
        cmd.Parameters.Clear();
        long conid = cn.GetCurrentAutoNumber(cmd,"feedback_form");
        cmd.CommandText = "INSERT INTO feedback_form(contact_id,email,name,country,state,have_account,message) VALUES(@conid,@email,@name,@country,@state,@have_account,@message)";
        cmd.Parameters.Add(new SqlParameter("conid",conid));
        cmd.Parameters.Add(new SqlParameter("email", emailbox.Text));
        cmd.Parameters.Add(new SqlParameter("name", fnamebox.Text));
        cmd.Parameters.Add(new SqlParameter("country", txtCountry.Text));
        cmd.Parameters.Add(new SqlParameter("state", txtState.Text));
        cmd.Parameters.Add(new SqlParameter("have_account", rblAccount.SelectedValue));
        cmd.Parameters.Add(new SqlParameter("message", msgbox.Text));
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        lblReply.Text = "Thank you for your Feedback! We will get back to you Soon!";
    }
}