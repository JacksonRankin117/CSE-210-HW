using System.Collections.Generic;

public class HittableList : IHittable
{
    private List<IHittable> Objects = new List<IHittable>();

    public void Add(IHittable obj) => Objects.Add(obj);
    public void Clear() => Objects.Clear();

    public bool Hit(Ray ray, float tMin, float tMax, out HitRecord rec)
    {
        rec = new HitRecord();
        bool hitAnything = false;
        float closestSoFar = tMax;

        foreach (var obj in Objects)
        {
            if (obj.Hit(ray, tMin, closestSoFar, out HitRecord tempRec))
            {
                hitAnything = true;
                closestSoFar = tempRec.T;
                rec = tempRec;
            }
        }

        return hitAnything;
    }
}
