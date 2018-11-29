var UtilizationParameters = {};

function Utilization() {


    UtilizationParameters.StartDate = $("#FromDate").val();
    UtilizationParameters.StopDate = $("#TomDate").val();
    UtilizationParameters.TestBedId = $("#ddlTestBed").val();
    UtilizationParameters.AllTestBeds = $("#chkAllTestBed").is(":checked") == true ? true : false;

    var str = JSON.stringify(UtilizationParameters);

    $.ajax({
        url: 'Data',
        type: 'POST',
        dataType: 'JSON',
        data: '{data: ' + JSON.stringify(UtilizationParameters) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            var jsondata = response;
            $("#chart").html("");

            //Reply in JSON format, to build up statistic page.

            $.each(jsondata, function (i, item) {
                $("#chart").html(item.Text);
            });

            
        },
        error: function (xhr, status, error) {
            $("#addSubEvent").prop("disabled", true);
            alert('Failed to get correct data (most probably a bug). Check if there is a log!!');
        }

    });

}