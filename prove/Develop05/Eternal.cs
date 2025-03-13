class Eternal : Goal 
{   

    public override void GetDescription() 
    {
        Console.WriteLine("How many points is this goal worth?");
        _points = int.Parse(Console.ReadLine());

        Console.WriteLine("Write a title for this goal");
        _title = Console.ReadLine();

        Console.WriteLine("Write a short description of this goal");
        _desc = Console.ReadLine();
    }
    public override bool IsDone()
    {
        return false;
    }

    public override int CalcPoints()
    {
        return _points;
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