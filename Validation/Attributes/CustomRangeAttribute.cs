using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Interfaces;

namespace Validation.Attributes
{
    /// <summary>
    /// Used for specifying a range constraint
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomRangeAttribute : Attribute, IValidationAttribute
    {
        /// <summary>
        /// Gets or sets the minimum value for the range
        /// </summary>
        public int Minimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the range
        /// </summary>
        public int Maximum { get; set; }

        public string ErrorMessage { get; set; }

        /// <summary>
        /// Constructor that takes integer minimum and maximum values
        /// </summary>
        /// <param name="minimum">The minimum value, inclusive</param>
        /// <param name="maximum">The maximum value, inclusive</param>
        public CustomRangeAttribute(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Returns true if the value falls between min and max, inclusive.
        /// </summary>
        /// <param name="value">The value to test for validity.</param>
        /// <returns><c>true</c> means the <paramref name="value"/> is valid</returns>
        public bool IsValid(object value)
        {

            if (value == null)
                return true;

            int intValue = (int) value;
 

            if (intValue <= Minimum || intValue >= Maximum)
            {
                ErrorMessage = $"The value of the number has to be in range of [{Minimum}, {Maximum}]!";

                return false;
            }

            return true;
        }

    }
}
