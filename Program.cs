using System;

namespace symnovel_ci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Job started.");
            Console.WriteLine();
            S40Setup.UnpackMIDPClasses();
        }
    }
}
