public class Camera
{
    private Vec3 Origin = new Vec3(0, 0, 0);
    private Vec3 LowerLeftCorner = new Vec3(-2, -1, -1);
    private Vec3 Horizontal = new Vec3(4, 0, 0);
    private Vec3 Vertical = new Vec3(0, 2, 0);

    public Ray GetRay(float u, float v)
    {
        return new Ray(Origin, LowerLeftCorner + u * Horizontal + v * Vertical - Origin);
    }
}
