using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Logging;
using Validation.Interfaces;

namespace Validation.Validator
{
    /// <summary>
    /// Class that implements functionality of validation service
    /// <typeparam name="T">Type of object that should be validated</typeparam>
    /// </summary>

    public class Validator<T> : IValidator<T> where T: class
    {
        private readonly ILogger logger;

        /// <summary>
        /// Standart .ctor of <see cref="Validator{T}"/> class
        /// </summary>
        public Validator()
        {
            logger = new NLogger();
        }

        /// <summary>
        /// Standart .ctor of <see cref="Validator{T}"/> class
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> logger</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="logger"></param> is equal to null</exception>
        public Validator(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} can't be equal to null!");
        }

        /// <summary>
        /// Public method for object validation
        /// </summary>
        /// <param name="value">Current validated object</param>
        /// <returns><see cref="ValidationResult"/> object that represent the result of validation</returns>
        /// <exception cref="ArgumentNullException">Throws when <param name="value"></param> is equal to null</exception>
        public ValidationResult Validate(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null!");
            }

            bool result = true;
            List<string> errors = new List<string>();

            //Searching for all class properties attributes
            foreach (var prop in value.GetType().GetProperties())
            {
                if (prop.CustomAttributes != null)
                {
                    if (!ValidateProperty(prop, value, errors))
                    {
                        result = false;
                    }
                }
            }

            return new ValidationResult(result, errors);
        }

        /// <summary>
        /// Method for property validation
        /// </summary>
        /// <param name="property">Property info</param>
        /// <param name="instance">Object that contains the property</param>
        /// <param name="errorList">List of errors during the validation</param>
        /// <returns>Is property valid or not</returns>
        private bool ValidateProperty(PropertyInfo property, T instance, List<string> errorList)
        {
            bool result = true;

            foreach (var a in property.GetCustomAttributes(typeof(IValidationAttribute), false))
            {
                if (a is IValidationAttribute attribute)
                {
                    var value = instance.GetType().GetProperty(property.Name).GetValue(instance, null);
 
                    if (!attribute.IsValid(value))
                    {
                        errorList.Add(attribute.ErrorMessage);
                        logger.Warn(attribute.ErrorMessage);

                        result = false;
                    }
                }
            }

            return result;
        }

     
    }
}
