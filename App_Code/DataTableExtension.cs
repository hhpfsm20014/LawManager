using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

/// <summary>
/// Summary description for DataTableExtension
/// </summary>
public static class DataTableExtension
{
    public static DataTable ToDataTable<T>(this List<T> items)
    {
        var tb = new DataTable(typeof(T).Name);

        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in props)
        {
            tb.Columns.Add(prop.Name, prop.PropertyType);
        }

        foreach (var item in items)
        {
            var values = new object[props.Length];
            for (var i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }

            tb.Rows.Add(values);
        }

        return tb;
    }

    public static DataRow ConvertToDataRow<T>(this T item, DataTable table)
    {
        PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
        DataRow row = table.NewRow();
        foreach (PropertyDescriptor prop in properties)
            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
        return row;
    }

    public static T ConvertToEntity<T>(this DataRow tableRow) where T : new()
    {
        // Create a new type of the entity I want
        Type t = typeof(T);
        T returnObject = new T();

        foreach (DataColumn col in tableRow.Table.Columns)
        {
            string colName = col.ColumnName;

            // Look for the object's property with the columns name, ignore case
            PropertyInfo pInfo = t.GetProperty(colName.ToLower(),
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // did we find the property ?
            if (pInfo != null)
            {
                object val = tableRow[colName];

                // is this a Nullable<> type
                bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
                if (IsNullable)
                {
                    if (val is System.DBNull)
                    {
                        val = null;
                    }
                    else
                    {
                        // Convert the db type into the T we have in our Nullable<T> type
                        val = Convert.ChangeType(val, Nullable.GetUnderlyingType(pInfo.PropertyType));
                    }
                }
                else
                {
                    // Convert the db type into the type of the property in our entity
                    SetDefaultValue(ref val, pInfo.PropertyType);
                    if (pInfo.PropertyType.IsEnum && !pInfo.PropertyType.IsGenericType)
                    {
                        val = Enum.ToObject(pInfo.PropertyType, val);
                    }
                    else
                        val = Convert.ChangeType(val, pInfo.PropertyType);
                }
                // Set the value of the property with the value from the db
                if (pInfo.CanWrite)
                    pInfo.SetValue(returnObject, val, null);
            }
        }

        // return the entity object with values
        return returnObject;
    }

    private static void SetDefaultValue(ref object val, Type propertyType)
    {
        if (val is DBNull)
        {
            val = GetDefault(propertyType);
        }
    }

    public static object GetDefault(Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        return null;
    }

    public static string GetDefaultDateTimeFormat(this string date)
    {
        try
        {
            return Convert.ToDateTime(date).ToString("dd-MMM-yyyy");
        }
        catch (Exception ex)
        {
            return date;
        }
    }
    public static string ToDefaultDateTimeFormat(this string date)
    {
        try
        {
            string datetime = Convert.ToDateTime(date).ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
            return Convert.ToDateTime(datetime).ToString("dd-MMM-yyyy");
        }
        catch (Exception ex)
        {
            return date;
        }
    }
        
}