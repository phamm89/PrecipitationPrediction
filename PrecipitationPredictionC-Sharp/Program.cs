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

                /* Counters */
                    /* precipSum will store accumulated precipitation totals for each date value in data that matches input */
                double precipSum=0;
                    /* count will increase each time a data value matches input date */
                double count=0;
                    /* Average Precipitation */
                double avgPRCP=0;
                int j=0;

                /* Find the corresponding date values from the JSON data */
                /* There are 4492 data values in the JSON data */
		for (int i = 0; i < 4492; i++)
		{
			/* Return the average precipitation for the corresponding input date */
			if (precipData[i].DATE == date)
			{
				/* Print statement test to provide output for each entry that corresponded with input date
                        	Console.WriteLine($"\nThe predicted precipitation value for {date} was {avgPRCP}"); 
                        	*/
                        	/* Store the precipitation value as a string and convert to a double */
                        	string dataInt = precipData[i].PRCP;
                        	double dataInteger = Convert.ToDouble(dataInt);

                        	/* Calculate total precipitation on a given date based on data */
                        	precipSum = precipSum + dataInteger;

                        	count++;

                        	/* Calculate average precipitation for given date */
                        	avgPRCP = precipSum/count;
			}
                    	if (precipData[i].DATE != date)
                    	{
                        	j++;
                    	}

                }
                Console.WriteLine($"\nThe predicted precipitation amount for {date} is {avgPRCP} units of precipitation.");
            }
            return $"\nIf you would like to predict the precipitation for another date, \nplease run the app again.";
        }
    } 
} 
