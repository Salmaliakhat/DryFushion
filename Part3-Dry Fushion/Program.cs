using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_Dry_Fushion
{
    class Program
    {
        static void Main(string[] args)
        {
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            
            string input = File.ReadAllText(projectDirectory+ "/App_Data/weather.dat");
            List<Parser.Row> rows = Parser.ParseWeather(input);
            Parser.Row dayWithSmallestSpread = rows
                .OrderBy(x => x.AbsDiff)
                .First();
            Console.WriteLine($"Day: {dayWithSmallestSpread.Name}" +
                $" min: {dayWithSmallestSpread.ValueB}" +
                $" max: {dayWithSmallestSpread.ValueA}" +
                $" spread: {dayWithSmallestSpread.AbsDiff}");

            input = File.ReadAllText(projectDirectory + "/App_Data/football.dat");
            var teamWithSmallestDiff = Parser.ParseFootball(input)
                .OrderBy(x => x.AbsDiff)
                .First();
            Console.WriteLine($"Team: {teamWithSmallestDiff.Name}" +
                $" against: {teamWithSmallestDiff.ValueA}" +
                $" for: {teamWithSmallestDiff.ValueB}" +
                $" diff: {teamWithSmallestDiff.AbsDiff}");

            Console.ReadLine();
        }
    }
}
