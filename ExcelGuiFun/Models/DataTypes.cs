using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Models
{
    public enum DataType
    {
        System_Bool = 1,
        System_Date = 2,
        System_Numeric = 4,
        System_Text = 8,
    }

    public static class DataTypeExtensions
    {
        public static Type GetRealType(this DataType dataType)
        {
            switch(dataType)
            {
                case (DataType.System_Bool): return typeof(bool?);
                case (DataType.System_Date): return typeof(DateTime);
                case (DataType.System_Numeric): return typeof(long?);
                case (DataType.System_Text): return typeof(string);
                default: return typeof(string);
            }
        }

        public static dynamic GetDynamicValue(Type type, object value)
        {
            var @switch = new Dictionary<Type, dynamic>()
            {
                { typeof(bool), bool.TryParse(value.ToString(), out var boolResult) ? (bool?)boolResult : null },
                { typeof(DateTime), DateTime.TryParse(value.ToString(), out var dateResult) ? (DateTime?)dateResult : null },
                { typeof(long), long.TryParse(value.ToString(), out var longResult) ? (long?)longResult : null },
                { typeof(string), value?.ToString() },
            };

            return @switch[type];
        }
    }
}
