var stadium = {
    init: function () {
        stadium.registerEvents();
    },
    registerEvents: function () {
        $('.btn-images').off('click').on('click', function (e) {
            e.preventDefault();
            $('#imagesManage').modal('show');
            $('#hidStadiumID').val($(this).data('id'));
            stadium.loadImages();
        });

        $('#btnChooseImages').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $('#imageList').append('<div style="float:left"><img src="' + url + '" width="100" /><a href="#" class="btn-delImage"><i class="fa fa-times"></i></a></div>');

                $('.btn-delImage').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });

            };
            finder.popup();
        });

        $('#btnSaveImages').off('click').on('click', function () {
            var images = [];
            var id = $('#hidStadiumID').val();
            $.each($('#imageList img'), function (i, item) {
                images.push($(item).prop('src'));
            })
            console.log(id);
            $.ajax({
                url: '/Admin/Stadium/SaveImages',
                type: 'POST',
                data: {
                    id: id,
                    images: JSON.stringify(images)
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        $('#imagesManage').modal('hide');
                        $('#imageList').html('');
                        alert('Save thành công');
                    }

                    //thong bao thanh cong
                }
            });
        });
    },

    loadImages: function () {
        $.ajax({
            url: '/Admin/Stadium/LoadImages',
            type: 'GET',
            data: {
                id: $('#hidStadiumID').val()
            },
            dataType: 'json',
            success: function (response) {
                var data = response.data;
                var html = '';
                $.each(data, function (i, item) {
                    html += '<div style="float:left"><img src="' + item + '" width="100" /><a href="#" class="btn-delImage"><i class="fa fa-times"></i></a></div>'
                });
                $('#imageList').html(html);

                $('.btn-delImage').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });

                //thong bao thanh cong
            }
        });
    }
}
stadium.init();