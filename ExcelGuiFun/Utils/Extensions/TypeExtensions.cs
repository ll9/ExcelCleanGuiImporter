using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Utils.Extensions
{
    public static class TypeExtensions
    {
        public static string GetSqlType(this Type type) {
            var @switch = new Dictionary<Type, string>()
            {
                { typeof(bool), "BOOLEAN" },
                { typeof(long), "BIGINT" },
                { typeof(DateTime), "DATETIME" },
                { typeof(string), "TEXT" },
            };

            return (@switch.TryGetValue(type, out var value) ? value : "TEXT");
        }
    }
}
