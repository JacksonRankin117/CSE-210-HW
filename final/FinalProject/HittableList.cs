using System;
using System.Collections.Generic;
using System.Security.AccessControl;

public class HittableList : Hittable
{
    private List<Hittable> _objects = new List<Hittable>();

    public HittableList() { }
    public HittableList(Hittable obj) { Add(obj); }

    public void clear() { _objects.Clear(); }

    public void Add(Hittable obj)
    {
        _objects.Add(obj);
    }

    public bool Hit(Ray r, Interval rayT, out HitRecord rec)
    {
        rec = default;
        bool hitAnything = false;
        double closestSoFar = rayT._max;

        foreach (Hittable obj in _objects)
        {
            if (obj.Hit(r, new Interval(rayT._min, closestSoFar), out HitRecord tempRec)) {
                hitAnything = true;
                closestSoFar = tempRec._t;
                rec = tempRec;
            }
        }
        return hitAnything;
    }
}
