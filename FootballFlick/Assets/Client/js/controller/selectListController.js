var selectLevel = {
    init: function () {
        selectLevel.registerEvents();
    },
    registerEvents: function () {
        $(window).load(function (e) {
            //Lấy giá trị SelectedLevelId hiện thời
            var selectedLevelValue = $("#selectedLevelId").attr("value");
            var selectedLevelName = $("#selectedLevelId").text();

            $.ajax({
                url: '/Level/SetOption',
                data: {},
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        var data = res.data;
                        var html = '<option value="">---Select one---</option>';
                        $.each(data, function (i, item) {
                            if (item.ID == selectedLevelValue) {
                                html += '<option selected value="' + selectedLevelValue + '">' + selectedLevelName + '</option>';
                            }
                            else {
                                html += '<option value="' + item.ID + '">' + item.Name + '</option>';
                            }
                            
                        });
                        $('#slLevel').html(html);
                    }
                    else {
                        alert("Loading data from server failed");
                    }
                }
            })


        });

    }
}
selectLevel.init();


var selectMatchStatus = {
    init: function () {
        selectMatchStatus.registerEvents();
    },
    registerEvents: function () {
        $(window).load(function (e) {
            //Lấy giá trị SelectedMatchStatus hiện thời
            var selectedMatchStatusValue = $("#selectedMatchStatus").attr("value");
            var selectedMatchStatusName = $("#selectedMatchStatus").text();

            $.ajax({
                url: '/StatusCategory/SetOption',
                data: { forTable: "Match", type: 1},
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        var data = res.data;
                        var html = '<option value="">---Select one---</option>';
                        $.each(data, function (i, item) {
                            if (item.Stt == selectedMatchStatusValue) {
                                html += '<option selected value="' + selectedMatchStatusValue + '">' + selectedMatchStatusName + '</option>';
                            }
                            else {
                                html += '<option value="' + item.Stt + '">' + item.Name + '</option>';
                            }

                        });
                        $('#slMatchStatus').html(html);
                    }
                    else {
                        alert("Loading data from server failed");
                    }
                }
            })


        });

    }
}
selectMatchStatus.init();