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




public class ClsDBConnection
{
    SqlConnection conn;
    public SqlConnection OpenConnection()
    {
        conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        //conn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\pmsdb.mdf;Integrated Security=True;User Instance=True";
       
        conn.Open();
        return conn;
    }

    public void CloseConnection()
    {
        conn.Close();
    }

    public long GetCurrentAutoNumber(SqlCommand cmd, string TableName)
    {
        DataTable dtValue = new DataTable();
        long retValue = -1;
        try
        {
            cmd.Parameters.Clear();
            string query = "select current_row_id from AutoNumber_Table where Table_Name=@tbName ";
            
            cmd.Parameters.Add(new SqlParameter("tbName", TableName));
            cmd.CommandText = query;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dtValue);

            if (dtValue.Rows.Count > 0)
            {
                try
                {
                    cmd.Parameters.Clear();
                    retValue = long.Parse(dtValue.Rows[0]["current_row_id"].ToString());
                    retValue++;
                    query = "update AutoNumber_Table set current_row_id=@rtvalue ,modify_datetime=@dtnow where Table_Name=@tbName";
                    cmd.Parameters.Add(new SqlParameter("rtvalue",retValue));
                    cmd.Parameters.Add(new SqlParameter("dtnow", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("tbName",TableName));
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception e)
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
        return retValue;
    }
}
