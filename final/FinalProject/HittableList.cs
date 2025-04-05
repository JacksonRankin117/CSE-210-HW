using System;
using System.Collections.Generic;
using System.Security.AccessControl;

public class HittableList : Hittable
{
    private List<Hittable> objects = new List<Hittable>();

    public HittableList() { }
    public HittableList(Hittable obj) { Add(obj); }

    public void clear() { objects.Clear(); }

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
