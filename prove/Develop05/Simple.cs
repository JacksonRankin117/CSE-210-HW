class Simple : Goal 
{
    private bool IsCompleted = false;

    public Simple() { }
    public Simple(string[] data)
    {
        Title = data[1];
        Desc = data[2];
        Points = int.Parse(data[3]);
        IsCompleted = bool.Parse(data[4]);
    }
    public override void GetDescription() 
    {
        Console.Write("Title: ");
        Title = Console.ReadLine();
        Console.Write("Description: ");
        Desc = Console.ReadLine();
        Console.Write("Points: ");
        Points = int.Parse(Console.ReadLine());
    }
    public override int CalcPoints() => IsCompleted ? 0 : Points;
    public override void MarkDone() => IsCompleted = true;
    public override string Save() => $"Simple|{Title}|{Desc}|{Points}|{IsCompleted}";
    public override string Display() => $"[Simple] {Title} - {(IsCompleted ? "Completed" : "Not Done")}";
}