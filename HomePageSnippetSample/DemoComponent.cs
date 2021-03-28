using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace HomePageSnippetSample
{
    public class DemoComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return new HtmlContentViewComponentResult(new HtmlString("<h1>hello</h1>"));
        }
    }
}
