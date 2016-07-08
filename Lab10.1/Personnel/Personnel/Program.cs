using System;
using System.Collections.Generic;
using System.IO;

namespace Personnel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var streamReader = new StreamReader("File.txt");
            var namesList = ReadAllData(streamReader);

            Console.WriteLine("Names Loaded from the file \"File.txt\":");
            DisplayList(namesList);

            Console.WriteLine("Notice: The file \"File.txt\" is located under the path: ProjectDirectory/bin/Debug");
        }

        public static List<string> ReadAllData(StreamReader streamReader)
        {
            var namesList = new List<string>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                namesList.Add(line);
            }
            return namesList;
        }

        public static void DisplayList(List<string> namesList)
        {
            foreach (var name in namesList)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }
    }
}
