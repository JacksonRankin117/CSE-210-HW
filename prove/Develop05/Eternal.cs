class Eternal : Goal 
{
    public Eternal() { }
    public Eternal(string[] data) { Title = data[1]; Desc = data[2]; Points = int.Parse(data[3]); }
    public override void GetDescription() 
    {
        Console.Write("Title: "); Title = Console.ReadLine();
        Console.Write("Description: "); Desc = Console.ReadLine();
        Console.Write("Points: "); Points = int.Parse(Console.ReadLine());
    }
    public override int CalcPoints() => Points;
    public override void MarkDone() {}
    public override string Save() => $"Eternal|{Title}|{Desc}|{Points}";
    public override string Display() => $"[Eternal] {Title}";
}
