#pragma checksum "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a988e8bee290467e6b4956007753b8994b1c75a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employee_Views_Purchase_Insert), @"mvc.1.0.view", @"/Areas/Employee/Views/Purchase/Insert.cshtml")]
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
#line 1 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\_ViewImports.cshtml"
using Ragnarok;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\_ViewImports.cshtml"
using Ragnarok.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\_ViewImports.cshtml"
using Ragnarok.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a988e8bee290467e6b4956007753b8994b1c75a", @"/Areas/Employee/Views/Purchase/Insert.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37626085e97468cf27092cf987fa52bfb6edda16", @"/Areas/Employee/Views/_ViewImports.cshtml")]
    public class Areas_Employee_Views_Purchase_Insert : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PurchaseOrder>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Purchase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Insert", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default btn-sm btn-quick-task"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/queenadmin-logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("QueenAdmin Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Selecione", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "select2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("supplier"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:addProductList()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
  
    ViewData["Title"] = "Insert";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid primary-content"">
    <!-- PRIMARY CONTENT HEADING -->
    <div class=""primary-content-heading clearfix"">
        <h2>NOVA ORDEM DE COMPRA</h2>
        <ul class=""breadcrumb pull-left"">
            <li><i class=""icon ion-home""></i>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a988e8bee290467e6b4956007753b8994b1c75a10294", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a988e8bee290467e6b4956007753b8994b1c75a11875", async() => {
                WriteLiteral("Ordens de Compra");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a988e8bee290467e6b4956007753b8994b1c75a13468", async() => {
                WriteLiteral("Nova Ordem de Compra");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n        </ul>\r\n        <div class=\"sticky-content pull-right\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a988e8bee290467e6b4956007753b8994b1c75a15131", async() => {
                WriteLiteral("<i class=\"icon ion-person-add\"></i> Nova Ordem");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div class=""btn-group btn-dropdown"">
                <button type=""button"" class=""btn btn-default btn-sm btn-favorites"" data-toggle=""dropdown""><i class=""icon ion-android-star""></i> Favorites</button>
                <ul class=""dropdown-menu dropdown-menu-right list-inline"">
                    <li><a href=""#""><i class=""icon ion-pie-graph""></i> <span>Statistics</span></a></li>
                    <li><a href=""#""><i class=""icon ion-email""></i> <span>Inbox</span></a></li>
                    <li><a href=""#""><i class=""icon ion-chatboxes""></i> <span>Chat</span></a></li>
                    <li><a href=""#""><i class=""icon ion-help-circled""></i> <span>Help</span></a></li>
                    <li><a href=""#""><i class=""icon ion-gear-a""></i> <span>Settings</span></a></li>
                    <li><a href=""#""><i class=""icon ion-help-buoy""></i> <span>Support</span></a></li>
                </ul>
            </div>
        </div>
    </div>
");
#nullable restore
#line 30 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
     if (TempData["MSG_S"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success fade in\">\r\n            <button class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n            <i class=\"icon ion-checkmark-circled\"></i>\r\n            <strong>Feito!</strong> ");
#nullable restore
#line 35 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
                               Write(TempData["MSG_S"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 37 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
     if (TempData["MSG_E"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger fade in\">\r\n            <button class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n            <i class=\"icon ion-checkmark-circled\"></i>\r\n            <strong>Erro!</strong> ");
#nullable restore
#line 43 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
                              Write(TempData["MSG_E"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 45 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"invoice\">\r\n        <!-- invoice header -->\r\n        <div class=\"invoice-header\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-3 col-print-3\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1a988e8bee290467e6b4956007753b8994b1c75a20092", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""col-md-9 col-print-9"">
                    <ul class=""list-inline"">
                        <li><a onclick=""novaJanela()"" class=""btn btn-default btn-sm btn-quick-task""><i class=""icon ion-plus-round""></i> Pesquisar Produto</a></li>
                        <li>N??mero da Ordem #: <strong></strong></li>
                        <li>Data: <strong>");
#nullable restore
#line 57 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
                                     Write(DateTime.Now.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></li>
                        <li>Valor Total: <strong id=""totalTop"">R$ 0.00</strong></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- end invoice header -->
        <!-- invoice address -->
        <div class=""invoice-from-to"">
            <div class=""row"">
                <div class=""col-sm-5 col-print-6"">
                    <div class=""row"">
                        <div class=""col-md-10"">
                            <label>Selecione o fornecedor</label>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a988e8bee290467e6b4956007753b8994b1c75a22576", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a988e8bee290467e6b4956007753b8994b1c75a22869", async() => {
                    WriteLiteral("Selecione");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
#nullable restore
#line 71 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Insert.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Purchase;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
                    <br />
                    <p class=""name"" id=""companyNamePurchase""></p>
                    <input id=""selectProvider"" type=""hidden"" />
                    <address id=""companyDescriptionPurchase"">

                    </address>
                </div>
                <div class="" col-sm-6 col-print-6"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a988e8bee290467e6b4956007753b8994b1c75a26103", async() => {
                WriteLiteral(@"
                        <div class=""row"">                            
                            <div class=""col-md-9"">
                                <input id=""selectedProductId"" type=""hidden"" required />
                                <label>Produto Selecionado</label>
                                <input id=""selectedProduct"" class=""form-control"" required disabled style=""background-color:white"" />
                            </div>
                        </div>
                        <div class=""row"">

                            <div class=""col-md-3"">
                                <label>Pre??o Compra</label>
                                <div class=""input-group"">
                                    <span class=""input-group-addon"">R$</span>
                                    <input id=""purchasePrice"" type=""text"" class=""form-control"" required />
                                </div>
                            </div>
                            <div class=""col-md-3"">
        ");
                WriteLiteral(@"                        <label>Pre??o Venda</label>
                                <div class=""input-group"">
                                    <span class=""input-group-addon"">R$</span>
                                    <input id=""salesPrice"" type=""text"" class=""form-control"" required />
                                </div>
                            </div>
                            <div class=""col-md-3"">
                                <label>Quantidade</label>
                                <input id=""quantity"" type=""text"" value=""1"" class=""form-control"" required />
                            </div>
                        </div>
                        <div class=""row"">

                            <div class=""col-md-3"">
                                <label>Desconto</label>
                                <div class=""input-group"">
                                    <span class=""input-group-addon"">R$</span>
                                    <input id=""discont"" type=""text"" value");
                WriteLiteral(@"=""0"" class=""form-control"" />
                                </div>
                            </div>
                            <div class=""col-md-4"">
                                <label>Validade</label>
                                <input id=""validition"" type=""date"" value=""1"" class=""form-control"" />
                            </div>
                            <div class=""col-md-1"">
                                <button type=""submit"" class=""btn btn-success btn-sm btn-quick-task"" style=""margin-top: 25px;"">Add</button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_15.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_15);
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
            <!-- end invoice address -->
            <!-- invoice item table -->
            <div class=""table-responsive"">
                <table class=""table invoice-table"" id=""invoicePurchase"">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Produto</th>
                            <th>Quantidade</th>
                            <th>Pre??o Compra</th>
                            <th>Pre??o Venda</th>
                            <th>Desconto</th>
                            <th>Total</th>
                            <th>Validade</th>
                            <th>A????o</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <!-- end invoice item table -->
            <!-- invoice footer -->
            <div class=""invoice-footer"">
                <div class=""row"">");
            WriteLiteral(@"
                    <div class=""col-sm-5 col-sm-offset-1 col-print-4 col-print-offset-2 right-col"">
                        <div class=""invoice-total"">
                            <div class=""row"">
                                <div class=""col-xs-4 col-xs-offset-4 col-print-6 col-print-offset-2"">
                                    <p>Subtotal</p>
                                    <p>Total Desconto</p>
                                    <p>Total ?? pagar</p>
                                </div>
                                <div class=""col-xs-4 text-right col-print-4"">
                                    <p id=""resultSubTotal"">R$ 0.00</p>
                                    <p id=""resultDiscont"">R$ 0.00</p>
                                    <p id=""resultTotalPayment"">R$ 0.00</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-print-6 left-col"">
         ");
            WriteLiteral(@"               <blockquote class=""invoice-notes"">
                            <strong>Notes:</strong>
                            <textarea id=""notes"" class=""form-control""></textarea>
                        </blockquote>
                    </div>
                </div>
            </div>
            <!-- end invoice footer -->
            <!-- invoice action buttons -->
            <div class=""invoice-buttons"">
                <button class=""btn btn-default print-btn""><i class=""icon ion-printer""></i> Print</button>
                <a id=""finishPurchase"" class=""btn btn-success""><i class=""icon ion-ios-arrow-forward""></i> Proceed to Payment</a>
            </div>
            <!-- end invoice action buttons -->
        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PurchaseOrder> Html { get; private set; }
    }
}
#pragma warning restore 1591
