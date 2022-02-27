using System;
using System.Collections.Generic;

namespace mars_rover_case
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> roversInfo = new List<string>();

            Console.WriteLine("Welcome To Mars Rover Simulation");
            Console.WriteLine("Waiting for you inputs...");

            // getting inputs
            string plateauInfo = Console.ReadLine();

            roversInfo.Add(Console.ReadLine()); // rover1 first position
            roversInfo.Add(Console.ReadLine()); // rover1 commands

            roversInfo.Add(Console.ReadLine()); // rover2 first position
            roversInfo.Add(Console.ReadLine()); // rover2 commands

            // creating plateau with given input
            string[] plateauDimensions = plateauInfo.Split(' ');
            Plateau plateau = new Plateau(int.Parse(plateauDimensions[0]), int.Parse(plateauDimensions[1]));

            // creating rovers
            Rover rover1 = new Rover();
            Rover rover2 = new Rover();

            // setting up plateau dimensions for rovers
            rover1.SettingUpPlateuDimensions(plateau);
            rover2.SettingUpPlateuDimensions(plateau);

            // 
            int count = 0;
            foreach (var info in roversInfo)
            {
                if (count == 0) // setting up rover1 position and direction
                {
                    string[] roverFirstPosition = info.Split(' ');
                    rover1.SettingUpPositionAndDirection(
                        int.Parse(roverFirstPosition[0]), // Position X
                        int.Parse(roverFirstPosition[1]), // Position Y
                        (Direction)Enum.Parse(typeof(Direction), roverFirstPosition[2]) // Direction
                    );
                }
                else if (count == 1) // setting up rover1 commands
                {
                    string[] roverCommands = info.Split(' ');
                    rover1.SettingUpCommands(roverCommands);
                }
                else if (count == 2) // setting up rover2 position and direction
                {
                    string[] roverFirstPosition = info.Split(' ');
                    rover2.SettingUpPositionAndDirection(
                        int.Parse(roverFirstPosition[0]), // Position X
                        int.Parse(roverFirstPosition[1]), // Position Y
                        (Direction)Enum.Parse(typeof(Direction), roverFirstPosition[2]) // Direction
                    );
                }
                else if (count == 3) // setting up rover2 commands
                {
                    string[] roverCommands = info.Split(' ');
                    rover2.SettingUpCommands(roverCommands);
                }
                count++;
            }

            Console.WriteLine("Waiting for results...");

            Console.WriteLine(rover1.Move());
            Console.WriteLine(rover2.Move());

        }
    }
}
