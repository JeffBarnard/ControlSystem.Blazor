using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Wasm.ControlSystem.Shared
{
    public class StepController
    {
        public List<Step> Steps { get; set; }

        public void Initialize()
        {
            // wire up Action delegates
            Steps.ForEach(s => s.Operations.ForEach(o => o.ValueChanged = s.OnValueChanged));
        }
        
    }
}
