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
            if (!EnvSetup.checkRepo()) throw new DirectoryNotFoundException("The repository is not cloned!");
            Build();
            Verify();
            Pack();
        }

        static string getJavaBuildParams(string fileName)
        {
            string wd = Environment.CurrentDirectory;
            return "-encoding UTF-8 -bootclasspath lib -sourcepath "+wd+"\\repo\\src -d bin "+fileName;
        }

        static void Build()
        {
            string wd = Environment.CurrentDirectory;
            IEnumerable<string> files = Directory.EnumerateFiles("repo\\src", "*.*", SearchOption.AllDirectories);
            foreach(var p in files)
            {
                var opts = getJavaBuildParams(p);
                Process compiler = new Process();
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.FileName = wd + "\\jdk\\jdk1.5.0_22\\bin\\javac.exe";
                compiler.StartInfo.Arguments = opts;
                compiler.Start();
                StreamReader output = compiler.StandardOutput;
                Console.WriteLine(output.ReadToEnd());
                compiler.WaitForExit();
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
