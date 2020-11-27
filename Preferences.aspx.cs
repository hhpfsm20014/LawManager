using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Preferences : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
    {
        ClsDBConnection conn = new ClsDBConnection();
        SqlConnection cn = conn.OpenConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.Clear();
        cmd.Connection = cn;
        cmd.CommandText = "UPDATE User_Preference SET default_project=@df WHERE user_id = @uid";
        cmd.Parameters.Add(new SqlParameter("df",ddlProject.SelectedValue));
        cmd.Parameters.Add(new SqlParameter("uid",Session["userid"].ToString()));
        cmd.ExecuteNonQuery();
        lblReply.Text = "Successfully updated";
    }
}