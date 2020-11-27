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
using System.Net.Mail;
using System.Net;


public partial class forgetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnForget_Click(object sender, EventArgs e)
    {

        DBActivity login = new DBActivity();
        ClsDBConnection conn = new ClsDBConnection();
        try
        {
            SqlConnection cn = conn.OpenConnection(); //establishing the connection to database
            string qry = "select pwd  from User_Master where email_id ='" + txtEmail.Text + "'";

            SqlCommand cmd = new SqlCommand(qry, cn);
            //SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            //email.Value = txtEmail.Text.Trim().ToString();
            //cmd.Parameters.Add(email);

            //Create Dataset to store results and DataAdapter to fill Dataset 
            //DataTable dsPwd = new DataTable();
            //SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            //dAdapter.Fill(dsPwd);
            string dr = cmd.ExecuteScalar().ToString();
            
            if (dr!= null)
            {
                MailMessage loginInfo = new MailMessage();
                loginInfo.To.Add(txtEmail.Text.ToString());
                loginInfo.From = new MailAddress("mafiaboy5800@gmail.com");
                loginInfo.Subject = "Forgot Password Information";

                loginInfo.Body = "Your Password: " + dr + "<br><br>";
                loginInfo.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("mafiaboy5800@gmail.com", "mafiamafia");
                smtp.Send(loginInfo);
                lblMessage.Text = "Password is sent to you email id,you can now login";
            }
            else
            {
                lblMessage.Text = "Email Address Not Registered";
            }


        }
        finally {
            
            txtEmail.Text = "";
        }
    }
}

