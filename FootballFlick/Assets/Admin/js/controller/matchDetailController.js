var matchDetail = {
    init: function () {
        matchDetail.regEvents();
    },
    regEvents: function () {
        $('#btnAddRow').off('click').on('click', function () {
            var matchId = $("#txtMatchID").val();
            var clubId = $("#txtHomeClubID").val();
            var playerId = $("#txtPlayerID").val();
            var goal = $("#txtGoal").val();
            var assist = $("#txtAssist").val();
            var redCard = $("#txtRedCard").val();
            var yellowCard = $("#txtYellowCard").val();

            //Update vào database
            var row = {
                "MatchID": matchId,
                "ClubID": clubId,
                "PlayerId": playerId,
                "Goal": goal,
                "Assist": assist,
                "RedCard": redCard,
                "YellowCard" : yellowCard
            };
            $.ajax({
                url: '/Admin/MatchDetail/AddRow',
                data: { row: JSON.stringify(row) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Add a statistic successfully");
                        window.location.reload();
                    }
                    else {
                        alert("Add a statistic failed");
                    }
                }
            })

        });
    }
}
matchDetail.init();