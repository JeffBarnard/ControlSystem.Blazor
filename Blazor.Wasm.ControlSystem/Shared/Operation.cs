using Blazor.Wasm.ControlSystem.Shared.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    public class Operation //: IValidatableObject
    {
        public int OperationId { get; set; }
        public int StepId { get; set; }

        public string Label { get; set; }
        public string Hint { get; set; }

        [Required(AllowEmptyStrings=false)]
        [CustomOperationValidation]
        //[StringLength(10, ErrorMessage = "The value is too long.")]
        //[Range(0, 999.99)]
        public string Value { get; set; }
        public bool IsComplete { get; set; }
        public string Error { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(Error);

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (validationContext.MemberName == nameof(this.Value) || string.IsNullOrWhiteSpace(validationContext.MemberName))
        //    {
        //        if (Value.Contains(" "))
        //        {
        //            yield return new ValidationResult($"Whitespace is not allowed", new[] { nameof(Value) });
        //        }
        //    }
        //}

    }

}
