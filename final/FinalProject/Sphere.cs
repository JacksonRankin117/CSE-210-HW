using System;

public class Sphere : HittableList
{
    private readonly Vec3 center;
    private readonly double radius;
    private readonly Material mat;

    public Sphere(Vec3 center, double radius, Material mat)
    {
        this.center = center;
        this.radius = Math.Max(0, radius);
        this.mat = mat;
    }

    public bool Hit(Ray r, Interval rayT, out HitRecord rec)
    {
        rec = new HitRecord();
        Vec3 oc = center - r.Origin;
        double a = r.Direction.LengthSquared();
        double h = Vec3.Dot(r.Direction, oc);
        double c = oc.LengthSquared() - radius * radius;

        double discriminant = h * h - a * c;
        if (discriminant < 0)
            return false;

        double sqrtd = Math.Sqrt(discriminant);

        // Find the nearest root that lies in the acceptable range.
        double root = (h - sqrtd) / a;
        if (!rayT.Surrounds(root))
        {
            root = (h + sqrtd) / a;
            if (!rayT.Surrounds(root))
                return false;
        }

        rec.T = root;
        rec.P = r.At(rec.T);
        Vec3 outwardNormal = (rec.P - center) / radius;
        rec.SetFaceNormal(r, outwardNormal);
        rec.Mat = mat;

        return true;
    }
}
