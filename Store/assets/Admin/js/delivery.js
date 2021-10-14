var delivery = {
    init: function () {
        delivery.registerEvents();
    },
    registerEvents: function () {
        $("#btnsuccess").off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this)
            var id = btn.data('id')
            $.ajax({
                url: "/Admin/Payment/delivery",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {

                    if (response.TinhTrangGiaoHang == true) {

                        location.reload();
                    }
                }
            })
        })
    }
}
delivery.init();