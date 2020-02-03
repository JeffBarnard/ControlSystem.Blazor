using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    public class StepController
    {
        public List<Step> Steps { get; set; }

        public Action ValueChanged { get; set; }

        public bool AllStepsComplete { get; set; }

        public StepController()
        {
            Steps = new List<Step>()
            {
                new Step { StepId = 1, Name = "Measure Gears", State = StepState.NotSet, Operations = new List<Operation> {
                    new Operation() { StepId = 1, OperationId = 1, Label = "Measure ratio", Hint = "0-12cm" },
                    new Operation() { StepId = 1, OperationId = 1, Label = "Measure final", Hint = "5-10cm" },
                    new Operation() { StepId = 1, OperationId = 1, Label = "Weigh set", Hint = "25-50kg" },
                    new Operation() { StepId = 1, OperationId = 1, Label = "Validate free play", Hint = "1-2mm" },
                    }
                },
                new Step { StepId = 2, Name = "Measure Clutch", State = StepState.NotSet, Operations = new List<Operation> {
                    new Operation() { StepId = 2, OperationId = 1, Label = "Shim stack", Hint = "3-4" },
                    new Operation() { StepId = 2, OperationId = 1, Label = "Visually inspect", Hint = "" },
                    new Operation() { StepId = 2, OperationId = 1, Label = "Weigh basket", Hint = "20-25kg" },
                    }
                },
                new Step { StepId = 3, Name = "Install Drive", State = StepState.NotSet, Operations = new List<Operation> {
                    new Operation() { StepId = 3, OperationId = 1, Label = "Measure spline", Hint = "12-14cm" },
                    new Operation() { StepId = 3, OperationId = 1, Label = "Measure shim", Hint = "" },
                    new Operation() { StepId = 3, OperationId = 1, Label = "Insert spline drive", Hint = "" },
                    new Operation() { StepId = 3, OperationId = 1, Label = "Validate free play", Hint = "" },
                    }
                },
                new Step { StepId = 4, Name = "Install Covers", State = StepState.NotSet, Operations = new List<Operation> {
                    new Operation() { StepId = 4, OperationId = 1, Label = "Selected 12mm bolts", Hint = "" },
                    new Operation() { StepId = 4, OperationId = 1, Label = "Fastening case", Hint = "" },
                    }
                },
                new Step { StepId = 5, Name = "Verififcation", State = StepState.NotSet, Operations = new List<Operation> {
                    new Operation() { StepId = 1, OperationId = 1, Label = "Visual Inspect #1", Hint = "" },
                    new Operation() { StepId = 1, OperationId = 1, Label = "Visual Inspect #2", Hint = "" },                    
                    }
                },
                new Step { StepId = 5, Name = "Final Assembly", State = StepState.NotSet, Operations = new List<Operation> {
                    new Operation() { StepId = 1, OperationId = 1, Label = "Zip ties", Hint = "" },
                    new Operation() { StepId = 1, OperationId = 1, Label = "Tape", Hint = "" },
                    new Operation() { StepId = 1, OperationId = 1, Label = "Stickers", Hint = "" },
                    }
                },
            };
        }

        public void Initialize()
        {
            // wire up delegates
            Steps.ForEach(s => s.Operations.ForEach(o => o.ValueChanged = s.OnOperationValueChanged));
            Steps.ForEach(s => s.StateChanged = this.OnStepStateChanged);
        }

        internal void OnStepStateChanged(Step step)
        {
            // Evaluate completeness of all operations
            AllStepsComplete = Steps.TrueForAll(s => s.State == StepState.Completed);

            this.ValueChanged?.Invoke();
        }

        public Step GetNextStep(Step step)
        {
            if (Steps.IndexOf(step) == Steps.Count - 1)
                return Steps[Steps.Count - 1];
            else
                return Steps[Steps.IndexOf(step) + 1];
        }

    }
}
