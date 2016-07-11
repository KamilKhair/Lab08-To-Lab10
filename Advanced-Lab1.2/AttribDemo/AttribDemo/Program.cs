using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AttribDemo
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(AnalayzeAssembly(Assembly.GetExecutingAssembly())
                ? "All reviewed types are approved"
                : "Not all reviewed types are approved");

            //Question: What happens if you pass a reference to some other Assembly to the
            //AnalyzeAssembly method? Try it.

            // Answer: If Assembly.GetEntryAssembly(), Assembly.GetCallingAssembly() or
            // Assembly.GetExecutingAssembly() are passed, the output would be:

            // Output:
            //A: "Moaid"  "11/7/2016"(Boolean)True
            //B: "Alon"  "15/7/2016"(Boolean)True
            //C: "Saar"  "23/7/2016"(Boolean)False
            //Not all reviewed types are approved

            // Also if Assembly.GetAssembly(typeof(A)), Assembly.GetAssembly(typeof(B)), 
            // Assembly.GetAssembly(typeof(C)), Assembly.GetAssembly(typeof(Program))
            // or Assembly.GetAssembly(typeof(CodeReviewAttribute)) are paseed, the output
            // would be the same as above!

            // Otherwise, The passed reference to Assembly doesn't has any type which uses the custom
            // attribute CodeReviewAttribute!so nothing is printed on console.
        }

        public static bool AnalayzeAssembly(Assembly obj)
        {
            var types = obj.GetTypes();
            var allApproved = true;
            foreach (var type in types)
            {
                if (!type.IsDefined(typeof(CodeReviewAttribute))) continue;
                var attributeInfo = type.GetCustomAttributesData();
                foreach (var info in attributeInfo)
                {
                    Console.Write($"{type.Name}: ");
                    foreach (var argument in info.ConstructorArguments)
                    {
                        Console.Write($"{argument}  ");
                        if (argument.ToString() == "(Boolean)False")
                        {
                            allApproved = false;
                        }
                    }
                    Console.WriteLine();
                }
            }
            return allApproved;
        }
    }
}
