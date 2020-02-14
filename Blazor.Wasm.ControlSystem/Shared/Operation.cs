using Blazor.Wasm.ControlSystem.Shared.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    /// <summary>
    /// An operation is an item in the process that must be completed
    /// </summary>
    public class Operation //: IValidatableObject
    {
        public Action ValueChanged { get; set; }

        public int OperationId { get; set; }
        public int StepId { get; set; }

        public OperationType Type { get; set; }

        public string Label { get; set; }
        public string Hint { get; set; }

        private string _value;
        [Required(AllowEmptyStrings = false)]
        [CustomOperationValidation]
        [StringLength(10, ErrorMessage = "The value is too long.")]
        //[Range(0, 999.99)]
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged?.Invoke();
            }
        }

        public bool IsChecked
        {
            get => bool.Parse(string.IsNullOrEmpty(Value) ? "False" : Value);
            set => Value = value == false ? null : value.ToString();
        }

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
