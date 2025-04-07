using System;

public class Interval
{
    public double _min { get; }
    public double _max { get; }

    public Interval(double min, double max)
    {
        _min = min;
        _max = max;
    }

    public double Size() => _max - _min;

    public bool Contains(double x) => _min <= x && x <= _max;

    public bool Surrounds(double x) => _min < x && x < _max;

    public double Clamp(double x)
    {
        if (x < _min) return _min;
        if (x > _max) return _max;
        return x;
    }

    public static readonly Interval Empty = new Interval(double.PositiveInfinity, double.NegativeInfinity);
    public static readonly Interval Universe = new Interval(double.NegativeInfinity, double.PositiveInfinity);
}
