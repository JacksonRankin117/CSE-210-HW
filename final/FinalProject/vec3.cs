using System;

public struct Vec3
{
    public double _x, _y, _z;
    private static readonly Random _rand = new Random();

    public Vec3(double x, double y, double z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public static Vec3 operator +(Vec3 a, Vec3 b) => new Vec3(a._x + b._x, a._y + b._y, a._z + b._z);
    public static Vec3 operator -(Vec3 a, Vec3 b) => new Vec3(a._x - b._x, a._y - b._y, a._z - b._z);
    public static Vec3 operator *(Vec3 a, double t) => new Vec3(a._x * t, a._y * t, a._z * t);
    public static Vec3 operator *(double t, Vec3 a) => new Vec3(a._x * t, a._y * t, a._z * t);
    public static Vec3 operator /(Vec3 a, double t) => new Vec3(a._x / t, a._y / t, a._z / t);
    public static Vec3 operator -(Vec3 v) => new Vec3(-v._x, -v._y, -v._z);


    public double LengthSquared() => _x * _x + _y * _y + _z * _z;
    public double Length() => Math.Sqrt(LengthSquared());

    public static Vec3 Random()
    {
        return new Vec3(_rand.NextDouble(), _rand.NextDouble(), _rand.NextDouble());
    }

    public static Vec3 Random(double min, double max)
    {
        return new Vec3(
            min + (max - min) * _rand.NextDouble(),
            min + (max - min) * _rand.NextDouble(),
            min + (max - min) * _rand.NextDouble()
        );
    }

    public bool NearZero()
    {
        const double s = 1e-8;
        return (Math.Abs(_x) < s) && (Math.Abs(_y) < s) && (Math.Abs(_z) < s);
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
        return a._x * b._x + a._y * b._y + a._z * b._z;
    }

    public static Vec3 Cross(Vec3 a, Vec3 b)
    {
        return new Vec3(
            a._y * b._z - a._z * b._y,
            a._z * b._x - a._x * b._z,
            a._x * b._y - a._y * b._x
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

    public override string ToString() => $"{_x} {_y} {_z}";
}
