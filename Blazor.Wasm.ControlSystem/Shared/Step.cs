using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    public class Step
    {
        public int StepId { get; set; }
        public string Name { get; set; }
        public StepState State { get; set; }

        public List<Operation> Operations { get; set; }
    }

    public enum StepState : int
    {
        NotSet,
        Started,
        Completed
    }
}
