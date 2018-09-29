using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Interfaces
{
    /// <summary>
    /// Interface for all validation attributes.
    /// <para>Embody <see cref="IsValid(object)"/> to implement validation logic.</para>
    /// <para><see cref="ErrorMessage"/> is used to provide a non-localized error message.</para>
    /// </summary>
    public interface IValidationAttribute
    {
        string ErrorMessage { get; set; }
        bool IsValid(object value);
    }
}
