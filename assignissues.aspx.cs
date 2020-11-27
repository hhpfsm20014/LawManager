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

public partial class assignissues : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProject.SelectedIndex > 0)
        {
            ClsDBConnection con = new ClsDBConnection();

            SqlConnection cn = con.OpenConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT issue_id,issue_name from Issue_Master WHERE project_id='" + ddlProject.SelectedValue + "'", cn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            ddlIssue.DataSource = dr1;
            if (dr1.Read() == true)
            {
                //int ddl = 1;
                ddlIssue.Items.Clear();
                ddlIssue.Items.Insert(0, "--Select--");

                do
                {

                    ddlIssue.DataTextField = dr1.GetValue(1).ToString();
                    ddlIssue.DataValueField = dr1.GetValue(0).ToString();
                    ddlIssue.Items.Add(new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

                    //ddlIssue.Items.Insert(ddl, new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

                    //ddl++;
                } while (dr1.Read());


            }
            else
            {

                Response.Write("No Issues in Project");
            } dr1.Close();

            SqlCommand cmd2 = new SqlCommand("SELECT module_id,module_name from Project_Module WHERE project_id='" + ddlProject.SelectedValue + "'", cn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            ddlModule.DataSource = dr2;
            if (dr2.Read() == true)
            {
                //int ddl = 1;
                ddlModule.Items.Clear();
                ddlModule.Items.Insert(0, "--Select--");
                do
                {

                    ddlModule.DataTextField = dr2.GetValue(1).ToString();
                    ddlModule.DataValueField = dr2.GetValue(0).ToString();
                    ddlModule.Items.Add(new System.Web.UI.WebControls.ListItem(ddlModule.DataTextField, ddlModule.DataValueField));


                    //ddlModule.Items.Insert(ddl, new System.Web.UI.WebControls.ListItem(ddlModule.DataTextField, ddlModule.DataValueField));

                    //ddl++;
                } while (dr2.Read());

            }
            else
            {
                Response.Write("No modules in project");
            }
            dr2.Close();
        }
    }
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        if (ddlProject.SelectedIndex > 0 && ddlModule.SelectedIndex > 0 && ddlIssue.SelectedIndex > 0)
        {
            DBActivity db = new DBActivity();
            bool regi = db.addUser(ddlProject.SelectedValue.ToString(), ddlModule.SelectedValue.ToString(), ddlIssue.SelectedValue.ToString(), RblPriority.Text, txtStartDate.Text, txtEndDate.Text, txtIssueNotes.Text, ddlAddUsers.SelectedValue.ToString());
           
            if (regi == true)
            {
                fillgrid();
            }
        }
    }
    protected void fillgrid()
    {    //   where project_id='" + ddlProject.SelectedValue.ToString() + "'
        string qry = "SELECT * FROM modulewise_issue_assignment_query";
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection conn = objhdcon.OpenConnection();


        SqlCommand cmd = new SqlCommand(qry, conn);
        SqlDataReader dr = cmd.ExecuteReader();
        
        GridView1.DataSource = dr;
        GridView1.DataBind();

        dr.Close();
        conn.Close();
    }
}