using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szinozon
{
    internal class Program
    {
        public string[] colors = { "blue", "red", "green", "yellow", "purple", "orange", "grey", "white" };
        static string[] answer(string[] colors)
        {
            Random rnd = new Random();
            string[] answers = new string[4];
            for (int i = 0; i < 4; i++)
            {
                string color = colors[rnd.Next(0,8)];
                answers[i] = color;
            }
            /*for (int i = 0;i < 4; i++)
            {
                Console.WriteLine(answers[i]);
            }*/
            return answers;
        }
        static int szinvalaszto()
        {
            List<string> chosen_colors = new List<string>();
            string[] colors = { "blue", "red", "green", "yellow", "purple", "orange", "grey", "white" };
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
                    case ConsoleKey.L:
                        check(colors); break;
                }
            } while (lenyomott.Key != ConsoleKey.Escape);

            Console.WriteLine();
            for (int i = 0; i < chosen_colors.Count; i++)
            {
                Console.WriteLine(chosen_colors[i]);
            }
            return kivalasztott;
        }
        static void check(string[] colors)
        {
            string[] answers = answer(colors);
            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine(answers[i]);
            }
        }

        static void Main(string[] args)
        {
            // answer();
            szinvalaszto();
            
        }
    }
}
