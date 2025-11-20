public class Menu
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void ShowMenu()
    {
        Console.WriteLine("\n--- Eternal Quest Menu ---");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Record Event");
        Console.WriteLine("4. Save Goals");
        Console.WriteLine("5. Load Goals");
        Console.WriteLine("6. Show Score");
        Console.WriteLine("7. Quit");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose goal type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");

        int choice = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            _goals.Add(new SimpleGoal(name, points, desc));
        }
        else if (choice == 2)
        {
            _goals.Add(new EternalGoal(name, points, desc));
        }
        else if (choice == 3)
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\n--- Goals ---");

        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.returnStatus()}");
            i++;
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.WriteLine("\nWhich goal did you finish?");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].returnReport();
        _score += earned;

        Console.WriteLine($"\nYou earned {earned} points!");
    }

    public void SaveGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.goToSave());
            }
        }

        Console.WriteLine("Saved!");
    }

    public void LoadGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        _goals.Clear();

        foreach (string line in File.ReadAllLines(file))
        {
            string[] parts = line.Split('|');

            if (parts.Length == 1)
            {
                _score = int.Parse(parts[0]);
            }
            else
            {
                string type = parts[0];
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                if (type == "Simple")
                {
                    bool done = bool.Parse(parts[4]);
                    var g = new SimpleGoal(name, points, desc);
                    if (done)
                        g.goToSave(); 
                    _goals.Add(g);
                }
                else if (type == "Eternal")
                {
                    _goals.Add(new EternalGoal(name, points, desc));
                }
                else if (type == "Checklist")
                {
                    int target = int.Parse(parts[4]);
                    int current = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);

                    ChecklistGoal g = new ChecklistGoal(name, desc, points, target, bonus);

                    // simulate completions
                    for (int i = 0; i < current; i++)
                        g.goToSave();

                    _goals.Add(g);
                }
            }
        }

        Console.WriteLine("Loaded!");
    }

    public void ShowScore()
    {
        Console.WriteLine($"\nCurrent Score: {_score}");
    }
}
