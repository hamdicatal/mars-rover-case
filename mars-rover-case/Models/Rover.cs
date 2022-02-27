using System.Collections.Generic;

namespace mars_rover_case
{

    public class Rover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Direction Direction { get; set; }
        public List<Command> Commands { get; set; }
        public Plateau Plateau { get; set; }

        public void Move()
        {
            this.Plateau.Move(this.Direction, this.Commands);
        }
    }
}
