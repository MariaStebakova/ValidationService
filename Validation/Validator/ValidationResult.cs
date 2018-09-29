using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Validator
{
    /// <summary>
    /// Class to storage the information about validation
    /// <para><see cref = "ValidationConclusion"/>is used for the result about validation</para>
    /// <para><see cref = "ValidationErrors"/>is used for the errors of validation if validation has failed</para>
    /// </summary>
    public class ValidationResult
    {
        public bool ValidationConclusion { get; }
        public List<string> ValidationErrors { get; }

        public ValidationResult(bool validationConclusion, List<string> errors)
        {
            ValidationConclusion = validationConclusion;
            ValidationErrors = errors;
        }
    }
}
