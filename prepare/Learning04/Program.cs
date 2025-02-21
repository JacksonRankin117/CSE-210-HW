using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a MathAssignment object
        MathAssignment mathAssignment = new MathAssignment("Jackson Rankin", "Differential Equations", 5, 10);
        mathAssignment.DisplayInfo();
        mathAssignment.GetHWList();

        // Create a WritingAssignment object
        WritingAssignment writingAssignment = new WritingAssignment("Jackson Rankin", "Essay", "The Spirit World");
        writingAssignment.DisplayInfo();
        writingAssignment.GetWritingInfo();
    }
}