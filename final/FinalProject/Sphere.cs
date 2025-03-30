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
        Vec3 oc = r.Origin - center;  // Direction from ray origin to sphere center
        double a = r.Direction.LengthSquared();  // Length squared of ray direction
        double h = Vec3.Dot(r.Direction, oc);    // Dot product of ray direction and oc
        double c = oc.LengthSquared() - radius * radius; // Distance from ray origin to sphere center minus radius squared

        double discriminant = h * h - a * c;  // The discriminant of the quadratic equation
        Console.WriteLine($"Discriminant: {discriminant}");

        double sqrtd = Math.Sqrt(discriminant);  // Square root of discriminant
        double root = (h - sqrtd) / a;  // First root calculation
        Console.WriteLine($"Root 1: {root}");

        if (!rayT.Surrounds(root))
        {
            root = (h + sqrtd) / a;  // Second root calculation
            Console.WriteLine($"Root 2: {root}");

            if (!rayT.Surrounds(root))
            {
                Console.WriteLine("Both roots are outside the acceptable range.");
                return false;  // Both roots are outside the acceptable t-range
            }
        }

        rec.T = root;
        rec.P = r.At(rec.T);  // The point of intersection on the sphere
        Vec3 outwardNormal = (rec.P - center) / radius;  // Normal at the point of intersection
        rec.SetFaceNormal(r, outwardNormal);  // Determine the correct normal direction based on ray's direction
        rec.Mat = mat;  // Assign material to hit record

        Console.WriteLine($"Hit point: {rec.P}");
        return true;  // Return true if an intersection occurred
    }
}
