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
using System.IO;
using System.Net;


public partial class FileInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"].ToString() == "viewer")
        {
            Button1.Visible = false;
        }
        string file_id = Request.QueryString["FileID"];
        if (file_id != null)
        {
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection cn = objhdcon.OpenConnection();
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = cn;
            try
            {
                cmnd.Parameters.Clear();

                string qry = "SELECT File_Sharing_Info.*, Issue_Master.issue_id AS Expr1, Issue_Master.issue_name, File_Sharing_Info.issue_id AS Expr2 FROM File_Sharing_Info INNER JOIN Issue_Master ON File_Sharing_Info.issue_id = Issue_Master.issue_id WHERE(file_id = '" + file_id + "')";
                SqlCommand cmd = new SqlCommand(qry, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                lblId.Text = file_id;


                if (dr.Read())
                {
                    lblName.Text = dr.GetStringOrNull(2);

                    lblpath.Text = dr.GetStringOrNull(1);

                    lblIssueID.Text = dr.GetStringOrNull(5);
                    lblIssueName.Text = dr.GetStringOrNull(7);


                } dr.Close();


                string qryComment = "SELECT Comment.comment_id AS [c_id], User_Master.user_name AS [u_name], Comment.submitdatetime AS [c_time] , Comment.comment_statement AS [c_state], User_Master.userImage AS [u_image] FROM Comment INNER JOIN User_Master ON Comment.user_id = User_Master.user_id WHERE(file_id = '" + file_id + "')";
                SqlCommand cmdComment = new SqlCommand(qryComment, cn);
                SqlDataReader drComment = cmdComment.ExecuteReader();

                gridComment.DataSource = drComment;
                gridComment.DataBind();
                drComment.Close();

            }
            finally
            {
            }

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        try
        {

            string filename = lblpath.Text;
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string aaa = Server.MapPath("uploadedFiles/" + filename);
            Response.TransmitFile(Server.MapPath("uploadedFiles/" + filename));
            Response.End();


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection cn = objhdcon.OpenConnection();
        SqlCommand cmnd = new SqlCommand();
        cmnd.Connection = cn;
        try
        {
            cmnd.Parameters.Clear();

            string qry = "DELETE FROM File_Sharing_Info WHERE(file_id = '" + lblId.Text + "')";
            SqlCommand cmd = new SqlCommand(qry, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

            }
            dr.Close();
        }
        finally
        {
            String strPath = Server.MapPath(lblpath.Text);
            System.IO.File.Delete(strPath);
            Server.Transfer("Files.aspx");
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();
        bool note = db.addNote(null, lblId.Text, "3", tbNote.Text);
        if (note)
        {
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection cn = objhdcon.OpenConnection();
            SqlCommand cmnd = new SqlCommand();
            cmnd.Connection = cn;
            string qryComment = "SELECT Comment.comment_id AS [c_id], User_Master.user_name AS [u_name], Comment.submitdatetime AS [c_time] , Comment.comment_statement AS [c_state], User_Master.userImage AS [u_image]  FROM Comment INNER JOIN User_Master ON Comment.user_id = User_Master.user_id WHERE(file_id = '" + lblId.Text + "')";
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
