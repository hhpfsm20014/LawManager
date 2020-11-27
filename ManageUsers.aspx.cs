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
using System.Drawing;
using System.IO;

public partial class ManageUsers : System.Web.UI.Page

{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection conn = objhdcon.OpenConnection();
        if (ddlProject.SelectedIndex == 0)
        {
            string qryfiles = "SELECT user_id AS ID, user_name AS Name, email_id AS Email, status AS Status, created_date AS DateCreated, last_visit AS LastVisited FROM User_Master";
            //string qryfiles = "SELECT User_Master.user_id AS ID, User_Master.user_name AS Name, User_Master.email_id AS Email, User_Master.status AS Status, User_Master.created_date As DateCreated, User_Master.last_visit AS LastVisited FROM User_Master INNER JOIN Modulewise_Issue_Assignment ON User_Master.user_id = Modulewise_Issue_Assignment.user_id";
            SqlCommand cmdfiles = new SqlCommand(qryfiles, conn);
            SqlDataReader dr = cmdfiles.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            conn.Close();

        }
        else 
        {
            string qryfiles = "SELECT User_Master.user_id AS ID, User_Master.user_name AS Name, User_Master.email_id AS Email, User_Master.status AS Status, User_Master.created_date AS DateCreated, User_Master.last_visit AS LastVisited, Project_Master.project_id FROM User_Master INNER JOIN Project_Master ON User_Master.user_id = Project_Master.user_id WHERE (Project_Master.project_id = '" + ddlProject.SelectedValue + "')";
            SqlCommand cmd = new SqlCommand(qryfiles, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            conn.Close();
        }

    
    }
    //protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlProject.SelectedIndex > 0)
    //    {
    //        ClsDBConnection con = new ClsDBConnection();

    //        SqlConnection cn = con.OpenConnection();
    //        SqlCommand cmd1 = new SqlCommand("SELECT issue_id,issue_name from Issue_Master WHERE project_id='" + ddlProject.SelectedValue + "'", cn);
    //        SqlDataReader dr1 = cmd1.ExecuteReader();
    //        ddlIssue.DataSource = dr1;
    //        if (dr1.Read() == true)
    //        {
    //            //int ddl = 1;
    //            ddlIssue.Items.Clear();
    //            ddlIssue.Items.Insert(0, "--Select--");

    //            do
    //            {

    //                ddlIssue.DataTextField = dr1.GetValue(1).ToString();
    //                ddlIssue.DataValueField = dr1.GetValue(0).ToString();
    //                ddlIssue.Items.Add(new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

    //                //ddlIssue.Items.Insert(ddl, new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

    //                //ddl++;
    //            } while (dr1.Read());


    //        }
    //        else
    //        {

    //            Response.Write("No Issues in Project");
    //        } dr1.Close();

    //    }
    //}
}