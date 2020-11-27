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
public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //if ((Request.Cookies["loginid"].Value != null && Request.Cookies["logintype"].Value != null) && (Request.Cookies["loginid"].Value != "" && Request.Cookies["logintype"].Value != ""))
        //{
        //    Session["userid"] = Request.Cookies["loginid"].Value;
        //    Session["usertype"] = Request.Cookies["logintype"].Value;
        //    Response.Redirect("dashboard.aspx");
        //}
        if (Session["userid"] != null)
        {
            Response.Redirect("dashboard.aspx");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DBActivity login = new DBActivity();

        DataTable dtb = login.GetUserProfileDetails(txtEmail.Text, txtPassword.Text);
        if (dtb != null && dtb.Rows.Count > 0)
        {
            Session["usertype"] = dtb.Rows[0][3];
            Session["userid"] = dtb.Rows[0][0];
            //string abc = dtb.Rows[0][3].ToString();
            if (cbRemember.Checked)
            {
                Response.Cookies["loginid"].Value = Session["userid"].ToString();
                Response.Cookies["logintype"].Value = Session["usertype"].ToString();
                Response.Cookies["loginid"].Expires = DateTime.Now.AddDays(7);
                Response.Cookies["logintype"].Expires = DateTime.Now.AddDays(7);
            }
            else
            {
                Response.Cookies["loginid"].Value = Session["userid"].ToString();
                Response.Cookies["logintype"].Value = Session["usertype"].ToString();
                               
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            conn.Open();
            string qryProj = "SELECT default_project from user_preference where user_id = @user ";
            SqlCommand cmdProj = new SqlCommand(qryProj, conn);
            cmdProj.Parameters.Add(new SqlParameter("user", Session["userid"].ToString()));
            var default_project = cmdProj.ExecuteScalar();
            if (default_project==null)
            {
                default_project = "-1";
            }
            Session["selectedproject"] = default_project;


            conn.Close();
            Response.Redirect("dashboard.aspx");

        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}