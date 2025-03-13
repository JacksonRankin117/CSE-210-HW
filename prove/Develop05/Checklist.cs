class Checklist : Goal 
{   
    private int _bonus;
    private int _attempts;

    public override void GetDescription() 
    {
        Console.WriteLine("Write a title for this goal");
        _title = Console.ReadLine();

        Console.WriteLine("Write a short description of this goal");
        _desc = Console.ReadLine();
        
        Console.WriteLine("How many points is this goal worth?");
        _points = int.Parse(Console.ReadLine());

        Console.WriteLine("How many bonus points are rewarded upon completion?");
        _bonus = int.Parse(Console.ReadLine());

        Console.WriteLine("How many attempts will it take to complete this goal?");
        _attempts = int.Parse(Console.ReadLine());
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