using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;



Console.WriteLine();
Console.WriteLine();

float[] numbers = new float[16];

try
{
    //float number;
    string sNumber;
    float result;
    bool loop = true;
    int validCounter = 0;
    float avgNumber = 0.0f;
    float[] floatarray = new float[16];
    while (validCounter < 17)
    {
        Console.WriteLine("Gib mal Wert ein: ");
        sNumber = Console.ReadLine();

        if (float.TryParse(sNumber, out float number)){
            Console.WriteLine($"Successfully parsed: {number}");
            result = number;
        }
        else
        {
            Console.WriteLine("put in an number");
        }
        if (number < 0)
        {
            if (number < -100)
            {
                number = -100f;
            }
            else
            {
                floatarray[validCounter] = number;
            }
            validCounter++;
        }
        else
            continue;
    }


    while (true)
    {
        Console.WriteLine("enter n from last to first, so you get the avg of it: ");
        if (int.TryParse(Console.ReadLine(), out int resultn))
        {
            if (resultn < 1 || resultn > floatarray.Length)
            {
                Console.WriteLine("Successfully parsed");
                //int helper = 
                //for (int i = floatarray.Length-1; i < length; i--)
                //{

                //}
            }
        }
        else
        {
            throw new ArgumentException("Nahh man gimme an integer ");
           // continue;
        }
    }
   
        



}
catch (Exception)
{

    throw new ArgumentException("Nahh man");
}
