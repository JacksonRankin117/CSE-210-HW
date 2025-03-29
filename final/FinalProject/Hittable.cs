using System;

public class HitRecord
{
    public Vec3 P { get; set; }
    public Vec3 Normal { get; set; }
    public Material Mat { get; set; }
    public double T { get; set; }
    public bool FrontFace { get; private set; }

    public void SetFaceNormal(Ray r, Vec3 outwardNormal)
    {
        // Sets the hit record normal vector.
        // Assumes `outwardNormal` has unit length.
        FrontFace = Vec3.Dot(r.Direction, outwardNormal) < 0;
        Normal = FrontFace ? outwardNormal : -outwardNormal;
    }
}

public interface Hittable  // Fixed: Renamed Hittable to IHittable for clarity
{
    bool Hit(Ray r, Bounds rayT, out HitRecord rec); // Fixed: Uses Bounds
}
