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
        //static List<string> chosen_colors = new List<string>();

        static List<string> start()
        {
            Console.Clear();
            Random rnd = new Random();
            List<string> chosen_colors = new List<string>();

            Console.Write("Összes szín: ");
            for (int i = 0; i < colors.Length; i++)
            {
                Console.Write(colors[i] + "; ");
            }
            Console.WriteLine();
            Console.Write("Válassz hány színt kelljen kitalálni: ");
            int hany = int.Parse(Console.ReadLine());

            for (int i = 0; i < hany; i++)
            {
                chosen_colors.Add(colors[rnd.Next(0, 8)]);
            }
            return chosen_colors;
        }

        static void guesser()
        {
            List<string> chosen_colors = start();

            bool win = false;

            while (!win)
            {
                List<string> guessed_colors = new List<string>();
                int pontok = 0;
                int k = 0;

                while (k != chosen_colors.Count)
                {
                    Console.Write($"Add meg a(z) {k + 1}. színt: ");
                    string num = Console.ReadLine();
                    guessed_colors.Add(num);
                    k++;
                }

                for (int i = 0; i < chosen_colors.Count; i++)
                {
                    if (chosen_colors.Contains(guessed_colors[i]))
                    {
                        if (guessed_colors[i] == chosen_colors[i])
                        {
                            Console.WriteLine($"{i + 1}. színt eltaláltad");
                            pontok++;
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}. szín benne van, csak rossz helyen");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. szín nem talált");
                    }
                }

                if (pontok == chosen_colors.Count)
                {
                    win = true;
                    ujjatek();
                }
            }
        }

        static void ujjatek()
        {
            Console.Clear();

            int kivalasztott = 0;
            ConsoleKeyInfo lenyomott;
            string[] opcio = { "Új játék", "Kilépés" };

            do
            {
                Console.Clear();
                Console.WriteLine("Nyertél");
                Console.WriteLine("Válassz az alábbiak kozül: \n");


                for (int i = 0; i < opcio.Length; i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine($"\t{opcio[i]}");
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; break;
                    case ConsoleKey.DownArrow: if (kivalasztott < opcio.Length - 1) kivalasztott++; break;
                }
            } while (lenyomott.Key != ConsoleKey.Enter);
            if (kivalasztott == 0)
            {
                start();
                guesser();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Viszlát");
            }
        }

        static void Main(string[] args)
        {
            guesser();
        }
    }
}