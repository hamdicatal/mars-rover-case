using mars_rover_case.Helpers;
using System;
using System.Collections.Generic;

namespace mars_rover_case
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaration of neccessary variables
            string plateauInfo;
            List<string> roversInfo;

            // creating rovers
            Rover rover1 = new Rover();
            Rover rover2 = new Rover();

            // getting input formats
            GetUserInputs(out plateauInfo, out roversInfo);

            // check user inputs
            bool inputCheck =  InputValidationHelper.CheckUserInputs(plateauInfo, roversInfo);
            if (inputCheck)
            {
                // creating plateau with given input
                Plateau plateau = CreatePlateau(plateauInfo);

                // creating rover vehicles
                CreateRovers(roversInfo, plateau, rover1, rover2);

                // move rovers on plateau
                MoveRovers(rover1, rover2);
            }
            else
            {
                Console.WriteLine("======================================");
                Console.WriteLine("Input Error! Please try again and give expected input.");
                Console.WriteLine("======================================");
            }
        }


        private static Plateau CreatePlateau(string plateauInfo)
        {
            string[] plateauDimensions = plateauInfo.Split(' ');
            return new Plateau(int.Parse(plateauDimensions[0]), int.Parse(plateauDimensions[1]));
        }

        private static void MoveRovers(Rover rover1, Rover rover2)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Waiting for results...");
            Console.WriteLine("======================================");

            Console.WriteLine(rover1.Move());
            Console.WriteLine(rover2.Move());
            Console.WriteLine("======================================");
        }

        private static void CreateRovers(List<string> roversInfo, Plateau plateau, Rover rover1, Rover rover2)
        {
            // setting up plateau dimensions for rovers
            rover1.SettingUpPlateuDimensions(plateau);
            rover2.SettingUpPlateuDimensions(plateau);

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
                    char[] roverCommands = info.ToCharArray();
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
                    char[] roverCommands = info.ToCharArray();
                    rover2.SettingUpCommands(roverCommands);
                }
                count++;
            }
        }

        private static void GetUserInputs(out string plateauInfo, out List<string> roversInfo)
        {
            Console.WriteLine("Welcome To Mars Rover Simulation");
            Console.WriteLine("Waiting for you inputs...");
            Console.WriteLine("======================================");

            plateauInfo = Console.ReadLine()?.ToUpper();

            roversInfo = new List<string>();
            roversInfo.Add(Console.ReadLine()?.ToUpper()); // rover1 first position
            roversInfo.Add(Console.ReadLine()?.ToUpper()); // rover1 commands

            roversInfo.Add(Console.ReadLine()?.ToUpper()); // rover2 first position
            roversInfo.Add(Console.ReadLine()?.ToUpper()); // rover2 commands
        }

    }
}
