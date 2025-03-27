using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace BeSprache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine();
            Console.WriteLine();

            Dozemagic();
        }

        public static void Dozemagic()
        {
            Console.WriteLine("Gib mal einen Text ein: ");
            string inputfromuser = Console.ReadLine();
            string texttolower = MyToLower(inputfromuser);
            string translatedtext = translate(texttolower);

            Console.WriteLine(texttolower);
            Console.WriteLine(translatedtext);
        }

        public static string MyToLower(string text)
        {
            return text.ToLower();
        }

        public static string translate(string txt)
        {
          

            char[] chars = { 'a', 'e', 'i', 'o', 'u', 'ä', 'ö', 'ü' };
            //foreach (char item in txt)
            //{
                
            //}
            string BeSprache = "";
            string result = "";
            char letter;
            for (int i = 0; i < txt.Length; i++)
            {
                string position = txt.Substring(i, 1);
                letter = char.Parse(position);
                if(chars.Contains(letter))
                {
                    result = letter + "b" + letter;
                }
                else
                {
                    if (!chars.Contains(letter))
                    {
                        result = position;
                    }
                    
                
                }
                BeSprache += result;
                
            }
            return BeSprache;
        }
    }
}
