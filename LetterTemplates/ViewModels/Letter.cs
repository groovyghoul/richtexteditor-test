using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LetterTemplates.ViewModels
{
    public class Letter
    {
        public string Subject { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string Conclusion { get; set; }

        public Letter Merge(object obj)
        {

            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(obj, null);
                var propName = "[" + prop.Name + "]";

                if (Body != null)
                {
                    var s = Body.Normalize();
                    s.Replace(propName, propValue.ToString());
                    Body = s;
                }
            }

            return this;
        }

    }
}