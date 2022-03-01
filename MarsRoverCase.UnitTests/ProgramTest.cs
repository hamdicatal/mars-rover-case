using MarsRoverCase;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverCase.UnitTests
{
    public class ProgramTest
    {
        [Fact]
        public void Move_One_Rover_And_Check_Output()
        {
            //arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover();
            rover.PlateauDimensionX = plateau.DimensionX;
            rover.PlateauDimensionY = plateau.DimensionY;
            rover.PositionX = 1;
            rover.PositionY = 2;
            rover.Direction = Direction.N;
            rover.Commands = new List<Command>() {
                Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.M
            };

            //act
            string moveOutput = rover.Move();

            //assert
            Assert.Equal("1 3 N", moveOutput);
        }

        [Fact]
        public void Move_One_Border_Exceed_Rover_And_Check_Output()
        {
            //arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover();
            rover.PlateauDimensionX = plateau.DimensionX;
            rover.PlateauDimensionY = plateau.DimensionY;
            rover.PositionX = 1;
            rover.PositionY = 2;
            rover.Direction = Direction.N;
            rover.Commands = new List<Command>() {
                Command.M, Command.L, Command.M, Command.M, Command.M
            };

            //act
            string moveOutput = rover.Move();

            //assert
            Assert.StartsWith("0 3 W", moveOutput);
        }

        [Fact]
        public void PlateauBorderControl_Check_Border_Exceed_North()
        {
            //arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover();
            rover.PlateauDimensionX = plateau.DimensionX;
            rover.PlateauDimensionY = plateau.DimensionY;
            rover.PositionY = 6; // border exceeded
            rover.Direction = Direction.N;

            //act
            rover.PlateauBorderControl();

            //assert
            Assert.Equal(plateau.DimensionY, rover.PositionY);
        }

        [Fact]
        public void PlateauBorderControl_Check_Border_Exceed_West()
        {
            //arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover();
            rover.PlateauDimensionX = plateau.DimensionX;
            rover.PlateauDimensionY = plateau.DimensionY;
            rover.PositionX = -1; // border exceeded
            rover.Direction = Direction.W;

            //act
            rover.PlateauBorderControl();

            //assert
            Assert.Equal(0, rover.PositionX);
        }

        [Fact]
        public void FindNextLeftDirection_Check_New_Direction()
        {
            //arrange
            var rover = new Rover();
            rover.Direction = Direction.N;
            
            //act
            Direction direction = rover.FindNextLeftDirection(rover.Direction);

            //assert
            Assert.Equal(Direction.W, direction);
        }

        [Fact]
        public void FindNextRightDirection_Check_New_Direction()
        {
            //arrange
            var rover = new Rover();
            rover.Direction = Direction.N;

            //act
            Direction direction = rover.FindNextRightDirection(rover.Direction);

            //assert
            Assert.Equal(Direction.E, direction);
        }
    }
}
