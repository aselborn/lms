﻿function filterEvents() {
    var eventTypeId = $('#Item2_EventTypeId').val();

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

function AllEventsSelected(element) {
    //element.checked ? alert('checked.') : alert('not checked');
    //allEvents.checked = element.checked ? true : false;
    var checked = element.checked ? true : false;
    $('#IsAllEvents').val(checked);
}

function DrawMyChart(SimpleResultObject, typeOfChart) {

    resetCanvas();

    var chartName = "chart";
    var ctx = document.getElementById(chartName).getContext('2d');

    var myLabels = [];
    var myValues = [];
    $.each(SimpleResultObject, function (i, item) {
        $(myLabels.push(item.Text))
        $(myValues.push(item.myValue))
    });

    var data = {
        labels: myLabels,
        datasets: [{
            label: "Sammanställning",
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 0, 0)',
                'rgba(0, 255, 0)',
                'rgba(0, 0, 255)',
                'rgba(192, 192, 192)',
                'rgba(255, 255, 0)',
                'rgba(255, 0, 255)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(255, 0, 0)',
                'rgba(0, 255, 0)',
                'rgba(0, 0, 255)',
                'rgba(192, 192, 192)',
                'rgba(255, 255, 0)',
                'rgba(255, 0, 255)'
            ],
            borderWidth: 1,
            data: myValues
        }]
    };

    var options = {
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
                gridLines: {
                    display: false
                }
            }]
        }
    };

    var myChart = new Chart(ctx, {
        options: options,
        data: data,
        type: typeOfChart.toLowerCase()

    });


}
