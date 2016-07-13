using System;
using System.Xml.Linq;

namespace DynamicXml
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                dynamic planets = DynamicXElement.Create(XElement.Load("planets.xml"));
                var mercury = planets.Planet;       // first planet
                Console.WriteLine(mercury);
                var venus = planets["Planet", 1];   // second planet 
                Console.WriteLine(venus);
                var ourMoon = planets["Planet", 2].Moons.Moon;
                Console.WriteLine(ourMoon);
                var marsMoon = planets["Planet", 3]["Moons", 0].Moon; // mars second moon
                Console.WriteLine(marsMoon);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
