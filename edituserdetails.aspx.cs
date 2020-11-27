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
using System.Net;

public partial class edituserdetails : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string user_id = Request.QueryString["UserID"];

        if (user_id != null)
        {
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection cn = objhdcon.OpenConnection();
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = cn;
            string qryProject = "SELECT * FROM New_Feature_Tracking WHERE(User_id = '" + user_id + "')";
            SqlCommand cmdProject = new SqlCommand(qryProject, cn);
            SqlDataReader drProject = cmdProject.ExecuteReader();

            listUpdate.DataSource = drProject;
            listUpdate.DataValueField = "project_id";
            listUpdate.DataTextField = "project_name";
            listUpdate.DataBind();
            drProject.Close();
            try
            {
                cmnd.Parameters.Clear();
                string qry = "SELECT * From User_Master WHERE(User_id = '" + user_id + "')";
                SqlCommand cmd = new SqlCommand(qry, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                lblID.Text = user_id;


                if (dr.Read())
                {
                    txtName.Text = dr.GetStringOrNull(1);
                    lblEmailID.Text = dr.GetStringOrNull(4);
                    string abc = dr.GetStringOrNull(3);
                    if (abc == "Admin"||abc=="admin")
                    { ddlAccess.SelectedIndex = 0; }
                    else if (abc == "Developer" || abc == "developer")
                    { ddlAccess.SelectedIndex = 1; }
                    else
                        ddlAccess.SelectedIndex = 2;
                    //ddlAccess.Items.FindByValue(dr.GetStringOrNull(3)).Selected = true;

                } dr.Close();

            }
            finally
            {
                objhdcon.CloseConnection();
            }
            //string qryProject = "SELECT * FROM New_Feature_Tracking WHERE(User_id = '" + user_id + "')";
            //SqlCommand cmdProject = new SqlCommand(qryProject, cn);
            //SqlDataReader drProject = cmdProject.ExecuteReader();

            //gvprojects.DataSource = drProject;
            //gvprojects.DataBind();
            //drProject.Close();

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();


        string UserID = lblID.Text;
        string Name = txtName.Text;
        bool regi = db.EditUser(UserID, Name, ddlAccess.Text);
        if (regi)
        {
            Response.Write("update sucess");
        }
        else
        {
            Response.Write("update fail");
        }
    }
    protected void btnUser_Click(object sender, EventArgs e)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        DBActivity db = new DBActivity();
        string UserID = lblID.Text;
        string project = ListBox1.SelectedValue.ToString();
        string ProjectName = ListBox1.SelectedItem.ToString();
        bool regi = db.AddusersProject(UserID, project, ProjectName);
        if (regi)
        {
            lbltxt.Text = "The User is successfully assigned to the project";
        }
        else
        {
            lbltxt.Text = "The User is already assigned can't be assigned again";
        }
        string qryProject = "SELECT * FROM New_Feature_Tracking WHERE(User_id = '" + UserID + "')";
        SqlCommand cmdProject = new SqlCommand(qryProject, cn);
        SqlDataReader drProject = cmdProject.ExecuteReader();

        listUpdate.DataSource = drProject;
        listUpdate.DataValueField = "project_id";
        listUpdate.DataTextField = "project_name";
        listUpdate.DataBind();

        ////listUpdate.DataValueField = drProject.GetValue(1).ToString();
        //listUpdate.DataTextField = drProject.GetValue(4).ToString();
        //listUpdate.Items.Add(new System.Web.UI.WebControls.ListItem(listUpdate.DataValueField, listUpdate.DataTextField));
        drProject.Close();
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        DBActivity db = new DBActivity();
        string UserID = lblID.Text;
        string project = listUpdate.SelectedValue.ToString();
        string ProjectName = listUpdate.SelectedItem.ToString();
        bool regi = db.DeleteusersProject(UserID, project, ProjectName);
        if (regi)
        {
            lbl2txt.Text = "The Project is successfully removed";
        }
        else
        {
            lbl2txt.Text = "The Project can't be removed";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        string UserID = lblID.Text;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.Parameters.Clear();
        cmd.CommandText = "DELETE  FROM User_Master WHERE(User_id = @uid)";
        cmd.Parameters.Add(new SqlParameter("uid", UserID));
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
    }
}
