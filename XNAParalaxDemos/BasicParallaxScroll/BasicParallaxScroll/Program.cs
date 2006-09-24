using System;

namespace BasicParallaxScroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BasicParallaxScrollDemo game = new BasicParallaxScrollDemo())
            {
                game.Run();
            }
        }
    }
}

