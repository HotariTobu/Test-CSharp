using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class DownloadResourceTest
    {
        public static void Entry()
        {
            //Uri uri = new Uri("TEST.txt", UriKind.Relative);
            Uri uri = new Uri(Path.GetFullPath("TEST.txt"));
            uri = new Uri("http://www.java2s.com");

            if (uri.Scheme.StartsWith("file"))
            {
                string path = Uri.UnescapeDataString(uri.AbsolutePath);
                byte[] bytes = File.ReadAllBytes(path);
                string text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);
            }
            else
            {
                using HttpClient httpClient = new HttpClient();
                byte[] bytes = httpClient.GetByteArrayAsync(uri).Result;
                string text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);
            }
        }
    }
}
