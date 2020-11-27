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

public partial class ViewAddEditLandCase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadDistrict(ddlDistrict);
                HttpContext.Current.Session["action"] = "submit";
                if (Request.QueryString["LandCaseId"] != null)
                {
                    Int32 LandCaseId = Convert.ToInt32(Request.QueryString["LandCaseId"]);
                    HttpContext.Current.Session["action"] = "edit";
                    Session["LandCaseId"] = LandCaseId;
                    editDataLoad(LandCaseId);
                    GetNxtDate(LandCaseId);
                }
            }
        }
        catch (Exception ex)
        {
            //pokemon exception handling  
            //return dt;
        }
    }

    private void LoadDistrict(DropDownList ddlDistrict)
    {
        try
        {
            DataTable dt = new DataTable();
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection connection = new SqlConnection(strConnString);
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM District", connection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            connection.Close();

            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new ListItem("Select District", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ListItem lst = new ListItem();
                lst.Text = dr["DistrictName"].ToString();
                lst.Value = dr["DistrictID"].ToString();
                ddlDistrict.Items.Add(lst);
            }
        }
        catch (Exception ex)
        {
            lblerrmgs.Text = ex.Message;
        }
    }

    private void GetNxtDate(Int32 LandCaseId)
    {
        DataTable dt = new DataTable();
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        SqlConnection connection = new SqlConnection(strConnString);
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT isnull(CONVERT(VARCHAR(30),[nxtHearingDate],106),'N/A') AS NextDate,[issue_notes] AS Notes FROM [dbo].[Issue_Master] where [project_id]='" + LandCaseId + "'ORDER BY [nxtHearingDate] DESC", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        //NxtDateGrid.DataSource = dt;
        //NxtDateGrid.DataBind();
        connection.Close();
    }

    public void editDataLoad(Int32 LandCaseId)
    {
        try
        {
            ClsDBConnection cn = new ClsDBConnection();
            SqlConnection conn = cn.OpenConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM LandCase WHERE LandCaseId ='" + LandCaseId + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                ddlDistrict.SelectedValue = dr["DistrictID"].ToString();
                txtNameOfCourt.Text=dr["CourtName"].ToString();
                txtCaseId.Text=dr["CaseNo"].ToString();
                txtNatureOfCase.Text=dr["CaseNature"].ToString();
                txtNameOfParty.Text=dr["NameOfParty"].ToString();
                txtOppositions.Text=dr["OppoNameOfParty"].ToString();
                txtContactDetails.Text=dr["PartyContact"].ToString();
                txtOppoContactDetails.Text=dr["OppoPartyContact"].ToString();
                txtLawyer.Text=dr["Lawyer"].ToString();
                txtOppoLawyer.Text=dr["OppoLawyer"].ToString();
                txtLawyerContact.Text=dr["LawyerContact"].ToString();
                txtOppoLawyerContact.Text=dr["OppoLawyerContact"].ToString();
                txtScheduleoftheland.Text=dr["LandSchedule"].ToString();
                txtPlaintDescription.Text=dr["PlaintDescription"].ToString();
                txtDescriptionofWS.Text=dr["WSDescription"].ToString();
                txtPlaintorWSdate.Text= Convert.ToDateTime(dr["PlaintWSDate"])> Convert.ToDateTime("01 JAN 1950") ? Convert.ToDateTime(dr["PlaintWSDate"]).ToString("dd-MMM-yyyy"):"";
                txtNextDate.Text= Convert.ToDateTime(dr["NextDate"]) > Convert.ToDateTime("01 JAN 1950") ? Convert.ToDateTime(dr["NextDate"]).ToString("dd-MMM-yyyy") : "";
                txtNextDateReason.Text=dr["NextDateReason"].ToString();
                txtCaseResult.Text=dr["CaseOutcome"].ToString();
                txtCaseResultDate.Text= Convert.ToDateTime(dr["OutcomeDate"]) > Convert.ToDateTime("01 JAN 1950") ? Convert.ToDateTime(dr["OutcomeDate"]).ToString("dd-MMM-yyyy") : "";
                txtAppealorRevisionNo.Text=dr["AppealOrRevisionNo"].ToString();
                txtAppealRevisionSubmissiondate.Text= Convert.ToDateTime(dr["AppealOrRevisionFilingDate"]) > Convert.ToDateTime("01 JAN 1950") ? Convert.ToDateTime(dr["AppealOrRevisionFilingDate"]).ToString("dd-MMM-yyyy") : "";
                txtAppealCourtName.Text=dr["AppealCourtName"].ToString();
                txtAppealSubmissionOrReplyDate.Text= Convert.ToDateTime(dr["plaintFilingDate"]) > Convert.ToDateTime("01 JAN 1950") ? Convert.ToDateTime(dr["plaintFilingDate"]).ToString("dd-MMM-yyyy") : "";
                txtAdvocateName.Text=dr["AdvocateName"].ToString();
                txtDocumentHandoverDate.Text= Convert.ToDateTime(dr["DocumentHandoverDate"]) > Convert.ToDateTime("01 JAN 1950") ? Convert.ToDateTime(dr["DocumentHandoverDate"]).ToString("dd-MMM-yyyy") : "";
                txtHandoverList.Text=dr["DocumentHandoverList"].ToString();
                txtDocumentSubmissionDescription.Text=dr["CourtSubmittedDocumentNote"].ToString();
                txtNextAppealRevisionDate.Text= Convert.ToDateTime(dr["NextAppealDate"]) > Convert.ToDateTime("01 JAN 1950") ? Convert.ToDateTime(dr["NextAppealDate"]).ToString("dd-MMM-yyyy") : "";
                txtNextAppealRevisionDateReason.Text=dr["NextAppealReason"].ToString();
                txtResultAppealRevision.Text=dr["AppealOrRevisionResult"].ToString();
                txtRemark.Text=dr["Remark"].ToString();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int DistrictID = int.Parse(ddlDistrict.SelectedItem.Value);
            string CourtName = txtNameOfCourt.Text.Trim();
            string CaseNo = txtCaseId.Text.Trim();
            string CaseNature = txtNatureOfCase.Text.Trim();
            string NameOfParty = txtNameOfParty.Text.Trim();
            string OppoNameOfParty = txtOppositions.Text.Trim();
            string PartyContact = txtContactDetails.Text.Trim();
            string OppoPartyContact = txtOppoContactDetails.Text.Trim();
            string Lawyer = txtLawyer.Text.Trim();
            string OppoLawyer = txtOppoLawyer.Text.Trim();
            string LawyerContact = txtLawyerContact.Text.Trim();
            string OppoLawyerContact = txtOppoLawyerContact.Text.Trim();
            string LandSchedule = txtScheduleoftheland.Text.Trim();
            string PlaintDescription = txtPlaintDescription.Text.Trim();
            string WSDescription = txtDescriptionofWS.Text.Trim();
            string PlaintWSDate = string.IsNullOrEmpty(txtPlaintorWSdate.Text.Trim())? "" : DateTime.ParseExact(txtPlaintorWSdate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString();
            string NextDate = string.IsNullOrEmpty(txtNextDate.Text.Trim()) ? "" : DateTime.ParseExact(txtNextDate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString();
            string NextDateReason = txtNextDateReason.Text.Trim();
            string CaseOutcome = txtCaseResult.Text.Trim();
            string OutcomeDate = string.IsNullOrEmpty(txtCaseResultDate.Text.Trim()) ? "" : DateTime.ParseExact(txtCaseResultDate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString();
            string AppealOrRevisionNo = txtAppealorRevisionNo.Text.Trim();
            string AppealOrRevisionFilingDate = string.IsNullOrEmpty(txtAppealRevisionSubmissiondate.Text.Trim()) ? "" : DateTime.ParseExact(txtAppealRevisionSubmissiondate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString();
            string AppealCourtName = txtAppealCourtName.Text.Trim();
            string plaintFilingDate = string.IsNullOrEmpty(txtAppealSubmissionOrReplyDate.Text.Trim()) ? "" : DateTime.ParseExact(txtAppealSubmissionOrReplyDate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString();
            string AdvocateName = txtAdvocateName.Text.Trim();
            string DocumentHandoverDate = string.IsNullOrEmpty(txtDocumentHandoverDate.Text.Trim()) ? "" : DateTime.ParseExact(txtDocumentHandoverDate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString();
            string DocumentHandoverList = txtHandoverList.Text.Trim();
            string CourtSubmittedDocumentNote = txtDocumentSubmissionDescription.Text.Trim();
            string NextAppealDate = string.IsNullOrEmpty(txtNextAppealRevisionDate.Text.Trim()) ? "" : DateTime.ParseExact(txtNextAppealRevisionDate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString();
            string NextAppealReason = txtNextAppealRevisionDateReason.Text.Trim();
            string AppealOrRevisionResult = txtResultAppealRevision.Text.Trim();
            string Remark = txtRemark.Text.Trim();
            
            //DateTime entrydate = DateTime.ParseExact(DateTime.Now.ToString("dd-MMM-yyyy"), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            DBActivity db = new DBActivity();
            long regi = 0;
            int UserId = Convert.ToInt32(Session["userid"].ToString());
            if (Session["action"].ToString() == "edit")
            {
                regi = db.LandCaseEdit(Convert.ToInt32(Session["LandCaseId"]), DistrictID, CourtName, CaseNo, CaseNature, NameOfParty, OppoNameOfParty, PartyContact, OppoPartyContact, Lawyer, OppoLawyer, LawyerContact, OppoLawyerContact, LandSchedule, PlaintDescription, WSDescription, PlaintWSDate, NextDate, NextDateReason, CaseOutcome, OutcomeDate, AppealOrRevisionNo, AppealOrRevisionFilingDate, AppealCourtName, plaintFilingDate, AdvocateName, DocumentHandoverDate, DocumentHandoverList, CourtSubmittedDocumentNote, NextAppealDate, NextAppealReason, AppealOrRevisionResult, Remark);
            }
            else
            {
                if (CheckCaseNo(txtCaseId.Text.Trim()))
                {
                    throw new Exception("Duplicate Case No is not allowed");
                }
                else
                {
                    regi = db.LandCaseSave(CourtName, DistrictID, CaseNo, CaseNature, NameOfParty, OppoNameOfParty, PartyContact, OppoPartyContact, Lawyer, OppoLawyer, LawyerContact, OppoLawyerContact, LandSchedule, PlaintDescription, WSDescription, PlaintWSDate, NextDate, NextDateReason, CaseOutcome, OutcomeDate, AppealOrRevisionNo, AppealOrRevisionFilingDate, AppealCourtName, plaintFilingDate, AdvocateName, DocumentHandoverDate, DocumentHandoverList, CourtSubmittedDocumentNote, NextAppealDate, NextAppealReason, AppealOrRevisionResult, Remark, UserId);
                }
            }
            if (regi != 0)
            {
                //Server.Transfer("ViewAddEditLandCase.aspx");
                Response.Redirect("ViewAddEditLandCase.aspx");
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
        SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Project_Master WHERE CaseId='" + CaseId + "'", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        connection.Close();
        if (dt.Rows.Count > 0) { return true; } else { return false; }

    }
}