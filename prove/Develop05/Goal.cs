public abstract class Goal 
{
    public int _points;
    public string _title;
    public string _desc;

    public abstract bool IsDone();
    public abstract int CalcPoints();
    public abstract void Save();
    public abstract void Load();
    public abstract void Display();


}