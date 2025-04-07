using System;

public abstract class Material
{
    public virtual bool Scatter(Ray rIn, HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = default;
        scattered = default;
        return false;
    }
}

public class Lambertian : Material
{
    private Color _albedo;

    public Lambertian(Color albedo)
    {
        this._albedo = albedo;
    }

    public override bool Scatter(Ray rIn, HitRecord rec, out Color attenuation, out Ray scattered)
    {
        Vec3 _scatterDirection = rec._normal + Vec3.RandomUnitVector();

        // Catch degenerate scatter direction
        if (_scatterDirection.NearZero())
            _scatterDirection = rec._normal;

        scattered = new Ray(rec._p, _scatterDirection);
        attenuation = _albedo;
        return true;
    }
}

public class Metal : Material
{
    private Color _albedo;
    private double _fuzz;

    public Metal(Color albedo, double fuzz)
    {
        this._albedo = albedo;
        this._fuzz = fuzz < 1 ? fuzz : 1;
    }

    public override bool Scatter(Ray rIn, HitRecord rec, out Color attenuation, out Ray scattered)
    {
        Vec3 reflected = Vec3.Reflect(rIn.Direction, rec._normal);
        reflected = Vec3.UnitVector(reflected) + _fuzz * Vec3.RandomUnitVector();
        scattered = new Ray(rec._p, reflected);
        attenuation = _albedo;
        return Vec3.Dot(scattered.Direction, rec._normal) > 0;
    }
}

public class Dielectric : Material
{
    private double _refractionIndex;

    public Dielectric(double refractionIndex)
    {
        this._refractionIndex = refractionIndex;
    }

    public override bool Scatter(Ray rIn, HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = new Color(1.0, 1.0, 1.0);
        double ri = rec._front_face ? (1.0 / _refractionIndex) : _refractionIndex;

        Vec3 unitDirection = Vec3.UnitVector(rIn.Direction);
        double cosTheta = Math.Min(Vec3.Dot(-unitDirection, rec._normal), 1.0);
        double sinTheta = Math.Sqrt(1.0 - cosTheta * cosTheta);

        bool cannotRefract = ri * sinTheta > 1.0;
        Vec3 direction = default(Vec3);

        if (cannotRefract || Reflectance(cosTheta, ri) > RTWeekend.RandomDouble())
            direction = Vec3.Reflect(unitDirection, rec._normal);
        else
            direction = Vec3.Refract(unitDirection, rec._normal, ri);

        scattered = new Ray(rec._p, direction);
        return true;
    }

    private static double Reflectance(double cosine, double refractionIndex)
    {
        double r0  = (1 - refractionIndex) / (1 + refractionIndex);
        r0 = r0 * r0;
        return r0 + (1 - r0) * Math.Pow(1 - cosine, 5);
    }
}
