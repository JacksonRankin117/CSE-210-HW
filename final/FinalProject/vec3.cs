using System;

public struct Vec3
{
    public double X, Y, Z;
    private static readonly Random Rand = new Random();

    public Vec3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vec3 operator +(Vec3 a, Vec3 b) => new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vec3 operator -(Vec3 a, Vec3 b) => new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Vec3 operator *(Vec3 a, double t) => new Vec3(a.X * t, a.Y * t, a.Z * t);
    public static Vec3 operator *(double t, Vec3 a) => new Vec3(a.X * t, a.Y * t, a.Z * t);
    public static Vec3 operator /(Vec3 a, double t) => new Vec3(a.X / t, a.Y / t, a.Z / t);
    public static Vec3 operator -(Vec3 v) => new Vec3(-v.X, -v.Y, -v.Z);


    public double LengthSquared() => X * X + Y * Y + Z * Z;
    public double Length() => Math.Sqrt(LengthSquared());

    public static Vec3 Random()
    {
        return new Vec3(Rand.NextDouble(), Rand.NextDouble(), Rand.NextDouble());
    }

    public static Vec3 Random(double min, double max)
    {
        return new Vec3(
            min + (max - min) * Rand.NextDouble(),
            min + (max - min) * Rand.NextDouble(),
            min + (max - min) * Rand.NextDouble()
        );
    }

    public bool NearZero()
    {
        const double s = 1e-8;
        return (Math.Abs(X) < s) && (Math.Abs(Y) < s) && (Math.Abs(Z) < s);
    }

    public static Vec3 Reflect(Vec3 v, Vec3 n)
    {
        return v - 2 * Dot(v, n) * n;
    }

    public static Vec3 Refract(Vec3 uv, Vec3 n, double etaiOverEtat) {
        double cosTheta = Math.Min(Dot(-uv, n), 1.0);
        Vec3 rOutPerp = etaiOverEtat * (uv + cosTheta * n);
        Vec3 rOutParallel = -Math.Sqrt(Math.Abs(1.0 - rOutPerp.LengthSquared())) * n;
        return rOutPerp + rOutParallel;
    }


    public static double Dot(Vec3 a, Vec3 b)
    {
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    public static Vec3 Cross(Vec3 a, Vec3 b)
    {
        return new Vec3(
            a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X
        );
    }

    public static Vec3 UnitVector(Vec3 v)
    {
        return v / v.Length();
    }

    public static Vec3 RandomInUnitSphere()
    {
        while (true)
        {
            Vec3 p = Random(-1, 1);
            if (p.LengthSquared() < 1)
                return p;
        }
    }

    public static Vec3 RandomUnitVector()
    {
        return UnitVector(RandomInUnitSphere());
    }

    public static Vec3 RandomOnHemisphere(Vec3 normal)
    {
        Vec3 inUnitSphere = RandomUnitVector();
        return Dot(inUnitSphere, normal) > 0.0 ? inUnitSphere : -inUnitSphere;
    }

    public override string ToString() => $"{X} {Y} {Z}";
}
