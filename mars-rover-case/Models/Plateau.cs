using System;
using System.Collections.Generic;

namespace mars_rover_case
{
    public class Plateau
    {
        public Plateau(int positionX, int positionY)
        {
            this.DimensionX = positionX;
            this.DimensionY = positionY;
            this.Grid = new int[positionY, positionX];
        }

        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Direction CurrentDirection { get; set; }
        public int[,] Grid { get; set; }

        public void Move(Direction direction, List<Command> commands)
        {
            // loop in all commands
            foreach (var cmd in commands)
            {
                // if command is left, find new direction for left command
                if (cmd == Command.L)
                {
                    CurrentDirection = this.FindNextLeftDirection(this.CurrentDirection);
                }
                // if command is right, find new direction for right command
                else if (cmd == Command.R)
                {
                    CurrentDirection = this.FindNextRightDirection(this.CurrentDirection);
                }
                // if command is move, change currentPosition of rover in plateau
                else if(cmd == Command.M)
                {
                    if (this.CurrentDirection == Direction.N)
                        this.CurrentPositionY++;
                    else if (this.CurrentDirection == Direction.E)
                        this.CurrentPositionX++;
                    else if (this.CurrentDirection == Direction.S)
                        this.CurrentPositionY--;
                    else if (this.CurrentDirection == Direction.W)
                        this.CurrentPositionX--;
                }
            }

            Console.WriteLine($"{CurrentPositionX} {CurrentPositionY} {CurrentDirection}");
        }

        /// <summary>
        /// This method find the new direction for "left" command
        /// </summary>
        /// <param name="currentDirection"></param>
        /// <returns></returns>
        private Direction FindNextLeftDirection(Direction currentDirection)
        {
            if (currentDirection == Direction.N)
                return Direction.W;
            else if (currentDirection == Direction.E)
                return Direction.N;
            else if (currentDirection == Direction.S)
                return Direction.E;
            else if (currentDirection == Direction.W)
                return Direction.S;
            return currentDirection;
        }

        /// <summary>
        /// This method find the new direction for "right" command
        /// </summary>
        /// <param name="currentDirection"></param>
        /// <returns></returns>
        private Direction FindNextRightDirection(Direction currentDirection)
        {
            if (currentDirection == Direction.N)
                return Direction.E;
            else if (currentDirection == Direction.E)
                return Direction.S;
            else if (currentDirection == Direction.S)
                return Direction.W;
            else if (currentDirection == Direction.W)
                return Direction.N;
            return currentDirection;
        }

    }
}
