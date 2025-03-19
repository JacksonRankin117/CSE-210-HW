using System;
using System.Numerics;

public struct Vec3
{
    public float X, Y, Z;

    public Vec3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vec3 operator +(Vec3 a, Vec3 b) => new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vec3 operator -(Vec3 a, Vec3 b) => new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Vec3 operator *(Vec3 a, float t) => new Vec3(a.X * t, a.Y * t, a.Z * t);
    public static Vec3 operator /(Vec3 a, float t) => new Vec3(a.X / t, a.Y / t, a.Z / t);
    public static Vec3 operator *(float t, Vec3 v) => new Vec3(v.X * t, v.Y * t, v.Z * t);


    public float Length() => (float)Math.Sqrt(X * X + Y * Y + Z * Z);
    public Vec3 Normalize() => this / Length();

    public static float Dot(Vec3 a, Vec3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    public static Vec3 Cross(Vec3 a, Vec3 b) =>
        new Vec3(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
}
