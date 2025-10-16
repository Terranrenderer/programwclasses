// Pull up the menu, ask for user input. --
// Once the choice is made, make sure conditions are being met until time to pull menu up again--
// To write, simply push it into Journal -- 
// To display, simply pull all from journal --
// To provide, grab a random prompt (handle randomizer in prompt tab) --
//Handle datetime as well as sotre it
// To quit, end program. --

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        bool _flag = true;
        Menu mainMenu = new Menu();
        Prompt mainPrompt = new Prompt();
        Journal mainJournal = new Journal();

        DateTime dtn = DateTime.Now;
        string dt = dtn.ToString("dd/MM/yyyy HH:mm");

        while (_flag == true)
        {
            mainMenu.fullMenu();
            int uzer = int.Parse(Console.ReadLine());
            if (uzer == 1)
            {
                mainJournal.appendEntry();
            }
            else if (uzer == 2)
            {
                mainJournal.Display();
                mainJournal.appendEntry();
            }
            else if (uzer == 3)
            {
                mainPrompt.getPrompt();
                mainJournal._entries.Add(mainPrompt.promptContainer);
                mainJournal.appendEntry();

            }
            else
            {
                Console.WriteLine("QUIT");
                _flag = false;
            }
        }




    }
}