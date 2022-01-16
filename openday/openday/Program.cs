using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace openday {
    class Program {
        static async Task Main(string[] args)
        {
            One();
            //await Two();
        }

        public static void One()
        {
            var g1 = new Thread(() => new StudentGuide().Run());
            var g2 = new Thread(() => new StudentGuide().Run());
            var g3 = new Thread(() => new StudentGuide().Run());
            var g4 = new Thread(() => new StudentGuide().Run());
            var g5 = new Thread(() => new StudentGuide().Run());
            var v1 = new Thread(() => new VisitorGroup().Run());
            var v2 = new Thread(() => new VisitorGroup().Run());
            var v3 = new Thread(() => new VisitorGroup().Run());
            
            g1.Start();
            g2.Start();
            g3.Start();
            g4.Start();
            g5.Start();
            v1.Start();
            v2.Start();
            v3.Start();
        }

        public static async Task Two()
        {
            var stopwatch = Stopwatch.StartNew();

            var client = new WebClient();

            var urls = new List<string>()
            {
                "http://www.orf.at",
                "http://www.news.at"
            };

            var t1 = Task.Run(() => client.DownloadHTML(urls[0]));
            var t2 = Task.Run(() => client.DownloadHTML(urls[1]));

            var bruh = await Task.WhenAll(t1, t2);

            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Execution took {time} milliseconds");

            foreach (var ha in bruh)
            {
                Console.WriteLine(ha);
            }
        }
    }
}