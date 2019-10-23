using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FrameGenerator.FileReading
{
    class ReadFromFile
    {

        public static void read(System.Collections.Hashtable monster, Dictionary<string, Bitmap> monsterPNG, Dictionary<string, Bitmap> floorpng, Dictionary<string, Bitmap> wallpng, Dictionary<string, string[]> floorandwall)
        {
            
            string[] lines = System.IO.File.ReadAllLines(@"crawl-ref\source\mon-data.h");
            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("  MONS_"))
                {
                    string[] tokens = lines[i].Split(',');
                    tokens[1] = tokens[1].Replace("'", "").Replace(" ", "");
                    tokens[2] = tokens[2].Replace(" ", "");
                    tokens[0] = tokens[0].Replace("MONS_", "").Replace(" ", "").ToLower();
                    monster[tokens[1] + tokens[2]] = tokens[0];
                }
            }
      
            {
                lines = System.IO.File.ReadAllLines(@"..\..\..\Extra\tilefloor.txt");
                string[] temp = new string[2];
                for (var i = 0; i < lines.Length; i += 3)
                {
                    temp[0] = lines[i + 1];
                    temp[1] = lines[i + 2];
                    floorandwall[lines[i]] = temp;
                }
            }

            string[] allpngfiles = Directory.GetFiles(@"crawl-ref\source\rltiles\mon", "*.png*", SearchOption.AllDirectories);
            foreach (var file in allpngfiles)
            {
                FileInfo info = new FileInfo(file);
                Bitmap bitmap = new Bitmap(file);
                monsterPNG[info.Name.Replace(".png", "")] = bitmap;       
                
            }

            string[] floorpngfiles = Directory.GetFiles(@"crawl-ref\source\rltiles\dngn\floor", "*.png*", SearchOption.AllDirectories);
            foreach (var file in floorpngfiles)
            {
                FileInfo info = new FileInfo(file);
                Bitmap bitmap = new Bitmap(file);
                floorpng[info.Name.Replace(".png", "")] = bitmap;
            }

            string[] wallpngfiles = Directory.GetFiles(@"crawl-ref\source\rltiles\dngn\wall", "*.png*", SearchOption.AllDirectories);
            foreach (var file in allpngfiles)
            {
                FileInfo info = new FileInfo(file);
                Bitmap bitmap = new Bitmap(file);
                wallpng[info.Name.Replace(".png", "")] = bitmap;
            }

            string[] inputlines = System.IO.File.ReadAllLines(@"..\..\..\Extra\test.txt");
            
            using (Bitmap bmp = new Bitmap(1280, 720))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    using (Font arialFont = new Font("Courier New", 16))
                    {

                        var yellow = new SolidBrush(Color.FromArgb(252, 233, 79));
                        var brown = new SolidBrush(Color.FromArgb(143, 89, 2));
                        g.DrawString("name", arialFont, yellow, 32*22, 0);
                        g.DrawString("class", arialFont, yellow, 32 * 22, 20);
                        g.DrawString("Health:", arialFont, brown, 32 * 22, 40);
                        g.DrawString("Mana:", arialFont, brown, 32 * 22, 60);
                        g.DrawString("AC:", arialFont, brown, 32 * 22, 80);
                        g.DrawString("SH:", arialFont, brown, 32 * 22, 100);
                        g.DrawString("XL: Next:", arialFont, brown, 32 * 22, 120);
                        g.DrawString("Noise:", arialFont, brown, 32 * 22, 140);
                        g.DrawString("a)", arialFont, brown, 32 * 22, 160);
                        g.DrawString("Str:", arialFont, brown, 32 * 30, 80);
                        g.DrawString("Int:", arialFont, brown, 32 * 30, 100);
                        g.DrawString("Dex:", arialFont, brown, 32 * 30, 120);
                        g.DrawString("Place:", arialFont, brown, 32 * 30, 140);
                        g.DrawString("Time:", arialFont, brown, 32 * 30, 160);
                        int percentage = (int)(202 * 0.1);
                        Bitmap heathbar = new Bitmap(percentage, 16);
                        Bitmap mana = new Bitmap(percentage, 16);
                        Graphics temp = Graphics.FromImage(heathbar);               
                        temp.Clear(Color.Green);
                        temp = Graphics.FromImage(mana);
                        temp.Clear(Color.Blue);
                        g.DrawImage(heathbar, 32 * 30, 40);
                        g.DrawImage(mana, 32 * 30, 60);

                    }
                    var x = 0;
                    var y = 0;
                    foreach (var line in inputlines)
                    {
                        string[] words = line.Split(' ');
                        for (var i = 0; i < words.Length; i+=2)
                        {
                            if (words[i] == "#")
                            {
                                Bitmap wall = new Bitmap(@"crawl-ref\source\rltiles\dngn\wall\bars_red01.png");
                                g.DrawImage(wall, x, y, wall.Width, wall.Height);
                            }
                            else if (words[i] == ".")
                            {
                                Bitmap floor = new Bitmap(@"crawl-ref\source\rltiles\dngn\floor\black_cobalt04.png");
                                g.DrawImage(floor, x, y, floor.Width, floor.Height);
                            }
                            else 
                            {
                                Bitmap floor = new Bitmap(@"crawl-ref\source\rltiles\dngn\floor\black_cobalt04.png");
                                string name = (String)(monster[(String)(words[i] + words[i + 1]).Replace(" ", "")]);
                                Bitmap mnstr = monsterPNG[name];                              
                                g.DrawImage(floor, x, y, floor.Width, floor.Height);
                                g.DrawImage(mnstr, x, y, mnstr.Width, mnstr.Height);                    
                            }
                            x += 32;
                        }
                        x = 0;
                        y += 32;
                       
                    }
                    
                }  
                    bmp.Save(@"C:\Users\Aspectus\Desktop\img.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

            }
        }
    }
}
