#pragma checksum "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd0fb06ee7532cbb68a651645e434acd171e5516"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employee_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Employee/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd0fb06ee7532cbb68a651645e434acd171e5516", @"/Areas/Employee/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37626085e97468cf27092cf987fa52bfb6edda16", @"/Areas/Employee/Views/_ViewImports.cshtml")]
    public class Areas_Employee_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SalesOrder>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container-fluid primary-content"">
    <!-- PRIMARY CONTENT HEADING -->
    <div class=""primary-content-heading clearfix"">
        <h2>DASHBOARD</h2>
        <ul class=""breadcrumb pull-left"">
            <li><i class=""icon ion-home""></i><a href=""#"">Home</a></li>
            <li><a href=""#"">Dashboard</a></li>
            <li class=""active"">Dashboard v1</li>
        </ul>
        <div class=""sticky-content pull-right"">
            <div class=""btn-group btn-dropdown"">
                <button type=""button"" class=""btn btn-default btn-sm btn-favorites"" data-toggle=""dropdown""><i class=""icon ion-android-star""></i> Favorites</button>
                <ul class=""dropdown-menu dropdown-menu-right list-inline"">
                    <li><a href=""#""><i class=""icon ion-pie-graph""></i> <span>Statistics</span></a></li>
                    <li><a href=""#""><i class=""icon ion-email""></i> <span>Inbox</span></a></li>
                    <li><a href=""#""><i class=""icon ion-chatboxes""></i> <span>Chat</span");
            WriteLiteral(@"></a></li>
                    <li><a href=""#""><i class=""icon ion-help-circled""></i> <span>Help</span></a></li>
                    <li><a href=""#""><i class=""icon ion-gear-a""></i> <span>Settings</span></a></li>
                    <li><a href=""#""><i class=""icon ion-help-buoy""></i> <span>Support</span></a></li>
                </ul>
            </div>
        </div>
    </div>
    <!-- END PRIMARY CONTENT HEADING -->
    <div class=""widget widget-no-header widget-transparent bottom-30px"">
        <!-- QUICK SUMMARY INFO -->
        <div class=""widget-content"">
            <h3 class=""sr-only"">QUICK SUMMARY INFO</h3>
            <div class=""row"">
                <div class=""col-sm-3 text-center"">
                    <div class=""quick-info horizontal"">
                        <i class=""icon ion-thumbsup pull-left bg-seagreen""></i>
                        <p>3700 <span>LIKES</span></p>
                    </div>
                </div>
                <div class=""col-sm-3 text-center"">
        ");
            WriteLiteral(@"            <div class=""quick-info horizontal"">
                        <i class=""icon ion-arrow-graph-up-right pull-left bg-orange""></i>
                        <p>27% <span>GROWTH</span></p>
                    </div>
                </div>
                <div class=""col-sm-3 text-center"">
                    <div class=""quick-info horizontal"">
                        <i class=""icon ion-cash pull-left bg-green""></i>
                        <p>$5,400 <span>PROFIT</span></p>
                    </div>
                </div>
                <div class=""col-sm-3 text-center"">
                    <div class=""quick-info horizontal"">
                        <i class=""icon ion-person-stalker pull-left bg-blue""></i>
                        <p>7285 <span>USERS</span></p>
                    </div>
                </div>
            </div>
        </div>
        <!-- END QUICK SUMMARY INFO -->
    </div>
    <div class=""row"">
        <div class=""col-md-8"">
            <!-- CHART WITH JUSTIFIED ");
            WriteLiteral(@"TAB -->
            <div class=""widget"">
                <div class=""widget-header clearfix no-padding"">
                    <h3 class=""sr-only""><span>SALES AND VISITS STAT</span></h3>
                    <ul id=""dashboard-stat-tab"" class=""nav nav-pills nav-justified"">
                        <li class=""active""><a href=""#tab-sales"" data-cid=""#dashboard-sales-main"">Vendas</a></li>
                        <li");
            BeginWriteAttribute("class", " class=\"", 3561, "\"", 3569, 0);
            EndWriteAttribute();
            WriteLiteral(@"><a href=""#tab-visits"" data-cid=""#dashboard-visits-chart"">Fluxo de Caixa</a></li>
                    </ul>
                </div>
                <div id=""dashboard-stat-tab-content"" class=""widget-content tab-content"">
                    <div class=""tab-pane fade in active"" id=""tab-sales"">
                        <div class=""flot-chart"" id=""dashboard-sales-main""></div>
                    </div>
                    <div class=""tab-pane fade"" id=""tab-visits"">
                        <div class=""flot-chart"" id=""dashboard-visits-chart""></div>
                    </div>
                </div>
            </div>
            <!-- END CHART WITH JUSTIFIED TAB -->
        </div>
        <div class=""col-md-4"">
            <!-- ORDER STATUS -->
            <div class=""widget"">
                <div class=""widget-header clearfix"">
                    <h3><i class=""icon ion-bag""></i> <span>Ultimas Vendas</span></h3>                    
                </div>
                <div class=""widget-content");
            WriteLiteral(@""">
                    <table class=""table table-condensed"">
                        <thead>
                            <tr>
                                <th>Status</th>
                                <th>N. Order</th>
                                <th>Valor Total</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 102 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n");
#nullable restore
#line 105 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
                                     if (item.Payment.StatusPayment == Ragnarok.Models.Enums.StatusPayment.Pending)
                                    {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"label label-danger\">Pendente</span></td>\r\n");
#nullable restore
#line 110 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"label label-success\">Pago</span></td>\r\n");
#nullable restore
#line 114 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <td><a href=\"#\">");
#nullable restore
#line 116 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
                                               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                                    <td>");
#nullable restore
#line 117 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
                                   Write(item.TotalSales());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 119 "C:\Users\Kling\Desktop\Project_Ragnarok\Ragnarok\Ragnarok\Areas\Employee\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
            <!-- END ORDER STATUS -->
        </div>
    </div>

</div>
<script language=""javascript"" type=""text/javascript"">
    if ($('.basic-charts').length > 0) {

        if ($('#demo-area-chart').length > 0)
            chartWeek($('#demo-area-chart'));
    }

    $('#dashboard-stat-tab a:first').tab('show');
    if ($('#dashboard-sales-main').length > 0)
        chartBarVerticalMain($('#dashboard-sales-main'));

    $('#dashboard-stat-tab a').click(function (e) {
        e.preventDefault();

        $tabId = $(this).attr('href');
        $chartId = $(this).attr('data-cid');

        $('#dashboard-stat-tab li').removeClass('active');
        $(this).parents('li').addClass('active');

        /* show/hide tab pane */
        $('#dashboard-stat-tab-content .tab-pane').css('opacity', 0).removeClass('active');
        $('#dashboard-stat-tab-content .tab-pane' + $tabId).addCl");
            WriteLiteral(@"ass('active').animate({
            opacity: 1
        }, 300);

        if ($chartId == '#dashboard-sales-main') {
            chartBarVerticalMain($chartId);
        } else if ($chartId == '#dashboard-visits-chart') {
            demoChart.linesFill = false;
            chartWeek($chartId);
        }
    });

   function chartBarVerticalMain(placeholder) {
        var basic = [
            [gt(2013, 10, 21), 300], [gt(2013, 10, 22), 205], [gt(2013, 10, 23), 250], [gt(2013, 10, 24), 230], [gt(2013, 10, 25), 245], [gt(2013, 10, 26), 260], [gt(2013, 10, 27), 290]
        ];

        var gold = [
            [gt(2013, 10, 21), 100], [gt(2013, 10, 22), 110], [gt(2013, 10, 23), 155], [gt(2013, 10, 24), 120], [gt(2013, 10, 25), 135], [gt(2013, 10, 26), 150], [gt(2013, 10, 27), 175]
        ];

        var platinum = [
            [gt(2013, 10, 21), 75], [gt(2013, 10, 22), 65], [gt(2013, 10, 23), 80], [gt(2013, 10, 24), 60], [gt(2013, 10, 25), 65], [gt(2013, 10, 26), 80], [gt(2013, 10, 27), 11");
            WriteLiteral(@"0]
        ];

        var plot = $.plot(placeholder,
            [
                {
                    data: basic,
                    label: ""Basic""
                },
                {
                    data: gold,
                    label: ""Gold""
                },
                {
                    data: platinum,
                    label: ""Platinum""
                }
            ],
            {
                bars: {
                    show: true,
                    barWidth: 15 * 60 * 60 * 300,
                    fill: true,
                    order: true,
                    lineWidth: 0,
                    fillColor: { colors: [{ opacity: 1 }, { opacity: 1 }] }
                },
                grid: {
                    hoverable: true,
                    clickable: true,
                    borderWidth: 0,
                    tickColor: demoChart.gridTickColor,

                },
                colors: [""#919191"", ""#5399D6"", ""#d7ea2b""],
     ");
            WriteLiteral(@"           yaxis: {
                    font: { color: demoChart.axisFontColor },
                },
                xaxis: {
                    mode: ""time"",
                    timezone: ""browser"",
                    minTickSize: [1, ""day""],
                    timeformat: ""%a"",
                    font: { color: demoChart.axisFontColor },
                    tickColor: demoChart.xTickColor,
                    autoscaleMargin: 0.2
                },
                legend: {
                    labelBoxBorderColor: ""transparent"",
                    backgroundColor: ""transparent""
                },
                tooltip: true,
                tooltipOpts: {
                    content: '%s: %y'
                }
            }
        );
    }

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SalesOrder>> Html { get; private set; }
    }
}
#pragma warning restore 1591
