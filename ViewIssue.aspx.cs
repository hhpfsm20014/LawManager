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
using System.Text;

public partial class ViewIssue : System.Web.UI.Page
{
    protected void Page_Prerender(object sender, EventArgs e)
    {
        Control c = GetPostBackControl(this.Page);
        if (c != btnApply)
        {
            //DropDownList ddlProjectM = (DropDownList)Master.FindControl("ddlProject");
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

                string qryIssues = "SELECT * FROM Issue_Master";
                SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
                SqlDataReader drIssues = cmdIssues.ExecuteReader();
                gridIssues.DataSource = drIssues;
                gridIssues.DataBind();
                drIssues.Close();
                conn.Close();
            }
            else
            {
                string qryIssues = "SELECT * FROM Issue_Master WHERE(project_id='" + default_proj + "')";
                SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
                SqlDataReader drIssues = cmdIssues.ExecuteReader();
                gridIssues.DataSource = drIssues;
                gridIssues.DataBind();
                drIssues.Close();
                conn.Close();
            }
        }
        btnApply_Click(null, EventArgs.Empty);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //DropDownList ddlProjectM = (DropDownList)Master.FindControl("ddlProject");
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

            string qryIssues = "SELECT * FROM Issue_Master";
            SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
            SqlDataReader drIssues = cmdIssues.ExecuteReader();
            gridIssues.DataSource = drIssues;
            gridIssues.DataBind();
            drIssues.Close();
            conn.Close();
        }
        else
        {
            string qryIssues = "SELECT * FROM Issue_Master WHERE(project_id='" + default_proj + "')";
            SqlCommand cmdIssues = new SqlCommand(qryIssues, conn);
            SqlDataReader drIssues = cmdIssues.ExecuteReader();
            gridIssues.DataSource = drIssues;
            gridIssues.DataBind();
            drIssues.Close();
            conn.Close();
        }



    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFrom_PopupControlExtender.Commit(Calendar1.SelectedDate.ToShortDateString());
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtTo_PopupControlExtender.Commit(Calendar2.SelectedDate.ToShortDateString());
    }


    protected void gridIssues_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ClsDBConnection dbcon = new ClsDBConnection();
        SqlConnection conn = dbcon.OpenConnection();
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

    protected void btnApply_Click(object sender, EventArgs e)
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
       
        try
        {
            ClsDBConnection objhdcon = new ClsDBConnection();
            SqlConnection conn = objhdcon.OpenConnection();
            string sqlQuery = "SELECT Issue_Master.* " + "FROM Issue_Master inner join Project_Master on Issue_Master.project_id=Project_Master.project_id WHERE ";

            if (ddlReporter.SelectedValue != "--Select--")
            {
                sqlQuery += "Issue_Master.admin_id = " + ddlReporter.SelectedValue + "  AND ";
            }

            //if (ddlStatus.SelectedValue != "--Select--")
            //{
            //    sqlQuery += "issue_status = '" + ddlStatus.SelectedValue + "'  AND ";
            //}

            //if (ddlReproducability.SelectedValue != "--Select--")
            //{
            //    sqlQuery += "reproducibility = '" + ddlReproducability.SelectedValue + "'  AND ";
            //}
            //if (ddlPriority.SelectedValue != "--Select--")
            //{
            //    sqlQuery += "issue_priority = '" + ddlPriority.SelectedValue + "'  AND ";
            //}
            if (default_proj != "0")
            {
                sqlQuery += "Issue_Master.project_id = '" + default_proj + "'  AND ";
            }

            if (txtSearchItem.Text.Trim() != "")
            {
                //sqlQuery += "submit_date BETWEEN '" + txtFrom.Text + "' OR ";


                sqlQuery += "(Project_Master.project_name like  '%" + txtSearchItem.Text + "%' or Project_Master.caseid like  '%" + txtSearchItem.Text + "%') AND ";

            }

            if (txtFrom.Text != "")
            {
                //sqlQuery += "submit_date BETWEEN '" + txtFrom.Text + "' OR ";


                sqlQuery += "(Issue_Master.last_modified_date >= '" + txtFrom.Text + "'  AND ";

            }
            //else if (txtTo.Text != "" && txtFrom.Text == "")
            else
            {
                sqlQuery += "(";
            }
            if (txtTo.Text != "")
            {
                //sqlQuery += "'" + txtTo.Text + "' OR ";
                sqlQuery += "Issue_Master.last_modified_date <= '" + txtTo.Text + "')  AND ";

            }
            else
            {
                //sqlQuery += "'" + txtTo.Text + "' OR ";
                sqlQuery += "Issue_Master.last_modified_date <= '" + DateTime.Today + "')  AND ";

            }
            //sqlQuery = sqlQuery.Substring(sqlQuery.Trim(), 1, sqlQuery.Len(sqlQuery.Trim()) - 5);
            sqlQuery = sqlQuery.Trim().Substring(0, (sqlQuery.Trim().Length - 5));
            //da.SelectCommand = new SqlCommand(sqlQuery);
            //da.SelectCommand.Connection = connection;
            //da.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //{
            //    GridView1.DataSource = dataTable;
            //    GridView1.DataBind();
            //}
            SqlCommand cmdIssues = new SqlCommand(sqlQuery, conn);
            SqlDataReader drIssues = cmdIssues.ExecuteReader();
            gridIssues.DataSource = drIssues;
            gridIssues.DataBind();
            drIssues.Close();
            conn.Close();
        }
        catch (Exception ex)
        {
            // Catch Exception Here
        }
    }

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
