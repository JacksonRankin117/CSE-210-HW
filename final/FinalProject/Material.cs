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
    private Color albedo;

    public Lambertian(Color albedo)
    {
        this.albedo = albedo;
    }

    public override bool Scatter(Ray rIn, HitRecord rec, out Color attenuation, out Ray scattered)
    {
        var scatterDirection = rec.Normal + Vec3.RandomUnitVector();

        // Catch degenerate scatter direction
        if (scatterDirection.NearZero())
            scatterDirection = rec.Normal;

        scattered = new Ray(rec.P, scatterDirection);
        attenuation = albedo;
        return true;
    }
}

public class Metal : Material
{
    private Color albedo;
    private double fuzz;

    public Metal(Color albedo, double fuzz)
    {
        this.albedo = albedo;
        this.fuzz = fuzz < 1 ? fuzz : 1;
    }

    public override bool Scatter(Ray rIn, HitRecord rec, out Color attenuation, out Ray scattered)
    {
        Vec3 reflected = Vec3.Reflect(rIn.Direction, rec.Normal);
        reflected = Vec3.UnitVector(reflected) + fuzz * Vec3.RandomUnitVector();
        scattered = new Ray(rec.P, reflected);
        attenuation = albedo;
        return Vec3.Dot(scattered.Direction, rec.Normal) > 0;
    }
}

public class Dielectric : Material
{
    private double refractionIndex;

    public Dielectric(double refractionIndex)
    {
        this.refractionIndex = refractionIndex;
    }

    public override bool Scatter(Ray rIn, HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = new Color(1.0, 1.0, 1.0);
        double ri = rec.FrontFace ? (1.0 / refractionIndex) : refractionIndex;

        Vec3 unitDirection = Vec3.UnitVector(rIn.Direction);
        double cosTheta = Math.Min(Vec3.Dot(-unitDirection, rec.Normal), 1.0);
        double sinTheta = Math.Sqrt(1.0 - cosTheta * cosTheta);

        bool cannotRefract = ri * sinTheta > 1.0;
        Vec3 direction = default(Vec3);

        if (cannotRefract || Reflectance(cosTheta, ri) > RTWeekend.RandomDouble())
            direction = Vec3.Reflect(unitDirection, rec.Normal);
        else
            direction = Vec3.Refract(unitDirection, rec.Normal, ri);

        scattered = new Ray(rec.P, direction);
        return true;
    }

    private static double Reflectance(double cosine, double refractionIndex)
    {
        double r0  = (1 - refractionIndex) / (1 + refractionIndex);
        r0 = r0 * r0;
        return r0 + (1 - r0) * Math.Pow(1 - cosine, 5);
    }
}
