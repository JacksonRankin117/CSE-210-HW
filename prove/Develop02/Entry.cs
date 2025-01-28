using System;
using System.ComponentModel.DataAnnotations;

class Entry
{
    // Class Attributes
    public string _Prompt;
    public string _EntryDateTime;
    public string _EntryText;

    //
    public void Display() {
        Console.WriteLine($"{_EntryDateTime} - ");
        Console.WriteLine($"{_EntryText}");

    }

}