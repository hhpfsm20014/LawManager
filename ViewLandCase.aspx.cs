using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewLandCase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GridLoadAll();
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void GridLoadAll()
    {
        //DataTable dt = new DataTable();
        //string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        //SqlConnection connection = new SqlConnection(strConnString);
        //connection.Open();
        //SqlCommand sqlCmd = new SqlCommand("SELECT LandCaseId, CaseNo, CaseNature, CourtName FROM [dbo].[LandCase]  WHERE IsDeleted=0", connection);
        //SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        //connection.Close();
        //sqlDa.Fill(dt);
        //CaseGrid.DataSource = dt;
        //CaseGrid.DataBind();

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

            cmd = new SqlCommand("spGetsLandCase", con);
            //cmd.Parameters.AddWithValue("@CourtNo", CourtNo);
            cmd.CommandType = CommandType.StoredProcedure;
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
            Int32 LandCaseId = Convert.ToInt32(CaseGrid.DataKeys[rowindex].Values[0]);
            Response.Redirect("ViewAddEditLandCase.aspx?LandCaseId=" + LandCaseId);
        }
        if (e.CommandName == "CaseDelete")
        {
            Int32 rowindex = Convert.ToInt32(e.CommandArgument);
            Int32 LandCaseId = Convert.ToInt32(CaseGrid.DataKeys[rowindex].Values[0]);
            DataTable dt = new DataTable();
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection connection = new SqlConnection(strConnString);
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand("UPDATE [dbo].[LandCase] SET IsDeleted = 1 WHERE LandCaseId=" + LandCaseId, connection);
            sqlCmd.ExecuteNonQuery();
            //sqlDa.Fill(dt);
            connection.Close();
            GridLoadAll();
        }
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        this.SearchLoad();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}

    //public void SearchLoad()
    //{
    //    string CaseNo = txtCaseId.Text.Trim();
    //    LoadGrid(CaseNo);
    //}

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
            if (!string.IsNullOrEmpty(CaseNo)) { ssql = ssql + " AND CaseId='" + CaseNo + "'"; }
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