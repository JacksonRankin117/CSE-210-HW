using System;

public class Vec3
{
    public double[] E { get; } = new double[3];

    public Vec3() { E[0] = 0; E[1] = 0; E[2] = 0; }
    public Vec3(double e0, double e1, double e2)
    {
        E[0] = e0;
        E[1] = e1;
        E[2] = e2;
    }

    public double X { get { return E[0]; } }
    public double Y { get { return E[1]; } }
    public double Z { get { return E[2]; } }

    public double this[int i]
    {
        get { return E[i]; }
        set { E[i] = value; }
    }

    public static Vec3 operator -(Vec3 v) { return new Vec3(-v.E[0], -v.E[1], -v.E[2]); }
    public static Vec3 operator +(Vec3 u, Vec3 v) { return new Vec3(u.E[0] + v.E[0], u.E[1] + v.E[1], u.E[2] + v.E[2]); }
    public static Vec3 operator -(Vec3 u, Vec3 v) { return new Vec3(u.E[0] - v.E[0], u.E[1] - v.E[1], u.E[2] - v.E[2]); }
    public static Vec3 operator *(Vec3 u, Vec3 v) { return new Vec3(u.E[0] * v.E[0], u.E[1] * v.E[1], u.E[2] * v.E[2]); }
    public static Vec3 operator *(double t, Vec3 v) { return new Vec3(t * v.E[0], t * v.E[1], t * v.E[2]); }
    public static Vec3 operator *(Vec3 v, double t) { return t * v; }
    public static Vec3 operator /(Vec3 v, double t) { return (1 / t) * v; }

    public Vec3 Add(Vec3 v)
    {
        E[0] += v.E[0];
        E[1] += v.E[1];
        E[2] += v.E[2];
        return this;
    }

    public Vec3 Multiply(double t)
    {
        E[0] *= t;
        E[1] *= t;
        E[2] *= t;
        return this;
    }

    public Vec3 Divide(double t) 
    { 
        return Multiply(1 / t); 
    }

    public double Length() 
    { 
        return Math.Sqrt(LengthSquared()); 
    }
    public double LengthSquared() 
    { 
        return E[0] * E[0] + E[1] * E[1] + E[2] * E[2]; 
    }

    public static double Dot(Vec3 u, Vec3 v) 
    { 
        return u.E[0] * v.E[0] + u.E[1] * v.E[1] + u.E[2] * v.E[2];
    }

    public static Vec3 Cross(Vec3 u, Vec3 v)
    {
        return new Vec3(
            u.E[1] * v.E[2] - u.E[2] * v.E[1],
            u.E[2] * v.E[0] - u.E[0] * v.E[2],
            u.E[0] * v.E[1] - u.E[1] * v.E[0]
        );
    }

    public static Vec3 UnitVector(Vec3 v) 
    { 
        return v / v.Length(); 
    }

    public override string ToString() 
    { 
        return $"{E[0]} {E[1]} {E[2]}"; 
    }
}
