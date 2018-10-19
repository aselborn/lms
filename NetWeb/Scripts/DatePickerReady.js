if (!Modernizr.inputtypes.date) {
    $(function () {

        $(".FromDate").datepicker();
        $(".TomDate").datepicker();

    });
}