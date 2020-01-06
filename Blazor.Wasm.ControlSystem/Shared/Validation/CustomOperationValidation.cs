using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Wasm.ControlSystem.Shared.Validation
{
    public class CustomOperationValidation : ValidationAttribute
    {
        public CustomOperationValidation()
        {

        }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if ((value as string).Contains(" "))
            {
                return new ValidationResult("Whitespace is not allowed.", new[] { validationContext.MemberName });
            }

            return null;
        }
    }
}
