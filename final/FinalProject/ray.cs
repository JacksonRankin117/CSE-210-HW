public struct Ray
{
    public Vec3 Origin { get; }
    public Vec3 Direction { get; }

    public Ray(Vec3 origin, Vec3 direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public Vec3 At(float t) => Origin + Direction * t;
}
