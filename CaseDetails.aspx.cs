using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CaseDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["ProjID"] != null)
            {
                Int32 ProjectID = Convert.ToInt32(Request.QueryString["ProjID"]);
                Session["EditIssueId"] = ProjectID;
                GetData(ProjectID);
                GetNxtDate(ProjectID);
            }
        }
        
    }

    private void GetNxtDate(Int32 ProjectID)
    {
        DataTable dt = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        SqlConnection connection = new SqlConnection(strConnString);
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT isnull(CONVERT(VARCHAR(30),[nxtHearingDate],106),'N/A') AS NextDate,[issue_notes] AS Notes FROM [dbo].[Issue_Master] where [project_id]='" + ProjectID + "'ORDER BY [nxtHearingDate] DESC", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        NxtDateGrid.DataSource = dt;
        NxtDateGrid.DataBind();
        connection.Close();
    }

    private void GetData(Int32 ProjectID)
    {
        DataTable dt = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        SqlConnection connection = new SqlConnection(strConnString);
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT * FROM [dbo].[Project_Master] where [project_id]='" + ProjectID + "'", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        connection.Close();

        foreach (DataRow item in dt.Rows)
        {
            lblCourt.Text = item["Category"].ToString();
            lblCaseNo.Text = item["CaseId"].ToString();
            lblCaseName.Text = item["project_name"].ToString();
            lblNameFrstParty.Text = item["NameOfParty"].ToString();
            lblNameScndParty.Text = item["Oppositions"].ToString();
            lblContctFrst.Text = item["ContactDetails"].ToString();
            lblContctScnd.Text = item["OppoContactDetails"].ToString();
            lblLawerFrst.Text = item["Lawyer"].ToString();
            lblLawerScnd.Text = item["OppoLawyer"].ToString();
            lblLawterContctFrst.Text = item["LaywerContactDetails"].ToString();
            lblLawterContctScnd.Text = item["OppoLaywerContactDetails"].ToString();
            lblNature.Text = item["NatureOfCase"].ToString();
            lblSummary.Text = item["project_description"].ToString();
            lblCaseStrtDate.Text = Convert.ToDateTime(item["start_date"]).ToString("dd/MM/yyyy");         
        }
       
    }
}