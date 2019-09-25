using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace PrecipitationPrediction
{
    [TestFixture]
    public class PrecipitationTests
    {
        [Test]
        public void PrecipitationGivenDate()
        {
            /* No Input */
            string date = "9/21";

            /* Expected Output */
            string expectedOutput = $"\nThe predicted precipitation amount in the 27612 zipcode\nfor 9/21 is 0.135 units of precipitation.";

            /* Predicted Output */
            string predictedOutput = $"{PrecipitationOutput.Precipitation(date)}";

            /* Check to see if equal */
            Assert.AreEqual(expectedOutput, predictedOutput);
        }

        [Test]
        public void PrecipitationNoDate()
        {
            /* No Input */
            string date = "";

            /* Expected Output */
            string expectedOutput = $"\nThe predicted precipitation amount in the 27612 zipcode\nfor 9/25 is 0.56285714857143 units of precipitation.";

            /* Predicted Output */
            string predictedOutput = $"{PrecipitationOutput.Precipitation(date)}";

            /* Check to see if equal */
            Assert.AreEqual(expectedOutput, predictedOutput);
        }
    }
}
