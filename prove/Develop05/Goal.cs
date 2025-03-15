public abstract class Goal 
{
    public int Points;
    public string Title;
    public string Desc;
    public abstract void GetDescription();
    public abstract int CalcPoints();
    public abstract void MarkDone();
    public abstract string Save();
    public static Goal Load(string[] data)
    {
        switch (data[0])
        {
            case "Simple": return new Simple(data);
            case "Checklist": return new Checklist(data);
            case "Eternal": return new Eternal(data);
        }
        return null;
    }
    public abstract string Display();
}