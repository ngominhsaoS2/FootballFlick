var productSearch = {
    init: function () {
        productSearch.registerEvent();
    },
    registerEvent: function () {
        $("#txtProductID").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/Product/ListProduct",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtProductID").val(ui.item.Name);
                return false;
            },
            select: function (event, ui) {
                $("#txtProductID").val(ui.item.ID);
                $("#txtPrice").val(ui.item.Price);
                return false;
            }
        })
     .autocomplete("instance")._renderItem = function (ul, item) {
         return $("<li>")
           .append("<a>" + item.Name + "</a>")
           .appendTo(ul);
     };
    }
}
productSearch.init();

var playerSearch = {
    init: function () {
        playerSearch.registerEvent();
    },
    registerEvent: function () {
        $("#txtPlayerID").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/Player/ListPlayer",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtPlayerID").val(ui.item.Name);
                return false;
            },
            select: function (event, ui) {
                $("#txtPlayerID").val(ui.item.ID);
                $("#txtPlayerName").val(ui.item.Name);
                $("#txtPlayerIdentification").val(ui.item.Identification);
                return false;
            }
        })
     .autocomplete("instance")._renderItem = function (ul, item) {
         return $("<li>")
           .append("<a>" + item.Identification + " - " + item.Name + "</a>")
           .appendTo(ul);
     };
    }
}
playerSearch.init();

var clubSearch = {
    init: function () {
        clubSearch.registerEvent();
    },
    registerEvent: function () {
        $("#txtHomeClubID").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/Club/ListClub",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtHomeClubID").val(ui.item.Code);
                return false;
            },
            select: function (event, ui) {
                $("#txtHomeClubID").val(ui.item.ID);
                $("#txtHomeClubCode").val(ui.item.Code);
                return false;
            }
        })
     .autocomplete("instance")._renderItem = function (ul, item) {
         return $("<li>")
           .append("<a>" + item.Code + " - " + item.Name + "</a>")
           .appendTo(ul);
     };

        $("#txtVisitingClubID").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/Club/ListClub",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtVisitingClubID").val(ui.item.Code);
                return false;
            },
            select: function (event, ui) {
                $("#txtVisitingClubID").val(ui.item.ID);
                $("#txtVisitingClubCode").val(ui.item.Code);
                return false;
            }
        })
     .autocomplete("instance")._renderItem = function (ul, item) {
         return $("<li>")
           .append("<a>" + item.Code + " - " + item.Name + "</a>")
           .appendTo(ul);
     };
    }
}
clubSearch.init();

var stadiumSearch = {
    init: function () {
        stadiumSearch.registerEvent();
    },
    registerEvent: function () {
        $("#txtStadiumID").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/Stadium/ListStadium",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtStadiumID").val(ui.item.Code);
                return false;
            },
            select: function (event, ui) {
                $("#txtStadiumID").val(ui.item.ID);
                $("#txtStadiumCode").val(ui.item.Code);
                $("#txtStadiumName").val(ui.item.Name);
                $("#txtHoldAddress").val(ui.item.Address);
                return false;
            }
        })
     .autocomplete("instance")._renderItem = function (ul, item) {
         return $("<li>")
           .append("<a>" + item.Code + " - " + item.Name + "</a>")
           .appendTo(ul);
     };
    }
}
stadiumSearch.init();

var userSearch = {
    init: function () {
        userSearch.registerEvent();
    },
    registerEvent: function () {
        $("#txtUserID").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/User/ListUser",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtUserID").val(ui.item.Name);
                return false;
            },
            select: function (event, ui) {
                $("#txtUserID").val(ui.item.ID);
                $("#txtUserName").val(ui.item.UserName);
                return false;
            }
        })
     .autocomplete("instance")._renderItem = function (ul, item) {
         return $("<li>")
           .append("<a>" + item.ID + " - " + item.UserName + "</a>")
           .appendTo(ul);
     };
    }
}
userSearch.init();