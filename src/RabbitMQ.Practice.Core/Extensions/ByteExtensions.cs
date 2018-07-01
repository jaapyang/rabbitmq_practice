using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Practice.Core.Extensions
{
    public static class ByteExtensions
    {
        public static string GetStringByUtf8(this byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        public static byte[] GetBytesByUtf8(this string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }
    }
}
