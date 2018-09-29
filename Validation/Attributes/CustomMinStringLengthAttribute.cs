using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Interfaces;

namespace Validation.Attributes
{
    /// <summary>
    /// Validation attribute to assert a string property, field or parameter does not exceed a maximum length
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomMinStringLengthAttribute: Attribute, IValidationAttribute
    {
        /// <summary>
        /// Gets or sets the minimum acceptable length of the string
        /// </summary>
        public int MinLength { get; set; }

        public string ErrorMessage { get; set; }

        public CustomMinStringLengthAttribute(int minLength)
        {
            MinLength = minLength;
        }

        /// <summary>
        /// Inherited of <see cref="IValidationAttribute.IsValid(object)"/>
        /// </summary> 
        /// <param name="value">The value to test.</param>
        /// <returns><c>false</c> if the value is null or less than the set minimum length</returns>
        public bool IsValid(object value)
        {
            if (value == null)
                return true;
 
            int length = ((string)value).Length;
            
            if (length <= MinLength)
            {
                ErrorMessage = $"The length of the string has to be minimum {MinLength}!";

                return false;
            }

            return true;
        }
    }
}
