using mars_rover_case;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverCase.UnitTests
{
    public class ProgramTest
    {
        [Fact]
        public void Move_One_Rover()
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
                Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.M};

            //act
            string moveOutput = rover.Move();

            //assert
            Assert.Equal("1 3 N", moveOutput);
        }
    }
}
