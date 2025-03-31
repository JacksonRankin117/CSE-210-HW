using System;
using System.Collections.Generic;

public class HittableList : Hittable  // Fixed: Implementing interface
{
    private List<Hittable> objects = new List<Hittable>(); // Fixed: Correct list type

    public HittableList() { }
    public HittableList(Hittable obj) { Add(obj); }

    public void Add(Hittable obj)
    {
        objects.Add(obj);
    }

    public bool Hit(Ray r, Interval rayT, out HitRecord rec)
    {
        rec = default;
        bool hitAnything = false;
        double closestSoFar = rayT.Max;

        foreach (Hittable obj in objects)
        {
            if (obj.Hit(r, new Interval(rayT.Min, closestSoFar), out HitRecord tempRec)) {
                hitAnything = true;
                closestSoFar = tempRec.T;
                rec = tempRec;
            }
        }
        return hitAnything;
    }
}

public struct Bounds  // Changed from Interval to avoid conflicts
{
    public double Min { get; }
    public double Max { get; }

    public Bounds(double min, double max)
    {
        Min = min;
        Max = max;
    }
}
