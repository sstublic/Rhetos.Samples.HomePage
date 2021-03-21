using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rhetos.Dsl;
using Rhetos.Host.AspNet;

namespace HomePageSnippetSample
{
    public class DemoComponent2 : ViewComponent
    {
        private readonly IRhetosComponent<IDslModel> dslModel;
        public DemoComponent2(IRhetosComponent<IDslModel> dslModel)
        {
            this.dslModel = dslModel;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/DemoComponentView.cshtml", $"Concepts in model: {dslModel.Value.Concepts.Count()}");
        }
    }
}
