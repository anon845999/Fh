using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FHTechnikum
{
    [Serializable]
    public class CZooManager //<t>
    {
        // public t Test { get; set; }
        
        public required int Number { get; set; }

        public float[] Values { get; set; } //mal nur mit länge


        //  public int MyProperty { get; set; }

        
        public CZooManager(int number)
        {
            if(number != 0)
            {
                this.Number = number;
                Values = new float[number];
            }else
            {
                throw new ArgumentException("Gimme a number");
            }
        }
        public static int Read(int switchvalue)
        {
            //            Liest von der Console ein und speichert diese im Array values.Nach Eingabe einer 0 oder wenn
            //values vollständig befüllt ist endet die Eingabe.Vor jeder Eingabe wird v: als Eingabeaufforderung
            //ausgegeben.
            return switchvalue;
        }
        public static void Print(float[] values)
        {
            //            Gibt values in der selben Zeile, % .2f - Formatiert, innnerhalb von geschwungenen Klammern { },
            //durch Leerzeichen getrennt aus.
            //Bsp: { 1.00 2.00 4.00 }
            //            Ein Zeilenumbruch ist weder am Anfang, noch am Ende notwendig.
            //Die Ausgabe wird beendet, wenn 0 gefunden wurde oder values vollständig ausgegeben wurde.

            if(values != null && values.Length > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine($" Wert: {values[i]:F2}");
                }
            }

            

        }
        public static int Count(float[] values)
        {
            //Zählt die Anzahl der Werte in values, bis entweder 0 gefunden wurde, oder das Ende erreicht wurde.
            int counter = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > 0.0f)
                {
                    counter++;
                }
            }
            return 0;
        }

        public static void Clear(float[] values)
        {
            //Setzt alle Werte in dem Array values auf 0.
            if(values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = 0.0f;
                }
            }
            
        }
        public static float Avg(float[] values)
        {
           // Berechnet den Durchschnitt aller Werte, bis entweder 0 gefunden wurde, oder das Ende erreicht wurde.

            float sum = 0.0f;
            float avg = 0.0f;
            int counts = 0;
            if(values != null && values.Length > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == 0.0f)
                    {
                        break;
                    }
                
                }
                if(counts > 0)
                {
                    avg = sum / counts;
                    return avg; // return sum / counts;
                }
            }
            return 0.0f;
        }
        public static float b_of_max_a(float[] a, float[] b)
        {
            //            Übergeben werden zwei Arrays a und b.
            //Die Funktion sucht den ersten Index des höchsten Wertes in a.Der Rückgabewert ist der Wert im
            //Array b an dem gefundenen Index.
            //In beiden Arrays befinden sich die selbe Anzahl an Werten. Sind beide Arrays leer, wird -1 zurück
            //gegeben.
            if (a.Length == b.Length)
            {
                float max = 0.0f;
                int indexofmax_a = 0;
                //get me the greatest value of the a array and put it into max and of course the index of max value in array!!!
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        indexofmax_a = i;
                    }
                }
                //return the index
                return b[indexofmax_a];
                ////get me the index of 
                //for (int i = 0; i < a.Length-1; i++)
                //{
                //    if (a[i] == max)
                //    {
                //        index = i;
                //    }
                //}
            }
            else
            {
                return -1.0f;
            }

        }
       
    }
}
