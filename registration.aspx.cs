using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Net.Mail;
using System.Net;


public partial class Registration : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();
        if (Session["CAPTCHA"].ToString().Equals(txtInput.Text))
        {
            bool regi = db.NewUserDetails(txtCompany.Text, txtIndustry.Text, txtPerson.Text, txtContactNo.Text, txtAddress.Text, txtCity.Text, txtPincode.Text, txtState.Text, txtCountry.Text, txtEmail.Text, txtPwd.Text);
            if (regi == true)
            {

                // Response.Redirect("Login.aspx");
                string sendto = txtEmail.Text;
                string subject = "Successfull Registration";
                string body = "Welcome  " + txtCompany.Text + System.Environment.NewLine + "You have sucessfully registered" + System.Environment.NewLine + "Your Email_id is " + txtEmail.Text + System.Environment.NewLine + System.Environment.NewLine + "Thank you";

                db.sendMail(sendto, subject, body);

                db.sendSMS(txtContactNo.Text, "Thank you! for your registration with REXPMS");

                Response.Redirect("login.aspx");
            }
            else
            {
                txtEmail.Text = "Email already exist!";
                txtEmail.Focus();
            }
        }
        else
        {
            lblMessage1.Text = "InValid Code Inputed";

        }
    }






    protected void btnReset_Click(object sender, EventArgs e)
    {
        //  btnReset.Attributes.Add("onClick", "document.forms[0].reset();return false;");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CatpchaImage a = new CatpchaImage();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        CatpchaImage a = new CatpchaImage();
    }
}