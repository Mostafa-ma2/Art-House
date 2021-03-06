#pragma checksum "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b01bccb88d471a700dd2223f7e3ce2edd39fe5ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Offers_Questions), @"mvc.1.0.view", @"/Areas/Admin/Views/Offers/Questions.cshtml")]
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
#line 1 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Art_House.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Art_House.Domain.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.Questions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Art_House.Common.ViewModels.DashBoard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Art_House.Common.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b01bccb88d471a700dd2223f7e3ce2edd39fe5ec", @"/Areas/Admin/Views/Offers/Questions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc5217e02e2867d29d6b2e3b4e260952d2f985e4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Offers_Questions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddQuestionViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Admin/Offers/UpdateQuestion"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Admin/Offers/AddBtnQuestions"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
  
    ViewData["Title"] = "نظر سنجی";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"" style=""margin-top:10px"">
    <div class=""col-md-12"">
        <div class=""panel"">
            <div class=""panel-heading"">مدیریت سوال ها <a style=""float: left"" id=""OpenCreatModal"" class=""btn btn-primary"">افرودن سوال</a></div>
            <div class=""table-responsive"">
                <table class=""table table-hover manage-u-table"">
                    <thead>
                        <tr>
                            <th width=""70"" class=""text-center"">#</th>
                            <th>متن</th>
                            <th>شروع نظر سنجی</th>
                            <th>پایان نظر سنجی</th>
                            <th width=""300"">مدیریت کردن</th>
                        </tr>
                    </thead>
                    <tbody id=""group-list"">
");
#nullable restore
#line 22 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
                         foreach (var item in Model.Question.OrderByDescending(p=>p.StartThePoll))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr");
            BeginWriteAttribute("id", " id=\"", 1033, "\"", 1046, 1);
#nullable restore
#line 24 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 1038, item.Id, 1038, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <td class=\"text-center\">");
#nullable restore
#line 25 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td");
            BeginWriteAttribute("id", " id=\"", 1156, "\"", 1174, 2);
            WriteAttributeValue("", 1161, "Name-", 1161, 5, true);
#nullable restore
#line 26 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 1166, item.Id, 1166, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    ");
#nullable restore
#line 27 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
                               Write(item.QuestionText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td");
            BeginWriteAttribute("id", " id=\"", 1308, "\"", 1334, 2);
            WriteAttributeValue("", 1313, "StartThePoll-", 1313, 13, true);
#nullable restore
#line 29 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 1326, item.Id, 1326, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    ");
#nullable restore
#line 30 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
                               Write(item.StartThePoll.ToPersianDateStrings());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td");
            BeginWriteAttribute("id", " id=\"", 1491, "\"", 1515, 2);
            WriteAttributeValue("", 1496, "EndThePoll-", 1496, 11, true);
#nullable restore
#line 32 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 1507, item.Id, 1507, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    ");
#nullable restore
#line 33 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
                               Write(item.EndThePoll.ToPersianDateStrings());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <button type=\"button\"");
            BeginWriteAttribute("attr", " attr=\"", 1730, "\"", 1745, 1);
#nullable restore
#line 36 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 1737, item.Id, 1737, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" onclick=""OpenDeleteModel(this)"" class=""btn btn-info btn-outline btn-circle btn-lg m-r-5"">
                                        <i class=""ti-trash""></i>
                                    </button>
                                    <button type=""button""");
            BeginWriteAttribute("attr", " attr=\"", 2008, "\"", 2023, 1);
#nullable restore
#line 39 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 2015, item.Id, 2015, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" onclick=""OpenUpdateModal(this)"" class=""btn btn-info btn-outline btn-circle btn-lg m-r-5"">
                                        <i class=""ti-pencil-alt""></i>
                                    </button>
                                </td>
                            </tr>
");
#nullable restore
#line 44 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<!-- Add Modal -->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"" style=""padding:10px"">
            <div class=""col-12 text-center"">
                <h3>
                    افزودن سوال
                </h3>
                ");
#nullable restore
#line 59 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
           Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 2936, "\"", 2942, 0);
            EndWriteAttribute();
            WriteLiteral(">سوال :</label>\r\n                <input type=\"text\" class=\"form-control\" id=\"creatTextGroup\" name=\"name\"");
            BeginWriteAttribute("value", " value=\"", 3047, "\"", 3055, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 3141, "\"", 3147, 0);
            EndWriteAttribute();
            WriteLiteral(">زمان شروع :</label>\r\n                <input type=\"text\" id=\"AddStartThePoll\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3225, "\"", 3303, 4);
            WriteAttributeValue("", 3235, "PersianDatePicker.Show(this,", 3235, 28, true);
            WriteAttributeValue(" ", 3263, "\'", 3264, 2, true);
#nullable restore
#line 67 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 3265, DateTime.Now.ToPersianDateString(), 3265, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3300, "\');", 3300, 3, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 3389, "\"", 3395, 0);
            EndWriteAttribute();
            WriteLiteral(">زمان اتمام :</label>\r\n                <input type=\"text\" id=\"AddEndThePoll\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3472, "\"", 3550, 4);
            WriteAttributeValue("", 3482, "PersianDatePicker.Show(this,", 3482, 28, true);
            WriteAttributeValue(" ", 3510, "\'", 3511, 2, true);
#nullable restore
#line 71 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 3512, DateTime.Now.ToPersianDateString(), 3512, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3547, "\');", 3547, 3, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 3636, "\"", 3642, 0);
            EndWriteAttribute();
            WriteLiteral(">وضعیت :</label>\r\n                <select class=\"form-control\" id=\"CreatIsDeletedGroup\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01bccb88d471a700dd2223f7e3ce2edd39fe5ec15372", async() => {
                WriteLiteral("حذف نشده");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01bccb88d471a700dd2223f7e3ce2edd39fe5ec16353", async() => {
                WriteLiteral("حذف شده");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </select>
            </div>
            <button style=""width:100%;margin-top:10px"" class=""btn btn-success"" id=""save"">افزودن</button>
        </div>
    </div>
</div>
<!-- Edit Modal -->
<div class=""modal fade"" id=""exampleModal2"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"" style=""padding:10px"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01bccb88d471a700dd2223f7e3ce2edd39fe5ec17794", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" id=\"id\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 4396, "\"", 4404, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <div class=\"col-12 text-center\">\r\n                    <h3>\r\n                        ویرایش سوال\r\n                    </h3>\r\n                    ");
#nullable restore
#line 94 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
               Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label");
                BeginWriteAttribute("for", " for=\"", 4678, "\"", 4684, 0);
                EndWriteAttribute();
                WriteLiteral(">سوال :</label>\r\n                    <input type=\"text\" class=\"form-control\" id=\"text\" name=\"text\"");
                BeginWriteAttribute("value", " value=\"", 4783, "\"", 4791, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label");
                BeginWriteAttribute("for", " for=\"", 4889, "\"", 4895, 0);
                EndWriteAttribute();
                WriteLiteral(">زمان شروع :</label>\r\n                    <input type=\"text\" id=\"startPoll\" name=\"startPoll\"");
                BeginWriteAttribute("onclick", " onclick=\"", 4988, "\"", 5066, 4);
                WriteAttributeValue("", 4998, "PersianDatePicker.Show(this,", 4998, 28, true);
                WriteAttributeValue(" ", 5026, "\'", 5027, 2, true);
#nullable restore
#line 102 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 5028, DateTime.Now.ToPersianDateString(), 5028, 35, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5063, "\');", 5063, 3, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label");
                BeginWriteAttribute("for", " for=\"", 5164, "\"", 5170, 0);
                EndWriteAttribute();
                WriteLiteral(">زمان اتمام :</label>\r\n                    <input type=\"text\" id=\"endPoll\" name=\"endPoll\"");
                BeginWriteAttribute("onclick", " onclick=\"", 5260, "\"", 5338, 4);
                WriteAttributeValue("", 5270, "PersianDatePicker.Show(this,", 5270, 28, true);
                WriteAttributeValue(" ", 5298, "\'", 5299, 2, true);
#nullable restore
#line 106 "C:\Users\Mostafa\Downloads\Csharp_Web\Art-House\Art-House.Web\Areas\Admin\Views\Offers\Questions.cshtml"
WriteAttributeValue("", 5300, DateTime.Now.ToPersianDateString(), 5300, 35, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5335, "\');", 5335, 3, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label");
                BeginWriteAttribute("for", " for=\"", 5436, "\"", 5442, 0);
                EndWriteAttribute();
                WriteLiteral(">وضعیت :</label>\r\n                    <select class=\"form-control\" id=\"isDeleted\" name=\"isDeleted\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01bccb88d471a700dd2223f7e3ce2edd39fe5ec21645", async() => {
                    WriteLiteral("حذف نشده");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01bccb88d471a700dd2223f7e3ce2edd39fe5ec22686", async() => {
                    WriteLiteral("حذف شده");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </select>\r\n                </div>\r\n                <button style=\"width:100%;margin-top:10px\" class=\"btn btn-success\">ویرایش</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>
<!-- delete Modal -->
<div class=""modal fade"" id=""exampleModal3"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"" style=""padding:10px"">
            <input type=""hidden"" id=""DeleteID"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 6172, "\"", 6180, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
            <label id=""lal"">

            </label>
            <br />
            <button style=""width:100%;margin-top:10px"" class=""btn btn-success"" id=""btnDelete"">حذف</button>
        </div>
    </div>
</div>
<!-- Add Btn Modal -->
<div class=""modal fade"" id=""exampleModal32"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01bccb88d471a700dd2223f7e3ce2edd39fe5ec26110", async() => {
                WriteLiteral("\r\n            <div class=\"modal-content\" style=\"padding:10px\" id=\"CreateBtn\">\r\n                <input type=\"hidden\" id=\"BtnQuestionsId\" name=\"questionId\"");
                BeginWriteAttribute("value", " value=\"", 6825, "\"", 6833, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                <div class=""col-12 text-center"">
                    <h3>
                        افزودن دکمه (بین 3 تا 4 تا امکان پذیر است)
                    </h3>
                    <label id=""lall""></label>
                </div>
                <div class=""form-group"">
                    <label");
                BeginWriteAttribute("for", " for=\"", 7149, "\"", 7155, 0);
                EndWriteAttribute();
                WriteLiteral(">تعداد را وارد نمایید :</label>\r\n                    <input type=\"number\" class=\"form-control\" onkeyup=\"ShowTheBtn(this)\" id=\"NumberBtn\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 7304, "\"", 7312, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <a style=\"width:100%;margin-top:10px;display:none\" class=\"btn btn-success\"  onclick=\"AddInputBtnQuestion(this)\" id=\"btnQuestion\">ساختن</a>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            //افزودن
            $(""#OpenCreatModal"").click(function () {
                $(""#exampleModal"").modal(""show"");
                $(""#creatTextGroup"").val("""");
                $(""#CreatIsDeletedGroup"").val("""");
                $(""#AddStartThePoll"").val("""");
                $(""#AddEndThePoll"").val("""");
            });
            $(""#save"").click(function (e) {
                e.preventDefault();
                var QuestionText = $(""#creatTextGroup"").val();
                var QuestionIsDeleted = $(""#CreatIsDeletedGroup"").val();
                var QuestionStartThePoll = $(""#AddStartThePoll"").val();
                var QuestionEndThePoll = $(""#AddEndThePoll"").val();
                $.ajax({
                    type: ""Post"",
                    data: { text: QuestionText, isDeleted: QuestionIsDeleted, startPoll: QuestionStartThePoll, endPoll: QuestionEndThePoll },
                    url: ""/Admin/Offers/A");
                WriteLiteral(@"ddQuestion"",
                    success: function (result) {
                        if (result != null) {
                            $(""#exampleModal"").modal(""hide"");
                            var html = '<tr id=""' + result.id + '"">'
                            html += '<td class=""text-center"">' + result.id + '</td>'
                            html += '<td id=""Name-' + result.id + '"">'
                            html += '' + result.questionText + ''
                            html += '</td>'
                            html += '<td id=""StartThePoll-' + result.id + '"">'
                            html += '' + result.startThePoll + ''
                            html += ' </td>'
                            html += '<td id=""EndThePoll-' + result.id + '"">'
                            html += '' + result.endThePoll + ''
                            html += '</td>'
                            html += ' <td>'
                            html += '<button type=""button"" attr=""' + result.id + '"" ");
                WriteLiteral(@"onclick=""OpenDeleteModel(this)"" class=""btn btn-info btn-outline btn-circle btn-lg m-r-5"">'
                            html += '<i class=""ti-trash""></i>'
                            html += '</button>'
                            html += '<button type=""button"" attr=""' + result.id + '"" onclick=""OpenUpdateModal(this)"" class=""btn btn-info btn-outline btn-circle btn-lg m-r-5"">'
                            html += '<i class=""ti-pencil-alt""></i>'
                            html += '</button>'
                            html += '</td>'
                            html += '</tr>'
                            $(""#group-list"").append(html);
                            BtnQuestionsId
                            $(""#BtnQuestionsId"").val(result.id);
                            $(""#exampleModal32"").modal(""show"");

                        }
                    }

                });
            })
            
            //حذف
            $(""#btnDelete"").click(function (e) {
                e.preventD");
                WriteLiteral(@"efault();
                var id = $(""#DeleteID"").val();
                $.ajax({
                    type: ""Post"",
                    url: ""/Admin/Offers/DeleteQuestion"",
                    data: { ID: id },
                    success: function (result) {
                        if (result != null) {
                            $(""#exampleModal3"").modal(""hide"");
                            debugger;
                            $(""tr#"" + result.id).remove();
                        }
                    }

                })
            })
        });
        //گرفتن ایدی
        function OpenUpdateModal(obj) {
            var attr = obj.getAttribute(""attr"");
            $.ajax({
                type: ""Post"",
                url: ""/Admin/Offers/GetQuestionById"",
                data: { id: attr },
                success: function (result) {
                    if (result != null) {
                        $(""#exampleModal2"").modal(""show"");
                        $(""#id"").val(re");
                WriteLiteral(@"sult.id);
                        $(""#text"").val(result.questionText);
                        $(""#startPoll"").val(result.startThePoll);
                        $(""#endPoll"").val(result.endThePoll);
                        if (result.isDeleted) {
                            $(""#isDeleted"").val(""حذف شده"");
                        } else {
                            $(""#isDeleted"").val(""حذف نشده"");
                        }
                    }
                }
            });
        }
        function OpenDeleteModel(obj) {
            var attr = obj.getAttribute(""attr"");
            $.ajax({
                type: ""Post"",
                url: ""/Admin/Offers/GetQuestionById"",
                data: { id: attr },
                success: function (result) {
                    if (result != null) {
                        $(""#exampleModal3"").modal(""show"");
                        $(""#DeleteID"").val(result.id);
                        document.getElementById(""lal"").innerHTML = ' ایا از ح");
                WriteLiteral(@"ذف ان اطمینان دارید؟';
                    }
                }
            });
        }
        //گرفتن تعداد دکمه دکمه
        function ShowTheBtn(obj) {
            if (obj.value == """") {
                document.getElementById(""btnQuestion"").style.display = ""none"";
            } else {
                document.getElementById(""btnQuestion"").style.display = ""block"";
            }
        }
        //ساخت دکمه
        function AddInputBtnQuestion(obj) {
            obj.style.display = ""none"";
            var number = $(""#NumberBtn"").val();
            if (number <= 4 && number > 0) {
                for (var i = 0; i < number; i++) {
                    var html = '<div class=""form-group"">'
                    html += '<label for="""">نام دکمه را بنویسید :</label>'
                    html += '<input type=""text"" class=""form-control"" name=""BtnQuestion[' + i + '].name"" value="""" />'
                    html += '</div>'
                    $(""#CreateBtn"").append(html);
                }
  ");
                WriteLiteral(@"              var htmls = '<br />'
                htmls +='<button style=""width:100%;margin-top:10px"" class=""btn btn-success"">افزودن دکمه ها</button>'
                $(""#CreateBtn"").append(htmls);

            } else {
                $(""#lall"").html(""نمی تواند 0 یا بیشتر از 4 باشد"");
            }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddQuestionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
