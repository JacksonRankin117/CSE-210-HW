class Checklist : Goal 
{   
    private int Attempts;
    private int Bonus;
    private int RequiredAttempts;
    public Checklist() { }
    public Checklist(string[] data)
    {
        Title = data[1];
        Desc = data[2];
        Points = int.Parse(data[3]);
        Bonus = int.Parse(data[4]);
        Attempts = int.Parse(data[5]);
        RequiredAttempts = int.Parse(data[6]);
    }
    public override void GetDescription() 
    {
        Console.Write("Title: "); Title = Console.ReadLine();
        Console.Write("Description: "); Desc = Console.ReadLine();
        Console.Write("Points: "); Points = int.Parse(Console.ReadLine());
        Console.Write("Bonus: "); Bonus = int.Parse(Console.ReadLine());
        Console.Write("Attempts required: "); RequiredAttempts = int.Parse(Console.ReadLine());
    }
    public override int CalcPoints() => Attempts >= RequiredAttempts ? Points + Bonus : Points;
    public override void MarkDone() { Attempts++; }
    public override string Save() => $"Checklist|{Title}|{Desc}|{Points}|{Bonus}|{Attempts}|{RequiredAttempts}";
    public override string Display() => $"[Checklist] {Title} ({Attempts}/{RequiredAttempts} done)";
}