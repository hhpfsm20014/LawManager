using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string CategoryName = txtCategories.Text.Trim();
            if (CategoryName.Length > 0)
            {
                DBActivity db = new DBActivity();
                bool regi = db.CategorySubmit(CategoryName);
                if (regi)
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.opener.location.reload();", true);
                    //ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.close();", true);
                }
                else
                {
                    string display = "This Category already added !!! ";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
            else
            {
                string display = "Please add a Category first !!! ";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
            
        }
        catch (Exception ex)
        {
           
        }

        
    }
}