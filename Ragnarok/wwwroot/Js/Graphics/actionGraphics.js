$(document).ready(function () {
    /* manually show/hide tab content to avoid chart visual problems */
    if ($('.headline').length > 0) {

        /* init chart */
        $('.headline a:first').tab('show');
        headlineSummaryChart('#headline-summary-chart');

        $('.headline a').click(function (e) {
            e.preventDefault();

            $tabId = $(this).attr('href');
            $chartId = $(this).attr('data-cid');

            /* adjust tab nav status */
            $('.headline li').removeClass('active');
            $(this).parent().addClass('active');

            /* show/hide tab pane */
            $('.headline .tab-pane').css('opacity', 0).removeClass('active');
            $('.headline .tab-pane' + $tabId).addClass('active').animate({
                opacity: 1
            }, 300);

            if ($chartId == '#headline-summary-chart') {
                headlineSummaryChart($chartId);
            } else if ($chartId == '#headline-sales-chart') {
                headlineSalesChart($chartId);
            } else if ($chartId == '#headline-bar-chart') {
                headlineBarChart($chartId);
            } else if ($chartId == '#headline-mini-chart') {
                headlineMiniChart();
            } else if ($chartId == '#headline-pie-chart') {
                headlinePieChart();
            }
        });
    }
    /* general chart parameters for demo charts page and dashboard charts */
    var demoChart = {
        linesFill: true,
        pointsFillColor: '#fff',
        pointsLineWidth: 2,
        linesLineWidth: 3,
        gridTickColor: '#e4e4e4',
        axisFontColor: '#555',
        xTickColor: '#fff'
    }
    // helper function, get day
    function gt(y, m, d) {
        return new Date(y, m - 1, d).getTime();
    }
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
        $('#dashboard-stat-tab-content .tab-pane' + $tabId).addClass('active').animate({
            opacity: 1
        }, 300);

        if ($chartId == '#dashboard-sales-main') {
            chartBarVerticalMain($chartId);
        } else if ($chartId == '#dashboard-comparative-weekly') {
            demoChart.linesFill = false;
            chartWeekMain($chartId);
        }
    });

    function chartBarVerticalMain(placeholder) {

        var result = [];

        $.ajax({
            type: "POST",
            url: "/Employee/Graphics/SalesSevenDays",
            async: true,
            success: function (message) {
                if (message.includes("Error")) {
                    //TODO implementar msg de erro
                } else {
                    result = message;

                    var basic = [
                        [gt(result[6].yaer, result[6].month, result[6].day), result[6].value],
                        [gt(result[5].yaer, result[5].month, result[5].day), result[5].value],
                        [gt(result[4].yaer, result[4].month, result[4].day), result[4].value],
                        [gt(result[3].yaer, result[3].month, result[3].day), result[3].value],
                        [gt(result[2].yaer, result[2].month, result[2].day), result[2].value],
                        [gt(result[1].yaer, result[1].month, result[1].day), result[1].value],
                        [gt(result[0].yaer, result[0].month, result[0].day), result[0].value]
                    ];

                    var gold = [
                        [gt(result[13].yaer, result[13].month, result[13].day), result[13].value],
                        [gt(result[12].yaer, result[12].month, result[12].day), result[12].value],
                        [gt(result[11].yaer, result[11].month, result[11].day), result[11].value],
                        [gt(result[10].yaer, result[10].month, result[10].day), result[10].value],
                        [gt(result[9].yaer, result[9].month, result[9].day), result[9].value],
                        [gt(result[8].yaer, result[8].month, result[8].day), result[8].value],
                        [gt(result[7].yaer, result[7].month, result[7].day), result[7].value]
                    ];

                    var platinum = [
                        [gt(result[20].yaer, result[20].month, result[20].day), result[20].value],
                        [gt(result[19].yaer, result[19].month, result[19].day), result[19].value],
                        [gt(result[18].yaer, result[18].month, result[18].day), result[18].value],
                        [gt(result[17].yaer, result[17].month, result[17].day), result[17].value],
                        [gt(result[16].yaer, result[16].month, result[16].day), result[16].value],
                        [gt(result[15].yaer, result[15].month, result[15].day), result[15].value],
                        [gt(result[14].yaer, result[14].month, result[14].day), result[14].value]
                    ];




                    var plot = $.plot(placeholder,
                        [
                            {
                                data: basic,
                                label: "Money"
                            },
                            {
                                data: gold,
                                label: "Debit"
                            },
                            {
                                data: platinum,
                                label: "Credito"
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
                            colors: ["#919191", "#5399D6", "#d7ea2b"],
                            yaxis: {
                                font: { color: demoChart.axisFontColor },
                            },
                            xaxis: {
                                mode: "time",
                                timezone: "browser",
                                minTickSize: [1, "day"],
                                timeformat: "%a",
                                font: { color: demoChart.axisFontColor },
                                tickColor: demoChart.xTickColor,
                                autoscaleMargin: 0.2
                            },
                            legend: {
                                labelBoxBorderColor: "transparent",
                                backgroundColor: "transparent"
                            },
                            tooltip: true,
                            tooltipOpts: {
                                content: '%s: %y'
                            }
                        }
                    );


                }
            }
        });           
            
    }

    function chartWeekMain(placeholder) {

        var result = [];

        $.ajax({

            type: "POST",
            url: "/Employee/Graphics/ComparativeWeekly",
            async:true,
            success: function (message) {
                if (message.includes("Error")) {
                    //TODO implementar msg de erro
                } else {
                    result = message;

                    var currentWeek = [
                        [gt(result[6].yaer, result[6].month, result[6].day), result[6].value],
                        [gt(result[5].yaer, result[5].month, result[5].day), result[5].value],
                        [gt(result[4].yaer, result[4].month, result[4].day), result[4].value],
                        [gt(result[3].yaer, result[3].month, result[3].day), result[3].value],
                        [gt(result[2].yaer, result[2].month, result[2].day), result[2].value],
                        [gt(result[1].yaer, result[1].month, result[1].day), result[1].value],
                        [gt(result[0].yaer, result[0].month, result[0].day), result[0].value]
                    ];

                    var lastWeek = [
                        [gt(result[6].yaer, result[6].month, result[6].day), result[13].value],
                        [gt(result[5].yaer, result[5].month, result[5].day), result[12].value],
                        [gt(result[4].yaer, result[4].month, result[4].day), result[11].value],
                        [gt(result[3].yaer, result[3].month, result[3].day), result[10].value],
                        [gt(result[2].yaer, result[2].month, result[2].day), result[9].value],
                        [gt(result[1].yaer, result[1].month, result[1].day), result[8].value],
                        [gt(result[0].yaer, result[0].month, result[0].day), result[7].value]
                    ];

                    var plot = $.plot(placeholder,
                        [
                            {
                                data: currentWeek,
                                label: "Semana atual",
                            },
                            {
                                data: lastWeek,
                                label: "Semana passada",
                            }
                        ],

                        {
                            series: {
                                lines: {
                                    show: true,
                                    lineWidth: demoChart.linesLineWidth,
                                    fill: demoChart.linesFill,
                                },
                                points: {
                                    show: true,
                                    lineWidth: demoChart.pointsLineWidth,
                                    fill: true,
                                    fillColor: demoChart.pointsFillColor
                                },

                                shadowSize: 0
                            },
                            grid: {
                                hoverable: true,
                                clickable: true,
                                borderWidth: 0,
                                tickColor: demoChart.gridTickColor
                            },
                            colors: ["#ff9800", "#ccc"],
                            yaxis: {
                                font: { color: demoChart.axisFontColor },
                                ticks: 5
                            },
                            xaxis: {
                                mode: "time",
                                timezone: "browser",
                                minTickSize: [1, "day"],
                                timeformat: "%a",
                                font: { color: demoChart.axisFontColor },
                                tickColor: "transparent",
                                autoscaleMargin: 0.02
                            },
                            legend: {
                                labelBoxBorderColor: "transparent",
                                backgroundColor: "transparent"
                            },
                            tooltip: true,
                            tooltipOpts: {
                                content: '%s: %y'
                            }

                        });



                }
            }
        })


        
    }

});

