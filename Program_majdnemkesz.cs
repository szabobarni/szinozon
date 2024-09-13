using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Színkitaláló
{
    internal class Program
    {

        static string[] colors = { "blue", "red", "green", "yellow", "purple", "orange", "grey", "white" };
        static List<string> chosen_colors = new List<string>();

        static void start()
        {
            Random rnd = new Random();

            Console.Write("Összes szín: ");
            for (int i = 0; i < colors.Length; i++)
            {
                Console.Write(colors[i]+"; ");
            }
            Console.WriteLine();
            Console.Write("Válassz hány színt kelljen kitalálni: ");
            int hany = int.Parse(Console.ReadLine());

            for (int i = 0; i < hany; i++)
            {
                chosen_colors.Add(colors[rnd.Next(0,8)]);
            }
            /*
            for (int i = 0; i < chosen_colors.Count; i++)
            {
                Console.WriteLine(chosen_colors[i]);
            }*/
        }
        static int szinvalaszto()
        {

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
                    case ConsoleKey.Enter: if (chosen_colors.Count < 4) chosen_colors.Add(colors[kivalasztott]); break;
                }
            } while (lenyomott.Key != ConsoleKey.Escape);



            Console.SetCursorPosition(0, 9);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            return kivalasztott;
        }

        static void guesser()
        {
            
            for (int i = 0; i < chosen_colors.Count; i++)
            {
                Console.WriteLine(chosen_colors[i] + " ");
            }
          
            /*
            Console.WriteLine();
            for (int i = 0; i < chosen_colors.Count; i++)
            {
                Console.Write(i + " ");
            }*/

            List<string> guessed_colors = new List<string>();

            
            /*
            for (int i = 0; i < guessed_colors.Count; i++)
            {
                Console.Write(guessed_colors[i]+" ");
            }
            Console.WriteLine();
            for (int i = 0; i < chosen_colors.Count; i++)
            {
                Console.Write(chosen_colors[i]+" ");
            }*/
            bool win = false;
            while (win != true)
            {
                int k = 0;
                while (k != chosen_colors.Count)
                {
                    
                    Console.Write($"Add meg a(z) {k+1}. színt: ");
                    string num = Console.ReadLine();
                    guessed_colors.Add(num);
                    k++;

                    
                }
                
                for (int i = 0; i < chosen_colors.Count; i++)
                {
                    if (guessed_colors[i] == chosen_colors[i])
                    {
                        Console.WriteLine($"{i+1}. színt eltaláltad");
                    }
                    else
                    {
                        Console.WriteLine($"{i+1}. szín nem talált");
                    }
                    
                }
                
                guessed_colors.Clear();



            }




        }



        static void Main(string[] args)
        {
            start();
            //szinvalaszto();
            guesser();


        }
    }
}