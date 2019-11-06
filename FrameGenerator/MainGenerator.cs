using FrameGenerator.FileReading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;
using FrameGenerator.FrameCreation;
using System.Threading.Tasks;
using Window;
using System.Linq;

namespace FrameGenerator
{
    public class MainGenerator
    {
        Widow_Display display = new Widow_Display();
        private Dictionary<string, string> _monsterdata;
        private Dictionary<string, string[]> _floorandwall;
        private Dictionary<string, Bitmap> _monsterpng;
        private Dictionary<string, Bitmap> _floorpng;
        private Dictionary<string, Bitmap> wallpng;

        public MainGenerator()
        {
            string GameLocation = File.ReadAllLines(@"..\..\..\..\FrameGenerator\Extra\config.ini").First();
            
            _monsterdata = ReadFromFile.GetMonsterData(GameLocation);
            _floorandwall = ReadFromFile.Get_Floor_And_Wall_Names_For_Dungeons();
            _monsterpng = ReadFromFile.GetMonsterPNG(GameLocation);
            _floorpng = ReadFromFile.GetFloorPNG(GameLocation);
            wallpng = ReadFromFile.GetWallPNG(GameLocation);
        }

        public Task GenerateImage()
        {
            CreatingFrame.DrawFrame(_monsterdata, _monsterpng, _floorpng, wallpng, _floorandwall, display);
            Console.WriteLine("Done");
            return default;
        }

  

    }

   

    
}



