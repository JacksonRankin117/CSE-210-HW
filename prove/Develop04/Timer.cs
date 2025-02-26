using System;

class Timer{
    public void DisplayLoadingIcon(int duration)
    {
        string[] loadingIcons = { "|", "/", "-", "\\" };
        int index = 0;

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write(loadingIcons[index]);
            index = (index + 1) % loadingIcons.Length;
            System.Threading.Thread.Sleep(250);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        Console.WriteLine();
    }
}