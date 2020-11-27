using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Court : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string CourtName = txtCourt.Text.Trim();
            if (CourtName.Length > 0)
            {
                DBActivity db = new DBActivity();
                bool regi = db.CourtSubmit(CourtName);
                if (regi)
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.opener.location.reload();", true);
                    //ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.close();", true);
                }
                else
                {
                    string display = "This Court already added !!! ";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else
            {
                string display = "Please add a Court first !!! ";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }

        }
        catch (Exception ex)
        {
            //pokemon exception handling  
            //return dt;
        }
    }
}