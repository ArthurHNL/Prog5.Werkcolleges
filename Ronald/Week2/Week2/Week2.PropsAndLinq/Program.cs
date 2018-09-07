using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.PropsAndLinq.Data;

namespace Week2.PropsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Properties 
            Console.WriteLine("=== Properties ===");

            PropertyVoorbeeld voorbeeld = new PropertyVoorbeeld("Kist");
            voorbeeld.VoorNaam = "Kees";
            voorbeeld.VoorNaam = "Jan";

            if (voorbeeld.VoorNaam == "Kees")
                Console.WriteLine($"Een voetballer: {voorbeeld.Naam}");
            else
                Console.WriteLine($"{voorbeeld.Naam} is de broer van Kees");

            Console.WriteLine();

            // Linq
            Console.WriteLine("=== LINQ ===");

            string[] names = { "Ronald", "Jasper", "Roland", "Stijn", "Piet", "Anne", "Laura", "Margot" };
            // Query Expression
            var namesQuery = from n in names
                             where n.Contains("a")
                             orderby n descending
                             select n;

            foreach (var name in namesQuery)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();
            Console.WriteLine("=== LINQ (Lamda) ===");

            // Lambda Expression
            names
                .Where(x => x.Contains("R"))
                .OrderBy(x => x) 
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            // GroupBy
            Console.WriteLine();
            Console.WriteLine("=== LINQ (GroupBy) ===");

            Person person = new Person();

            var people = person.GetPeople().Where(x => x.Gender == Gender.Unknown || x.Name.Contains("o")).GroupBy(x => x.Gender);
            foreach (var groep in people)
            {
                Console.WriteLine(groep.Key);
                foreach (var p in groep)
                    Console.WriteLine($"Name: {p.Name}\tGender:{p.Gender}");
            }
            Console.ReadLine();
        }
    }
}
