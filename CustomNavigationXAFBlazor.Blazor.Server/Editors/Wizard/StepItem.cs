using Microsoft.AspNetCore.Components;

namespace CustomNavigationXAFBlazor.Blazor.Server.Editors.Wizard
{
    public class StepItem
    {
        public string Title { get; set; }
        public RenderFragment Content { get; set; }
    }
}
