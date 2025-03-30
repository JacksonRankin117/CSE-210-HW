using System;

public class Vec3 {
    public double[] E { get; } = new double[3];
    public static Random rand = new Random();

    public Vec3() {
        E[0] = E[1] = E[2] = 0;
    }

    public Vec3(double e0, double e1, double e2) {
        E[0] = e0;
        E[1] = e1;
        E[2] = e2;
    }

    public double X => E[0];
    public double Y => E[1];
    public double Z => E[2];

    public static Vec3 operator -(Vec3 v) => new Vec3(-v.E[0], -v.E[1], -v.E[2]);

    public double this[int i] {
        get => E[i];
        set => E[i] = value;
    }

    public static Vec3 operator +(Vec3 u, Vec3 v) {
        return new Vec3(u.E[0] + v.E[0], u.E[1] + v.E[1], u.E[2] + v.E[2]);
    }

    public static Vec3 operator -(Vec3 u, Vec3 v) {
        return new Vec3(u.E[0] - v.E[0], u.E[1] - v.E[1], u.E[2] - v.E[2]);
    }

    public static Vec3 operator *(Vec3 v, double t) {
        return new Vec3(v.E[0] * t, v.E[1] * t, v.E[2] * t);
    }

    public static Vec3 operator *(double t, Vec3 v) {
        return v * t;
    }

    public static Vec3 operator /(Vec3 v, double t) {
        return v * (1 / t);
    }

    public double Length() => Math.Sqrt(LengthSquared());

    public double LengthSquared() => E[0] * E[0] + E[1] * E[1] + E[2] * E[2];

    public bool NearZero() {
        const double s = 1e-8;
        return Math.Abs(E[0]) < s && Math.Abs(E[1]) < s && Math.Abs(E[2]) < s;
    }

    public static Vec3 Random() {
        return new Vec3(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
    }

    public static Vec3 Random(double min, double max) {
        // Ensure that the random values are scaled between min and max
        return new Vec3(
            min + (max - min) * rand.NextDouble(),
            min + (max - min) * rand.NextDouble(),
            min + (max - min) * rand.NextDouble()
        );
    }


    public static double Dot(Vec3 u, Vec3 v) {
        return u.E[0] * v.E[0] + u.E[1] * v.E[1] + u.E[2] * v.E[2];
    }

    public static Vec3 Cross(Vec3 u, Vec3 v) {
        return new Vec3(
            u.E[1] * v.E[2] - u.E[2] * v.E[1],
            u.E[2] * v.E[0] - u.E[0] * v.E[2],
            u.E[0] * v.E[1] - u.E[1] * v.E[0]
        );
    }

    public static Vec3 UnitVector(Vec3 v) {
        return v / v.Length();
    }

    public static Vec3 RandomUnitVector()
    {
        while (true)
        {
            var p = Random(-1, 1);
            double lensq = p.LengthSquared();
            if (lensq > 1e-10 && lensq <= 1.0) // original line: if (lensq > 1e-10 && lensq <= 1.0)
                return p / Math.Sqrt(lensq);
        }
    }

    

    public static Vec3 Reflect(Vec3 v, Vec3 n) {
        return v - 2 * Dot(v, n) * n;
    }

    public static Vec3 Refract(Vec3 uv, Vec3 n, double etaiOverEtat) {
        double cosTheta = Math.Min(Dot(-uv, n), 1.0);
        Vec3 rOutPerp = etaiOverEtat * (uv + cosTheta * n);
        Vec3 rOutParallel = -Math.Sqrt(Math.Abs(1.0 - rOutPerp.LengthSquared())) * n;
        return rOutPerp + rOutParallel;
    }
}
