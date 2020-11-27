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

public partial class DashMaster : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            string qry = "SELECT user_name from user_master where user_id = @user ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(qry, conn);
            //cmd.Parameters.Add("@u_id", SqlDbType.Int);
            //cmd.Parameters["@u_id"].Value = Session["userid"].ToString();;
            cmd.Parameters.Add(new SqlParameter("user", Session["userid"].ToString()));
            lblName.Text = cmd.ExecuteScalar().ToString();
            if (Session["usertype"].ToString() != "admin")
            {
                leftpane.Visible = false;
            }




            if (!IsPostBack)
            {
                if (Session["selectedproject"] != null)
                {
                    if (Session["selectedproject"].ToString() != "-1")
                    {
                        Int32 selind = Convert.ToInt32(Session["selectedproject"].ToString());
                        ddlProject.SelectedIndex = selind;
                    }
                }
            }

            conn.Close();

        }
        else
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["selectedproject"] != null)
        //    {
        //        SqlDataSource sqlData = new SqlDataSource();
        //        sqlData.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        //        sqlData.SelectCommand = "SELECT * FROM Project_Master";
        //        sqlData.ID = "sqlD1";
        //        DropDownList ddlProject = new DropDownList();
        //        ddlProject.DataSourceID = "sqlD1";
        //        ddlProject.AppendDataBoundItems = true;
        //        ddlProject.DataTextField = "project_name";
        //        ddlProject.DataValueField = "project_id";

        //        ddlProject.AutoPostBack = true;
        //        this.form2.Controls.Add(ddlProject);
        //        this.form2.Controls.Add(sqlData);
        //        ddlProject.DataBind();
        //        string val = Session["selectedproject"].ToString();
        //        ddlProject.SelectedValue = Session["selectedproject"].ToString();
        //        ddlProject.Items.FindByValue(val).Selected = true;
        //    }
        //}.
        if (!IsPostBack)
        {
            if (Session["selectedproject"] != null)
            {
                if (Session["selectedproject"].ToString() != "-1")
                {
                    Int32 selind = Convert.ToInt32(Session["selectedproject"].ToString());
                    ddlProject.SelectedIndex = selind;
                }
            }
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["loginid"].Value = null;
        Response.Cookies["logintype"].Value = null;
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
    public String LabelValue
    {

        get { return lblName.Text; }

    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["selectedproject"] = null;
        Session["selectedprojectname"] = null;
        if (ddlProject.SelectedIndex == 0)
        {
            Session["selectedproject"] = -1;
            Session["selectedprojectname"] = "All";

        }
        else
        {
            Session["selectedproject"] = ddlProject.SelectedValue;
            Session["selectedprojectname"] = ddlProject.SelectedItem.Text;

        }
    }


}
