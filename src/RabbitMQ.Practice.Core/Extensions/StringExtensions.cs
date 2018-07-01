using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Practice.Core.Extensions
{
    public static class StringExtensions
    {
        public static string AppendLine(this string str, params string[] strList )
        {
            var list = strList.ToList();
            return str.AppendLine(list);
        }

        public static string AppendLine(this string str, IList<string> strList, string formmatLineChar = "\t")
        {
            var sb = new StringBuilder(str);
            foreach (var line in strList)
            {
                sb.AppendLine($"{formmatLineChar}{line}");
            }
            
            var message = sb.ToString();
            return message;
        }
    }
}
