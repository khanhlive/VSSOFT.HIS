using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Vssoft.Data.Extension
{
    public static class DataConverter
    {

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public static int StringToInt(string value)
        {
            int obj = 0;
            if (int.TryParse(value, out obj))
            {
                return obj;
            }
            else throw new ArgumentNullException("Chuỗi không phải là một số");
        }

        public static int? ToInt(string value)
        {
            int obj = 0;
            if (int.TryParse(value, out obj))
            {
                return obj;
            }
            else return null;
        }

        public static byte? ToByte(string value)
        {
            byte obj = 0;
            if (byte.TryParse(value, out obj))
            {
                return obj;
            }
            else return null;
        }

        public static string ToUpper(string value)
        {
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
            {
                return value.ToUpper();
            }
            else return string.Empty ;
        }

    }
}
