var clubPlayer = {
    init: function () {
        clubPlayer.registerEvents();
    },
    registerEvents: function () {
        $('#btnAddPlayer').off('click').on('click', function (e) {
            e.preventDefault();
            $('#formAddPlayer').modal('show');
        });

        $('#btnSavePlayer').off('click').on('click', function () {
            var clubId = $("tr:first").attr("id");
            var name = $("#txtName").val();
            var identification = $("#txtIdentification").val();
            var address = $("#txtAddress").val();
            var email = $("#txtEmail").val();
            var phone = $("#txtPhone").val();
            var image = $("#txtImage").val();

            if (name == "") {
                alert("Please enter Name");
            } else if (email == "") {
                alert("Please enter Email");
            } else if (validateEmail(email) == false) {
                alert("Please enter a real Email");
            }
            else {
                var clubPlayerViewModel = {
                    "ClubID": clubId,
                    "PlayerID": 0,
                    "PlayerName": name,
                    "PlayerIdentification": identification,
                    "PlayerAddress": address,
                    "PlayerEmail": email,
                    "PlayerPhone": phone,
                    "PlayerImage": image
                };

                //Insert một dòng ClubPlayer mới vào bảng ClubPlayer
                $.ajax({
                    url: '/ClubPlayer/AddPlayer',
                    data: { clubPlayerViewModel: JSON.stringify(clubPlayerViewModel) },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            $('#formAddPlayer').modal('hide');
                            alert("Add a player successfully");
                            window.location.reload();
                        }
                        else {
                            alert("Add a player failed. Please try again!");
                        }
                    }
                })
            }


            

        });

        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            var stt = $(this).data('id');
            var clubId = $("tr:first").attr("id");

            var cf = confirm("Do you really want to delete this Player");
            if (cf == true) {
                $.ajax({
                    url: '/ClubPlayer/Delete',
                    data: { clubId: clubId, stt: stt },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            alert("Delete the player successfully");
                            window.location.reload();
                        }
                        else {
                            alert("Delete the player failed");
                        }
                    }
                })
            }

        });

        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }



    }

}
clubPlayer.init();
