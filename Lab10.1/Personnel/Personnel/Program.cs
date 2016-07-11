using System;
using System.Collections.Generic;
using System.IO;

namespace Personnel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (var streamReader = new StreamReader("File.txt"))
                {
                    var namesList = ReadAllData(streamReader);

                    Console.WriteLine("Names Loaded from the file \"File.txt\":");
                    DisplayList(namesList);

                    Console.WriteLine("Notice: The file \"File.txt\" is located under the path: ProjectDirectory/bin/Debug");
                }
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        public static List<string> ReadAllData(StreamReader streamReader)
        {
            var namesList = new List<string>();
            string line;

            // Read and display lines from the file until the end of 
            // the file is reached.
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
