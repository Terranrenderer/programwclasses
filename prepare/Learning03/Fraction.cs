class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int numerator)
    {
        _top = numerator;
        _bottom = 1;
    }
    public Fraction(int numerator, int baconator)
    {
        _top = numerator;
        _bottom = baconator;
    }
    //Getters&Setters Here?
    public int GetTop() { return _top; }
    public int GetBottom() { return _bottom; }
    public void SetTop(int value)
    {
        _top = value;
    }
    public void SetBottom(int bvalue)
    {
        _bottom = bvalue;
    }
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}