﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace symnovel_ci
{
    sealed class EnvSetup
    {

        public static void UnpackJDK() => UnpackZip("jdk");
        public static void UnpackMIDPClasses() => UnpackZip("lib");

        private static void UnpackZip(string name)
        {
            FileStream stream = File.OpenRead(name+".zip");
            using (ZipArchive classes = new ZipArchive(stream, ZipArchiveMode.Read, false))
            {
                Console.WriteLine("Extracting " + stream.Name);
                classes.ExtractToDirectory(name);
            }
        }
    }
}