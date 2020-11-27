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

public partial class editissue : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\pmsdb.mdf;Integrated Security=True;User Instance=True");

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //protected void btnUpdateIssues_Click(object sender, EventArgs e)
    //{
    //    DBActivity db = new DBActivity();
    //    string issueID = DDLIssue.SelectedValue;
    //    bool regi = db.EditIssue(issueID, txtissuetype.Text, txtissuedesc.Text);
    //    if (regi)
    //    {
    //        Response.Write("update sucess");
    //    }
    //    else
    //    {
    //        Response.Write("update fail");
    //    }
    //}
    protected void DDLIssue_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtissueid.Text = DDLIssue.SelectedValue;

        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Issue_Master WHERE issue_id='" + DDLIssue.SelectedValue + "'", conn);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read() == true)
        {

            txtissuetype.DataTextField = dr.GetValue(4).ToString();
            
            txtissuedesc.Text = dr.GetValue(5).ToString();
            

        }
        dr.Close();
        conn.Close();
    }
   
}