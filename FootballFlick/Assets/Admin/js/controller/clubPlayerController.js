var clubPlayer = {
    init: function () {
        clubPlayer.regEvents();
    },
    regEvents: function () {
        $('#btnAddRow').off('click').on('click', function () {
            var clubId = $("#txtHomeClubID").val();
            var playerId = $("#txtPlayerID").val();

            //Update vào database
            var row = { "ClubID": clubId, "PlayerId": playerId };
            $.ajax({
                url: '/Admin/ClubPlayer/AddRow',
                data: { row: JSON.stringify(row) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Add a player successfully");
                        window.location.reload();
                    }
                    else {
                        alert("Add a player failed. Please try again!");
                    }
                }
            })

        });
    }
}
clubPlayer.init();