using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars_rover_case.Helpers
{
    public static class InputValidationHelper
    {
        /// <summary>
        /// This method used for checking user input from terminal.
        /// </summary>
        /// <param name="plateauInfo"></param>
        /// <param name="roversInfo"></param>
        /// <returns></returns>
        public static bool CheckUserInputs(string plateauInfo, List<string> roversInfo)
        {
            // check plateau dimension inputs
            string[] plateauDimensions = plateauInfo.Split(' ');
            if (plateauDimensions.Length == 2)
            {
                for (int i = 0; i < plateauDimensions.Length; i++)
                {
                    bool isNumeric = int.TryParse(plateauDimensions[i], out int num);
                    if (!isNumeric || num < 0)
                        return false;
                }
            }
            else return false;

            // check rover inputs
            int count = 0;
            foreach (var info in roversInfo)
            {
                if (count == 0 || count == 2) // rovers first positions
                {
                    string[] roverFirstPosition = info.Split(' ');
                    if (roverFirstPosition.Length == 3)
                    {
                        // check rovers first position coordinates
                        for (int i = 0; i < roverFirstPosition.Length - 1; i++)
                        {
                            bool isNumeric = int.TryParse(roverFirstPosition[i], out _);
                            if (!isNumeric)
                                return false;
                        }

                        // check rover first direction
                        char[] expectedDirections = new char[] { 'N', 'E', 'S', 'W' };
                        int dirIndex = Array.IndexOf(expectedDirections, char.Parse(roverFirstPosition[2]));
                        if (dirIndex == -1)
                            return false;
                    }
                    else return false;
                }
                else if (count == 1 || count == 3) // rovers commands
                {
                    char[] roverCommands = info.ToCharArray();
                    char[] expectedCommands = new char[] { 'L', 'R', 'M' };

                    if (roverCommands.Length > 0)
                    {
                        for (int i = 0; i < roverCommands.Length; i++)
                        {
                            int numIndex = Array.IndexOf(expectedCommands, roverCommands[i]);
                            if (numIndex == -1)
                                return false;
                        }
                    }
                    else return false;
                }

                count++;
            }

            return true;

        }
    }
}
