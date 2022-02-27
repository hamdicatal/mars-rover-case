using System;
using System.Collections.Generic;

namespace mars_rover_case
{
    class Program
    {
        // temel olarak case'deki çıktıyı verecek şekilde düzenlemeler yapıldı.

        // todo: unit testleri yazılacak.
        // todo: plato sınırlarının dışına çıkması durumu için kontroller eklenecek. 0'dan küçükse veya 5'den büyük 0 setlenebilir. 

        static void Main(string[] args)
        {
            string plateauInfo = string.Empty;
            List<string> roversInfo = new List<string>();

            Console.WriteLine("Welcome To Mars Rover Simulation");
            Console.WriteLine("Waiting for you inputs...");

            // getting inputs
            plateauInfo = Console.ReadLine();

            roversInfo.Add(Console.ReadLine()); // rover1 first position
            roversInfo.Add(Console.ReadLine()); // rover1 commands

            roversInfo.Add(Console.ReadLine()); // rover2 first position
            roversInfo.Add(Console.ReadLine()); // rover2 commands

            // creating plateaus
            string[] plateauDimensions = plateauInfo.Split(' ');
            Plateau plateau1 = new Plateau(int.Parse(plateauDimensions[0]), int.Parse(plateauDimensions[1]));
            Plateau plateau2 = new Plateau(int.Parse(plateauDimensions[0]), int.Parse(plateauDimensions[1]));

            // creating rovers
            Rover rover1 = new Rover();
            Rover rover2 = new Rover();

            int count = 0;
            foreach (var info in roversInfo)
            {
                if (count == 0) // setting up rover1 position and direction
                {
                    string[] roverFirstPosition = info.Split(' ');
                    rover1.PositionX = int.Parse(roverFirstPosition[0]);
                    rover1.PositionY = int.Parse(roverFirstPosition[1]);
                    rover1.Direction = (Direction)Enum.Parse(typeof(Direction), roverFirstPosition[2]);
                }
                else if (count == 1) // setting up rover1 commands
                {
                    string[] roverCommands = info.Split(' ');
                    rover1.Commands = new List<Command>();

                    for (int i = 0; i < roverCommands.Length; i++)
                    {
                        Command cmd = (Command)Enum.Parse(typeof(Command), roverCommands[i]);
                        rover1.Commands.Add(cmd);
                    }
                }
                else if (count == 2) // setting up rover2 position and direction
                {
                    string[] roverFirstPosition = info.Split(' ');
                    rover2.PositionX = int.Parse(roverFirstPosition[0]);
                    rover2.PositionY = int.Parse(roverFirstPosition[1]);
                    rover2.Direction = (Direction)Enum.Parse(typeof(Direction), roverFirstPosition[2]);
                }
                else if (count == 3) // setting up rover2 commands
                {
                    string[] roverCommands = info.Split(' ');
                    rover2.Commands = new List<Command>();

                    for (int i = 0; i < roverCommands.Length; i++)
                    {
                        Command cmd = (Command)Enum.Parse(typeof(Command), roverCommands[i]);
                        rover2.Commands.Add(cmd);
                    }
                }
                count++;
            }

            // adding plateau infos to rovers and setting up plateaus current positions
            rover1.Plateau = plateau1;
            rover1.Plateau.CurrentPositionX = rover1.PositionX;
            rover1.Plateau.CurrentPositionY = rover1.PositionY;
            rover1.Plateau.CurrentDirection = rover1.Direction;

            rover2.Plateau = plateau2;
            rover2.Plateau.CurrentPositionX = rover2.PositionX;
            rover2.Plateau.CurrentPositionY = rover2.PositionY;
            rover2.Plateau.CurrentDirection = rover2.Direction;

            Console.WriteLine("Waiting for results...");

            rover1.Move();
            rover2.Move();

        }
    }
}
