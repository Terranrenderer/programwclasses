using System;
using System.ComponentModel.DataAnnotations;
using System.Formats.Tar;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference();
        Scripture scripture = new Scripture();
        Word word = new Word("");

        Console.WriteLine("Type a reference");
        string refEntry = Console.ReadLine();
        reference.handleRefEntry(refEntry);
        
        Console.WriteLine("Type a scripture to begin");
        string entry = Console.ReadLine();

        scripture.handleEntry(entry);

        reference.Display();
        scripture.Display();

        while (true)
        {
            while (scripture.knowHidden() == false)
            {
                string checker = Console.ReadLine();
                if (checker == "")
                {
                    Console.Clear();
                    scripture.HideRandom();
                    reference.Display();
                    scripture.Display();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("OK");
            break;
        }
    } 
}