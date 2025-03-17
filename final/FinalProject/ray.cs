using System;

public class Ray
{
    private Point3 orig;
    private Vec3 dir;

    // Default constructor
    public Ray() { }

    // Constructor with parameters
    public Ray(Point3 origin, Vec3 direction)
    {
        orig = origin;
        dir = direction;
    }

    // Getters for origin and direction
    public Point3 Origin => orig;
    public Vec3 Direction => dir;

    // Method to calculate the point at a given distance t along the ray
    public Point3 At(double t)
    {
        return orig + t * dir;
    }
}
