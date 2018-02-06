using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SWYRA_Movil
{
    public static class Extensions
    {
        /// <summary>
        /// Convierte un data table a List de una clase
        /// EJEMPLO: List<Employee> lst = ds.Tables[0].ToList<Employee>();
        /// El nombre de la propiedad de la clase debe coincidir con el nombre de la columna
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            return (from object row in table.Rows select CreateItemFromRow<T>((DataRow)row, properties)).ToList();
        }

        public static T ToData<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            return (from object row in table.Rows select CreateItemFromRow<T>((DataRow)row, properties)).ToList().FirstOrDefault();
        }

        public static string ToStrSql(this DateTime d)
        {
            string str = "null";
            str = (d.Year != 1) ? "CONVERT(datetime, '" + d.ToString("dd-MM-yyyy HH:mm:ss") + "', 105)" : "Null";
            return str;
        }

        public static string ToStrSql(this DateTime? d)
        {
            string str = "null";
            DateTime r = new DateTime();
            if (d != null)
            {
                r = (DateTime)d;
            }
            str = (d != null) ? "CONVERT(datetime, '" + r.ToString("dd-MM-yyyy HH:mm:ss") + "', 105)" : "Null";
            return str;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    if (property.PropertyType == typeof(System.DayOfWeek))
                    {
                        DayOfWeek day = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString(), false);
                        property.SetValue(item, day, null);
                    }
                    else
                    {
                        if (row[property.Name] == DBNull.Value)
                            property.SetValue(item, null, null);
                        else
                            property.SetValue(item, row[property.Name], null);
                    }
                }
            }
            return item;
        }

        public static bool In<T>(this T value, params T[] opcion)
        {
            return opcion.Contains(value);
        }

        /// <summary>
        /// Convierte en mayúscula la primera letra del texto dado.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Capitalize(this string s)
        {
            return Char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
