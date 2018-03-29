var clubStadium = {
    init: function () {
        clubStadium.regEvents();
    },
    regEvents: function () {
        $('#btnAddRow').off('click').on('click', function () {
            var clubId = $("#txtHomeClubID").val();
            var stadiumId = $("#txtStadiumID").val();

            //Update vào database
            var row = { "ClubID": clubId, "StadiumId": stadiumId };
            $.ajax({
                url: '/Admin/ClubStadium/AddRow',
                data: { row: JSON.stringify(row) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Add a stadium successfully");
                        window.location.reload();
                    }
                    else {
                        alert("This stadium is already added to the team");
                    }
                }
            })

        });
    }
}
clubStadium.init();