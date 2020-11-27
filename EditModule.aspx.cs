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

public partial class EditModule : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    //protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        protected void Page_Prerender(object sender, EventArgs e)
    {
        //txtProjectID.Text = ddlProject.SelectedValue;
        ClsDBConnection con = new ClsDBConnection();

        SqlConnection cn = con.OpenConnection();
        SqlCommand cmd = new SqlCommand("SELECT module_id,module_name from Project_Module WHERE project_id='" + Session["selectedproject"].ToString() + "'", cn);
        SqlDataReader dr = cmd.ExecuteReader();
        ddlModule.DataSource = dr;
        if (dr.Read())
        {
            ddlModule.Items.Clear();
            int ddl = 0;
            do
            {
                ddlModule.DataTextField = dr.GetValue(1).ToString();
                ddlModule.DataValueField = dr.GetValue(0).ToString();

                ddlModule.Items.Insert(ddl, ddlModule.DataTextField);
                ddl++;
            }
            while (dr.Read());
        }
        else
        {
            Console.WriteLine("no modules");
        }


        //txtProjectID.Text = ddlP.SelectedValue;
        //conn.Open();

        //SqlCommand cmd = new SqlCommand("SELECT Project_Module.module_id, Project_Module.module_name, Project_Module.module_description, Project_Master.project_id FROM Project_Master CROSS JOIN Project_Module WHERE project_id='" + DDL1.SelectedValue + "'", conn);
        //SqlDataReader dr = cmd.ExecuteReader();

        //if (dr.Read() == true)
        //{
        //    txtProjectDesc.Text = dr.GetValue(4).ToString();
        //    txtStartDate.Text = dr.GetValue(5).ToString();
        //    txtEndDate.Text = dr.GetValue(6).ToString();
        //}
        //dr.Close();
        //conn.Close();
    }
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {

        //txtModuleID.Text = ddlModule.SelectedValue;
        ClsDBConnection cn = new ClsDBConnection();
        SqlConnection conn = cn.OpenConnection();
        

        SqlCommand cmd = new SqlCommand("SELECT * FROM Project_Module WHERE module_name='" + ddlModule.SelectedValue + "'", conn);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read() == true)
        {
            txtModuleID.Text = dr.GetValue(0).ToString();
            txtModuleName.Text = dr.GetValue(2).ToString();
            txtModuledesc.Text = dr.GetValue(3).ToString();
        }
        dr.Close();
        conn.Close();
    }
    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{
    //    DBActivity db = new DBActivity();
    //    string modulename = ddlModule.SelectedValue;
    //    bool regi = db.EditModule(txtModuleID.Text, txtModuleName.Text, txtModuledesc.Text);
    //    if (regi)
    //    {
    //        Response.Write("update sucess");
    //    }
    //    else
    //    {
    //        Response.Write("update fail");
    //    }
    //}


    protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
    {

        DBActivity db = new DBActivity();
        string modulename = ddlModule.SelectedValue;
        bool regi = db.EditModule(txtModuleID.Text, txtModuleName.Text, txtModuledesc.Text);
        if (regi)
        {
            Response.Write("update sucess");
        }
        else
        {
            Response.Write("update fail");
        }
    }

  
}