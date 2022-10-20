using System;
using System.Text.RegularExpressions;

namespace NHSNumberValidator
{
    public class NhsNumberValidator
    {
        /// <summary>
        /// The Check Number.  This is the Last number of the NHS Number
        /// </summary>
        private int _checkNumber;

        /// <summary>
        /// The NHS Number.  This is a String
        /// </summary>
        private string _nhsNumber;

        /// <summary>
        /// A array of multipliers
        /// </summary>
        private int[] _multipliers;

        /// <summary>
        /// Validates a NHS Number
        /// </summary>
        /// <param name="NHSNumber">String</param>
        public bool ValidateNHSNumber(string NHSNumber)
        {
            // Remove any white space from the NHSNumber
            _nhsNumber = NHSNumber.Replace(" ", string.Empty);

            // Create the multipliers array
            _multipliers = new int[9];

            _multipliers[0] = 10;
            _multipliers[1] = 9;
            _multipliers[2] = 8;
            _multipliers[3] = 7;
            _multipliers[4] = 6;
            _multipliers[5] = 5;
            _multipliers[6] = 4;
            _multipliers[7] = 3;
            _multipliers[8] = 2;

            // Make sure the input is valid
            return ValidateInput() && ValidateNhsNumber();
        }

        /// <summary>
        /// Validates the input
        /// Makes sure that the NHSNumber is numeric
        /// </summary>
        private bool ValidateInput()
        {
            var match = Regex.Match(_nhsNumber, "(\\d+)");
            return match.Success && _nhsNumber.Length == 10;
        }

        /// <summary>
        /// Validates the NHSNumber
        /// </summary>
        private bool ValidateNhsNumber()
        {
            // The current number
            var currentNumber = 0;

            // The sum of the multipliers
            var currentSum = 0;

            // The current multipliers in use
            var currentMultipliers = 0;

            // Get the check number
            var currentString = "";

            var checkDigit = _nhsNumber.Substring(_nhsNumber.Length - 1, 1);
            _checkNumber = Convert.ToInt16(checkDigit);

            // The remainder after the sum calculations
            var remainder = 0;

            // The total to be checked against the check number
            var total = 0;

            // Loop over each number in the string and calculate the current sum
            for (var i = 0; i <= 8; i++)
            {
                currentString = _nhsNumber.Substring(i, 1);

                currentNumber = Convert.ToInt16(currentString);
                currentMultipliers = _multipliers[i];
                currentSum += (currentNumber * currentMultipliers);
            }

            // Calculate the remainder and get the total
            remainder = currentSum % 11;
            total = 11 - remainder;

            // Now we have our total we can validate it against the check number
            if (total.Equals(11))
            {
                total = 0;
            }

            if (total.Equals(10))
            {
                return false;
            }

            return total.Equals(_checkNumber);
        }
    }
}
