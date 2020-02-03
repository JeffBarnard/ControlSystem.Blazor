using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    /// <summary>
    /// A process step that must be completed by the operator.
    /// Steps are completed when all of their operations are completed.
    /// </summary>
    public class Step
    {
        public Action<Step> StateChanged { get; set; }

        public int StepId { get; set; }
        public string Name { get; set; }

        private StepState _state = StepState.NotSet;
        public StepState State
        {
            get => _state;
            set
            {
                _state = value;
                StateChanged?.Invoke(this);
            }
        }

        public bool IsComplete => State == StepState.Completed;

        public List<Operation> Operations { get; set; }

        internal void OnOperationValueChanged()
        {
            // Evaluate completeness of all operations
            if (Operations.TrueForAll((o) => !string.IsNullOrWhiteSpace(o.Value)))
                State = StepState.Completed;
            else
                State = StepState.Started;
        }

        public void ResetOperations()
        {
            Operations.ForEach(o => o.Value = string.Empty);
        }
    }

    public enum StepState : int
    {
        NotSet,
        Started,
        Completed
    }
}
