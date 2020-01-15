using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    /// <summary>
    /// A process step.
    /// Steps are completed when all of their operations are completed.
    /// </summary>
    public class Step
    {
        public Action ValueChanged { get; set; }

        public int StepId { get; set; }
        public string Name { get; set; }

        private StepState _state = StepState.NotSet;
        public StepState State
        {
            get => _state;
            set
            {
                _state = value;
                ValueChanged?.Invoke();
            }
        }
        public bool IsComplete => State == StepState.Completed;

        public List<Operation> Operations { get; set; }

        internal void OnValueChanged()
        {
            State = StepState.Completed;
        }
    }

    public enum StepState : int
    {
        NotSet,
        Started,
        Completed
    }
}
