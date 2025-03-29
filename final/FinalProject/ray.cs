using System;

public class Ray
{
    public Vec3 Origin { get; }
    public Vec3 Direction { get; }

    public Ray() : this(new Vec3(0, 0, 0), new Vec3(0, 0, 0)) { }

    public Ray(Vec3 origin, Vec3 direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public Vec3 At(double t)
    {
        return Origin + t * Direction;
    }
}
