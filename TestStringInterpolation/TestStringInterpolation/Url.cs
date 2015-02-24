using System;

namespace TestStringInterpolation
{
    class Url
    {
        private static readonly UrlFormatProvider _formatProvider = new UrlFormatProvider();
        private readonly IFormattable _formattable;

        public Url(IFormattable formattable)
        {
            _formattable = formattable;
        }

        public override string ToString()
        {
            return _formattable.ToString(null, _formatProvider);
        }

        public static implicit operator string (Url url)
        {
            return url.ToString();
        }

        class UrlFormatProvider : IFormatProvider
        {
            private readonly UrlFormatter _formatter = new UrlFormatter();

            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter))
                    return _formatter;
                return null;
            }
        }

        private class UrlFormatter : ICustomFormatter
        {
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                if (arg == null)
                    return String.Empty;
                if (format == "r")
                    return arg.ToString();
                return Uri.EscapeDataString(arg.ToString());
            }
        }
    }
}
