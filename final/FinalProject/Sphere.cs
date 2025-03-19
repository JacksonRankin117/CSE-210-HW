using System;

public class Sphere : IHittable
{
    public Vec3 Center { get; }
    public float Radius { get; }

    public Sphere(Vec3 center, float radius)
    {
        Center = center;
        Radius = radius;
    }

    public bool Hit(Ray ray, float tMin, float tMax, out HitRecord rec)
    {
        rec = new HitRecord();
        Vec3 oc = ray.Origin - Center;
        float a = Vec3.Dot(ray.Direction, ray.Direction);
        float halfB = Vec3.Dot(oc, ray.Direction);
        float c = Vec3.Dot(oc, oc) - Radius * Radius;
        float discriminant = halfB * halfB - a * c;
        
        if (discriminant < 0)
            return false;
        
        float sqrtd = (float)Math.Sqrt(discriminant);
        float root = (-halfB - sqrtd) / a;
        
        if (root < tMin || root > tMax)
        {
            root = (-halfB + sqrtd) / a;
            if (root < tMin || root > tMax)
                return false;
        }
        
        rec.T = root;
        rec.Point = ray.At(rec.T);
        rec.SetFaceNormal(ray, (rec.Point - Center) / Radius);
        
        return true;
    }
}