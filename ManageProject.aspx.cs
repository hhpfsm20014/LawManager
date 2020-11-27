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

public partial class ManageProject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                HttpContext.Current.Session["action"] = "submit";
                if (Request.QueryString["ProjectId"] != null)
                {
                    Int32 ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                    HttpContext.Current.Session["action"] = "edit";
                    Session["ProjectId"] = ProjectId;
                    editDataLoad(ProjectId);
                    GetNxtDate(ProjectId);

                    btnHearing.Visible = true;
                    lblHearing.Visible = true;
                    lblDateSummary.Visible = true;
                }
                
                if (Request.QueryString["ProjectId"] == null)
                {
                    btnHearing.Visible = false;
                    lblHearing.Visible = false;
                    lblDateSummary.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            //pokemon exception handling  
            //return dt;
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

    public void editDataLoad(Int32 ProjectId)
    { 
        try
            {
                ClsDBConnection cn = new ClsDBConnection();
                SqlConnection conn = cn.OpenConnection();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project_Master WHERE project_id='" + ProjectId + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtCaseId.Text=dr.GetValue(17).ToString();
                    //txtCaseId.ReadOnly=true;
                    txtCaseId.BackColor=Color.LightGoldenrodYellow;
                    txtPname.Text=dr.GetValue(3).ToString();
                    //txtPname.ReadOnly = true;
                    //txtPname.BackColor = Color.LightGoldenrodYellow;
                    txtNameOfParty.Text=dr.GetValue(11).ToString();
                    txtOppositions.Text=dr.GetValue(12).ToString();
                    txtContactDetails.Text=dr.GetValue(13).ToString();
                    txtLawer.Text=dr.GetValue(14).ToString();
                    txtLawyerContact.Text=dr.GetValue(15).ToString();
                    txtNatureOfCase.Text=dr.GetValue(16).ToString();
                    txtSummary.Text = dr.GetValue(10).ToString();
                    txtStart.Text = Convert.ToDateTime(dr.GetValue(5)).ToString("dd/MM/yyyy");
                    //txtEnd.Text = Convert.ToDateTime(dr.GetValue(6)).ToString("dd/MM/yyyy");
                    ddlCategory.SelectedValue = dr.GetValue(18).ToString();
                    ddlCourt.SelectedValue = dr.GetValue(19).ToString();
                    txtOppoContactDetails.Text = dr.GetValue(20).ToString();
                    txtOppoLawer.Text = dr.GetValue(21).ToString();
                    txtOppoLawyerContact.Text = dr.GetValue(22).ToString();
                    //txtProjectDesc.HtmlStrippedText=dr.GetValue(10).ToString();
                    //testinf
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string descriptions = txtSummary.Text;
            string htmltext = txtSummary.HtmlStrippedText;
            //string startdate = txtStart.Text;
            DateTime startdate = DateTime.ParseExact(txtStart.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime enddate = DateTime.ParseExact(txtEnd.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime entrydate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DBActivity db = new DBActivity();
            long regi = 0;
            int userid = Convert.ToInt32(Session["userid"].ToString());
            if (Session["action"] == "edit")
            {
                regi = db.EditProject(Convert.ToInt32(Session["ProjectId"]), txtPname.Text, txtSummary.Text, startdate.ToString(), "", entrydate.ToString(), ddlCategory.SelectedItem.Text, ddlCourt.SelectedItem.Text, htmltext, txtNameOfParty.Text.Trim(), txtOppositions.Text.Trim(), txtContactDetails.Text.Trim(), txtLawer.Text.Trim(), txtLawyerContact.Text.Trim(), txtNatureOfCase.Text.Trim(), txtCaseId.Text.Trim(), Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlCourt.SelectedValue), txtOppoContactDetails.Text.Trim(), txtOppoLawer.Text.Trim(), txtOppoLawyerContact.Text.Trim(), int.Parse(ddlDistrict.SelectedItem.Value.ToString()));
            }
            else
            {
                if (CheckCaseNo(txtCaseId.Text.Trim()))
                {
                    throw new Exception("Duplicate Case No is not allowed");
                }
                else
                {
                    regi = db.ProjectSubmit(txtPname.Text, txtSummary.Text, startdate.ToString(), "", entrydate.ToString(), ddlCategory.SelectedItem.Text, ddlCourt.SelectedItem.Text, htmltext, txtNameOfParty.Text.Trim(), txtOppositions.Text.Trim(), txtContactDetails.Text.Trim(), txtLawer.Text.Trim(), txtLawyerContact.Text.Trim(), txtNatureOfCase.Text.Trim(), txtCaseId.Text.Trim(), Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlCourt.SelectedValue), txtOppoContactDetails.Text.Trim(), txtOppoLawer.Text.Trim(), txtOppoLawyerContact.Text.Trim(), userid, int.Parse(ddlDistrict.SelectedItem.Value.ToString()));
                }
            }
            if (txtFileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(txtFileUpload.FileName).Trim();
                    string guid = Guid.NewGuid().ToString();
                    string FN = guid.Replace("-", "");
                    string abc = FN + filename;
                    txtFileUpload.SaveAs(Server.MapPath("~/uploadedFiles/") + abc);
                    string filePath = "~/uploadedFiles/" + abc;
                    string fileID = db.fileUploading(abc, filename, filePath, regi, "");

                }
                catch (Exception ex) { lblerrmgs.Text = ex.Message; }
            }
            if (regi != 0)
            {
                Server.Transfer("viewprojects.aspx");
            }
        }
        catch (Exception ex) { lblerrmgs.Text = ex.Message; }
    }

    protected void end_SelectionChanged(object sender, EventArgs e)
    {
       // txtEnd_PopupControlExtender.Commit(end.SelectedDate.ToShortDateString());
    }
    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {
       // txtStart_PopupControlExtender.Commit(start.SelectedDate.ToShortDateString());
    }

    bool CheckCaseNo(string CaseId)
    {
        DataTable dt = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        SqlConnection connection = new SqlConnection(strConnString);
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Project_Master WHERE CaseId='"+ CaseId + "'", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        connection.Close();
        if (dt.Rows.Count > 0) { return true; } else { return false; }
        
    }
}