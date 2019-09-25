using System;
using System.IO;
using Newtonsoft.Json;

namespace PrecipitationPrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Print introduction statement for app */
            Console.WriteLine("Welcome to the precipitation prediction app!\nLet's take a look at how much precipitation you will expect in the 27612 Zipcode.");

            /* Ask user to provide an input date for precipitation prediction */
            Console.WriteLine("\nWhat date would you like to examine precipitation for?\n(e.g. month/day input, such as 10/22 or 5/19): ");
            string date = Console.ReadLine();

            /* Take date input from user to find precipitation */
            string prediction = PrecipitationOutput.Precipitation(date);

            /* Provide output for precipitation on given date */
            Console.WriteLine(prediction);
        }
    }

    public static class PrecipitationOutput
    {
        /* Precipitation class requires date input */
        public static string Precipitation(string date)
        {
            /* Use StreamReader to read JSON file */
            using (StreamReader precip = new StreamReader(@"precipitation.json"))
            {
                string json = precip.ReadToEnd();

                /* JSON Deserialization */
				var precipData = JsonConvert.DeserializeObject<dynamic>(json);
            
                /* Assign current date if input date is blank */
                if (date == "")
                {
                    date = DateTime.Now.ToString("M/d");
                }

                /* Find the corresponding date values from the JSON data */
                int j = 0;
				for (int i = 0; i < 4492; i++)
				{
					/* Return the average precipitation for the corresponding input date */
					if (precipData[i].DATE == date)
					{
						return $"\nThe predicted precipitation for {date} is {precipData[i].PRCP} in the 27612 zipcode. {j} times";
					}
                    j++;
				}
				/* If there is no data, then return the following. */
				return $"\nThere is no historical data available to predict precipitation for {date}.";
            }
        }
    } 
} 
