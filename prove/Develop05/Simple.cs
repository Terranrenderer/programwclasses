public class SimpleGoal : Goal
{
    private bool _completed = false;
    public SimpleGoal(string name, int points, string desc)
        : base(name, points, desc)
    {
        
    }
    public override int returnReport()
    {
        if (!_completed)
        {
            _completed = true;
            return Points;
        }
        return 0;
    }

    public override string returnStatus()
    {
        // could use ternary op?
        if (_completed)
            return "[X] " + name;
        else
            return "[ ] " + name;

    }
    public override string goToSave()
    {
        return $"Simple|{name}|{Desc}|{Points}|{_completed}";
    }
}