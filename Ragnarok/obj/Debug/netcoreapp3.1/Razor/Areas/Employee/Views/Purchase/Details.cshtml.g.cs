#pragma checksum "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d75c9f31ad1d7af155b7d3919c564fc3c05e12d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employee_Views_Purchase_Details), @"mvc.1.0.view", @"/Areas/Employee/Views/Purchase/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75c9f31ad1d7af155b7d3919c564fc3c05e12d8", @"/Areas/Employee/Views/Purchase/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37626085e97468cf27092cf987fa52bfb6edda16", @"/Areas/Employee/Views/_ViewImports.cshtml")]
    public class Areas_Employee_Views_Purchase_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PurchaseOrder>
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
  
    ViewData["Title"] = "Details";

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d75c9f31ad1d7af155b7d3919c564fc3c05e12d87799", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d75c9f31ad1d7af155b7d3919c564fc3c05e12d89379", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d75c9f31ad1d7af155b7d3919c564fc3c05e12d810971", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d75c9f31ad1d7af155b7d3919c564fc3c05e12d812634", async() => {
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
#line 31 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
     if (TempData["MSG_S"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success fade in\">\r\n            <button class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n            <i class=\"icon ion-checkmark-circled\"></i>\r\n            <strong>Feito!</strong> ");
#nullable restore
#line 36 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(TempData["MSG_S"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 38 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
     if (TempData["MSG_E"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger fade in\">\r\n            <button class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n            <i class=\"icon ion-checkmark-circled\"></i>\r\n            <strong>Erro!</strong> ");
#nullable restore
#line 44 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                              Write(TempData["MSG_E"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 46 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"invoice\">\r\n        <!-- invoice header -->\r\n        <div class=\"invoice-header\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-3 col-print-3\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d75c9f31ad1d7af155b7d3919c564fc3c05e12d817603", async() => {
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
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-9 col-print-9\">\r\n                    <ul class=\"list-inline\">\r\n                        <li>Número da Ordem #: <strong>");
#nullable restore
#line 56 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                  Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></li>\r\n                        <li>Data: <strong>");
#nullable restore
#line 57 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                     Write(Model.InsertDate.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></li>\r\n                        <li>Valor Total: <strong id=\"totalTop\">");
#nullable restore
#line 58 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                          Write(Model.TotalPurchase().ToString("F2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- end invoice header -->
        <!-- invoice address -->
        <div class=""invoice-from-to"">
            <div class=""row"">
                <div class=""col-sm-5 col-print-6"">
");
#nullable restore
#line 68 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                     if (Model.Supplier is SupplierJuridical)
                    {
                        SupplierJuridical supplier = (SupplierJuridical)Model.Supplier;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"name\" id=\"companyNamePurchase\">");
#nullable restore
#line 71 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                            Write(supplier.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <address id=\"companyDescriptionPurchase\">\r\n                            ");
#nullable restore
#line 73 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                       Write(supplier.Address.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 73 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                  Write(supplier.Address.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <br />\r\n                            ");
#nullable restore
#line 75 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                       Write(supplier.Address.Neighborhood);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 75 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                        Write(supplier.Address.City.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 75 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                                                     Write(supplier.Address.City.State.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <br />\r\n                            <div class=\'contact\'>\r\n\r\n                                <p><span>Email:</span> ");
#nullable restore
#line 79 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                  Write(supplier.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n\r\n                            </div>\r\n                        </address>\r\n");
#nullable restore
#line 84 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                    }
                    else
                    {
                        SupplierPhysical supplier = (SupplierPhysical)Model.Supplier;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"name\" id=\"companyNamePurchase\">");
#nullable restore
#line 88 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                            Write(supplier.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <address id=\"companyDescriptionPurchase\">\r\n                            ");
#nullable restore
#line 90 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                       Write(supplier.Address.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </address>\r\n");
#nullable restore
#line 92 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
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
                            <th>Preço Compra</th>
                            <th>Preço Venda</th>
                            <th>Desconto</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 113 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                         foreach (var item in Model.PurchaseItemOrder)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 116 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 117 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 118 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 119 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(item.PurchasePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 120 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(item.SalesPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 121 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(item.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 122 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                               Write(item.TotalDiscontPurchase());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 124 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
            <!-- end invoice item table -->
            <!-- invoice footer -->
            <div class=""invoice-footer"">
                <div class=""row"">
                    <div class=""col-sm-5 col-sm-offset-1 col-print-4 col-print-offset-2 right-col"">
                        <div class=""invoice-total"">
                            <div class=""row"">
                                <div class=""col-xs-4 col-xs-offset-4 col-print-6 col-print-offset-2"">
                                    <p>Subtotal</p>
                                    <p>Total Desconto</p>
                                    <p>Total à pagar</p>
                                </div>
                                <div class=""col-xs-4 text-right col-print-4"">
                                    <p id=""resultSubTotal"">R$ ");
#nullable restore
#line 141 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                         Write(Model.Total());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p id=\"resultDiscont\">R$ ");
#nullable restore
#line 142 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                        Write(Model.TotalDiscont());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p id=\"resultTotalPayment\">R$ ");
#nullable restore
#line 143 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                                                             Write(Model.TotalPurchase());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-print-6 left-col"">
                        <blockquote class=""invoice-notes"">
                            <strong>Notes:</strong>
                            <p>");
#nullable restore
#line 151 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Purchase\Details.cshtml"
                          Write(Model.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </blockquote>
                    </div>
                </div>
            </div>
            <!-- end invoice footer -->
            <!-- invoice action buttons -->
            <div class=""invoice-buttons"">
                <button class=""btn btn-default print-btn""><i class=""icon ion-printer""></i> Print</button>                
            </div>
            <!-- end invoice action buttons -->
        </div>
    </div>
</div>");
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
