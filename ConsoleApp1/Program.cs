using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams;
            Console.Write("How many teams? ");
            numberOfTeams = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            // initialize List of teams with size numberOfTeams
            List<SoccerTeam> soccerTeams = new List<SoccerTeam>();

            // ask for team names
            string name; // placeholder var for input
            int points; // placebolder var for points
            for (int i = 0; i < numberOfTeams; i++)
            {
                Console.Write("Enter Team " + (i + 1) + "\'s name: ");
                name = UppercaseFirst(Console.ReadLine());
                soccerTeams.Add(new SoccerTeam());
                soccerTeams[i].name = name;
                Console.WriteLine();
                Console.Write("Enter Team " + soccerTeams[i].name + "\'s points: ");
                points = Convert.ToInt32(Console.ReadLine());
                soccerTeams[i].points = points;
                Console.WriteLine("\n");
            }

            // sort list desc by points
            List<SoccerTeam> sortedTeams = soccerTeams.OrderByDescending(team => team.points).ToList();

            // display formatted data
            Console.WriteLine("Position\t\tName\t\tPoints");
            Console.WriteLine("--------\t\t----\t\t------");
            for (int i = 0; i < numberOfTeams; i++)
            {
                Console.WriteLine((i + 1) + "       \t\t" + sortedTeams[i].name + "\t\t" + sortedTeams[i].points);
            }

            // End programs
            Console.WriteLine("\n\nPress any key to continue . . .");
            Console.ReadKey();
        }

        // given function to make first letter uppercase
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
