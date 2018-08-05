var clubStadium = {
    init: function () {
        clubStadium.registerEvents();
    },
    registerEvents: function () {
        $('#btnAddStadium').off('click').on('click', function (e) {
            e.preventDefault();
            $('#formAddStadium').modal('show');
        });

        $('.btnModalAdd').off('click').on('click', function (e) {
            e.preventDefault();
            var clubId = $("tr:first").attr("id");
            var stadiumId = $(this).data('id');
            var delBut = '#btn_' + stadiumId;

            $.ajax({
                url: '/ClubStadium/AddStadium',
                data: { clubId: clubId, stadiumId: stadiumId },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status === true) {
                        alert("Add the Stadium successfully!!!");
                        $(delBut).remove();
                    }
                    else {
                        alert("Add the Stadium failed!!!");
                    }
                }
            })
        });

        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            var clubId = $("tr:first").attr("id");
            var stadiumId = $(this).data('id');

            var cf = confirm("Do you really want to delete this Stadium");
            if (cf === true) {
                $.ajax({
                    url: '/ClubStadium/Delete',
                    data: { clubId: clubId, stadiumId: stadiumId },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status === true) {
                            alert("Delete the Stadium successfully");
                            window.location.reload();
                        }
                        else {
                            alert("Delete the Stadium failed");
                        }
                    }
                })
            }
        });

        $('#btnClose').off('click').on('click', function (e) {
            window.location.reload();
        });
    }
}
clubStadium.init();