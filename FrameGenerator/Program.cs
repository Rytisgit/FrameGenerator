using FrameGenerator.FileReading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;
using FrameGenerator.FrameCreation;

namespace FrameGenerator
{
    class Program
    {
      
        static void Main(string[] args)
        {

            string GameLocation = @"crawl-ref\";
            string ImageSaveLocation = @"C:\Users\Aspectus\Desktop\";

            var monsterdata = ReadFromFile.GetMonsterData(GameLocation);
            var floorandwall = ReadFromFile.Get_Floor_And_Wall_Names_For_Dungeons();
            var monsterpng = ReadFromFile.GetMonsterPNG(GameLocation);
            var floorpng = ReadFromFile.GetFloorPNG(GameLocation);
            var wallpng = ReadFromFile.GetWallPNG(GameLocation);


            CreatingFrame.DrawFrame(monsterdata, monsterpng, floorpng, wallpng, floorandwall,ImageSaveLocation);
            Console.WriteLine("Done");
            System.Console.ReadKey();

        }
    }

   

    
}



