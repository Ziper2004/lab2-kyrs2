using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StopWatch
{
    public static class FileHandler
    {
        public static void WriteData(string message, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
                sw.WriteLine(message);
        }
        public static string ReadLine(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
                return reader.ReadLine();
        }
        public static bool ExistsFile(string fileName)
        {
            return File.Exists(fileName);
        }
        public static void DeleteFile(string fileName)
        {
            File.Delete(fileName);
        }
    }
}
