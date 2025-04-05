public class Sphere : Hittable
{
    private readonly Vec3 center;
    private readonly double radius;
    private readonly Material mat;

    public Sphere(Vec3 center, double radius, Material mat)
    {
        this.center = center;
        this.radius = Math.Max(0, radius); // Ensure the radius is non-negative
        this.mat = mat;
    }

    public bool Hit(Ray r, Interval ray_t, out HitRecord rec)
    {
        rec = new HitRecord();

        Vec3 oc = r.Origin - center;  // Vector from ray origin to sphere center
        double a = r.Direction.LengthSquared();  // Direction squared
        double b = 2.0 * Vec3.Dot(oc, r.Direction);  // Standard quadratic equation term
        double c = oc.LengthSquared() - radius * radius;  // Sphere equation

        double discriminant = b * b - 4 * a * c;  // Quadratic discriminant
        if (discriminant < 0)  // If the discriminant is negative, no intersection
        {
            return false;
        }

        double sqrtd = Math.Sqrt(discriminant);
        double root = (-b - sqrtd) / (2.0 * a);  // Closest root
        
        if (!ray_t.Contains(root))  // Check if root is within the bounds
        {
            root = (-b + sqrtd) / (2.0 * a);  // Try the second root
            if (!ray_t.Contains(root))  // If it's also out of bounds, no hit
            {
                return false;
            }
        }

        // Set the hit record
        rec.T = root;
        rec.P = r.At(rec.T);  // Calculate intersection point
        Vec3 outwardNormal = (rec.P - center) / radius;  // Compute normal
        rec.SetFaceNormal(r, outwardNormal);  // Adjust normal based on ray direction
        rec.Mat = mat;  // Assign material

        return true;
    }
}
