using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Net;

class Program
{
    static void Main(string[] args)
    {   
        bool flag = true;

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,100);

        Console.Write("Guess ");

        while (flag == true)
        {
            Console.Write("");
            int response = int.Parse(Console.ReadLine());

            if (number < response)
                Console.Write("Lower ");
            else if (number > response)
                Console.Write("Higher ");
            else
            {
                Console.Write("CONGRATZ");
                flag = false;
            }
        }
    }
}