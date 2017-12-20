using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingExample
{
    class Program
    {
        public static bool TextContent { get; private set; }

        static void Main(string[] args)
        {
            var WebClient = new WebClient();
            var html = WebClient.DownloadString("https://www.cia.gov/careers/opportunities/support-professional/information-assurance.html");

            var parser = new HtmlParser();
            var document = parser.Parse(html);

            var content = document.QuerySelector("article #content h1");
            var tbody = document.QuerySelector("tbody");
            var paragraph1 = document.QuerySelector("#content-core #parent-fieldname-text-8af356a1496b001c9995eb20bf334f4f p ~ p");
            var paragraph2 = document.QuerySelector("#content-core #parent-fieldname-text-8af356a1496b001c9995eb20bf334f4f p + p");
            var bullet1 = document.QuerySelector("#content-core #parent-fieldname-text-8af356a1496b001c9995eb20bf334f4f ul");

            
            Console.WriteLine(content.TextContent);
            Console.WriteLine(tbody.TextContent);
            Console.WriteLine(paragraph1.TextContent);
            Console.WriteLine("");
            Console.WriteLine(paragraph2.TextContent);
            Console.WriteLine("");
            Console.WriteLine(bullet1.TextContent);

        }
    }
}
