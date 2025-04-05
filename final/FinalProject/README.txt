    My project is a ray tracer. I ray trace spheres of differing materials, 
like a shiney metal sphere, or a glass sphere, or a sphere with a matte finish.
The prohram works by first mathematically defining spheres in a space. These 
spheres are centered on specific coordinates, and their size is determined by a
radius argument. 
    The Ray class represents a specific path that a photon, or 
light particle might make. The Ray is fired out, and if it detects a sphere, 
there are multiple trajectories the ray might take. If it is a Lambertian 
(matte finish) material, it will bounce off randomly. If it hits a metalic 
surface, it will reflect exactly like a mirror. If it hits a dielectric, it 
will bend the light, very much like how light bends when it hits a real glass 
sphere. 
    The Camera class will shoot out many Rays, and those rays will bounce 
many times. There are many rays shot out per pixel, and the average color value
per ray is used to determine the final pixel color. So, the number of samples 
directly influences the image quality, but it also drastically increases render
time. 
    My program also uses supersampling antialiasing, which divides the 
aliased pixel into sub-pixels, casts a ray through each sub pixel, and uses 
those values to determine the final color.
    Also, my tracer uses a defocus angle, to emulate the way a camera lens 
focuses. a camera lens will have a single plane of focus, then anything nearer 
or closer to that plane will gradually be more and more out of focus.
    On top of that, my program has a sort of progress bar. It will write a 
message to the terminal on which line of the image we are on, though I may make
that a loading bar. Maybe it will look like this:

[############-----------] 50% - Scanlines remaining: 512

Or something
    One thing that I wanted to get done, but I didn't have time was 
gravitational lensing, which is the effect that a massive body has on space. In
physics, light always takes the easiest path. But, if a body warps space, maybe
that light ray needs to bend a little to take the easier path, which is exactly
what we see in space. We see massive groups of star clusters bend light from 
galaxies, distorting their true shape. This would have been cool, and this is 
probably something I will implement in future renditions of this code.

Demonstrations of OOP techniques used:

Inheritance: Sphere class is a Hittable
             HittableList class is a Hittable
             Metal class is a Material
             Lambertian class is a Material
             Dielectric class is a Material

Encapsulation: I mean, its kind of everywhere. I dont think any class doesn't 
               use it

Abstraction: Its kind of everywhere. Most of my methods hide what exactly 
             they are doing. Like the boolean Hit() method. It doesn't tell you 
             how its detecting a hit, just if it is.

Polymorphism: In my material class, the boolean method Hit is overriden through
              each Material child class

And that is it. This was a fun project.
             