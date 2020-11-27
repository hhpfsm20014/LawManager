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

public partial class createUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        DBActivity db = new DBActivity();
        bool user = db.createUser(txtName.Text, txtEmail.Text, txtContactNo.Text, ddlType.SelectedValue, radioStatus.Text, txtPassword.Text);
        if (user == true)
        {

            string pw = "mafiamafia"; //(ConfigurationManager.AppSettings["password"]);
            string from = "mafiaboy5800@gmail.com"; //Replace this with your own correct Gmail Address
            string to = txtEmail.Text; //Replace this with the Email Address to whom you want to send the mail
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = "Successfull Registration";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Welcome  " + txtName.Text + System.Environment.NewLine + "You have sucessfully registered" + System.Environment.NewLine + "Your Email_id is " + txtEmail.Text + System.Environment.NewLine + System.Environment.NewLine + "Thank you";

            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();

            //Add the Creddentials- use your own email id and password
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pw);
            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer

            try
            {
                client.Send(mail);
                Response.Write("Message Sent...");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            } // end try
            if (txtContactNo.Text != null)
            {
               // send(txtContactNo.Text);
            }
        }
    }
    public void send(string no)
    {
        HttpWebRequest myReq =
        (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=9998544799&pwd=attitude" +
        "&msg= you successfully registered to REXPMS, your email address is:" + txtEmail.Text + "&phone=" + no + "&provider=site2sms");

        HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
        System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
        string responseString = respStreamReader.ReadToEnd();
        respStreamReader.Close();
        myResp.Close();
    }

}
