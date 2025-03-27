using System;
using System.IO;
using System.Linq;



namespace PartyHandshake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Queue<CPerson> personQueue = new Queue<CPerson>();
            EnquePeople(personQueue);
            DequePeople(personQueue);
            DequePeople(personQueue);

          
        }

        public static void EnquePeople(Queue<CPerson> personQueue)
        {
            int participants;
            while (true)
            {
                Console.WriteLine("wv leit sind auf der Party?: ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result <= 10)
                    {
                        participants = result;
                        break;
                    }
                }
                else
                {
                    throw new ArgumentException("NENENENENE nur zahlen, mach ma vielleicht maximal 10 Personen!");
                }
            }
            string name = "";
            int age = 0;
            int validcounter = 1;
            while (validcounter <= participants)
            {
                Console.WriteLine("Gib mal den Namen ein: ");
                name = Console.ReadLine();

                Console.WriteLine("Gib mal das alter ein: ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    age = result;
                    if (name != null)
                        personQueue.Enqueue(new CPerson(name, age));
                    validcounter++;
                    Console.WriteLine("Nächste Person :D");
                }
                else
                {
                    throw new ArgumentException("nahh not valid Alter");
                }
            }
        }

        public static void DequePeople(Queue<CPerson> personQueue)
        {
            CPerson p;
            if (personQueue == null || personQueue.Count == 0)
            {
                throw new ArgumentException("Liste is null");
            }
            else
            {
                p = personQueue.Peek();
            }
            foreach (var item in personQueue)
            {
                if (item.Equals(p))
                {
                    continue;
                }else
                {
                    Console.WriteLine($"{p.Name} verabschiedet sich von {item.Name}");
                }
            }
            if(personQueue != null || personQueue.Count != 0)
            {
                personQueue.Dequeue();
            }else
            {
                throw new ArgumentException("niemand in der liste oder null");
            }
        }
    }
}
