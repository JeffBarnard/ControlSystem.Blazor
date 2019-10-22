using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    public class Operation
    {
        public int OperationId { get; set; }
        public int StepId { get; set; }

        public string Label { get; set; }
        public string Hint { get; set; }
        public string Value { get; set; }
        public bool IsComplete { get; set; }
        public string Error { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(Error);

    }

}
