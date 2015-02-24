using System;
using System.Globalization;

namespace TestStringInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInvariant();
            TestUrl();
            TestSql();
            Console.ReadLine();
        }

        static void TestInvariant()
        {
            Console.WriteLine(Invariant($"Today is {DateTime.Today:D}"));
        }

        static void TestUrl()
        {
            int id = 42;
            string name = "foo/bar?";
            string url = Url($"http://foobar/item/{id}/{name}");
            Console.WriteLine(url);
        }

        static void TestSql()
        {
            int id = 42;
            string name = "Let's go";
            string sql = Sql($"insert into items(id, name, creationDate) values({id}, {name}, {DateTime.Now})");
            Console.WriteLine(sql);
        }

        static string Url(FormattableString formattable)
        {
            return formattable.ToString(new UrlFormatProvider());
        }
        static string Sql(FormattableString formattable)
        {
            return formattable.ToString(new SqlFormatProvider());
        }
        static string Invariant(FormattableString formattable)
        {
            return formattable.ToString(CultureInfo.InvariantCulture);
        }
    }
}
