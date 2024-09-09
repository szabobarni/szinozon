using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szinozon
{
    internal class Program
    {
        static void answer()
        {
            Random rnd = new Random();
            string[] colors = {"blue","red","green","yellow","purple","orange","grey" ,"white"};
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
        }
        static void Main(string[] args)
        {
            answer();
        }
    }
}
