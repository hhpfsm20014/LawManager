using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_rptDistrictJudgeCourt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadGrid(13);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void LoadGrid(int categoryId)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter sda = null;

        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd = new SqlCommand("SP_RptCaseByCategory", con);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            gvLawMgt.DataSource = dt;
            gvLawMgt.DataBind();
            Session["gvLawMgt"] = dt;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            sda.Dispose();
            cmd.Dispose();
            con.Close();
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=DistrictJudgeCases.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //To Export all pages
                gvLawMgt.AllowPaging = false;
                DataTable dt = Session["gvLawMgt"] as DataTable;
                gvLawMgt.DataSource = dt;
                gvLawMgt.DataBind();

                gvLawMgt.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvLawMgt.HeaderRow.Cells)
                {
                    cell.BackColor = gvLawMgt.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvLawMgt.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvLawMgt.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvLawMgt.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvLawMgt.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //Allows for printing
    }
}