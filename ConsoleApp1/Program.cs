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
            int numberOfTeams = 0; // initialize variable so it plays nicely with for loop scope
            // set error flag
            bool accepted = false;
 
            while (!accepted)
            {
                try 
                {
                    Console.Write("How many teams? ");
                    numberOfTeams = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    accepted = true; // input accepted
                }
                catch (Exception ex)
                {
                    Console.Write("Invalid Input...Try Again");
                    Console.WriteLine("\n");
                }    
            }   

            // initialize List of teams with size numberOfTeams
            List<SoccerTeam> soccerTeams = new List<SoccerTeam>();

            // ask for team names
            string name; // placeholder var for input
            int points; // placebolder var for points
            for (int i = 0; i < numberOfTeams; i++)
            {
                accepted = false; // reset error flag
                Console.Write("Enter Team " + (i + 1) + "\'s name: ");
                name = UppercaseFirst(Console.ReadLine());
                soccerTeams.Add(new SoccerTeam());
                soccerTeams[i].name = name;
                Console.WriteLine();
                while (!accepted)
                {
                    try 
                    {
                        Console.Write("Enter Team " + soccerTeams[i].name + "\'s points: ");
                        points = Convert.ToInt32(Console.ReadLine());
                        soccerTeams[i].points = points;
                        Console.WriteLine("\n");
                        accepted = true; // accepted input
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Invalid Input...Try Again");
                        Console.WriteLine("\n");
                    }
                }  
            }

            // sort list desc by points
            List<SoccerTeam> sortedTeams = soccerTeams.OrderByDescending(team => team.points).ToList();

            // display formatted data
            Console.WriteLine("Here is the sorted list:\n");
            Console.WriteLine("Position\t\t Name\t\t\t  Points");
            Console.WriteLine("--------\t\t ----\t\t\t  ------");
            int pos = 1; // position var

            // placeholders for formatted data to output in table
            string formattedName;
            string formattedPoints;
            string formattedPos; 

            foreach (SoccerTeam team in sortedTeams)
            {
                formattedName = Convert.ToString(team.name).PadRight(25, ' ');
                formattedPoints = Convert.ToString(team.points).PadRight(25, ' ');
                formattedPos = Convert.ToString(pos).PadRight(25, ' ');
                Console.WriteLine(formattedPos + formattedName + formattedPoints);
                pos++;
            }

            // End programs
            Console.WriteLine("\n\n");
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
