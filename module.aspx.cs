using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class module : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["sessionhistory"] != null)
        //    {
        //        long dtUser = (long)Session["sessionhistory"];


        //    }
        //    else
        //    {
        //        Session.Abandon();
        //        Session.Clear();

        //    }
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();
        string selpro = Session["selectedproject"].ToString();
        if (selpro != "-1")
        {
            bool regi = db.moduleSubmit(selpro, txtModuleName.Text, txtModuleDesc.Text);
            if (regi == true)
            {
                fillgrid();
            }
        }
        else
        {
            lblError.Text = "please select project";
        
        }


    }
    protected void fillgrid()
    {
        string selpro = Session["selectedproject"].ToString();
        string qry = "SELECT module_id AS [Id], module_name AS [Module Name] FROM Project_Module where project_id='" + selpro + "' order by module_id";
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection conn = objhdcon.OpenConnection();


        SqlCommand cmd = new SqlCommand(qry, conn);
        SqlDataReader dr = cmd.ExecuteReader();

        GridView1.DataSource = dr;
        GridView1.DataBind();

        dr.Close();
        conn.Close();
    }

    //protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fillgrid();
    //    ddlProject.Items.Remove("--Select--");
    //}
}