using System.Collections.Generic;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            string[] cells = line.Split(','); //   {34.071477,  -84.296345,  Taco Bell Alpharett}

            logger.LogInfo("Finished the line split");
            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("The Array length was less than 3");    // Log that and return null

                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            // grab the latitude from your array at index 0
            logger.LogInfo("Assign cell[0]");
            double dblTacoLATPt = double.Parse(cells[0]);

            // grab the longitude from your array at index 1
            logger.LogInfo("Assign cell[1]");
            double dblTacoLONGPt = double.Parse(cells[1]);

            // grab the name from your array at index 2
            logger.LogInfo("Assign cell[2]");
            string tacboBellName = cells[2];




            logger.LogInfo("Create TacoBellPt POINT ");
            Point tacoBellPoint = new Point();
            tacoBellPoint.Latitude = dblTacoLATPt;
            tacoBellPoint.Longitude = dblTacoLONGPt;

            TacoBell tacoBellNamLoc = new TacoBell();
            tacoBellNamLoc.Name = tacboBellName;
            tacoBellNamLoc.Location = tacoBellPoint;

            // You'll need to create a TacoBell class
            // that *****conforms to ITrackable******* [DONE]

            // Then, you'll need an instance of the TacoBell class
            // With the name and [point set] correctly;
            logger.LogInfo("Create Tacbobell class instance, assign Name and POINT ");
            tacoBellNamLoc = new TacoBell() { Name = tacboBellName, Location = tacoBellPoint };

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            //we have CONVERTED the Lat/Long as two separate doubles, and
            //returning them as a POINT <==> LAT/LONG position 
            logger.LogInfo("Return tacoBelNamLoc");
            return tacoBellNamLoc;
        }//Method

    }//class
}//LoggingKata