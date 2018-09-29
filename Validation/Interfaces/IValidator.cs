using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Validator;

namespace Validation.Interfaces
{
    /// <summary>
    /// Interface for Validation Service
    /// <typeparam name="T">Type of object that should be validated</typeparam>
    /// <para>Embody <see cref="Validate(T)"/> to implement validation logic.</para>
    /// </summary>
    public interface IValidator<T> where T: class 
    {
        ValidationResult Validate(T value);
    }
}
