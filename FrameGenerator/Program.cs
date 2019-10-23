using FrameGenerator.FileReading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace FrameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable monster = new Hashtable();
            var monsterpng = new Dictionary<string, Bitmap>();
            var floorpng = new Dictionary<string, Bitmap>();
            var wallpng = new Dictionary<string, Bitmap>();
            var floorandwall = new Dictionary<string, string[]>();
            ReadFromFile.read(monster, monsterpng, floorpng, wallpng, floorandwall); 
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }

   

    
}



