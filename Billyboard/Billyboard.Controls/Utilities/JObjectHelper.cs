using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Utilities
{
    public static class JObjectHelper
    {
        public static string GetString(JObject jObject, string propertyName, string defaultValue)
        {
            if (jObject != null)
            {
                if (jObject[propertyName] != null)
                    return Convert.ToString(jObject[propertyName]);
                else
                    return defaultValue;
            }
            else
                return defaultValue;
        }

        public static int GetInt32(JObject jObject, string propertyName, int defaultValue)
        {
            if (jObject != null)
            {
                if (jObject[propertyName] != null)
                    return Convert.ToInt32(jObject[propertyName]);
                else
                    return defaultValue;
            }
            else
                return defaultValue;
        }
    }
}
