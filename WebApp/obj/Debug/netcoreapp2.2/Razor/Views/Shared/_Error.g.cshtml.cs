#pragma checksum "C:\Consulting Group\PrestamoLibrosWebApp\WebApp\Views\Shared\_Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8a46328d93490164511ab4b75131a671e04699d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Shared.Views_Shared__Error), @"mvc.1.0.view", @"/Views/Shared/_Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Error.cshtml", typeof(WebApp.Pages.Shared.Views_Shared__Error))]
namespace WebApp.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Consulting Group\PrestamoLibrosWebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 3 "C:\Consulting Group\PrestamoLibrosWebApp\WebApp\Views\_ViewImports.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8a46328d93490164511ab4b75131a671e04699d", @"/Views/Shared/_Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d588d83374107d108775bcf716f2f55f6ed6fbb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Consulting Group\PrestamoLibrosWebApp\WebApp\Views\Shared\_Error.cshtml"
  
    ViewData["Title"] = "Not Found";

#line default
#line hidden
            BeginContext(45, 933, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""error-template"">
                <h1>
                    Oops!
                </h1>
                <h2>
                    Ups! Something went wrong
                </h2>
                <div class=""error-details"">
                    Sorry, an error has occured, Requested information error!
                </div>
                <div class=""error-actions"">
                    <a href=""/"" class=""btn btn-primary btn-lg"">
                        <i class=""fas fa-home""></i>
                        Take Me Home
                    </a>
                    <a href=""/"" class=""btn btn-default btn-lg"">
                        <i class=""fas fa-envelope""></i>
                        Contact Support
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591