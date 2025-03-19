public struct HitRecord
{
    public Vec3 Point;
    public Vec3 Normal;
    public float T;
    public bool FrontFace;

    public void SetFaceNormal(Ray ray, Vec3 outwardNormal)
    {
        FrontFace = Vec3.Dot(ray.Direction, outwardNormal) < 0;
        Normal = FrontFace ? outwardNormal : outwardNormal * -1;
    }
}

public interface IHittable
{
    bool Hit(Ray ray, float tMin, float tMax, out HitRecord rec);
}
