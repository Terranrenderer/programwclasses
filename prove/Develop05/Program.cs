class Program
{
    static void Main(string[] args)
    {
        Menu fullMenu = new Menu();
        bool running = true;

        while (running)
        {
            fullMenu.ShowMenu();
            Console.Write("\nChoose an option: ");
            int choice = int.Parse(Console.ReadLine());

            // I tried to use switch here, not something ive done before but I think it works.
            switch (choice)
            {
                case 1: fullMenu.CreateGoal(); break;
                case 2: fullMenu.ListGoals(); break;
                case 3: fullMenu.RecordEvent(); break;
                case 4: fullMenu.SaveGoals(); break;
                case 5: fullMenu.LoadGoals(); break;
                case 6: fullMenu.ShowScore(); break;
                case 7: running = false; break;
            }
        }
    }
}
