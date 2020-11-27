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
using System.Text;
using System.Globalization;

public partial class view_projects : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txtCaseId.Attributes.Add("placeholder", "Case Id");
            txtCaseId.Attributes.Add("style", "width:100%;");
            if (!IsPostBack)
            {
                getWhileLoopData();
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    private void getWhileLoopData()
    {
        DataTable dt = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        SqlConnection connection = new SqlConnection(strConnString);
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT project_id,project_name AS CaseName,CaseId AS CaseId,project_description AS Description FROM Project_Master WHERE IsDeleted =0", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        connection.Close();
        sqlDa.Fill(dt);
        CaseGrid.DataSource = dt;
        CaseGrid.DataBind();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
        
        if (CategoryId == -1)
        {
            getWhileLoopData();         
        }
        else
        {
            GetGridDate(CategoryId);
        }
    }

    private void GetGridDate(Int32 CategoryId)
    {
        DataTable dt = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        SqlConnection connection = new SqlConnection(strConnString);
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT project_id,project_name AS CaseName,CaseId AS CaseId,project_description AS Description FROM Project_Master WHERE [CategoryId] = '" + CategoryId + "'", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        connection.Close();
        sqlDa.Fill(dt);
        CaseGrid.DataSource = dt;
        CaseGrid.DataBind();
    }
    protected void CaseGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CaseEdit")
        {
            Int32 rowindex = Convert.ToInt32(e.CommandArgument);
            Int32 ProjId = Convert.ToInt32(CaseGrid.DataKeys[rowindex].Values[0]);
            Response.Redirect("ManageProject.aspx?ProjectId=" + ProjId);
        }
        if(e.CommandName == "CaseDelete")
        {
            Int32 rowindex = Convert.ToInt32(e.CommandArgument);
            Int32 ProjId = Convert.ToInt32(CaseGrid.DataKeys[rowindex].Values[0]);
            DataTable dt = new DataTable();
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection connection = new SqlConnection(strConnString);
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand("UPDATE [dbo].[Project_Master] SET IsDeleted = 1 WHERE project_id="+ ProjId, connection);
            sqlCmd.ExecuteNonQuery();
            //sqlDa.Fill(dt);
            connection.Close();
            getWhileLoopData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            this.SearchLoad();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void SearchLoad()
    {
        string CaseNo = txtCaseId.Text.Trim();
        LoadGrid(CaseNo);
    }

    protected void LoadGrid(string CaseNo)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter sda = null;

        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string ssql = "SELECT project_id,project_name AS CaseName,CaseId AS CaseId,project_description AS Description FROM Project_Master WHERE IsDeleted =0";
            if (!string.IsNullOrEmpty(CaseNo)) { ssql=ssql+ " AND CaseId='"+ CaseNo + "'"; }
            cmd = new SqlCommand(ssql, con);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            CaseGrid.DataSource = dt;
            CaseGrid.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            sda.Dispose();
            cmd.Dispose();
            con.Close();
        }
    }
}