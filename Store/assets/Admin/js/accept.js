
    var order = {
        init: function () {
            order.registerEvents();
        },
        registerEvents: function () {
            $("#btnAccept").off('click').on('click', function (e) {
                e.preventDefault();
                var btn = $(this)
                var id = btn.data('id')
                $.ajax({
                    url: "/Admin/Payment/accept",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        
                        if (response.DaThanhToan == true) {

                            location.reload();
                        }
                    }
                })
            })
        }
    }
order.init();


