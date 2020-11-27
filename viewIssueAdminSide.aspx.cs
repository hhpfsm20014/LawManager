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

public partial class viewIssueAdminSide : System.Web.UI.Page
{
    protected void Page_Prerender(object sender, EventArgs e)
    {
        Control c = GetPostBackControl(this.Page);
        //if (c != ddlIssue)
        //{
            //DropDownList ddlProjectM = (DropDownList)Master.FindControl("ddlProject");
            //if (Session["selectedproject"].ToString() != "-1")
            //{

            //    ddlProjectM.SelectedValue = Session["selectedproject"].ToString();
            //}
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
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection conn = objhdcon.OpenConnection();
            if (default_proj == "0")
            {
                string qryIssues = "SELECT issue_id AS [Issue ID],CONVERT(date , nxtHearingDate, 102) AS [Issue Name], issue_description AS Description FROM Issue_Master";
                SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
                SqlDataReader drIssues = cmdIssues.ExecuteReader();
                gridIssues.DataSource = drIssues;
                gridIssues.DataBind();
                drIssues.Close();
                conn.Close();
                //ddlProjectTable();
            }
            else
            {
                string qryIssues = "SELECT issue_id AS [Issue ID],CONVERT(date , nxtHearingDate, 102)  AS [Issue Name], issue_description AS Description FROM Issue_Master WHERE(project_id='" + default_proj + "')";
                SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
                SqlDataReader drIssues = cmdIssues.ExecuteReader();
                gridIssues.DataSource = drIssues;
                gridIssues.DataBind();
                drIssues.Close();
                conn.Close();
                //ddlProjectTable();
            }

        }
        //ModalPopupExtender1.Hide();
    //}
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    Control c = GetPostBackControl(this.Page);
    //    if (c != ddlIssue)
    //    {
    //        DropDownList ddlProjectM = (DropDownList)Master.FindControl("ddlProject");
    //        if (Session["selectedproject"].ToString() != "-1")
    //        {

    //            ddlProjectM.SelectedValue = Session["selectedproject"].ToString();
    //        }
    //        ClsDBConnection objhdcon = new ClsDBConnection();
    //        SqlConnection conn = objhdcon.OpenConnection();
    //        if (ddlProjectM.SelectedIndex == 0)
    //        {
    //            string qryIssues = "SELECT issue_id AS [Issue ID],issue_name AS [Issue Name], issue_description AS Description FROM Issue_Master";
    //            SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
    //            SqlDataReader drIssues = cmdIssues.ExecuteReader();
    //            gridIssues.DataSource = drIssues;
    //            gridIssues.DataBind();
    //            drIssues.Close();
    //            conn.Close();
    //            ddlProjectTable();
    //        }
    //        else
    //        {
    //            string qryIssues = "SELECT issue_id AS [Issue ID],issue_name AS [Issue Name], issue_description AS Description FROM Issue_Master WHERE(project_id='" + ddlProjectM.SelectedValue.ToString() + "')";
    //            SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
    //            SqlDataReader drIssues = cmdIssues.ExecuteReader();
    //            gridIssues.DataSource = drIssues;
    //            gridIssues.DataBind();
    //            drIssues.Close();
    //            conn.Close();
    //            ddlProjectTable();
    //        }

    //    }
    //    ModalPopupExtender1.Hide();


    //}

    //public string getWhileLoopData()
    //{
    //    string htmlStr = "";
    //    conn.Open();
    //    SqlCommand cmd = new SqlCommand("SELECT issue_name,issue_description FROM Issue_Master", conn);
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    while (dr.Read())
    //    {

    //        string issue_name = dr.GetString(0);
    //        string issue_desc = dr.GetString(1);
    //        //SqlCommand pro_detail = new SqlCommand("SELECT project_name,project_description,start_date,end_date FROM Project_Master", conn);


    //        string one = "Style = ";
    //        string two = "color:brown;";
    //        string three = one + two;
    //        htmlStr += "<tr><td " + three + ">" + issue_name + "</td><td>" + issue_desc + "</td></tr>";
    //    }
    //    return htmlStr;
    //}
    //protected void btnUpdateIssues_Click(object sender, EventArgs e)
    //{
    //    DBActivity db = new DBActivity();
    //    string issueID = ddlIssue.SelectedValue;
    //    bool regi = db.EditIssue(issueID, ddlIssueType.SelectedValue, txtissuedesc.Text, ddlPriority.SelectedValue, ddlReproducibility.SelectedValue, txtSteps.Text, txtNotes.Text, ddlStatus.SelectedValue);
    //    if (regi)
    //    {
    //        Response.Write("update sucess");

    //    }
    //    else
    //    {
    //        Response.Write("update fail");
    //    }
    //}
    //protected void DDLIssue_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtissueid.Text = ddlIssue.SelectedValue;


    //    ClsDBConnection cn = new ClsDBConnection();
    //    SqlConnection conn = cn.OpenConnection();
    //    if (ddlIssue.SelectedIndex >= 0)
    //    {
    //        SqlCommand cmd = new SqlCommand("SELECT * FROM Issue_Master WHERE issue_id='" + ddlIssue.SelectedValue + "'", conn);
    //        SqlDataReader dr = cmd.ExecuteReader();

    //        if (dr.Read() == true)
    //        {


    //            ddlStatus.SelectedValue = dr.GetStringOrNull(6);
    //            ddlIssueType.SelectedValue = dr.GetStringOrNull(4);
    //            ddlPriority.SelectedValue = dr.GetStringOrNull(7);
    //            ddlReproducibility.SelectedValue = dr.GetStringOrNull(8);
    //            txtissuedesc.Text = dr.GetStringOrNull(5);

    //            txtSteps.Text = dr.GetStringOrNull(9);
    //            txtNotes.Text = dr.GetStringOrNull(13);

    //            ModalPopupExtender1.Show();
    //        }

    //        dr.Close();
    //    }
    //    else
    //    {
    //        ddlIssue.Focus();
    //    }
    //    conn.Close();
    //}
    //public void ddlProjectTable()
    //{
    //    //DropDownList ddlProjectM = (DropDownList)Master.FindControl("ddlProject");
    //    string default_proj;

    //    if (Session["selectedproject"].ToString() == "-1")
    //    {
    //        default_proj = "0";
    //    }
    //    else
    //    {
    //        default_proj = Session["selectedproject"].ToString();

    //        //ddlProjectM.Items.FindByValue(Session["selectedproject"].ToString()).Selected = true;
    //    }
    //    if (default_proj != "0")
    //    {
    //        ClsDBConnection con = new ClsDBConnection();

    //        SqlConnection cn = con.OpenConnection();
    //        SqlCommand cmd1 = new SqlCommand("SELECT issue_id,issue_name from Issue_Master WHERE project_id='" + default_proj + "'", cn);
    //        SqlDataReader dr1 = cmd1.ExecuteReader();
    //        ddlIssue.DataSource = dr1;
    //        if (dr1.Read() == true)
    //        {
    //            //int ddl = 1;
    //            ddlIssue.Items.Clear();
    //            ListItem select = new ListItem();
    //            select.Text = "--Select--";
    //            select.Value = "0";
    //            ddlIssue.Items.Insert(0, select);

    //            do
    //            {

    //                ddlIssue.DataTextField = dr1.GetValue(1).ToString();
    //                ddlIssue.DataValueField = dr1.GetValue(0).ToString();
    //                ddlIssue.Items.Add(new ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));

    //                //ddlIssue.Items.Insert(ddl, new System.Web.UI.WebControls.ListItem(ddlIssue.DataTextField, ddlIssue.DataValueField));
    //                ModalPopupExtender1.Show();
    //                //ddl++;
    //            } while (dr1.Read());


    //        }
    //        else
    //        {

    //            Response.Write("No Issues in Project");
    //        } dr1.Close();



    //    }
    //}
    public static Control GetPostBackControl(Page page)
    {
        Control control = null;

        string ctrlname = page.Request.Params.Get("__EVENTTARGET");
        if (ctrlname != null && ctrlname != string.Empty)
        {
            control = page.FindControl(ctrlname);
        }
        else
        {
            foreach (string ctl in page.Request.Form)
            {
                Control c = page.FindControl(ctl);
                if (c is System.Web.UI.WebControls.Button)
                {
                    control = c;
                    break;
                }
            }
        }
        return control;
    }
}
