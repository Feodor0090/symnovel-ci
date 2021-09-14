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
            Console.WriteLine("Working from "+ Environment.CurrentDirectory);
            Console.WriteLine();
            EnvSetup.UnpackJDK();
            EnvSetup.UnpackMIDPClasses();
            if (!EnvSetup.checkRepo()) throw new DirectoryNotFoundException();
            Build();
            Verify();
            Pack();
        }

        static string getJavaBuildCmd(string jdkPath, string fileName)
        {
            return jdkPath+" -bootclasspath \\lib -sourcepath repo\\src -d bin "+fileName;
        }

        static void Build()
        {
            IEnumerable<string> files = Directory.EnumerateFiles("repo\\src", "*.*", SearchOption.AllDirectories);
            foreach(var p in files)
            {
                var cmd = getJavaBuildCmd(Environment.CurrentDirectory+ "\\jdk\\jdk1.5.0_22\\bin\\javac.exe", p);
                Process compiler = Process.Start(cmd);
                StreamReader output = compiler.StandardOutput;
                compiler.WaitForExit();
                Console.WriteLine(output.ReadToEnd());
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
