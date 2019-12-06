$(document).ready(function () {
    var user = {
        init: function () {
            user.registerEvents();
        },
        registerEvents: function () {
            $('.btn-active-xxx').on('click', function (e) {             
                e.preventDefault();      
                var id = $(this).data('userID');
                $.ajax({
                    url: "Admin/User/ChangeStatus",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response.status);
                        if (response.status == false) {
                            $(this).text("Kích hoạt");
                        } else {
                            $(this).text("Khóa");
                        }
                    }
                })
            })//end-function
        }
    }
});

