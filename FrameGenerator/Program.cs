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

            var monsterdata = ReadFromFile.GetMonsterData();
            var floorandwall = ReadFromFile.Get_Floor_And_Wall_Names_For_Dungeons();
            var monsterpng = ReadFromFile.GetMonsterPNG();
            var floorpng = ReadFromFile.GetFloorPNG();
            var wallpng = ReadFromFile.GetWallPNG();


            CreatingFrame.DrawFrame(monsterdata, monsterpng, floorpng, wallpng, floorandwall);
            Console.WriteLine("Done");
            System.Console.ReadKey();

        }
    }

   

    
}



