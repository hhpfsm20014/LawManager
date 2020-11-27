using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Drawing;


/// <summary>
/// Summary description for stringnull
/// </summary>
public static class DataReaderExtensions
{
    public static string GetStringOrNull(this IDataReader reader, int ordinal)
    {
        return reader.IsDBNull(ordinal) ? null : Convert.ToString(reader.GetValue(ordinal));
    }

    public static string GetStringOrNull(this IDataReader reader, string columnName)
    {
        return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : Convert.ToString(reader.GetOrdinal(columnName));
    }
}