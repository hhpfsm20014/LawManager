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
using System.Globalization;

public partial class dashboard : System.Web.UI.Page
{
    protected void Page_Prerender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataSource2.SelectCommand = "SELECT COUNT(issue_status) AS Count, issue_status AS Status FROM Issue_Master GROUP BY issue_status";
            string default_proj;

            if (Session["selectedproject"].ToString() == "-1")
            {
                default_proj = "0";
            }
            else
            {
                default_proj = Session["selectedproject"].ToString();

                //ddlProjectM.Items.FindByValue(Session["selectedproject"].ToString()).Selected = true;
            }
            string userid = Session["userid"].ToString();
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection conn = objhdcon.OpenConnection();
            if (default_proj == "0")
            {
                //lblProject.Text = "All";
                string qryUnassigned = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(issue_status = 'unassigned')";
                string qryResolved = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(issue_status = 'closed') ORDER BY issue_id ";
                string qryModified = "SELECT issue_id AS [Issue ID], issue_description AS Description, last_modified_date AS [Modified Date] FROM Issue_Master ORDER BY last_modified_date DESC";
                string qryReported = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(admin_id='" + userid + "')";

                SqlCommand cmdUnassigned = new SqlCommand(qryUnassigned, conn);
                SqlCommand cmdResolved = new SqlCommand(qryResolved, conn);
                SqlCommand cmdModified = new SqlCommand(qryModified, conn);
                SqlCommand cmdReported = new SqlCommand(qryReported, conn);

                SqlDataReader drUnassigned = cmdUnassigned.ExecuteReader();
                //gridUnassigned.DataSource = drUnassigned;
                //gridUnassigned.DataBind();
                drUnassigned.Close();

                SqlDataReader drResolved = cmdResolved.ExecuteReader();
                //gridResolved.DataSource = drResolved;
                //gridResolved.DataBind();
                drResolved.Close();

                SqlDataReader drModified = cmdModified.ExecuteReader();
                //gridModified.DataSource = drModified;
                //gridModified.DataBind();
                drModified.Close();

                SqlDataReader drReported = cmdReported.ExecuteReader();
                //gridReported.DataSource = drReported;
                //gridReported.DataBind();
                drReported.Close();


                conn.Close();

            }
            else
            {
                string qryProjectName = "SELECT project_name FROM Project_Master WHERE project_id='" + default_proj + "'";
                SqlCommand cmdProjectName = new SqlCommand(qryProjectName, conn);
                SqlDataReader drProjectName = cmdProjectName.ExecuteReader();
                while (drProjectName.Read())
                {
                    //lblProject.Text = drProjectName[0].ToString();
                }

                drProjectName.Close();
                SqlDataSource2.SelectCommand = "SELECT COUNT(issue_status) AS Count, issue_status AS Status FROM Issue_Master WHERE (project_id='" + default_proj + "') GROUP BY issue_status";


                string qryUnassigned = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(issue_status = 'unassigned' AND project_id='" + default_proj + "')";
                string qryResolved = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(issue_status = 'closed' AND project_id='" + default_proj + "') ORDER BY issue_id ";
                string qryModified = "SELECT issue_id AS [Issue ID], issue_description AS Description, last_modified_date AS [Modified Date] FROM Issue_Master WHERE (project_id='" + default_proj + "') ORDER BY last_modified_date DESC";
                string qryReported = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(admin_id='" + userid + "' AND project_id='" + default_proj + "')";

                SqlCommand cmdUnassigned = new SqlCommand(qryUnassigned, conn);
                SqlCommand cmdResolved = new SqlCommand(qryResolved, conn);
                SqlCommand cmdModified = new SqlCommand(qryModified, conn);
                SqlCommand cmdReported = new SqlCommand(qryReported, conn);

                SqlDataReader dr = cmdUnassigned.ExecuteReader();
                //gridUnassigned.DataSource = dr;
                //gridUnassigned.DataBind();
                dr.Close();

                SqlDataReader drResolved = cmdResolved.ExecuteReader();
                //gridResolved.DataSource = drResolved;
                //gridResolved.DataBind();
                drResolved.Close();

                SqlDataReader drModified = cmdModified.ExecuteReader();
                //gridModified.DataSource = drModified;
                //gridModified.DataBind();
                drModified.Close();

                SqlDataReader drReported = cmdReported.ExecuteReader();
                //gridReported.DataSource = drReported;
                //gridReported.DataBind();
                drReported.Close();

                conn.Close();
            }

        }
        else
        {
            string default_proj;
            if (Session["selectedproject"].ToString() == "-1")
            {
                default_proj = "0";
            }
            else
            {
                default_proj = Session["selectedproject"].ToString();

                //ddlProjectM.Items.FindByValue(Session["selectedproject"].ToString()).Selected = true;
            }
            ClsDBConnection cn = new ClsDBConnection();
            SqlConnection conn = cn.OpenConnection();

            if (default_proj == "0")
            {
                //lblProject.Text = "All";
            }
            else
            {
                string qryProjectName = "SELECT project_name FROM Project_Master WHERE project_id='" + default_proj + "'";
                SqlCommand cmdProjectName = new SqlCommand(qryProjectName, conn);
                SqlDataReader drProjectName = cmdProjectName.ExecuteReader();
                while (drProjectName.Read())
                {
                    //lblProject.Text = drProjectName[0].ToString();
                }

                drProjectName.Close();
            }
        }
      
    }

    public string getWhileLoopData()
    {

            string default_proj;
            string commandStr = "SELECT Issue_Master.issue_id,Project_Master.project_id,Project_Master.CaseId, isnull(CONVERT(VARCHAR(30),Issue_Master.nxtHearingDate,106),'') as nxtHearingDate,Issue_Master.prevHearingDes,Issue_Master.issue_description,Issue_Master.issue_notes,Project_Master.project_name FROM  Project_Master left outer join Issue_Master on Issue_Master.project_id=Project_Master.project_id where  1=1 ";
            if (Session["selectedproject"].ToString() == "-1")
            {
                default_proj = "0";
            }
            else
            {
                default_proj = Session["selectedproject"].ToString();
                commandStr = commandStr + "and Issue_Master.project_id='" + default_proj + "'";

                //ddlProjectM.Items.FindByValue(Session["selectedproject"].ToString()).Selected = true;
            }
            Int32 CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            if (CategoryId > 0)
            {
                //commandStr = "SELECT Issue_Master.issue_id,Issue_Master.nxtHearingDate,Issue_Master.prevHearingDes,Issue_Master.issue_description,Issue_Master.issue_notes,Project_Master.project_name FROM Issue_Master inner join Project_Master on Issue_Master.project_id=Project_Master.project_id where  Project_Master.CategoryId='" + CategoryId + "'";
                commandStr = commandStr + " and  Project_Master.CategoryId='" + CategoryId + "'";
            }
            commandStr = commandStr + " order by Issue_Master.nxtHearingDate desc";
            ClsDBConnection cn = new ClsDBConnection();
            SqlConnection conn = cn.OpenConnection();


            string htmlStr = "";


            SqlCommand cmd = new SqlCommand(commandStr, conn);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            var result = from tab in dt.AsEnumerable()
                         group tab by tab["project_id"]
                             into groupDt
                             select new
                             {
                                 company_code = groupDt.Key,
                                 project_id = groupDt.First()["project_id"].ToString(),
                                 CaseId =groupDt.First()["CaseId"].ToString(),
                                 nxtHearingDate = groupDt.First()["nxtHearingDate"].ToString(),
                                 issue_notes = groupDt.First()["issue_notes"].ToString(),
                                 project_name = groupDt.First()["project_name"].ToString(),
                                 issue_description = groupDt.First()["issue_description"].ToString(),
                                        };
           var exactdt = result.ToList().ToDataTable();
           foreach (DataRow dr in exactdt.Rows)
           {
               //Int32 HearingID = Convert.ToInt32(dr["issue_id"]);
               var nextDate =dr["nxtHearingDate"].ToString();
               string CaseId = dr["CaseId"].ToString();
               string currDesc = dr["issue_description"].ToString();
               string note = dr["issue_notes"].ToString();
               string ProjectName = dr["project_name"].ToString();
               Int32 ProjectId = Convert.ToInt32(dr["project_id"]);
               string one = "Style = ";
               string two = "color:#111111;";
               string three = one + two;

               htmlStr += "<tr><td " + three + "><div class='customBoxforTable' style='width:600px;'><h3><b>Case Name: </b>" + ProjectName + "</h3><h3>" + CaseId + "</h3>" + "<b>Next Date: </b>" + nextDate + "<br /><br />" + "<b>Notes: </b>" + note + "<br /><br /><a href='CaseDetails.aspx?ProjID=" + ProjectId + "'><b>Details</b></a></div></td></tr>";
          
           }
              
           return htmlStr;

    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        getWhileLoopData();
    }

    public void gridUnassigned_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ClsDBConnection cn = new ClsDBConnection();
        SqlConnection conn = cn.OpenConnection();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (e.Row.Cells[0].Text == "somevalue") //compare first column of current row value  
            //    e.Row.BackColor = Color.FromName("Red");
            string issue_id = ((HyperLink)e.Row.Cells[0].Controls[0]).Text;
            string qry = "SELECT issue_priority FROM Issue_Master WHERE issue_id='" + issue_id + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string prior = dr.GetString(0);
                if (prior == "None")
                {

                    e.Row.BackColor = Color.White;
                }
                else if (prior == "Low")
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#C2DFFF");
                }

                else if (prior == "Normal")
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#FFF494");
                }
                else if (prior == "High")
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#FFCD85");
                }
                else if (prior == "Urgent")
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#FCBDBD");
                }
                else
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#C9CCC4"); ;
                }
            }
            dr.Close();
        } conn.Close();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string userid = Session["userid"].ToString();
        string default_proj = "";
        ClsDBConnection objhdcon = new ClsDBConnection();
        SqlConnection conn = objhdcon.OpenConnection();
        string qryProjectName = "SELECT * FROM Project_Master where project_name like  '%" + txtSearchItem.Text + "%' or caseid like  '%" + txtSearchItem.Text + "%'";
        SqlCommand cmdProjectName = new SqlCommand(qryProjectName, conn);
        SqlDataReader drProjectName = cmdProjectName.ExecuteReader();
        while (drProjectName.Read())
        {
            //lblProject.Text = drProjectName["project_name"].ToString();
            default_proj = drProjectName["project_id"].ToString();
        }

        drProjectName.Close();

        if (default_proj.Length > 0)
        {
            Session["selectedproject"] = default_proj;
        }
        else
        {
            Session["selectedproject"] = "-1";
        }
        getWhileLoopData();

        SqlDataSource2.SelectCommand = "SELECT COUNT(issue_status) AS Count, issue_status AS Status FROM Issue_Master WHERE (project_id='" + default_proj + "') GROUP BY issue_status";


        string qryUnassigned = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(issue_status = 'unassigned' AND project_id='" + default_proj + "')";
        string qryResolved = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(issue_status = 'closed' AND project_id='" + default_proj + "') ORDER BY issue_id ";
        string qryModified = "SELECT issue_id AS [Issue ID], issue_description AS Description, last_modified_date AS [Modified Date] FROM Issue_Master WHERE (project_id='" + default_proj + "') ORDER BY last_modified_date DESC";
        string qryReported = "SELECT issue_id AS [Issue ID], issue_description AS Description FROM Issue_Master WHERE(admin_id='" + userid + "' AND project_id='" + default_proj + "')";

        SqlCommand cmdUnassigned = new SqlCommand(qryUnassigned, conn);
        SqlCommand cmdResolved = new SqlCommand(qryResolved, conn);
        SqlCommand cmdModified = new SqlCommand(qryModified, conn);
        SqlCommand cmdReported = new SqlCommand(qryReported, conn);

        SqlDataReader dr = cmdUnassigned.ExecuteReader();
        //gridUnassigned.DataSource = dr;
        //gridUnassigned.DataBind();
        dr.Close();

        SqlDataReader drResolved = cmdResolved.ExecuteReader();
        //gridResolved.DataSource = drResolved;
        //gridResolved.DataBind();
        drResolved.Close();

        SqlDataReader drModified = cmdModified.ExecuteReader();
        //gridModified.DataSource = drModified;
        //gridModified.DataBind();
        drModified.Close();

        SqlDataReader drReported = cmdReported.ExecuteReader();
        //gridReported.DataSource = drReported;
        //gridReported.DataBind();
        drReported.Close();

        conn.Close();

    }
}