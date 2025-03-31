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
        rec = new HitRecord(); // Initialize rec to avoid uninitialized reference error
        
        Vec3 oc = r.Origin - center;  // Vector from ray origin to sphere center
        double a = r.Direction.LengthSquared();  // Direction squared (dot product of direction with itself)
        double h = Vec3.Dot(oc, r.Direction);  // Half of the dot product of the ray's origin to sphere center with the direction
        double c = oc.LengthSquared() - radius * radius;  // Distance from ray origin to sphere center squared minus sphere's radius squared

        double discriminant = h * h - a * c;  // Discriminant of the quadratic equation

        if (discriminant < 0)  // If the discriminant is negative, no intersection
        {
            return false;
        }

        double sqrtd = Math.Sqrt(discriminant);  // Square root of the discriminant

        // Find the nearest root that lies within the acceptable t range
        double root = (h - sqrtd) / a;  
        if (!ray_t.Contains(root))  // Check if root is within the bounds
        {
            root = (h + sqrtd) / a;  // Check the second root
            if (!ray_t.Contains(root))  // Check if the second root is within bounds
            {
                return false;
            }
        }

        // Set the hit record
        rec.T = root;
        rec.P = r.At(rec.T);  // Calculate the intersection point
        Vec3 outwardNormal = (rec.P - center) / radius;  // Calculate the normal at the intersection
        rec.SetFaceNormal(r, outwardNormal);  // Set the normal, handling front/back face
        rec.Mat = mat;  // Set the material

        return true;
    }
}
