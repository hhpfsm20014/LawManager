using System;
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

public partial class NoofUsersonprojects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClsDBConnection cn = new ClsDBConnection();
        SqlConnection conn = cn.OpenConnection();

        ReportDocument customRpt = new ReportDocument();
        String reportPath = Server.MapPath("~/Reports/NoofUsersonProject.rpt");
        customRpt.Load(reportPath);


        //change following connection string

        SqlDataAdapter SqlDA = new SqlDataAdapter("SELECT * FROM NoOf_users_on_project", conn);

        DataSet ds = new DataSet();
        SqlDA.Fill(ds, "NoOf_users_on_project");

        DataTable dt = new DataTable();
        customRpt.SetDataSource(ds.Tables[0]);

        CrystalReportViewer1.ReportSource = customRpt;
    }
}