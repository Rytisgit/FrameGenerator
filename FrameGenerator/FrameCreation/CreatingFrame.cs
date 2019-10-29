using System;
using System.Collections.Generic;
using System.Drawing;

namespace FrameGenerator.FrameCreation
{
    class CreatingFrame
    {
        public static void DrawFrame(Dictionary<string, string> monsterdata, Dictionary<string, Bitmap> monsterPNG, Dictionary<string, Bitmap> floorpng, Dictionary<string, Bitmap> wallpng, Dictionary<string, string[]> floorandwall)
        {

            var model = InputParser.Parser.ParseData();

            

            
            using (Bitmap bmp = new Bitmap(1280, 720))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {   
                    using (Font arialFont = new Font("Courier New", 16))
                    {
                        var yellow = new SolidBrush(Color.FromArgb(252, 233, 79));
                        var brown = new SolidBrush(Color.FromArgb(143, 89, 2));

                     

                        g.DrawString(model.SideData.Name, arialFont, yellow, 32 * 22, 0);
                        g.DrawString(model.SideData.Race, arialFont, yellow, 32 * 22, 20);
                        g.DrawString("Health: "+ model.SideData.Health.ToString()+'/'+ model.SideData.MaxHealth.ToString(), arialFont, brown, 32 * 22, 40);
                        g.DrawString("Mana: "+ model.SideData.Magic.ToString() + '/'+ model.SideData.MaxMagic.ToString(), arialFont, brown, 32 * 22, 60);
                        g.DrawString("AC: "+ model.SideData.ArmourClass, arialFont, brown, 32 * 22, 80);
                        g.DrawString("EV: " + model.SideData.Evasion, arialFont, brown, 32 * 22, 100);
                        g.DrawString("SH: "+ model.SideData.Shield, arialFont, brown, 32 * 22, 120);
                        g.DrawString("XL: "+ model.SideData.ExperienceLevel+" Next: "+ model.SideData.NextLevel, arialFont, brown, 32 * 22, 140);
                        g.DrawString("Noise:", arialFont, brown, 32 * 22, 160);
                        g.DrawString("a)", arialFont, brown, 32 * 22, 180);
                        g.DrawString("Str: "+ model.SideData.Strength, arialFont, brown, 32 * 30, 80);
                        g.DrawString("Int: "+ model.SideData.Inteligence, arialFont, brown, 32 * 30, 100);
                        g.DrawString("Dex: "+ model.SideData.Dexterity, arialFont, brown, 32 * 30, 120);
                        g.DrawString("Place: "+ model.SideData.Place, arialFont, brown, 32 * 30, 140);
                        g.DrawString("Time: "+ model.SideData.Time, arialFont, brown, 32 * 30, 160);


                        Bitmap bar = new Bitmap(250, 16);
                        Graphics temp = Graphics.FromImage(bar);
                        temp.Clear(Color.Gray);
                        g.DrawImage(bar, 32 * 30, 40);
                        g.DrawImage(bar, 32 * 30, 60);

                        int percentage = (int)(250 * ((float)model.SideData.Health / model.SideData.MaxHealth));
                        Bitmap heathbar = new Bitmap(percentage, 16);
                        percentage = (int)(250 * ((float)model.SideData.Magic / model.SideData.MaxMagic));
                        Bitmap mana = new Bitmap(percentage, 16);
                        temp = Graphics.FromImage(heathbar);
                        temp.Clear(Color.Green);
                        temp = Graphics.FromImage(mana);
                        temp.Clear(Color.Blue);
                        g.DrawImage(heathbar, 32 * 30, 40);
                        g.DrawImage(mana, 32 * 30, 60);
                    }
                    
                    var x = 0;
                    var y = 0;
                    string[] inputlines = System.IO.File.ReadAllLines(@"..\..\..\Extra\test.txt");
                    string[] tempo = model.SideData.Place.Split(':');
                    string name = floorandwall[tempo[0].ToUpper()][0];
                    Console.WriteLine();
                    Bitmap wall = wallpng[name];
                    name = floorandwall[tempo[0].ToUpper()][1];
                    Bitmap floor = floorpng[name];

                    foreach (var line in inputlines)
                    {
                        string[] words = line.Split(' ');
                        for (var i = 0; i < words.Length; i += 2)
                        {
                            if (words[i] == "#")
                            {                   
                                g.DrawImage(wall, x, y, wall.Width, wall.Height);
                            }
                            else if (words[i] == ".")
                            {                           
                                g.DrawImage(floor, x, y, floor.Width, floor.Height);
                            }
                            else
                            {
                                
                                string nam = monsterdata[(String)(words[i] + words[i + 1]).Replace(" ", "")];
                                Bitmap mnstr = monsterPNG[nam];
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
