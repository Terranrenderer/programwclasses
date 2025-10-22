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

        string entry = Console.ReadLine();

        scripture.handleEntry(entry);

        reference.Display();
        scripture.Display();

        while (true)
        {
            string checker = Console.ReadLine();
            if (checker == "")
            {
                scripture.HideRandom();
                reference.Display();
                scripture.Display();

            }
            else if(scripture.knowHidden() == true)
            {
                break;
            } 
            else
            {
                break;
            }
        }
    }
}