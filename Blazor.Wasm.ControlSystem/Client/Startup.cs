using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using MatBlazor;

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

        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
