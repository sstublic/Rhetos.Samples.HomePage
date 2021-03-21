using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomePageSnippetSample
{
    public class DemoComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/DemoComponentView.cshtml", "Hello from snippet sample!");
        }
    }
}
