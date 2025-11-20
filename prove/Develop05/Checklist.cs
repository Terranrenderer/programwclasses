public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int targetCount, int bonus)
        : base(name, points, desc)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int returnReport()
    {
        _currentCount++;

        // Give regular points
        int total = Points;

        // If finished, here give the xtra
        if (_currentCount == _targetCount)
        {
            total += _bonus;
        }

        return total;
    }

    public override string returnStatus()
    {
        string box;

        if (_currentCount >= _targetCount)
        {
            box = "[X]";
        }
        else
        {
            box = "[ ]";
        }
        return $"{box} {name} — Completed {_currentCount}/{_targetCount}";
    }

    public override string goToSave()
    {
        return $"Checklist|{name}|{Desc}|{Points}|{_targetCount}|{_currentCount}|{_bonus}";
    }
}
