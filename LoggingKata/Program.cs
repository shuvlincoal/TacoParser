using System;
using System.Linq;
using System.IO;

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Input;
using GeoCoordinatePortable;
//using System.Device.Location.GeoCoordinateWatcher;
//using System.Device.Location.GeoCoordinate

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  OJBECITIVE:
            // Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            //--------------------------------------------------------
            logger.LogInfo("Log initialized"); //Loggin INFO

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);


            //--------------------------------------------------------
            logger.LogInfo($"Lines: {lines[0]}"); //Logging how MANY lines we got from CSV


            //--------------------------------------------------------
            // Create a new instance of your TacoParser class
            TacoParser parser = new TacoParser();
            logger.LogInfo("Created TacoParser Class"); //Loggin INFO


            //--------------------------------------------------------
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            ITrackable[] locations = lines.Select(parser.Parse).ToArray();
            logger.LogInfo("Finished Parsing all of the CSV file with TacoBell Locations\n\n\n");
            Console.WriteLine("Press Return To Find stores furthest apart> ");
            Console.ReadLine();

            //--------------------------------------------------------
            // DON'T FORGET TO LOG YOUR STEPS
            // Now that your Parse method is completed, START BELOW ----------


            // TODO: Create two `ITrackable` variables with initial values of `null`. These
            // will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable trackable1 = null;
            ITrackable trackable2 = null;

            // Include the Geolocation toolbox, so you can compare
            // locations: `using GeoCoordinatePortable;`  [DONE]




            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            double longestDistance    = 0;
            double tmpMeters = 0;
            double tmpMiles = 0;
            string name1 = "";
            string name2 = "";
            double kilometerConvert = 0.000621371;

            for (int i=0; i<locations.Length; i++)
            {
                //Console.WriteLine($"LOCATION Name:{locations[i].Name}, LAT/LONG:{locations[i].Location} ");
                GeoCoordinate geoCordA = new GeoCoordinate();
                geoCordA.Latitude  = locations[i].Location.Latitude;
                geoCordA.Longitude = locations[i].Location.Longitude;

                //Point pointA = locations[i].Location;
                for (int j=0; j<locations.Length; j++)
                {
                    GeoCoordinate geoCordB = new GeoCoordinate();
                    geoCordB.Latitude  = locations[j].Location.Latitude;
                    geoCordB.Longitude = locations[j].Location.Longitude;
                    tmpMeters = geoCordA.GetDistanceTo(geoCordB);
                    tmpMiles = tmpMeters  * kilometerConvert;
                    if ( tmpMiles > longestDistance)
                    {
                        longestDistance = tmpMiles;
                        name1 = locations[i].Name;
                        name2 = locations[j].Name;
                    }//if

                }//for inner
            }//for outter 
            Console.WriteLine($"Longest Distance in Miles: {longestDistance}, {name1}, {name2}");
            Console.WriteLine("Press Return To Continue> ");
            Console.ReadLine();

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }//Methd
    }//Class
}//Namespace
