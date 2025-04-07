using System;

public class HitRecord
{
    public Vec3 _p { get; set; }
    public Vec3 _normal { get; set; }
    public Material _mat { get; set; }
    public double _t { get; set; }
    public bool _front_face { get; private set; }

    public void SetFaceNormal(Ray r, Vec3 outwardNormal)
    {
        // Sets the hit record normal vector.
        _front_face = Vec3.Dot(r.Direction, outwardNormal) < 0;
        _normal = _front_face ? outwardNormal : -outwardNormal;
    }
}

public interface Hittable
{
    bool Hit(Ray r, Interval rayT, out HitRecord rec);
}
