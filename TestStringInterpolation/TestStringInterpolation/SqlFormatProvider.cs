using System;
using System.Globalization;

namespace TestStringInterpolation
{
    class SqlFormatProvider : IFormatProvider
    {
        private readonly SqlFormatter _formatter = new SqlFormatter();

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return _formatter;
            return null;
        }

        class SqlFormatter : ICustomFormatter
        {
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                if (arg == null)
                    return "NULL";
                if (arg is string)
                    return "'" + ((string)arg).Replace("'", "''") + "'";
                if (arg is DateTime)
                    return "'" + ((DateTime)arg).ToString("MM/dd/yyyy") + "'";
                if (arg is IFormattable)
                    return ((IFormattable)arg).ToString(format, CultureInfo.InvariantCulture);
                return arg.ToString();
            }
        }
    }
}