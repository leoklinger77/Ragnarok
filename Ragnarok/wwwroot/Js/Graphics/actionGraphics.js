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
        } else if ($chartId == '#dashboard-visits-chart') {
            demoChart.linesFill = false;
            chartWeek($chartId);
        }
    });

    function chartBarVerticalMain(placeholder) {

        var result = "teste";

        $.ajax({
            type: "POST",
            url: "/Employee/Graphics/SalesSevenDays",
            data: { result },
            success: function (message) {
                result = message;
            }
        });


        var basic = [
            [gt(2013, 10, 21), 300], [gt(2013, 10, 22), 205], [gt(2013, 10, 23), 250], [gt(2013, 10, 24), 230], [gt(2013, 10, 25), 245], [gt(2013, 10, 26), 260], [gt(2013, 10, 27), 290]
        ];

        var gold = [
            [gt(2013, 10, 21), 100], [gt(2013, 10, 22), 110], [gt(2013, 10, 23), 155], [gt(2013, 10, 24), 120], [gt(2013, 10, 25), 135], [gt(2013, 10, 26), 150], [gt(2013, 10, 27), 175]
        ];

        var platinum = [
            [gt(2013, 10, 21), 75], [gt(2013, 10, 22), 65], [gt(2013, 10, 23), 80], [gt(2013, 10, 24), 60], [gt(2013, 10, 25), 65], [gt(2013, 10, 26), 80], [gt(2013, 10, 27), 110]
        ];

        var plot = $.plot(placeholder,
            [
                {
                    data: basic,
                    label: "Basic"
                },
                {
                    data: gold,
                    label: "Gold"
                },
                {
                    data: platinum,
                    label: "Platinum"
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

    function chartWeek(placeholder) {

        var currentWeek = [
            [gt(2013, 10, 21), 500], [gt(2013, 10, 22), 215], [gt(2013, 10, 23), 250], [gt(2013, 10, 24), 230], [gt(2013, 10, 25), 245],
            [gt(2013, 10, 26), 260], [gt(2013, 10, 27), 300]
        ];

        var lastWeek = [
            [gt(2013, 10, 21), 50], [gt(2013, 10, 22), 75], [gt(2013, 10, 23), 205], [gt(2013, 10, 24), 170], [gt(2013, 10, 25), 205],
            [gt(2013, 10, 26), 198], [gt(2013, 10, 27), 195]
        ];

        var plot = $.plot(placeholder,
            [
                {
                    data: currentWeek,
                    label: "Current Week",
                },
                {
                    data: lastWeek,
                    label: "Last Week",
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

});