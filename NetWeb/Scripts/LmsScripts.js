function filterEvents() {
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
