﻿using System;
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
            string[]  lines = File.ReadAllLines(csvPath);

            //--------------------------------------------------------
            logger.LogInfo($"Lines: {lines[0]}"); //Logging how MANY lines we got from CSV


            //--------------------------------------------------------
            // Create a new instance of your TacoParser class
            TacoParser parser = new TacoParser();
            logger.LogInfo("Created TacoParser Class"); //Loggin INFO


            //--------------------------------------------------------
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            //LINQ delegate reference  to a method, method reference - not technically a method call
            //you are passing a reference so  delegate ref <==> (parser.Parse)   vs (parser.Parse())
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

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;

            // Include the Geolocation toolbox, so you can compare
            // locations: `using GeoCoordinatePortable;`  [DONE]

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            //Class Version
            double kilometerConvert = 0.000621371;

            double distance = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                ITrackable locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int x = 0; x < locations.Length; x++)
                {
                    ITrackable locB = locations[x];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }

                }//for inner
            }//for outter 
            Console.WriteLine($"Longest Distance in Miles: {distance*kilometerConvert}, {tacoBell1.Name}, {tacoBell2.Name}");
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
