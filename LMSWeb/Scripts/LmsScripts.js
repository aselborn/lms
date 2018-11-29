var FilterParameters = {};
var selectedChartType = null;
var AddSerieOk = false;

var MyChart;
var MyChartData = {};

var ChartOptionsStacked = {

    title: {
        display: true,
        text: 'Stacked Chart'
    },
    tooltips: {
        mode: 'index',
        intersect: false
    },
    responsive: true,
    scales: {
        xAxes: [{
            stacked: true,
            barPercentage: 0.4
        }],
        yAxes: [{
            stacked: true
        }]
    }

}

var ChartOptions = {
    title: {
        display: true,
        text: 'Antal händelser.'
    },
    maintainAspectRatio: false,
    scales: {
        yAxes: [{
            ticks: {
                min: 0,
                beginAtZero: true
            },
            gridLines: {
                display: true,
                color: "rgba(255,99,164,0.2)"
            }
        }],
        xAxes: [{
            ticks: {
                min: 0,
                beginAtZero: true
            },
            barPercentage: 0.4,
            gridLines: {
                display: false
            }
        }]
    }
};

var MyBackgroundColors = {
    col1: 'rgba(255, 99, 132, 0.2)',
    col2: 'rgba(54, 162, 235, 0.2)',
    col3: 'rgba(255, 206, 86, 0.2)',
    col4: 'rgba(75, 192, 192, 0.2)',
    col5: 'rgba(153, 102, 255, 0.2)',
    col6: 'rgba(255, 159, 64, 0.2)',
    col7: 'rgba(255, 0, 0)',
    col8: 'rgba(0, 255, 0)',
    col9: 'rgba(0, 0, 255)',
    col10: 'rgba(192, 192, 192)',
    col11: 'rgba(255, 255, 0)',
    col12: 'rgba(255, 0, 255)'
};

var MyBorderColors = {
    col1: 'rgba(255,99,132,1)',
    col2: 'rgba(54, 162, 235, 1)',
    col3: 'rgba(255, 206, 86, 1)',
    col4: 'rgba(75, 192, 192, 1)',
    col5: 'rgba(153, 102, 255, 1)',
    col6: 'rgba(255, 159, 64, 1)',
    col7: 'rgba(255, 0, 0)',
    col8: 'rgba(0, 255, 0)',
    col9: 'rgba(0, 0, 255)',
    col10: 'rgba(192, 192, 192)',
    col11: 'rgba(255, 255, 0)',
    col12: 'rgba(255, 0, 255)'
};

var MyFixedColors = { 
    no_activity: 'rgba(255,255,0,0.3)', //yellow
    rig_stop: 'rgba(255, 0, 0, 0.3)', //red
    fp_activity: 'rgba(0,255,0,0.3)', //green
    lp_activity: 'rgba(0,255,0,0.3)', //green
    planned_maintenance: 'rgba(0,0,255,0.3)' // blue
};

MychartColors = {
    red: 'rgb(255, 99, 132)',
    orange: 'rgb(255, 159, 64)',
    yellow: 'rgb(255, 205, 86)',
    green: 'rgb(75, 192, 192)',
    blue: 'rgb(54, 162, 235)',
    purple: 'rgb(153, 102, 255)',
    grey: 'rgb(231,233,237)'
};

var BackColors = [];
var ForColors = [];
var FixedColors = [];

function IsOneOfCheckboxAllSelected() {

    var alleventsChecked = document.getElementById("chkEventTypes").checked;
    var allSubeventsChecked = document.getElementById("chkSubEventTypes").checked;

    if (alleventsChecked === true || allSubeventsChecked === true)
        return true;
    else
        return false;
}

function SetFilterParameters() {

    var myCheckedValue;
    $('input:radio').each(function () {
        if ($(this).is(':checked')) {
            // You have a checked radio button here...
            myCheckedValue = $(this).val();
        }

    });

    FilterParameters.StartDate = $("#FromDate").val();
    FilterParameters.StopDate = $("#TomDate").val();
    FilterParameters.AllSubEvents = $('#chkSubEventTypes').is(":checked") == true ? true : false;
    FilterParameters.AllEvents = $('#chkEventTypes').is(":checked") == true ? true : false;

    if (FilterParameters.AllEvents) {
        FilterParameters.EventTypeId = $('#ddlEventTypes').val();
    } else {
        FilterParameters.EventTypeId = $('#chkSubEventTypes').is(":checked") == true ? $('#ddlEventTypes').val() : $('#idSubEvent').val();
    }

    FilterParameters.WithReporting = $("#ddlReportType").val();
    FilterParameters.TestBedId = $("#ddlTestBed").val();
    FilterParameters.WithGrouping = myCheckedValue;


    FilterParameters.AllTestBeds = $("#chkAllTestBed").is(":checked") == true ? true : false;
}

function AddNewSerie() {

    if (IsOneOfCheckboxAllSelected()) {
        alert('Please uncheck both All Events, and All SubEvents to add a serie.');
        return;
    }
    var prevId = FilterParameters.EventTypeId;

    SetFilterParameters();
    
    //Ajax call
    $.ajax({
        url: 'Data',
        type: 'POST',
        dataType: 'JSON',
        data: '{data: ' + JSON.stringify(FilterParameters) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            var jsondata = response;

            addChartSerie(jsondata, FilterParameters);

        },
        error: function (xhr, status, error) {
            $("#addSubEvent").prop("disabled", true);
            alert('Failed to get correct data (most probably a bug). Check if there is a log!!');
        }

    });

}

function FetchStatistics() {

    SetFilterParameters();

    if (FilterParameters.TestBedId == "") {
        //chkAllTestBed
        var isAllTestbedsChecked = $('#chkAllTestBed').is(':checked');

        if (isAllTestbedsChecked === false) {
            if (FilterParameters.WithReporting === "2") {
                alert('You must select ONE or ALL testbeds.');
                return;
            } else {
                alert('A testbed must be selected. Exiting.');
                return;
            }

        }

    }

    
    var jsonData = JSON.stringify(FilterParameters);

    $.ajax({
        url: 'Data',
        type: 'POST',
        dataType: 'JSON',
        data: '{data: ' + JSON.stringify(FilterParameters) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            var jsondata = response;
            $("#chart").html("");

            //Reply in JSON format, to build up statistic page.

            $.each(jsondata, function (i, item) {
                $("#chart").html(item.Text);
            });

            if (FilterParameters.WithReporting === "2") { // Hardcoded, param in db. check if not sure.

                var selectedTestbedText = $("#ddlTestBed option:selected").text();
                //Utilization, nyttjandegrad.
                var infoObj = {

                    testBed: selectedTestbedText,
                    charttype: selectedChartType
                };
                DrawUtilization(jsondata, infoObj);

            } else if (FilterParameters.WithReporting === "1") {

                if (FilterParameters.WithGrouping === "Day") {
                    DrawMyStacked(jsondata);
                } else {
                    DrawChart(jsondata, selectedChartType);
                }

            }


            //Series button enabled/disabled?
            if (jsondata.length > 0) {
                $("#addSubEvent").prop("disabled", false); //Add serie enabled
                $("#addSubEvent").removeClass("btn-default");
                $("#addSubEvent").addClass("btn-info");
            } else {
                $("#addSubEvent").prop("disabled", true); //Add serie disabled.
                $("#addSubEvent").removeClass("btn-info");
                $("#addSubEvent").addClass("btn-default");
            }
        },
        error: function (xhr, status, error) {
            $("#addSubEvent").prop("disabled", true);
            alert('Failed to get correct data (most probably a bug). Check if there is a log!!');
        }

    });

}

function AllSubEventsSelected(element) {
    //element.checked ? alert('checked.') : alert('not checked');
    //allEvents.checked = element.checked ? true : false;
    var checked = element.checked ? true : false;
    //$('#IsSubAllEvents').val(checked);

    if (checked) {
        document.getElementById("idSubEvent").disabled = checked;
    } else {
        document.getElementById("idSubEvent").disabled = checked;
    }


}

function AllEventsSelected(element) {
    //element.checked ? alert('checked.') : alert('not checked');
    //allEvents.checked = element.checked ? true : false;
    var checked = element.checked ? true : false;

    //Set this control disabled.
    if (checked) {
        document.getElementById("ddlEventTypes").disabled = checked;
        document.getElementById("idSubEvent").disabled = checked;
    } else {
        document.getElementById("ddlEventTypes").disabled = checked;
        document.getElementById("idSubEvent").disabled = checked;
    }

}

function AllTestBedsSelected(element) {
    //element.checked ? alert('checked.') : alert('not checked');
    //allEvents.checked = element.checked ? true : false;
    var checked = element.checked ? true : false;

    //Set this control disabled.
    if (checked) {
        $("#ddlTestBed").prop('disabled', true);
    } else {
        $("#ddlTestBed").prop('disabled', false);
    }

}

function filterEvents() {
    var eventTypeId = $('#ddlEventTypes').val();

    $.ajax({
        url: 'Details',
        type: "GET",
        dataType: "JSON",
        data: { MasterEventId: eventTypeId },
        success: function (SubEventTypes) {
            $('#idSubEvent').html("");

            var jsondata = SubEventTypes;

            $.each(jsondata, function (i, item) {
                $('#idSubEvent').append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });

        }
    })
}

//Om Nyttjandegrad vald, filtrera GUI.
function filterReportType() {
    var reportTypeId = $("#ddlReportType").val();
    var reportText = $("#ddlReportType").text();

    $("#ddlTestBed").prop('disabled', false);

    //Disable eventtypes selection
    if (reportTypeId === "2") {
        document.getElementById("idSubEvent").disabled = true;
        document.getElementById("ddlEventTypes").disabled = true;
        document.getElementById('chkEventTypes').disabled = true;
        document.getElementById('chkSubEventTypes').disabled = true;
        document.getElementById('addSubEvent').style.visibility = "hidden";

        $("#chkAllTestBed").show();
        $("#lblAllTestBeds").show();
    } else {
        document.getElementById("idSubEvent").disabled = false;
        document.getElementById("ddlEventTypes").disabled = false;
        document.getElementById('chkEventTypes').disabled = false;
        document.getElementById('chkSubEventTypes').disabled = false;
        document.getElementById('addSubEvent').style.visibility = "visible";
        $("#chkAllTestBed").hide();
        $("#lblAllTestBeds").hide();

    }

    ///****TESTING
    //Ajax call

    var popupObject = {
        TestBed: 'TestBednamn',
        MainEventTypeDescription: 'MainEventDescriptionNamn',
        SubEventTypeDescription: 'SubEventTypeDescriptionNamn',
        Message: 'MessageInfoText'
    };

    //$.ajax({
    //    url: 'Modalpopup',
    //    type: 'POST',
    //    dataType: 'JSON',
    //    data: '{data: ' + JSON.stringify(popupObject) + '}',
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (response) {

    //        var jsondata = response;

    //        //addChartSerie(jsondata, FilterParameters);

    //    },
    //    error: function (xhr, status, error) {
    //        //$("#addSubEvent").prop("disabled", true);
    //        //alert('Failed to get correct data (most probably a bug). Check if there is a log!!');
    //    }

    //});

}


function fillColors() {

    BackColors.push(MyBackgroundColors.col1);
    BackColors.push(MyBackgroundColors.col2);
    BackColors.push(MyBackgroundColors.col3);
    BackColors.push(MyBackgroundColors.col4);
    BackColors.push(MyBackgroundColors.col5);
    BackColors.push(MyBackgroundColors.col6);
    BackColors.push(MyBackgroundColors.col7);
    BackColors.push(MyBackgroundColors.col8);
    BackColors.push(MyBackgroundColors.col9);
    BackColors.push(MyBackgroundColors.col10);
    BackColors.push(MyBackgroundColors.col11);
    BackColors.push(MyBackgroundColors.col12);

    FixedColors.push(MyFixedColors.fp_activity);
    FixedColors.push(MyFixedColors.lp_activity);
    FixedColors.push(MyFixedColors.no_activity);
    FixedColors.push(MyFixedColors.planned_maintenance);
    FixedColors.push(MyFixedColors.rig_stop);

    ForColors.push(MychartColors.col1);
    ForColors.push(MychartColors.col2);
    ForColors.push(MychartColors.col3);
    ForColors.push(MychartColors.col4);
    ForColors.push(MychartColors.col5);
    ForColors.push(MychartColors.col6);
    ForColors.push(MychartColors.col7);
    ForColors.push(MychartColors.col8);
    ForColors.push(MychartColors.col9);
    ForColors.push(MychartColors.col10);
    ForColors.push(MychartColors.col11);
    ForColors.push(MychartColors.col12);


}



function addChartSerie(data, parameters) {
    //alert('Adding serie');

  
    //Appending to current
    var myEventLabel = [];
    var dateLabel = [];
    var dataValues = [];

    var newDataset = {};

    var newXValue = false;

    for (var x = 0; x < data.length; x++) {
        myEventLabel.push(data[x].info.trim());
        dataValues.push(data[x].myValue);
        dateLabel.push(data[x].Text);
    }
   

    //Ny text vid botten?
    if ($.inArray(data[0].Text, myChart.data.labels) === -1) {
        myChart.data.labels.push(data[0].Text);
        myChart.update();
        newXValue = true;
    }

    for (var stapel = 0; stapel < myChart.data.labels.length; stapel++) {

        var eventDate = myChart.data.labels[stapel];

        for (var p = 0; p < myChart.data.datasets.length; p++) { //Loopa igenom alla klossar för varje stapel! //myChart.data.datasets[KLOSS].data[STAPEL] = 1;

            var selectedEventType = $("#ddlEventTypes option:selected").text().toLowerCase().split(' ').join('_');

            if ($.inArray(eventDate, dateLabel) === 0) {
                //stapeln finns.

                newDataset = {
                    label: myEventLabel[0],
                    //backgroundColor: BackColors[xp],
                    backgroundColor: MyFixedColors[selectedEventType],
                    borderColor: ForColors[selectedEventType],
                    data: dataValues,
                    fill: false
                };

            } 
            
        }

        //myChart.data.labels.push("other label.");
        myChart.data.datasets.push(newDataset);
        myChart.data.datasets
        myChart.update();

    }
    

  

}


function DrawUtilization(dataSets, info) {
    resetCanvas();
    fillColors();

    var myValues = [];
    var myEventLabels = [];
    var myDateLabels = [];

    for (var n = 0; n <= dataSets.length - 1; n++) {

        var myObject = dataSets[n];

        if (myDateLabels.indexOf(myObject.Text) == -1) {
            myDateLabels.push(myObject.Text);
        }

        if ($.inArray(myObject.info.trim(), myEventLabels) === -1) {
            myEventLabels.push(myObject.info.trim());
        }

        if (parseInt(myObject.myValue) > 0) {

            var utilizationData = {

                EventDate: myObject.Text.trim(),
                EventName: myObject.info.trim(),
                EventPercentage: myObject.myValue

            };
            myValues.push(utilizationData);
        }
    }


    var chartData = {
        labels: myDateLabels,
        datasets: []
    };
    //ChartOptionsStacked.title = 'bacon';

    if (info.charttype.toLowerCase() === "bar") {
        var myChart = new Chart(ctx, {
            options: ChartOptionsStacked,
            data: chartData,
            type: info.charttype.toLowerCase()
        });

    } else {
        var myChart = new Chart(ctx, {
            options: ChartOptions,
            data: chartData,
            type: info.charttype.toLowerCase()
        });
    }



    ////Create initial chart, all values same
    for (var xp = 0; xp < myEventLabels.length; xp++) {

        var eventName = myEventLabels[xp].toLowerCase().split(' ').join('_');
        
        var newDataset = {
            label: myEventLabels[xp],
            //backgroundColor: BackColors[xp],
            backgroundColor: MyFixedColors[eventName],
            borderColor: ForColors[xp],
            data: [],
            fill: false
        };

        for (var index = 0; index < myChart.data.labels.length; ++index) {
            newDataset.data.push(0);
        }

        myChart.data.datasets.push(newDataset);
        //myChart.titleBlock.options.text = "Utilization for " + info.testBed + "(percent values)"; //setting chart title.
        myChart.update();
    }

    //Now, fix the values to correct values.
    //Uppdatera...?
    for (var stapel = 0; stapel < myChart.data.labels.length; stapel++) {

        var eventDate = myChart.data.labels[stapel];

        for (var p = 0; p < myChart.data.datasets.length; p++) { //Loopa igenom alla klossar för varje stapel! //myChart.data.datasets[KLOSS].data[STAPEL] = 1;

            var eventLabel = myChart.data.datasets[p].label;

            //Find that label in myValues array.

            for (var z = 0; z < myValues.length; z++) {

                var d = myValues[z];
                if (d.EventDate === eventDate && d.EventName === eventLabel) {
                    myChart.data.datasets[p].data[stapel] = d.EventPercentage;
                    myChart.update();
                }

            }

        }
    }

}

function DrawMyStacked(dataSets) {

    resetCanvas();
    fillColors();

    var myDateLabels = [];

    var myValues = [];
    var myEventLabels = [];

    for (var n = 0; n <= dataSets.length - 1; n++) {

        var myObject = dataSets[n];

        for (var p = 0; p <= myObject.length - 1; p++) {

            if (myDateLabels.indexOf(myObject[p].EventTime) == -1) {
                myDateLabels.push(myObject[p].EventTime);
            }

            if ($.inArray(myObject[p].EventTypeDescription.trim(), myEventLabels) === -1) {
                myEventLabels.push(myObject[p].EventTypeDescription.trim());
            }

            var eventData = {
                EventTime: myObject[p].EventTime,
                EventTypeDescription: myObject[p].EventTypeDescription.trim(),
                Number: myObject[p].Number
            };


            myValues.push(eventData);
        }
    }

    var chartData = {
        labels: myDateLabels,
        datasets: []
    };

    /*
    var myChart = new Chart(ctx, {
        options: ChartOptionsStacked,
        data: chartData,
        type: 'bar'
    });
    */

    myChart = new Chart(ctx, {
        options: ChartOptionsStacked,
        data: chartData,
        type: 'bar'
    });

    ////Create initial chart, all values same
    for (var xp = 0; xp < myEventLabels.length; xp++) {
        var newDataset = {
            label: myEventLabels[xp],
            //backgroundColor: BackColors[xp],
            backgroundColor: MyFixedColors[myEventLabels[xp]],
            borderColor: ForColors[xp],
            data: [],
            fill: false
        };

        for (var index = 0; index < myChart.data.labels.length; ++index) {
            newDataset.data.push(0);
        }

        myChart.data.datasets.push(newDataset);
        myChart.update();
    }

    //Now, fix the values to correct values.
    //Uppdatera...?
    for (var stapel = 0; stapel < myChart.data.labels.length; stapel++) {

        var eventDate = myChart.data.labels[stapel];

        for (var p = 0; p < myChart.data.datasets.length; p++) { //Loopa igenom alla klossar för varje stapel! //myChart.data.datasets[KLOSS].data[STAPEL] = 1;

            var eventLabel = myChart.data.datasets[p].label;

            //Find that label in myValues array.

            for (var z = 0; z < myValues.length; z++) {

                var d = myValues[z];
                if (d.EventTime === eventDate && d.EventTypeDescription === eventLabel) {
                    myChart.data.datasets[p].data[stapel] = d.Number;
                    myChart.update();
                }

            }

        }
    }

}



function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}



function addData(chart, label, color, data) {
    chart.data.labels.push(label);
    chart.data.datasets.forEach((dataset) => {
        dataset.data.push(data);
    });
    chart.update();
}

function addData2(label, color, data) {
    myChart.data.labels.push(label);
    myChart.data.datasets.forEach((dataset) => {
        dataset.data.push(data);
    });
    myChart.update();
}


function DrawStacked() {

    resetCanvas();

    var chartName = "chart";
    var ctx = document.getElementById(chartName).getContext('2d');

    var myLabels = [];
    var myValues = [];


    var data = {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
        datasets: [{
            label: 'Dataset 1',
            backgroundColor: window.chartColors.red,
            data: [
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor()
            ]
        }, {
            label: 'Dataset 2',
            backgroundColor: window.chartColors.blue,
            data: [
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor()
            ]
        }, {
            label: 'Dataset 3',
            backgroundColor: window.chartColors.green,
            data: [
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor()
            ]
        }]

    };

    var newOptions = {

        title: {
            display: true,
            text: 'Chart.js Bar Chart - Stacked'
        },
        tooltips: {
            mode: 'index',
            intersect: false
        },
        responsive: true,
        scales: {
            xAxes: [{
                stacked: true,
            }],
            yAxes: [{
                stacked: true
            }]
        }

    }

    /*
    var myChart = new Chart(ctx, {
        options: newOptions,
        data: data,
        type: 'bar'

    });
    */

    myChart = new Chart(ctx, {
        options: newOptions,
        data: data,
        type: 'bar'

    });
}

/*
 * Working example...used for test purposes.
*/
function DrawFixedDates() {

    resetCanvas();

    var chartName = "chart";
    var ctx = document.getElementById(chartName).getContext('2d');

    var myLabels = [];
    var myValues = [];
    var myLabels = ["Stop Reason 2", "Daily", "FP Reason 3", "None", "FP Reason 2"];

    var chartData = {
        labels: ['2018-11-01', '2018-11-02', '2018-11-03'],
        datasets: []
    };

    /*
    var myChart = new Chart(ctx, {
        options: ChartOptionsStacked,
        data: chartData,
        type: 'bar'

    });
    */

    myChart = new Chart(ctx, {
        options: ChartOptionsStacked,
        data: chartData,
        type: 'bar'

    });

    for (var xp = 0; xp < myLabels.length; xp++) {

        var newDataset = {
            label: myLabels[xp],
            backgroundColor: getRandomColor(),
            borderColor: getRandomColor(),
            data: [],
            fill: false
        };

        for (var index = 0; index < myChart.data.labels.length; ++index) {
            newDataset.data.push(2);
        }

        myChart.data.datasets.push(newDataset);
        myChart.update();
    }


    //myChart.data.datasets[KLOSS].data[STAPEL] = 1;

    myChart.data.datasets[3].data[2] = 1;
    myChart.update();



}

function DrawChart(SimpleResultObject, typeOfChart) {

    resetCanvas();
    fillColors();

    var chartName = "chart";
    var ctx = document.getElementById(chartName).getContext('2d');

    var myLabels = [];
    var myValues = [];

    $.each(SimpleResultObject, function (i, item) {
        $(myLabels.push(item.Text))
        $(myValues.push(item.myValue))
    });

    var chartLabel = SimpleResultObject[0]["info"].trim();
    
    var selectedEventType = $("#ddlEventTypes option:selected").text().toLowerCase().split(' ').join('_');
    var data = {
        labels: myLabels,
        datasets: [{
            label: chartLabel,
            backgroundColor: MyFixedColors[selectedEventType],
            borderColor: MyFixedColors[selectedEventType],
            borderWidth: 1,
            data: myValues
        }]
    };



    myChart = new Chart(ctx, {
        options: ChartOptions,
        data: data,
        type: typeOfChart.toLowerCase()

    });

    /*
    var myChart = new Chart(ctx, {
        options: ChartOptions,
        data: data,
        type: typeOfChart.toLowerCase()

    });
    */
    var chartTitle = "[Testbed] : " + $("#ddlTestBed option:selected").text();
    if (FilterParameters.AllEvents) {
        //chartTitle = $("#ddlEventTypes option:selected").text();
        chartTitle = chartTitle + " all occurences of " + $("#ddlEventTypes option:selected").text() + " during : " + $("#FromDate").val() + " and " + $("#TomDate").val();
    } else {
        if (FilterParameters.AllSubEvents) {
            chartTitle = chartTitle +" all occurences of subeventtypes from " + $("#ddlEventTypes option:selected").text() + " during " + $("#FromDate").val() + " and " + $("#TomDate").val();
        } else {
            chartTitle = chartTitle + " all occurences of subeventtype " + $("#idSubEvent option:selected").text() + " during " + $("#FromDate").val() + " and " + $("#TomDate").val();
        }
    }

    //Update chart-information.
    myChart.titleBlock.options.text = chartTitle;
    myChart.update();
}


var resetCanvas = function () {
    $('#chart').remove(); // this is my <canvas> element
    $('#statisticsDiv').append('<canvas id="chart"><canvas>');
    canvas = document.querySelector('#chart');
    ctx = canvas.getContext('2d');
    ctx.canvas.width = $('#graph').width(); // resize to parent width
    ctx.canvas.height = $('#graph').height(); // resize to parent height
    var x = canvas.width / 2;
    var y = canvas.height / 2;
    ctx.font = '10pt Verdana';
    ctx.textAlign = 'center';
    ctx.fillText('This text is centered on the canvas', x, y);
};