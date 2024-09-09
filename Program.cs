using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Színkitaláló
{
    internal class Program
    {

        static int szinvalaszto()
        {
            
            string[] colors = { "blue", "red", "green", "yellow", "purple", "orange", "grey", "white" };
            List<string> chosen_colors = new List<string>();          

            int kivalasztott = 0;
            ConsoleKeyInfo lenyomott;

            do
            {
                Console.Clear();
                Console.WriteLine("Válassz egy színt: \n");


                for (int i = 0; i < colors.Length; i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine($"\t{colors[i]}");
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; break;
                    case ConsoleKey.DownArrow: if (kivalasztott < colors.Length - 1) kivalasztott++; break;
                    case ConsoleKey.Enter: if (chosen_colors.Count < 4) chosen_colors.Add(colors[kivalasztott]);  break;
                }
            } while (lenyomott.Key != ConsoleKey.Escape);

            Console.WriteLine();
            for (int i = 0; i < chosen_colors.Count; i++)
            {
                Console.WriteLine(chosen_colors[i]);
            }
            return kivalasztott;
        }


    

        static void Main(string[] args)
        {

            szinvalaszto();
                

        }
    }
}
