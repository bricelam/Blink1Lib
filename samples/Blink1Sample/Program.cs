using System;
using System.Diagnostics;
using System.Threading;

namespace Bricelam.Blink1Lib.Sample
{
    internal class Program
    {
        private static void Main()
        {
            // Open the first blink(1) device that's found
            using (var blink1 = new Blink1Mk2())
            {
                // Get device information
                Console.WriteLine("Version: {0}", blink1.Version);
                Console.WriteLine("Serial: {0}", blink1.Serial);
                Console.WriteLine();

                // Turn on (whiteout)
                blink1.SetColor(255, 255, 255);
                Thread.Sleep(1000);

                // Fade to blue over 1 second
                blink1.FadeTo(1000, 0, 0, 255);

                // Get color
                byte r, g, b;
                var stopwatch = Stopwatch.StartNew();
                do
                {
                    blink1.GetColor(out r, out g, out b, Blink1Led.All);

                    Console.WriteLine("rgb: {0,3} {1,3} {2,3}", r, g, b);

                    Thread.Sleep(100);
                }
                while (stopwatch.ElapsedMilliseconds <= 1000);
                Thread.Sleep(1000);

                // Fade first LED to green
                blink1.FadeTo(1000, 0, 255, 0, Blink1Led.First);
                Thread.Sleep(2000);

                // Fade all to red
                blink1.FadeTo(1000, 255, 0, 0);
                Thread.Sleep(2000);

                // Fade top to blue and bottom to green
                blink1.FadeTo(1000, 0, 0, 255, Blink1Led.First);
                blink1.FadeTo(1000, 0, 255, 0, Blink1Led.Second);
                Thread.Sleep(2000);

                // Fade to black (turn off)
                blink1.FadeTo(1000, 0, 0, 0);
            }

            Console.WriteLine();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
