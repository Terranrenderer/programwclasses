using System;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        bool flag = true;
        List<int> numbers = new List<int>();

        while (flag == true)
        {
            Console.WriteLine("Enter Number");
            int response = int.Parse(Console.ReadLine());

            if (response == 0)
            {
                flag = false;
            }
            else
            {
                numbers.Add(response);
            }
        }
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine($"\nSum : {sum}");
        Console.WriteLine($"Average: {(double)sum / numbers.Count:F2}");
    }
}