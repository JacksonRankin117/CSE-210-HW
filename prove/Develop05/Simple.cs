class Simple : Goal 
{
    private int _attempts = 0;
    private Simple simple = new Simple();
    
    public override void GetDescription() 
    {
        Console.WriteLine("Write a title for this goal");
        _title = Console.ReadLine();

        Console.WriteLine("Write a short description of this goal");
        _desc = Console.ReadLine();

        Console.WriteLine("How many points is this goal worth?");
        _points = int.Parse(Console.ReadLine());
    }
    public override bool IsDone()
    {
        if (_attempts < 1) {
            return false;
        } else {
            return true;
        }
    }

    public override int CalcPoints()
    {
        if (simple.IsDone()) 
        {
            return _points;
        } else {
            return 0;
        }
    }

    public override void Save() 
    {

    }

    public override void Load() 
    {

    }

    public override void Display() 
    {

    }
}