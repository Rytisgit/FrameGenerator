using FrameGenerator.FileReading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;
using FrameGenerator.FrameCreation;
using System.Threading.Tasks;

namespace FrameGenerator
{
    public class ImageCreator
    {
        private string _gameLocation;
        private string _imageSaveLocation;
        private Dictionary<string, string> _monsterdata;
        private Dictionary<string, string[]> _floorandwall;
        private Dictionary<string, Bitmap> _monsterpng;
        private Dictionary<string, Bitmap> _floorpng;
        private Dictionary<string, Bitmap> wallpng;
        public ImageCreator(string GameLocation = @"crawl-ref\", string ImageSaveLocation = @"C:\Users\Aspectus\Desktop\")
        {
            _gameLocation = GameLocation;
            _imageSaveLocation = ImageSaveLocation;
            _monsterdata = ReadFromFile.GetMonsterData(GameLocation);
            _floorandwall = ReadFromFile.Get_Floor_And_Wall_Names_For_Dungeons();
            _monsterpng = ReadFromFile.GetMonsterPNG(GameLocation);
            _floorpng = ReadFromFile.GetFloorPNG(GameLocation);
            wallpng = ReadFromFile.GetWallPNG(GameLocation);
        }

        public Task GenerateImage()
        {
            CreatingFrame.DrawFrame(_monsterdata, _monsterpng, _floorpng, wallpng, _floorandwall, _imageSaveLocation);
            Console.WriteLine("Done");
            return Task.CompletedTask;
        }
    }

   

    
}



