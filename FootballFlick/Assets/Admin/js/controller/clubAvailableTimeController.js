var clubAvailableTime = {
    init: function () {
        clubAvailableTime.regEvents();
    },
    regEvents: function () {
        $('#btnAddRow').off('click').on('click', function () {
            var clubId = $("#txtHomeClubID").val();
            var stt = $("#txtStt").val();
            var day = $("#txtDay").val();
            var startTime = $("#txtStartTime").val();
            var endTime = $("#txtEndTime").val();

            //Update vào database
            var row = { "ClubID": clubId, "Stt": stt, "Day": day, "StartTime": startTime, "EndTime": endTime };
            $.ajax({
                url: '/Admin/ClubAvailableTime/AddRow',
                data: { row: JSON.stringify(row) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Add a AvailableTime successfully");
                        window.location.reload();
                    }
                    else {
                        alert("This AvailableTime is already added to the team");
                    }
                }
            })

        });
    }
}
clubAvailableTime.init();