// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RegexGeneratorFrontend.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using RegexGeneratorFrontend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/_Imports.razor"
using RegexGeneratorFrontend.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/Components/TestComponent.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/Components/TestComponent.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/Components/TestComponent.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/Components/TestComponent.razor"
using Serilog;

#line default
#line hidden
#nullable disable
    public partial class TestComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 11 "/Users/martinholst/Desktop/RegexGenerator/RegexGeneratorFrontend/Components/TestComponent.razor"
       
    [Parameter] public string Name { get; set; }
    [Parameter] public EventCallback<string> OnUpdate { get; set; }

    private async Task Method()
    {
        await OnUpdate.InvokeAsync("Whatever");
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
