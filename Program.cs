using System;

namespace symnovel_ci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Job started.");
            Console.WriteLine();
            EnvSetup.UnpackJDK();
            EnvSetup.UnpackMIDPClasses();
        }
    }
}
