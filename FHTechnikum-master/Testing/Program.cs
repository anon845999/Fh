using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;


namespace Testing
{    internal class Program
    {

        const String CPATH = @"..\\..\\..\\loremipsum.txt";
        public static async Task Main(string[] args)
        {
            // Zusätzliche Ausgabe vor der Run-Methode
            Console.WriteLine("Vor den Zufallszahlen!");

            // Aufruf von Run, um die zufälligen Zahlen auszugeben
            var Task =  Run();

            // Weitere Ausgabe nach der Run-Methode
            Console.WriteLine("Nach den Zufallszahlen!");

            readingFiles();

            await Task;

            

        }

        public static void Printype<T>(T input,T output, ref bool isWhat)
        {
         
            if(input is string)
            {
                Console.WriteLine("input is a string");
            }

            if(input is double)
            {
                Console.WriteLine("input is a double");
            }
            if(input is int)
            {
                Console.WriteLine("input is an int");
            }
            if(input is float)
            {
                Console.WriteLine("input is a float");
            }
        }

        public static async Task Run()
        {
            
            Random rm = new();


            var f = await Asynctest(rm);

            List<string> newList = new(f);

            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
        }
        public static async Task<List<string>> Asynctest(Random rm)
        {

            List<string> liste = new();
            string randomstring;
            for (int i = 0; i < 100; i++)
            {
                randomstring = FillingWithStrings(rm);
                liste.Add(randomstring);
                await Task.Delay(1000);
            }
            return liste;

        }

        public static string FillingWithStrings(Random rm)
        {
            string randomstring = rm.Next(0, 200).ToString();
           // string randomstring = rm.Next(0, 200) + "";  
            return randomstring;

        }

        public static void readingFiles()
        {
            List<string> textfromfileliste = new();

            bool fileExisted = File.Exists(CPATH);
            using (FileStream fs = new FileStream(CPATH,FileMode.OpenOrCreate,FileAccess.ReadWrite))
            {
                if (!fileExisted)
                {
                    Console.WriteLine("File has been created");
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("Create mal paar loremipsum texte :DD");
                    }
                }
                else
                {
                    Console.WriteLine("File already exists!");
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string txt;
                        while (!sr.EndOfStream)
                        {
                            txt = sr.ReadLine();
                            if(txt != null)
                            {
                                textfromfileliste.Add(txt);
                            }
                           
                        }
                    }
                }
                    
            }
            if(textfromfileliste != null){

                var test = from t in textfromfileliste
                           where t.Contains('a')
                           select t.Count();


                foreach (var item in textfromfileliste)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("number of how many a´s ");
                foreach (var item in test)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
