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


public partial class Issuedetails : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string issue_id = Request.QueryString["IssueID"];
        if (issue_id != null)
        {
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection cn = objhdcon.OpenConnection();
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = cn;
            try
            {
                cmnd.Parameters.Clear();
                string qry = "SELECT Issue_Master.*, Project_Master.project_name,Project_Master.CaseId,User_Master.user_name FROM Project_Master INNER JOIN Issue_Master ON Project_Master.project_id = Issue_Master.project_id INNER JOIN User_Master ON Issue_Master.admin_id=User_Master.user_id WHERE(issue_id = '" + issue_id + "')";
                SqlCommand cmd = new SqlCommand(qry, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                

                if (dr.Read())
                {
                    lblissueid.Text=dr.GetStringOrNull(0);
                    lblId.Text = dr.GetStringOrNull(17);
                    lblProject.Text = dr.GetStringOrNull(16);
                    //lblType.Text = dr.GetStringOrNull(4);
                    //lblPriority.Text = dr.GetStringOrNull(10);
                    //lblReproducibility.Text = dr.GetStringOrNull(8);
                    //lblStatus.Text = dr.GetStringOrNull(4);
                    //lblName.Text = dr.GetStringOrNull(3);
                    lblDescription.Text = dr.GetStringOrNull(3);
                    //lblDateSubmit.Text = Convert.ToDateTime(dr.GetStringOrNull(5)).ToString("dd/MM/yyyy");
                    lblLastUpdate.Text = Convert.ToDateTime(dr.GetStringOrNull(14)).ToString("dd/MM/yyyy");
                    //lblReporter.Text = dr.GetStringOrNull(2);
                    lblNotes.Text = dr.GetStringOrNull(6);
                    lblNextHearingDate.Text = Convert.ToDateTime(dr.GetStringOrNull(8)).ToString("dd/MM/yyyy");
                    lblPrevDesc.Text = dr.GetStringOrNull(7);
                    lblReportedBy.Text = dr.GetStringOrNull(18);
                    
                } dr.Close();
                SqlDataReader drl = cmd.ExecuteReader();
                //lblId.Text = issue_id;
                gridIssues.DataSource = drl;
                gridIssues.DataBind();
                drl.Close();
            }
            finally
            {
            }

            string qryComment = "SELECT Comment.comment_id AS [c_id], User_Master.user_name AS [u_name], Comment.submitdatetime AS [c_time] , Comment.comment_statement AS [c_state], User_Master.userImage AS [u_image] FROM Comment INNER JOIN User_Master ON Comment.user_id = User_Master.user_id WHERE(issue_id = '" + issue_id + "')";
            SqlCommand cmdComment = new SqlCommand(qryComment, cn);
            SqlDataReader drComment = cmdComment.ExecuteReader();

            gridComment.DataSource = drComment;
            gridComment.DataBind();
            drComment.Close();

            string qryFile = "SELECT file_name,actualname FROM File_Sharing_Info WHERE(issue_id = '" + issue_id + "')";
            SqlCommand cmdFile = new SqlCommand(qryFile, cn);
            SqlDataReader drFile = cmdFile.ExecuteReader();

            gvFiles.DataSource = drFile;
            gvFiles.DataBind();
            drFile.Close();

        }
    }

    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();
        string u_id = Session["userid"].ToString();
        bool note = db.addNote(lblId.Text,null, u_id, tbNote.Text);
        if (note)
        {
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection cn = objhdcon.OpenConnection();
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = cn;
            string qryComment = "SELECT Comment.comment_id AS [c_id], User_Master.user_name AS [u_name], Comment.submitdatetime AS [c_time] , Comment.comment_statement AS [c_state], User_Master.userImage AS [u_image]  FROM Comment INNER JOIN User_Master ON Comment.user_id = User_Master.user_id WHERE(issue_id = '" + lblissueid.Text + "')";
            SqlCommand cmdComment = new SqlCommand(qryComment, cn);
            SqlDataReader drComment = cmdComment.ExecuteReader();

            gridComment.DataSource = drComment;
            gridComment.DataBind();
            drComment.Close();
            UpdatePanel1.Update();
            tbNote.Text = "";
            drComment.Close();
            btnAdd.Focus();
        }
        else
        {
            UpdatePanel1.Update();
            tbNote.Text = "*Not Updated :(";
        }
    }


    
}

