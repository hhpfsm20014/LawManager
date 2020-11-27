using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Drawing2D;

public class CatpchaImage
{
    public static string SESSION_CAPTCHA = "CAPTCHA";


    const int default_width = 140;
    const int default_height = 40;

    protected Bitmap result = null;

    public int Width;
    public int Height;

    public CatpchaImage()
    {
        InitBitmap(default_width, default_height);
        rnd = new Random();
    }

    public CatpchaImage(int width, int height)
    {
        InitBitmap(width, height);
    }

    protected void InitBitmap(int width, int height)
    {
        result = new Bitmap(width, height);
        Width = width;
        Height = height;
        rnd = new Random();
    }



    public PointF Noise(PointF p, double eps)
    {
        p.X = Convert.ToSingle(rnd.NextDouble() * eps * 2 - eps) + p.X;
        p.Y = Convert.ToSingle(rnd.NextDouble() * eps * 2 - eps) + p.Y;
        return p;
    }

    public PointF Wave(PointF p, double amp, double size)
    {
        p.Y = Convert.ToSingle(Math.Sin(p.X / size) * amp) + p.Y;
        p.X = Convert.ToSingle(Math.Sin(p.X / size) * amp) + p.X;
        return p;
    }



    public GraphicsPath RandomWarp(GraphicsPath path)
{
// Add line //
int PsCount = 10;
PointF[] curvePs = new PointF [PsCount=2];
for (int u = 0; u < PsCount; u++)
{
curvePs[u].X = u * (Width / PsCount);
curvePs[u].Y = Height / 2;
}
for (int u = PsCount; u < (PsCount=2); u++)
{
curvePs[u].X = (u - PsCount) * (Width / PsCount);
curvePs[u].Y = Height / 2 + 2;
}


double eps = Height * 0.05;

double amp = rnd.NextDouble() * (double)(Height / 3);
double size = rnd.NextDouble() * (double)(Width / 4) + Width / 8;

double offset = (double)(Height / 3);


PointF[] pn = new PointF[path.PointCount];
byte[] pt = new byte[path.PointCount];

GraphicsPath np2 = new GraphicsPath();

GraphicsPathIterator iter = new GraphicsPathIterator(path);
for (int i = 0; i < iter.SubpathCount; i++)
{
GraphicsPath sp = new GraphicsPath();
bool closed;
iter.NextSubpath(sp, out closed);

Matrix m = new Matrix();
m.RotateAt(Convert.ToSingle(rnd.NextDouble() * 30 - 15), sp.PathPoints[0]);

m.Translate(-1 * i, 0);//uncomment

sp.Transform(m);

np2.AddPath(sp, true);
}




for (int i = 0; i < np2.PointCount; i++)
{
//pni = Noise( path.PathPointsi , eps);
pn[i] = Wave(np2.PathPoints[i], amp, size);
pt[i] = np2.PathTypes[i];
}

GraphicsPath newpath = new GraphicsPath(pn, pt);

return newpath;

}

    Random rnd;


    public string DrawNumbers(int len)
    {
        string str = "";
        string possible = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789abcdfghjkmnpqrstvwxyz";
        char ch = 'A';
        for (int i = 0; i < len; i++)
        {
            ch = possible[rnd.Next(0, possible.Length - 1)];
            str = str + ch.ToString();
        }

        DrawText(str);
        return str;
    }

    public void DrawText(string aText)
{

Graphics g = Graphics.FromImage(result);
int startsize = Height;
Font f = new Font("Verdana", startsize, FontStyle.Bold, GraphicsUnit.Pixel);

do
{
f = new Font("Verdana", startsize, GraphicsUnit.Pixel);
startsize--;
} while ((g.MeasureString(aText, f).Width >= Width) || (g.MeasureString(aText, f).Height >= Height));
SizeF sf = g.MeasureString(aText, f);
int width = Convert.ToInt32(sf.Width);
int height = Convert.ToInt32(sf.Height);

int x = Convert.ToInt32(Math.Abs((double)width - (double)Width) * rnd.NextDouble());
int y = Convert.ToInt32(Math.Abs((double)height - (double)Height) * rnd.NextDouble());

//////// Paths ///
GraphicsPath path = new GraphicsPath(FillMode.Alternate);

FontFamily family = new FontFamily("Verdana");
int fontStyle = (int)(FontStyle.Regular);
float emSize = f.Size;
Point origin = new Point(x, y);
StringFormat format = StringFormat.GenericDefault;

path.AddString(aText, family, fontStyle, emSize, origin, format);


g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
Rectangle rect = new Rectangle(0, 0, Width, Height);
g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(rect, Color.White, Color.White, 0f), rect);
g.SmoothingMode = SmoothingMode.HighQuality;


Color noiseCol = Color.FromArgb(100, 120, 180);
Pen p = new Pen(noiseCol);


/* generate random dots in background */
for( int i=0; i<(Width*Height)/3; i++ ) {
g.FillEllipse(Brushes.Blue, rnd.Next(0, Width), rnd.Next(0, Height), 1, 1);
}
///noise ends here/

/* generate random lines in background */
for( int i=0; i<(Width*Height)/150; i++ ) {
g.DrawLine(p,rnd.Next(0,Width), rnd.Next(0,Height), rnd.Next(0,Width), rnd.Next(0,Height));
}

Color textColor = Color.FromArgb(20, 40, 100);
g.FillPath(new SolidBrush(textColor), path);

g.Dispose();
}

    public Bitmap Result
    {
        get
        {
            return result;
        }
    }


}
