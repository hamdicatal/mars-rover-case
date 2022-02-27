namespace mars_rover_case
{
    public class Plateau
    {
        public Plateau(int positionX, int positionY)
        {
            this.DimensionX = positionX;
            this.DimensionY = positionY;
        }

        /// <summary>
        /// Top right corner X coordinate
        /// </summary>
        public int DimensionX { get; set; }

        /// <summary>
        /// Top right corner Y coordinate
        /// </summary>
        public int DimensionY { get; set; } 
    }
}
