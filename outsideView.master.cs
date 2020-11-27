using System;
using System.Data;
using System.Collections.Generic;
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


public partial class outsideView : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //HttpCookie loginid = new HttpCookie("loginid");
        //HttpCookie logintype = new HttpCookie("logintype");
        //Response.Cookies.Add(loginid);
        //Response.Cookies.Add(logintype);

        //Response.Cookies["loginid"].Value = "3";

        //Response.Cookies["logintype"].Value = "admin";




    }
    protected void Page_Init(object sender, EventArgs e)
    {
        //if (Request.Cookies["loginid"] != null)
        //{
        //    Session["userid"] = Request.Cookies["loginid"].Value;

        //    Session["usertype"] = Request.Cookies["logintype"].Value;
        //}
        if (Session["userid"] != null)
        {
            createSession();
            Response.Redirect("dashboard.aspx");



        }
        if ((Request.Cookies["loginid"] != null && Request.Cookies["logintype"] != null) && (Request.Cookies["loginid"].Value != "" && Request.Cookies["logintype"].Value != ""))
        {
            Session["userid"] = Request.Cookies["loginid"].Value;
            Session["usertype"] = Request.Cookies["logintype"].Value;

            createSession();
            Response.Redirect("dashboard.aspx");
        }


        //HttpCookie loginid = new HttpCookie("loginid");
        //HttpCookie logintype = new HttpCookie("logintype");
        //Request.Cookies.Add(loginid);
        //Request.Cookies.Add(logintype);
        //Response.Cookies.Add(loginid);
        //Response.Cookies.Add(logintype);

    }

    public void createSession()
    {
        
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        conn.Open();
        
            string qryProj = "SELECT default_project from user_preference where user_id = @user ";
            SqlCommand cmdProj = new SqlCommand(qryProj, conn);
            cmdProj.Parameters.Add(new SqlParameter("user", Session["userid"].ToString()));
            var default_project = cmdProj.ExecuteScalar();
            if (default_project != null)
            {
                Session["selectedproject"] = default_project.ToString();
            }
            else
            {
                Session["selectedproject"] = "-1";
            }
        conn.Close();
    }
}
