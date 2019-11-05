using FrameGenerator;
using System;
using System.Threading.Tasks;

namespace imageGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageCreator generator = new ImageCreator(@"C:\source\DCSS\crawl-ref\", @"..\..\");
            Console.WriteLine("Hello World!");
            Task.Run(() => generator.GenerateImage()
            .ContinueWith((_) => { Console.WriteLine("Async magic"); return; }));
            Console.WriteLine("it just works");
            System.Console.ReadKey();
        }
    }
}
