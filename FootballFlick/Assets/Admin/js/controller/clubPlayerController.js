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
                url: '/ClubPlayer/AddRow',
                data: { row: JSON.stringify(row) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Add a player successfully");
                        window.location.reload();
                    }
                    else {
                        alert("This player is already added to the team");
                    }
                }
            })

        });
    }
}
clubPlayer.init();