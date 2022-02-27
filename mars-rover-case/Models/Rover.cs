using System;
using System.Collections.Generic;

namespace mars_rover_case
{

    public class Rover
    {
        public int PlateauDimensionX { get; set; }
        public int PlateauDimensionY { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Direction Direction { get; set; }
        public List<Command> Commands { get; set; }

        #region Move Process

        /// <summary>
        /// This is our main move method.
        /// </summary>
        public string Move()
        {
            // loop in the all given commands
            foreach (var cmd in this.Commands)
            {
                // if command is left, find new direction for left command
                if (cmd == Command.L)
                {
                    this.Direction = this.FindNextLeftDirection(this.Direction);
                }
                // if command is right, find new direction for right command
                else if (cmd == Command.R)
                {
                    this.Direction = this.FindNextRightDirection(this.Direction);
                }
                // if command is move, change currentPosition of rover in plateau
                else if (cmd == Command.M)
                {
                    if (this.Direction == Direction.N)
                        this.PositionY++;
                    else if (this.Direction == Direction.E)
                        this.PositionX++;
                    else if (this.Direction == Direction.S)
                        this.PositionY--;
                    else if (this.Direction == Direction.W)
                        this.PositionX--;

                    this.PlateauBorderControl(); // for border exceed control
                }
            }

            return $"{PositionX} {PositionY} {Direction}";
        }

        /// <summary>
        /// If rover exceeds the border limits, this method will arrange
        /// </summary>
        public void PlateauBorderControl()
        {
            if (this.Direction == Direction.N && this.PositionY > this.PlateauDimensionY)
                this.PositionY = this.PlateauDimensionY;
            else if (this.Direction == Direction.E && this.PositionX > this.PlateauDimensionX)
                this.PositionX = this.PlateauDimensionX;
            else if (this.Direction == Direction.S && this.PositionY < 0)
                this.PositionY = 0;
            else if (this.Direction == Direction.W && this.PositionX < 0) 
                this.PositionX = 0;
        }

        /// <summary>
        /// This method find the new direction for "left" command
        /// </summary>
        /// <param name="currentDirection"></param>
        /// <returns></returns>
        public Direction FindNextLeftDirection(Direction currentDirection)
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
        public Direction FindNextRightDirection(Direction currentDirection)
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

        #endregion

        #region Position, Direction and Command Process

        public void SettingUpPositionAndDirection(int posX, int posY, Direction dir)
        {
            this.PositionX = posX;
            this.PositionY = posY;
            this.Direction = dir;
        }

        public void SettingUpCommands(string[] commands)
        {
            this.Commands = new List<Command>();
            for (int i = 0; i < commands.Length; i++)
            {
                Command cmd = (Command)Enum.Parse(typeof(Command), commands[i]);
                this.Commands.Add(cmd);
            }
        }

        #endregion

        #region Plateau Process

        public void SettingUpPlateuDimensions(Plateau plateau)
        {
            this.PlateauDimensionX = plateau.DimensionX;
            this.PlateauDimensionY = plateau.DimensionY;
        }

        #endregion
    }
}
