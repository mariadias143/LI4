#pragma checksum "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f94c071fad1f2388296ee6ff619705939e664859"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recipe_Ingredients), @"mvc.1.0.view", @"/Views/Recipe/Ingredients.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Recipe/Ingredients.cshtml", typeof(AspNetCore.Views_Recipe_Ingredients))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f94c071fad1f2388296ee6ff619705939e664859", @"/Views/Recipe/Ingredients.cshtml")]
    public class Views_Recipe_Ingredients : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JARVIS.Models.Receita>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
  
    Layout = "~/Views/Shared/_LayoutTeste.cshtml";

#line default
#line hidden
            BeginContext(89, 1055, true);
            WriteLiteral(@"
<section class=""hero-wrap hero-wrap-2"" style=""background-image: url('/salvacao/images/bg_4.jpg');"" data-stellar-background-ratio=""0.5"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row no-gutters slider-text align-items-center justify-content-center"">
            <div class=""col-md-9 ftco-animate text-center"">
                <h1 class=""mb-2 bread"">Ingredients</h1>
            </div>
        </div>
    </div>
</section>

<section class=""ftco-section ftco-wrap-about ftco-no-pb ftco-no-pt"">
    <div class=""container"">
        <div class=""row no-gutters"">
            <div class=""col-sm-5 img img-2 d-flex align-items-center justify-content-center justify-content-md-end"" style=""background-image: url(/salvacao/images/massa.jpg); position: page "">

            </div>
            <div class=""col-sm-7 wrap-about py-5 ftco-animate"">
                <div class=""heading-section mt-5 mb-4"">
                    <div class=""pl-lg-5 ml-md-5"">
                        <s");
            WriteLiteral("pan class=\"subheading\">Receita ");
            EndContext();
            BeginContext(1145, 15, false);
#line 26 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                                                    Write(Model.idReceita);

#line default
#line hidden
            EndContext();
            BeginContext(1160, 1270, true);
            WriteLiteral(@"</span>
                        <h2 class=""mb-4"">Uma delícia!</h2>

                    </div>
                </div>
                <div class=""pl-lg-5 ml-md-5"">

                    <link href=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">


                    <link href=""//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css"" rel=""stylesheet"">

                    <div class=""container"">

                        <h3>Foods needed:</h3>
                        <form method=""post"">
                            <div class=""row"">
                                <div class=""col-md-4"">
                                    <div class=""panel panel-default"">
                                        <div class=""panel-body"">
                                           
                                                <table class=""table"">
                                                    <tr>
                                  ");
            WriteLiteral("                      <th>Id</th>\r\n                                                        <th>Alimento</th>\r\n                                                        <th>Disponivel</th>\r\n                                                    </tr>\r\n");
            EndContext();
#line 53 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                                                     foreach (var order in Model.Ingredientes)
        {

#line default
#line hidden
            BeginContext(2537, 202, true);
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    <input type=\"hidden\" name=\"Ingredientes.Index\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2739, "\"", 2764, 1);
#line 57 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 2747, order.idAlimento, 2747, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2765, 77, true);
            WriteLiteral(" />\r\n                                                    <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 2842, "\"", 2892, 3);
            WriteAttributeValue("", 2849, "Ingredientes.[", 2849, 14, true);
#line 58 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 2863, order.idAlimento, 2863, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 2880, "].idAlimento", 2880, 12, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2893, "\"", 2918, 1);
#line 58 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 2901, order.idAlimento, 2901, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2919, 77, true);
            WriteLiteral(" />\r\n                                                    <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 2996, "\"", 3039, 3);
            WriteAttributeValue("", 3003, "Ingredientes[", 3003, 13, true);
#line 59 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 3016, order.idAlimento, 3016, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 3033, "].Nome", 3033, 6, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 3040, "\"", 3059, 1);
#line 59 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 3048, order.Nome, 3048, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3060, 77, true);
            WriteLiteral(" />\r\n                                                    <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 3137, "\"", 3185, 3);
            WriteAttributeValue("", 3144, "Ingredientes.[", 3144, 14, true);
#line 60 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 3158, order.idAlimento, 3158, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 3175, "].Validade", 3175, 10, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 3186, "\"", 3209, 1);
#line 60 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 3194, order.Validade, 3194, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3210, 77, true);
            WriteLiteral(" />\r\n                                                    <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 3287, "\"", 3342, 3);
            WriteAttributeValue("", 3294, "Ingredientes[", 3294, 13, true);
#line 61 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 3307, order.idAlimento, 3307, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 3324, "].ValorNutricional", 3324, 18, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 3343, "\"", 3374, 1);
#line 61 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 3351, order.ValorNutricional, 3351, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3375, 57, true);
            WriteLiteral(" />\r\n                                                    ");
            EndContext();
            BeginContext(3433, 16, false);
#line 62 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                                               Write(order.idAlimento);

#line default
#line hidden
            EndContext();
            BeginContext(3449, 163, true);
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
            EndContext();
            BeginContext(3613, 10, false);
#line 65 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                                               Write(order.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(3623, 140, true);
            WriteLiteral("\r\n                                                </td>\r\n                                                <td><label for=\"checkOption\"><input");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 3763, "\"", 3811, 3);
            WriteAttributeValue("", 3770, "Ingredientes[", 3770, 13, true);
#line 67 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
WriteAttributeValue("", 3783, order.idAlimento, 3783, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 3800, "].IsChecked", 3800, 11, true);
            EndWriteAttribute();
            BeginContext(3812, 115, true);
            WriteLiteral(" type=\"checkbox\" id=\"checkOption\" value=\"true\" /></label></td>\r\n                                            </tr>\r\n");
            EndContext();
#line 69 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
}

#line default
#line hidden
            BeginContext(3930, 259, true);
            WriteLiteral(@"                                                </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <p>");
            EndContext();
            BeginContext(4190, 15, false);
#line 76 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                          Write(Model.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(4205, 50, true);
            WriteLiteral("</p>\r\n                            <p>Dificuldade: ");
            EndContext();
            BeginContext(4256, 17, false);
#line 77 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                                       Write(Model.Dificuldade);

#line default
#line hidden
            EndContext();
            BeginContext(4273, 46, true);
            WriteLiteral("</p>\r\n                            <p>Duração: ");
            EndContext();
            BeginContext(4320, 13, false);
#line 78 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                                   Write(Model.Duracao);

#line default
#line hidden
            EndContext();
            BeginContext(4333, 93, true);
            WriteLiteral("</p>\r\n\r\n                            <h3>Let\'s begin!</h3>\r\n                            <span>");
            EndContext();
            BeginContext(4427, 19, false);
#line 81 "/Users/ines/Desktop/Jarvis/JARVIS/Views/Recipe/Ingredients.cshtml"
                             Write(ViewBag.condicional);

#line default
#line hidden
            EndContext();
            BeginContext(4446, 383, true);
            WriteLiteral(@"</span>
                            <button onclick=""Check()"" class=""btn btn-default btn-sm"">
                                <span class=""glyphicon glyphicon-play-circle""></span> Start
                            </button>
                            </form>
                    </div>

                </div>
            </div>
        </div>
    </div>
</section>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JARVIS.Models.Receita> Html { get; private set; }
    }
}
#pragma warning restore 1591
