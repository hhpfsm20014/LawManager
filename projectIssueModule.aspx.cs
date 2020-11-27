using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using CrystalDecisions;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports.Engine;


public partial class projectIssueModule : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        ClsDBConnection cn = new ClsDBConnection();
        SqlConnection conn = cn.OpenConnection();

        ReportDocument customRpt = new ReportDocument();
        String reportPath = Server.MapPath("~/Reports/projectIssueModule.rpt");
        customRpt.Load(reportPath);


        //change following connection string
       
        SqlDataAdapter SqlDA = new SqlDataAdapter("SELECT * FROM projectIssueModule", conn);

        DataSet ds = new DataSet();
        SqlDA.Fill(ds, "projectIssueModule");

        DataTable dt = new DataTable();
        customRpt.SetDataSource(ds.Tables[0]);

        CrystalReportViewer1.ReportSource = customRpt;



    }
}