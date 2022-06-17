using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace Week2Checkpoint
{

    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public City(string name, int population)
        {
            this.Name = name;
            this.Population = population;
        }

        public static IEnumerable<City> FindCityByFirstAndLast(List<City> list, List<string> input)
        {
            return list.Where(p => (p.Name[0].ToString().ToLower().ToLower() == input[0]) && p.Name[p.Name.Length-1].ToString() == input[1]);
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            var parsedInput = new List<string>();
           
            cities.Add(new City(name:"Rome", population:2873000));
            cities.Add(new City(name:"Paris", population: 2161000));
            cities.Add(new City(name:"London", population:8982000));
            cities.Add(new City(name:"Nairobi", population:4397000));
            cities.Add(new City(name:"Los Angeles", population:3793000));
            cities.Add(new City(name:"New Delhi", population:26000000));
            cities.Add(new City(name:"Amsterdam", population:821752));
            cities.Add(new City(name:"Abu Dhabi", population:1450000));
            cities.Add(new City(name:"Zurich", population:402762));

            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*** City Database Search ***\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Search for cities by first and last letter");
                Console.Write("Enter letters divided by - (ex. a-b): ");
                string input = Console.ReadLine().ToLower().Trim();

                if (input.Length != 3 || !input.Contains("-")) { Console.Write("Invalid input, try again!"); Console.ReadKey(); continue; }
                else parsedInput = input.Split('-').ToList();

                var filteredCities = City.FindCityByFirstAndLast(cities, parsedInput).ToList();

                if(filteredCities.Count() > 0)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine($"Matches found: {filteredCities.Count()}");
                    filteredCities.ForEach(x => Console.WriteLine("Found: {0} with population of {1}", x.Name, x.Population));

                }
                else Console.WriteLine("Did not find any cities matching your search! Try again...");

                Console.ReadKey();
                var smallCity = (from p in cities orderby p.Population select p).First();
                Console.WriteLine("\nDid you know that by population the smallest city \nin database is {0} with population of {1}?",smallCity.Name,smallCity.Population);
                Console.ReadKey();
            }

        }
    }
}
