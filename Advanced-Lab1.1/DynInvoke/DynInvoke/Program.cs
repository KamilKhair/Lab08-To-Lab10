using System;
using System.Reflection;

namespace DynInvoke
{
    public class Program
    {
        public static void Main()
        {
            var a = new A();
            var b = new B();
            var c = new C();

            InvokeHello(a, "Moaid");
            InvokeHello(b, "Saar");
            InvokeHello(c, "Kamil");
        }

        public static void InvokeHello(object obj, string s)
        {
            // Use reflection to get information about all declared public instance 
            // methods of the argument object obj
            var publicMethodsInfo = obj.GetType().GetMethods(BindingFlags.Public 
                                                                | BindingFlags.Instance 
                                                                | BindingFlags.DeclaredOnly);

            // Use reflection to get information about all declared non public instance 
            // methods of the argument object obj
            var nonPublicMethodsInfo = obj.GetType().GetMethods(BindingFlags.NonPublic 
                                                                    | BindingFlags.Instance 
                                                                    | BindingFlags.DeclaredOnly);

            var foundInPublicMethods = false;
            string resultString = null;

            // Search all public methods and if the method "Hello" of the argument 
            // object obj was found call it dynamically.
            foreach (var methodInfo in publicMethodsInfo)
            {
                if (methodInfo.Name != "Hello") continue;
                resultString = obj.GetType().GetMethod(methodInfo.Name).Invoke(obj, new object[] {s}) as string;
                foundInPublicMethods = true;
            }

            // If the method "Hello" wasn't found as a public method, Search all non-public methods
            // and if the method "Hello" of the argument object obj was found call it dynamically.
            if (!foundInPublicMethods)
            {
                foreach (var methodInfo in nonPublicMethodsInfo)
                {
                    if (methodInfo.Name != "Hello") continue;
                    resultString = obj.GetType().GetMethod(methodInfo.Name).Invoke(obj, new object[] { s }) as string;
                }
            }

            // Alternatively:
            // var resultString = obj.GetType().GetMethod("Hello").Invoke(obj, new object[] {s});
            Console.WriteLine(resultString);
        }
    }
}
