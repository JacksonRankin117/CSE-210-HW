public class Sphere : Hittable
{
    private readonly Vec3 _center;
    private readonly double _radius;
    private readonly Material _mat;

    public Sphere(Vec3 center, double radius, Material mat)
    {
        this._center = center;
        this._radius = Math.Max(0, radius); // Ensure the radius is non-negative
        this._mat = mat;
    }

    public bool Hit(Ray r, Interval ray_t, out HitRecord rec)
    {
        rec = new HitRecord();

        Vec3 oc = r.Origin - _center;  // Vector from ray origin to sphere center
        double a = r.Direction.LengthSquared();  // Direction squared
        double b = 2.0 * Vec3.Dot(oc, r.Direction);  // Standard quadratic equation term
        double c = oc.LengthSquared() - _radius * _radius;  // Sphere equation

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
        rec._t = root;
        rec._p = r.At(rec._t);  // Calculate intersection point
        Vec3 outwardNormal = (rec._p - _center) / _radius;  // Compute normal
        rec.SetFaceNormal(r, outwardNormal);  // Adjust normal based on ray direction
        rec._mat = _mat;  // Assign material

        return true;
    }
}
