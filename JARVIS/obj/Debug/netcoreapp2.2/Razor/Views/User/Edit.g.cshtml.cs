#pragma checksum "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16f885865fda30cf60590a4df49e69271baa4c72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Edit), @"mvc.1.0.view", @"/Views/User/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Edit.cshtml", typeof(AspNetCore.Views_User_Edit))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16f885865fda30cf60590a4df49e69271baa4c72", @"/Views/User/Edit.cshtml")]
    public class Views_User_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JARVIS.Models.Utilizador>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery-1.10.2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery.validate.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery.validate.unobtrusive.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 4 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(73, 23, false);
#line 6 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(100, 90, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <h4>StudentModel</h4>\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(191, 64, false);
#line 11 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(255, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(266, 43, false);
#line 12 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
   Write(Html.HiddenFor(model => model.idUtilizador));

#line default
#line hidden
            EndContext();
            BeginContext(309, 50, true);
            WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(360, 93, false);
#line 15 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
       Write(Html.LabelFor(model => model.Nome, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(453, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(509, 93, false);
#line 17 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.EditorFor(model => model.Nome, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(602, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(621, 82, false);
#line 18 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Nome, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(703, 84, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(788, 103, false);
#line 22 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
       Write(Html.LabelFor(model => model.DataNascimento, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(891, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(947, 103, false);
#line 24 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.EditorFor(model => model.DataNascimento, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1050, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1069, 92, false);
#line 25 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.DataNascimento, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1161, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1248, 97, false);
#line 30 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
       Write(Html.LabelFor(model => model.Username, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1345, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1401, 97, false);
#line 32 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.EditorFor(model => model.Username, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1498, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1517, 86, false);
#line 33 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Username, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1603, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1690, 97, false);
#line 38 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
       Write(Html.LabelFor(model => model.Password, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1787, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1843, 97, false);
#line 40 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.EditorFor(model => model.Password, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1940, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1959, 86, false);
#line 41 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2045, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(2132, 94, false);
#line 46 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
       Write(Html.LabelFor(model => model.Email, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2226, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(2282, 94, false);
#line 48 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.EditorFor(model => model.Email, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2376, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2395, 83, false);
#line 49 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2478, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(2565, 93, false);
#line 54 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
       Write(Html.LabelFor(model => model.Foto, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2658, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(2714, 93, false);
#line 56 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.EditorFor(model => model.Foto, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2807, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2826, 82, false);
#line 57 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Foto, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2908, 253, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 67 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
}

#line default
#line hidden
            BeginContext(3164, 13, true);
            WriteLiteral("\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3178, 40, false);
#line 70 "/Users/pedrofreitas/Desktop/LI4/Jarvis/JARVIS/Views/User/Edit.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(3218, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3230, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16f885865fda30cf60590a4df49e69271baa4c7213878", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3284, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3286, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16f885865fda30cf60590a4df49e69271baa4c7215040", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3342, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3344, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16f885865fda30cf60590a4df49e69271baa4c7216202", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3412, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JARVIS.Models.Utilizador> Html { get; private set; }
    }
}
#pragma warning restore 1591
