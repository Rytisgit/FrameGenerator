using System;

class ReadFromFile
{

    public static void read()
    {

        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"mon-data.h");
        string[] lines = System.IO.File.ReadAllLines("mon-data.h");


        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("MONS_"))
            {
                Console.WriteLine("\t" + lines[i]);


            }


        }



        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}