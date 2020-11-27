<%@ WebHandler Language="C#" Class="captcha" %>

using System;
using System.Web;
using System.Drawing;
using System.Web.SessionState;

public class captcha : IHttpHandler, IRequiresSessionState
{


public void ProcessRequest (HttpContext context) {
context.Response.ContentType = "image/jpeg";
CatpchaImage captcha = new CatpchaImage();
string str = captcha.DrawNumbers(5);
if (context.Session [CatpchaImage.SESSION_CAPTCHA] == null) context.Session.Add(CatpchaImage.SESSION_CAPTCHA, str);
else
{
context.Session [CatpchaImage.SESSION_CAPTCHA] = str;
}
Bitmap bmp = captcha.Result;
bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
}



public bool IsReusable {
get {
return true;
}
}

}
