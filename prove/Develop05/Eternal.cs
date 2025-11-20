public class EternalGoal : Goal
{
    public EternalGoal(string name, int points, string desc)
        : base(name, points, desc)
    {
        
    }

    public override int returnReport()
    {
        return Points;
    }

    public override string returnStatus()
    {
        return $"[YUH] {name}";
    }
    public override string goToSave()
    {
        return $"Eternal {name}|{Desc}|{Points}";
    }
}