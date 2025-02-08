/*
Jackson Rankin
Bro. Gibbons
CSE 210
Feb 7 2025

This is the fraction class. It gets numerators and denomonators, outputs the
fraction, and the fractional value
*/

using System;
using System.Xml.XPath;

public class Fraction {
    // These are private attibutes because
    private int _numerator;
    private int _denomonator;

    public Fraction() {
        // Defualts the numerator and denomonator values so the program doesn't explode
        _numerator = 1;
        _denomonator = 1;
    }

    public Fraction(int numerator) {
        // If there is one value, the numerator is stored andthe denomonator is set at 1
        _numerator = numerator;
        _denomonator = 1;
    }

    public Fraction(int numerator, int denomonator) {
        // If there are two values, this stores them in the class attributes
        _numerator = numerator;
        _denomonator = denomonator;
    }

    public string DisplayFraction() {
        string ratio = $"{_numerator}/{_denomonator}";
        return ratio;
    }

    public double DecimalVal() {
        // Converted to doubles, because if they are left ints they will only return ints
        double result = (double)_numerator / (double)_denomonator;
        return result;
    }
}