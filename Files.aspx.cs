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
public partial class Files : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection conn = objhdcon.OpenConnection();
        if (ddlIssue.SelectedIndex == 0)
        {
            string qryfiles = "SELECT File_Sharing_Info.file_id AS f_id, File_Sharing_Info.file_name AS f_name, File_Sharing_Info.issue_id AS i_id, Issue_Master.issue_name AS i_name, File_Sharing_Info.submitdatetime AS f_date FROM File_Sharing_Info INNER JOIN Issue_Master ON File_Sharing_Info.issue_id = Issue_Master.issue_id";
            SqlCommand cmdfiles = new SqlCommand(qryfiles, conn);
            SqlDataReader dr = cmdfiles.ExecuteReader();
            gridFiles.DataSource = dr;
            gridFiles.DataBind();
            dr.Close();
            conn.Close();

        }
        else
        {
            string qryfiles = "SELECT File_Sharing_Info.file_id AS f_id, File_Sharing_Info.file_name AS f_name, File_Sharing_Info.issue_id AS i_id, Issue_Master.issue_name AS i_name, File_Sharing_Info.submitdatetime AS f_date FROM File_Sharing_Info INNER JOIN Issue_Master ON File_Sharing_Info.issue_id = Issue_Master.issue_id WHERE (Issue_Master.issue_id ='" + ddlIssue.SelectedValue.ToString() + "' )";
            SqlCommand cmd = new SqlCommand(qryfiles, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            gridFiles.DataSource = dr;
            gridFiles.DataBind();
            dr.Close();
            conn.Close();
        }
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProject.SelectedIndex > 0)
        {
            ClsDBConnection con = new ClsDBConnection();

            SqlConnection cn = con.OpenConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT issue_id,CAST(nxtHearingDate AS Date) as nxtHearingDate from Issue_Master WHERE project_id='" + ddlProject.SelectedValue + "'", cn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            ddlIssue.DataSource = dr1;
            if (dr1.Read() == true)
            {
                //int ddl = 1;
                ddlIssue.Items.Clear();
                ddlIssue.Items.Insert(0, "--Select--");

                do
                {

                    ddlIssue.DataTextField = Convert.ToDateTime(dr1.GetValue(1)).ToString("dd/mm/yyyy");
                    ddlIssue.DataValueField = dr1.GetValue(0).ToString();
                    ddlIssue.Items.Add(new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

                    //ddlIssue.Items.Insert(ddl, new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

                    //ddl++;
                } while (dr1.Read());


            }
            else
            {

                Response.Write("No Issues in Project");
            } dr1.Close();

        }
    }
    public void gridFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.BackColor = Color.FromArgb(9762047);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string previous = e.Row.Cells[1].Text;
            string next = previous.Substring(32);
            e.Row.Cells[1].Text = next;



        }
    }

    protected void ddlProject1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProject1.SelectedIndex > 0)
        {
            ClsDBConnection con = new ClsDBConnection();

            SqlConnection cn = con.OpenConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT issue_id,CAST(nxtHearingDate AS Date) as nxtHearingDate from Issue_Master WHERE project_id='" + ddlProject1.SelectedValue + "'", cn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            ddlIssue1.DataSource = dr1;
            if (dr1.Read() == true)
            {
                //int ddl = 1;
                ddlIssue1.Items.Clear();
                ddlIssue1.Items.Insert(0, "--Select--");

                do
                {

                    ddlIssue1.DataTextField = Convert.ToDateTime(dr1.GetValue(1)).ToString("dd/mm/yyyy");
                    ddlIssue1.DataValueField = dr1.GetValue(0).ToString();
                    ddlIssue1.Items.Add(new System.Web.UI.WebControls.ListItem(ddlIssue1.DataTextField, ddlIssue1.DataValueField));

                    //ddlIssue.Items.Insert(ddl, new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

                    //ddl++;
                } while (dr1.Read());


            }
            else
            {

                Response.Write("No Issues in Project");
            } dr1.Close();

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();
        //ClsDBConnection objhdcon = new ClsDBConnection();
        //SqlConnection cn = objhdcon.OpenConnection();
        //SqlCommand cmnd = new SqlCommand();
        //SqlTransaction trans;
        //trans = cn.BeginTransaction();
        //cmnd.Connection = cn;
        //cmnd.Transaction = trans;
        //cmnd.Parameters.Clear();



        if (FileUpload.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload.FileName).Trim();
                string guid = Guid.NewGuid().ToString();
                string FN = guid.Replace("-", "");
                string abc = FN + filename;
                FileUpload.SaveAs(Server.MapPath("~/uploadedFiles/") + abc);
                string filePath = "~/uploadedFiles/" + abc;
                string fileID = db.fileUploading(abc, filename, filePath,Convert.ToInt64(ddlProject.SelectedValue), ddlIssue1.SelectedValue);


                //trans.Commit();
                //conn.Close();


            }
            catch (Exception ex) { throw ex; }


        }
    }
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }

    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridFiles.PageIndex = e.NewPageIndex;
        gridFiles.DataBind();
    }

    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = gridFiles.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            gridFiles.DataSource = dataView;
            gridFiles.DataBind();
        }
    }
}