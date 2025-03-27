using FHTechnikum;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;


namespace ZooManager
{
    internal class Program
    {
        const string PATH = @"..\\..\\..\\ZooManager.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("dope");
            int n = -1;
            Console.WriteLine("wv werte im array ?: ");
            TryParseToInt(ref n);

            bool isLoop = true;
            int userinput = -1;
            CZooManager manager1 = new CZooManager(n) { Number=n};
            CZooManager manager2 = new CZooManager(n) { Number = n };
            Random rm = new Random();
            float randomfloat = 0.0f;

            FillInValues(rm, manager1, manager1.Number, ref randomfloat);
            FillInValues(rm, manager2, manager2.Number, ref randomfloat);

            Console.WriteLine();
            Console.WriteLine("ZooManager1:");
            WriteFloatValues(manager1);
            Console.WriteLine();
            Console.WriteLine("zooManager2:");
            WriteFloatValues(manager2);
            string jsonobject = "";
            SerializeJson(manager1, ref jsonobject);
            WritetoFileSerializedObj(PATH, jsonobject);
            //string jsonobj3 = @"{ ""Number"": 3,""Values"": [0.0,0.0,0.0]}";
            
            
            CZooManager manager3 = new CZooManager(n) { Number=n};
            manager3 = DesiralizeJson(PATH);

            Console.WriteLine(manager3.ToString());

            for (int i = 0; i < manager3.Values.Length; i++)
            {
                Console.WriteLine(manager3.Values[i]);
            }

            printMenu();

            float max = 0.0f;
            while (isLoop)
                {
                Console.WriteLine("Gib mal was vom Menu ein: ");
                TryParseToInt(ref userinput);
                switch (userinput)
                {
                    case 0:
                        Console.WriteLine("Programm is going to shutdown");
                        Environment.Exit(0);
                        break;
                   
                    case 3:
                        CZooManager.Print(manager1.Values);
                        break;

                    case 5:
                        CZooManager.Clear(manager1.Values);
                        CZooManager.Clear(manager2.Values);
                        break;
                    case 6:
                        CZooManager.Avg(manager1.Values);
                        break;
                    case 7:
                        CZooManager.Avg(manager2.Values);
                            break;
                    case 8:
                        max =  CZooManager.b_of_max_a(manager1.Values, manager2.Values);
                        Console.WriteLine("Von array 1 größter wert, nehme den index und gebe dann array2[index] aus: " + max);
                        break;
                    case 9:
                        
                        max = CZooManager.b_of_max_a(manager2.Values, manager1.Values);
                        Console.WriteLine("Von array 2 größter wert, nehme den index und gebe dann array1[index] aus: " + max);
                        break;
                    case 10:
                        SerializeJson(manager1, ref jsonobject);
                        Console.WriteLine("Manager 1 saved!");
                        break;

                    default:
                        continue;
                }
            }
        }

        public static void WritetoFileSerializedObj(string path, string jsonobj)
        {
            bool fileExits = File.Exists(path);
            if (fileExits && jsonobj != null)
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(jsonobj);
                    }
                }
            }
            else
            {
                using (FileStream fs = new FileStream(path,FileMode.Create,FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(jsonobj);
                    }
                }
            }
        }
        public static void ReadFromFile(string path)
        {
            if (path != null && path.Length > 0)
            {
                bool fileExits = File.Exists(path);
                if (fileExits)
                {
                     FileInfo fi = new FileInfo(path);
                    //Use libraries: For more accurate results, you can use external libraries
                    //    like MimeDetective to determine the file's type based on its content.
                }
            }
        }
        public static void FillInValues(Random rm, CZooManager manager, int n, ref float randomfloat)
        {
            for (int i = 0; i < n; i++)
            {
                manager.Values[i] = RandomManagerFloat(rm,randomfloat);
            }
        }
        public static void WriteFloatValues(CZooManager manager)
        {
            for (int i = 0; i < manager.Values.Length; i++)
            {
                Console.WriteLine($"Wert mit index{i}: {manager.Values[i]}");
            }
        }

        public static float RandomManagerFloat(Random rm, float randomfloat)
        {
            randomfloat = (float)rm.NextDouble() * 100.0f;
            return randomfloat;
        }
        public static void TryParseToInt(ref int userinput)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                userinput = result;
                Console.WriteLine("Got the right number");
                
            }
            else
            {
                throw new ArgumentException("Nah man gimme one of the integers given");
            }
        }


        public static void SerializeJson(CZooManager manager, ref string json)
        {
            json = JsonSerializer.Serialize(manager);
        }
        public static CZooManager DesiralizeJson(string path)
        {
            bool fileExits = File.Exists(path);
            if (!fileExits)
            {
                throw new Exception("File does not exists");
            }
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<CZooManager?>(json) ?? throw new Exception("Desierialization not possible");
            
        }
        public static void printMenu()
        {

           Console.Write("-------------------------\n");
           Console.Write("1: Gewicht erfassen\n");
           Console.Write("2: Groesze erfassen\n");
           Console.Write("3: Ausgeben\n");
           Console.Write("4: Angaben pruefen\n");
           Console.Write("5: Loeschen\n");
           Console.Write("6: Durchschn. Gewicht\n");
           Console.Write("7: Durchschn. Groesze\n");
           Console.Write("8: Groesze des Schwersten\n");
           Console.Write("9: Gewicht des Groesten\n");
           Console.Write("10: Speichern des 1 Objektes\n");
           Console.Write("0: Beenden\n");
           Console.Write("-------------------------\n");
        }



       
    }
}
