#pragma checksum "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Shared\Components\VisitTop\VisitTop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6462a87450f03ac3793321a8856b346fd511920e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_VisitTop_VisitTop), @"mvc.1.0.view", @"/Views/Shared/Components/VisitTop/VisitTop.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Domain.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.PostTexts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.Search;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.Questions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.ReadMore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6462a87450f03ac3793321a8856b346fd511920e", @"/Views/Shared/Components/VisitTop/VisitTop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed7c417c3cf19d7385814e1847bbc23dee3a9b36", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_VisitTop_VisitTop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PostText>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PostText", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadMore", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Shared\Components\VisitTop\VisitTop.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"Visit\">\r\n        <div class=\"visit-head\">\r\n            <h1><i class=\"fa fa-eye\"></i> پر بازدید ترین </h1>\r\n\r\n        </div>\r\n");
#nullable restore
#line 11 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Shared\Components\VisitTop\VisitTop.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"visit-main\">\r\n                <div class=\"visit-text\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462a87450f03ac3793321a8856b346fd511920e6286", async() => {
                WriteLiteral(" ");
#nullable restore
#line 15 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Shared\Components\VisitTop\VisitTop.cshtml"
                                                                                            Write(item.Groups.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" : ");
#nullable restore
#line 15 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Shared\Components\VisitTop\VisitTop.cshtml"
                                                                                                                Write(item.ShortText.Substring(0,25));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Shared\Components\VisitTop\VisitTop.cshtml"
                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <i class=\"fa fa-angle-double-left\"></i>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 19 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Shared\Components\VisitTop\VisitTop.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PostText>> Html { get; private set; }
    }
}
#pragma warning restore 1591
