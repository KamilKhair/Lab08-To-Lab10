using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    public class FileFinder
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Error: Please pass a directory path and a string to search");
                return;
            }

            // Get all files paths from the directory and save into array of strings
            string[] allFiles;
            try
            {
                allFiles = Directory.GetFiles(args[0], "*");
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Searching...");
            DisplayFiles(FindFiles(allFiles, args[1]));
        }

        public static Dictionary<string, int> FindFiles(string[] allFiles, string valeToSearch)
        {
            var files = new Dictionary<string, int>();
            foreach (var file in allFiles)
            {
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (var streamReader = new StreamReader(file))
                    {
                        var contents = streamReader.ReadToEnd();
                        if (contents.Contains(valeToSearch))
                        {
                            files.Add(file, contents.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine(ex.Message);
                }
            }
            return files;
        }

        public static void DisplayFiles(Dictionary<string, int> files)
        {
            if (files.Count <= 0)
            {
                Console.WriteLine("No files found");
                return;
            }
            Console.WriteLine(files.Count == 1 ? "1 File has been found:" : $"{files.Count} Files have been found:");
            foreach (var file in files)
            {
                Console.WriteLine($"File: {file.Key}, File Length: {file.Value}");
            }
            Console.WriteLine();
        }
    }
}
