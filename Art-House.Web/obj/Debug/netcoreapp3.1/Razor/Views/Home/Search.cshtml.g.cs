#pragma checksum "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1410e176b484b23b86e2b59d5a84f95710d76d1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
using Art_House.Common.ViewModels.ReadMore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\_ViewImports.cshtml"
using Art_House.Common.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1410e176b484b23b86e2b59d5a84f95710d76d1a", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24a5d120ac5d98d698b34c540d63eccdce494112", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PostText", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadMore", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("bro"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("fallow"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
  
    ViewData["Title"] = "Search";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"main-text-list col-md-8 col-sm-12\">\r\n");
#nullable restore
#line 7 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
     if (!Model.PostTexts.Any() && !Model.Users.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-list\">\r\n            <p style=\"text-align: center; padding: 12px;\">هیچ پست یا کاربری یافت نشد</p>\r\n        </div>\r\n");
#nullable restore
#line 12 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
    }
    else
    {
        if (Model.PostTexts == null)
        {

        }
        else
        {


            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
             foreach (var item in Model.PostTexts)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"text-list\">\r\n                    <div class=\"top-pro\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1410e176b484b23b86e2b59d5a84f95710d76d1a8656", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 621, "~/ProfileImage/", 621, 15, true);
#nullable restore
#line 28 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
AddHtmlAttributeValue("", 636, item.Users.ProfileImg, 636, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1410e176b484b23b86e2b59d5a84f95710d76d1a10264", async() => {
#nullable restore
#line 29 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                                                        Write(item.Users.UserName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                         WriteLiteral(item.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <a href=\"#\" style=\"margin-top:10px\">/");
#nullable restore
#line 30 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                        Write(item.Groups.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 31 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                         if (User.Identity.Name != item.Users.UserName && User.Identity.IsAuthenticated)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                             if (item.SavePosts.Where(p => p.UserId == ViewBag.UserId).Count() == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a onclick=\"AddSavePost(this)\" style=\"cursor:pointer\"");
            BeginWriteAttribute("attr", " attr=\"", 1239, "\"", 1254, 1);
#nullable restore
#line 35 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 1246, item.Id, 1246, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"fallow\">ذخیره پست</a>\r\n");
#nullable restore
#line 36 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"main-text\">\r\n");
#nullable restore
#line 41 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                         if (item.Groups.Name != "دلنوشته" && item.Groups.Name != "متن سنگین")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h1 class=\"text-center\" style=\"margin-top:10px\">نام داستان : <span>");
#nullable restore
#line 43 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h1>\r\n");
#nullable restore
#line 44 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                         if (item.Image != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1410e176b484b23b86e2b59d5a84f95710d76d1a16292", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1800, "~/PostTextImages/", 1800, 17, true);
#nullable restore
#line 47 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
AddHtmlAttributeValue("", 1817, item.Image, 1817, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>\r\n                            <span style=\"color:#1b1be1a6\"> نوضیح :  </span>\r\n                            ");
#nullable restore
#line 51 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                       Write(item.ShortText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                    <div class=\"main-footer\">\r\n                        <p style=\"margin-left: 20px;\"><span>بازدید :</span> ");
#nullable restore
#line 55 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                       Write(item.Visit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p><span>تاریخ ثبت :</span> ");
#nullable restore
#line 56 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                               Write(item.CreatedTime.ToPersianDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1410e176b484b23b86e2b59d5a84f95710d76d1a19355", async() => {
                WriteLiteral("ادامه داستان");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                             WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 60 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
             
        }
        if (Model.Users == null)
        {

        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
             foreach (var item in Model.Users)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"text-list\">\r\n                    <div class=\"top-pro\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1410e176b484b23b86e2b59d5a84f95710d76d1a22755", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2782, "~/ProfileImage/", 2782, 15, true);
#nullable restore
#line 73 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
AddHtmlAttributeValue("", 2797, item.ProfileImg, 2797, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1410e176b484b23b86e2b59d5a84f95710d76d1a24362", async() => {
#nullable restore
#line 74 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                                                    Write(item.UserName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1410e176b484b23b86e2b59d5a84f95710d76d1a27116", async() => {
                WriteLiteral("مشاهده پروفایل");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 78 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row text-center\" style=\"justify-content: center;\">\r\n            <nav aria-label=\"Page navigation example\">\r\n                <ul class=\"pagination\">\r\n                    <li class=\"page-item\">\r\n");
#nullable restore
#line 84 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                         if (ViewBag.PageID != 1)
                        {
                            var c = ViewBag.PageID - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3550, "\"", 3595, 4);
            WriteAttributeValue("", 3557, "/Home/Search?", 3557, 13, true);
#nullable restore
#line 87 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 3570, ViewBag.group, 3570, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3584, "&&pageid=", 3584, 9, true);
#nullable restore
#line 87 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 3593, c, 3593, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                                <span aria-hidden=\"true\">&laquo;</span>\r\n                            </a>\r\n");
#nullable restore
#line 90 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 92 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                     for (var i = 1; i <= ViewBag.CountPage; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 3899, "\"", 3972, 2);
#nullable restore
#line 94 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 3907, ((int)ViewBag.PageID == i) ? "page-item active" : "page-item", 3907, 64, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3971, ")", 3971, 1, true);
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3994, "\"", 4038, 4);
            WriteAttributeValue("", 4001, "/Home/Serch?", 4001, 12, true);
#nullable restore
#line 94 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 4013, ViewBag.group, 4013, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4027, "&&pageid=", 4027, 9, true);
#nullable restore
#line 94 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 4036, i, 4036, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 94 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                                                                                                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 95 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\">\r\n");
#nullable restore
#line 98 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                         if (ViewBag.CountPage > 5)
                        {
                            var c = ViewBag.PageID + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4307, "\"", 4358, 4);
            WriteAttributeValue("", 4314, "/Home/Search?group=", 4314, 19, true);
#nullable restore
#line 101 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 4333, ViewBag.group, 4333, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4347, "&&pageid=", 4347, 9, true);
#nullable restore
#line 101 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
WriteAttributeValue("", 4356, c, 4356, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                                <span aria-hidden=\"true\">&raquo;</span>\r\n                            </a>\r\n");
#nullable restore
#line 104 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n                </ul>\r\n            </nav>\r\n        </div>\r\n");
#nullable restore
#line 109 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Views\Home\Search.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        //function AddUserConnection(obj) {
        //    var attr = obj.getAttribute(""attr"");
        //    $.ajax({
        //        type: ""Post"",
        //        url: ""/Account/AddCommunicationWithUsers"",
        //        data: { id: attr },
        //        success: function (result) {
        //            obj.remove();
        //        }
        //    });
        //}
        function AddSavePost(obj) {
            var attr = obj.getAttribute(""attr"");
            $.ajax({
                type: ""Post"",
                url: ""/PostText/AddSavePost"",
                data: { id: attr },
                success: function (result) {
                    obj.remove();
                }
            });
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
