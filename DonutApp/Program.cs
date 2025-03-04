using System;

namespace donut.net
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize rotation angles and variables for donut rendering
            double A = 0, B = 0, i, j;
            var z = new double[7040]; // Array for depth values
            var b = new char[1760];  // Array for the 2D donut display

            // Infinite loop for continuous donut rendering
            while (true)
            {
                // Reset the arrays for the next frame
                memset(b, ' ', 1760);
                memset(z, 0.0f, 7040);

                // Loop through the angles for the donut shape
                for (j = 0; j < 6.28; j += 0.07)
                {
                    for (i = 0; i < 6.28; i += 0.02)
                    {
                        // Precompute trigonometrical values
                        double c = Math.Sin(i);
                        double d = Math.Cos(j);
                        double e = Math.Sin(A);
                        double f = Math.Sin(j);
                        double g = Math.Cos(A);
                        double h = d + 2; // Offset for vertical positioning
                        double D = 1 / (c * h * e + f * g + 5); // Depth calculation

                        // More trigonometric calculations for 3D positioning
                        double l = Math.Cos(i);
                        double m = Math.Cos(B);
                        double n = Math.Sin(B);
                        double t = c * h * g - f * e;
                        
                        // Calculate screen positions
                        int x = (int)(40 + 30 * D * (l * h * m - t * n));
                        int y = (int)(12 + 15 * D * (l * h * n + t * m));
                        int o = x + 80 * y; // Index for the 2D array (b)

                        // Use the 'shade' index to choose character based on intensity
                        int N = (int)(8 * ((f * e - c * d * g) * m - c * d * e - f * g - l * d * n));

                        // Only update the character if it's within the screen bounds and the new depth is greater
                        if (y > 0 && y < 22 && x > 0 && x < 80 && D > z[o])
                        {
                            z[o] = D; // Update depth
                            b[o] = ".,-~:;=!*#$@"[N > 0 ? N : 0]; // Update character at the position
                        }
                    }
                }

                // Pause for a short time and then clear the console for the next frame
                System.Threading.Thread.Sleep(33);
                Console.Clear();
                nl(b); // Add newlines for proper display format
                Console.Write(b); // Display the donut

                // Update the rotation angles for the next frame
                A += 0.04;
                B += 0.02;
            }
        }

        // Helper function to initialize array with a value
        static void memset<T>(T[] buf, T val, int bufsz)
        {
            // If the array is null, initialize it
            if (buf == null)
                buf = new T[bufsz];

            // Fill the array with the specified value
            for (int i = 0; i < bufsz; i++)
                buf[i] = val;
        }

        // Helper function to insert newline characters at proper intervals
        static void nl(char[] b)
        {
            for (int i = 80; i < 1760; i += 80)
            {
                b[i] = '\n'; // Insert newline at every 80th index
            }
        }
    }
}
