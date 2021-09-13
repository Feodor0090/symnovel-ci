using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;

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
            if (!EnvSetup.checkRepo()) throw new DirectoryNotFoundException();
            Build();
            Verify();
            Pack();
        }

        static String getJavaBuildCmd(String fileName)
        {
            return "jdk\\bin\\javac.exe -bootclasspath \\lib -sourcepath repo\\src -d bin "+fileName;
        }

        static void Build()
        {
            IEnumerable files = Directory.EnumerateFiles("repo\\src");
            foreach(var p in files)
            {
                Console.WriteLine(p);
            }
        }

        static void Verify()
        {

        }

        static void Pack()
        {

        }
    }
}
