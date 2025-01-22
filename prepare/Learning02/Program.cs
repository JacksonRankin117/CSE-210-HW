using System;

class Program
{
    static void Main(string[] args)
    {   
        // Adds details of my first job
        Job job1 = new Job();
        job1._jobTitle = "Team Member - Sales and Kitchen Design";
        job1._company = "Menards Inc.";
        job1._startYear = 2019;
        job1._endYear = 2024;

        // Adds details of my second job
        Job job2 = new Job();
        job2._jobTitle = "Observatory Operator";
        job2._company = "BYUI";
        job2._startYear = 2024;
        job2._endYear = 2025;

        // Creates a resume
        Resume myResume = new Resume();
        myResume._name = "Jackson Rankin";

        // Adds my jobs to it
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Displays my resume to the console
        myResume.Display();

    }
}