var productSearch = {
    init: function () {
        productSearch.registerEvent();
    },
    registerEvent: function () {
        $("#txtProductID").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/ListProduct",
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
                    url: "/Player/ListPlayer",
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
playerSearch.init();