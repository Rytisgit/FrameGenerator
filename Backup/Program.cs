using ImageDisplay;
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
            Display display = new Display();
            display.a_picture();
            Task.Run(() => generator.GenerateImage(display)
            .ContinueWith((_) => { Console.WriteLine("Async magic"); return; }));
            
            Console.WriteLine("it just works");
            System.Console.ReadKey();
        }
    }
}
