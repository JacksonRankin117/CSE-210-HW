public abstract class Goal 
{
    public int _points;
    public string _title;
    public string _desc;

    public static Goal Load(string[] data)
    {
        // Checks which goal type it is.
        switch (data[0])
        {
            case "Simple": 
                return new Simple(data);
            case "Checklist": 
                return new Checklist(data);
            case "Eternal": 
                return new Eternal(data);
        }
        return null;
    }
    // Initiates a bunch of methods.
    public abstract void GetDescription();
    public abstract int CalcPoints();
    public abstract void MarkDone();
    public abstract string Save();
    public abstract string Display();
}