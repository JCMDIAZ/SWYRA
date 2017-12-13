using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace swyraServices
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
            str = (d.Year != 1) ? "'" + d.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "Null";
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
                        DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
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

        private static readonly Regex ReAlfaNumerico = new Regex(@"\w+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Elimina todos los caracteres no alfanuméricos de un texto, incluyendo espacios y signos de puntuación.
        /// Adicionalmente elimina las marcas ortográficas como acentos y diéresis.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToAlphaNumeric(this string s)
        {
            var sb = new StringBuilder();
            foreach (Match m in ReAlfaNumerico.Matches(s))
                sb.Append(m.Value.ToLower());
            return sb.ToString().RemoveDiacritics();
        }

        /// <summary>
        /// Elimina las marcas ortográficas como acentos y diéresis de un texto.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string RemoveDiacritics(this string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s.Normalize(NormalizationForm.FormD))
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Verifica si el parámetro "find" es subcadena de "text", ignorando
        /// mayúsculas/minúsculas y acentos.
        /// </summary>
        /// <param name="text">Texto donde buscar.</param>
        /// <param name="find">Texto a buscar dentro de "text".</param>
        /// <returns></returns>
        public static bool Matches(this string text, string find)
        {
            var s = text.RemoveDiacritics();
            return find.Words().All(w => s.IndexOf(w.RemoveDiacritics(), StringComparison.CurrentCultureIgnoreCase) != -1);
        }

        /// <summary>
        /// Obtiene las palabras que componen un texto, incluyendo cualquier combinación de caracteres alfanuméricos.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string[] Words(this string text)
        {
            return ReAlfaNumerico.Matches(text).Cast<Match>().Select(m => m.Value).ToArray();
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
