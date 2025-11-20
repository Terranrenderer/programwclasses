public abstract class Goal
{
    private string _name;
    private int _points;
    private string _desc;
    public Goal(string name, int points, string desc)
    {
        _name = name;
        _points = points;
        _desc = desc;
    }
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }
    public string Desc
    {
        get { return _desc; }
        set { _desc = value; }
    }

    public abstract int returnReport();
    public abstract string returnStatus();
    public abstract string goToSave();
}