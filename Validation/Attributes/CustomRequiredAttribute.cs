using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Interfaces;

namespace Validation.Attributes
{
    /// <summary>
    /// Validation attribute to indicate that a property field or parameter is required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomRequiredAttribute : Attribute, IValidationAttribute
    {
        public string ErrorMessage { get; set; }

        public bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "An object or a field of an object can't be null";
                return false;
            }
            return true;
        }
    }
}
