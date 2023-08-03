public class Score
{
    private string _name;
    private int _points;

    public string Name { get { return _name; } }
    public int Points { get { return _points; } }
    public Score(string name, int score)
    {
        _name = name;
        _points = score;
    }
}
