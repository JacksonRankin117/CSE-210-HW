/*
Jackson Rankin
Bro. Gibbons
CSE 210
Feb 7 2025

This file is meant to more or less test the Fraction class. Actually, its meant
to complete the Learning #3 activity
*/

using System;

class Program
{
    static void Main(string[] args)
    {   
        // Creates fraction objects, and displays the fraction to the console

        // Checks default
        Fraction fractionA = new Fraction();
        Console.WriteLine(fractionA.DisplayFraction());
        Console.WriteLine(fractionA.DecimalVal());

        // Tests whole number
        Fraction fractionB = new Fraction(17);
        Console.WriteLine(fractionB.DisplayFraction());
        Console.WriteLine(fractionB.DecimalVal());
        
        // Tests rational numbers with finite dgits
        Fraction fractionC = new Fraction(7, 8);
        Console.WriteLine(fractionC.DisplayFraction());
        Console.WriteLine(fractionC.DecimalVal());

        // Tests rational numbers with infinite digits
        Fraction fractionD = new Fraction(106, 39); // Good aproximation for e
        Console.WriteLine(fractionD.DisplayFraction());
        Console.WriteLine(fractionD.DecimalVal());

        /*
        The output to the console should be:

        1/1
        1
        17/1
        17
        7/8
        0.875
        106/39
        2.717948717948718

        */
        
    }
}