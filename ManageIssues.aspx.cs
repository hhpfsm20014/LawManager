﻿using System;
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
using System.IO;
using System.Globalization;
using System.Drawing;

public partial class ManageIssues : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                HttpContext.Current.Session["issueaction"] = "submit";
                if (Request.QueryString["IssueId"] != null)
                {
                    Int32 IssueId = Convert.ToInt32(Request.QueryString["IssueId"]);
                    HttpContext.Current.Session["issueaction"] = "edit";
                    Session["EditIssueId"] = IssueId;
                    editIssueDataLoad(IssueId);

                }
            }
        }
        catch (Exception ex)
        {
            //pokemon exception handling  
            //return dt;
        }
    }

    private void GetNxtDate(string ProjectID)
    {
        DataTable dt = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        SqlConnection connection = new SqlConnection(strConnString);
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT isnull(CONVERT(VARCHAR(30),[nxtHearingDate],106),'N/A') AS NextDate,[issue_notes] AS Notes FROM [dbo].[Issue_Master] where [project_id]='" + ProjectID + "'ORDER BY [nxtHearingDate] DESC", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        connection.Close();
        NxtDateGrid.DataSource = dt;
        NxtDateGrid.DataBind();
    }

    public void editIssueDataLoad(Int32 IssueId)
    {
        try
        {
            ClsDBConnection cn = new ClsDBConnection();
            SqlConnection conn = cn.OpenConnection();

            SqlCommand cmd = new SqlCommand("SELECT Issue_Master.*, Project_Master.project_name,Project_Master.CaseId FROM Project_Master INNER JOIN Issue_Master ON Project_Master.project_id = Issue_Master.project_id WHERE issue_id = '" + IssueId + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                ddlProject.SelectedValue = dr.GetValue(1).ToString();
                ddlProject.Enabled = false;
                ddlProject.BackColor = Color.LightGoldenrodYellow;
                txtissuename.Text = dr.GetValue(17).ToString();
                txtPrevDesc.Text = dr.GetValue(7).ToString();
                txtissuedesc.Text = dr.GetValue(3).ToString();
                txtStart.Text = Convert.ToDateTime(dr.GetValue(8)).ToString("dd/MM/yyyy");
                txtNotes.Text = dr.GetValue(6).ToString();
            }
            dr.Close();
            conn.Close();
        }
        catch (Exception ex)
        {
            //pokemon exception handling  
            //return dt;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection conn = objhdcon.OpenConnection();
        string caseId = ddlProject.SelectedValue;
        Int32 issueId = 0;
        string qryProjectName = "SELECT top 1 issue_id FROM Issue_Master WHERE project_id='" + caseId + "' order by nxtHearingDate desc";
        SqlCommand cmdProjectName = new SqlCommand(qryProjectName, conn);
        SqlDataReader drProjectName = cmdProjectName.ExecuteReader();
        while (drProjectName.Read())
        {
            issueId = Convert.ToInt32(drProjectName[0]);
        }

        drProjectName.Close();

        DateTime nextdate = DateTime.ParseExact(txtStart.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DBActivity db = new DBActivity();
        int userid = Convert.ToInt32(Session["userid"].ToString());
        string projectid = caseId;
        try
        {
            if (fuProject.HasFile)
            {

                string filename = Path.GetFileName(fuProject.FileName).Trim();
                string guid = Guid.NewGuid().ToString();
                string FN = guid.Replace("-", "");
                string abc = FN + filename;
                fuProject.SaveAs(Server.MapPath("~/uploadedFiles/") + abc);
                string filePath = "~/uploadedFiles/" + abc;
                if (Session["issueaction"] == "submit")
                {
                    if (issueId > 0)
                    {
                        bool regi1 = db.IssueUpdate(issueId, txtPrevDesc.Text);
                    }
                    long regi = db.IssueSubmit(projectid, txtissuedesc.Text, txtNotes.Text, userid, nextdate.ToString());

                    string fileID = db.fileUploading(abc, filename, filePath, Convert.ToInt64(ddlProject.SelectedValue), (string)Convert.ToString(regi));
                }
                else
                {
                    bool bol = db.IssueDataUpdate(issueId, txtissuedesc.Text, txtPrevDesc.Text, txtNotes.Text, nextdate.ToString());
                    string fileID = db.fileUploading(abc, filename, filePath, Convert.ToInt64(ddlProject.SelectedValue), (string)Convert.ToString(Session["EditIssueId"]));
                }
            }
            else
            {
                if (Session["issueaction"] == "submit")
                {

                    if (issueId > 0)
                    {
                        bool regi1 = db.IssueUpdate(issueId, txtPrevDesc.Text);
                    }
                    long regi = db.IssueSubmit(projectid, txtissuedesc.Text, txtNotes.Text, userid, nextdate.ToString());
                }
                else
                {
                    bool bol = db.IssueDataUpdate(issueId, txtissuedesc.Text, txtPrevDesc.Text, txtNotes.Text, nextdate.ToString());
                }

            }
            GetNxtDate(caseId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {

        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection conn = objhdcon.OpenConnection();
        if (ddlProject.SelectedIndex == 0)
        {
            txtissuename.Text = "";
        }
        else
        {
            string caseId = ddlProject.SelectedValue;
            string qryProjectName = "SELECT CaseId FROM Project_Master WHERE project_id='" + caseId + "'";
            SqlCommand cmdProjectName = new SqlCommand(qryProjectName, conn);
            SqlDataReader drProjectName = cmdProjectName.ExecuteReader();
            while (drProjectName.Read())
            {
                txtissuename.Text = drProjectName[0].ToString();
            }
            drProjectName.Close();
            GetNxtDate(caseId);
        }
    }

}
