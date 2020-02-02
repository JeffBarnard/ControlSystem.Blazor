using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using MatBlazor;
using Blazor.Wasm.ControlSystem.Shared;
using System.Collections.Generic;

namespace Blazor.Wasm.ControlSystem.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomCenter;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = false;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

            Shared.Theme globalTheme = new Shared.Theme()
            {
                MatTheme = new MatTheme()
                {
                    Primary = MatThemeColors.Blue._500.Value,
                    Secondary = MatThemeColors.BlueGrey._500.Value,
                },
            };
            services.AddSingleton<Shared.Theme>(globalTheme);

            StepController stepController = new StepController()
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
                    new Step { StepId = 5, Name = "Final Assembly", State = StepState.NotSet, Operations = new List<Operation> {
                        new Operation() { StepId = 1, OperationId = 1, Label = "Zip ties", Hint = "" },
                        new Operation() { StepId = 1, OperationId = 1, Label = "Tape", Hint = "" },
                        new Operation() { StepId = 1, OperationId = 1, Label = "Stickers", Hint = "" },
                        }
                    },
                },
            };
            stepController.Initialize();
            services.AddSingleton<StepController>(stepController);

        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
