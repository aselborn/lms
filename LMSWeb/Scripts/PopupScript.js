
$(document).ready(function () {

    $(".popup").click(function () {
        clearContent();
        showMessageDialog();
    });


});

function clearContent() {

    $('.messageDialog-msgText').html('');
}



function SavePerson() {

    var name = $("#txtName").val();
    var address = $("#txtAddress").val();

    var data = JSON.stringify({ Name: name, Address: address });

    //lets make a Ajax call to the Controller Method
    $.ajax({
        url: "/Stat/SavePerson?JSONString=" + data,
        datatype: "application/json",
        type: "GET",
        success: function (data) {
            $('.messageDialog-msgText').html(data);
        },
        error: function (e) {
            $(".messageDialog-msgText").html("ERROR");
        }
    });

    //----------------------------------------------------------
    //Here is an example to make a Ajax call to a Web API class
    //----------------------------------------------------------
    //$.ajax({
    //    url: "/api/Popback?JSONString=" + data,
    //    datatype: "application/json",
    //    type: "GET",
    //    success: function (data) {
    //        $('.messageDialog-msgText').html(data);
    //    },
    //    error: function (e) {
    //        $(".messageDialog-msgText").html("ERROR");
    //    }
    //});
}
