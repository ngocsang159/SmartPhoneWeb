$(document).ready(function () {
        //Đăng nhập tài khoản client
    $("#btnLoginClient").click(function () {
        debugger
        $.ajax({
            url: "/HeThong/Login",
            method: "POST",
            data: {
                email: $("#emai_phone").val(),
                phone: $("#emai_phone").val(),
                Password: $("#password").val()
            },
            dataType: "json",
            success: function (res) {
                if (res.StatusCode !== 200) {
                    toastr.error(res.ErrorMessage, 'Thông báo!', { positionClass: 'toast-top-center', timeOut: 1000 });
                    return;
                }
                window.location.href = "/Home/Index";
            }

        })
    });
    //Đăng ký tài khoản client
    $("#btnRegister").click(function () {
        debugger
        let objInput = $("#form-register-client").serializeArray();
        let objRegister = objInput.reduce(function (o, val) { o[val.name] = val.value; return o }, {});
        console.log(objRegister);
        $.ajax({
            url: '/HeThong/Register',
            method: 'POST',
            data: objRegister,
            dataType: 'json',
            success: function (res) {
                if (res.StatusCode == 201) {
                    toastr.error(res.ErrorMessage, 'Thông báo!', { positionClass: 'toast-top-center', timeOut: 1000 });
                    return;
                }
                window.location.href = '/HeThong/Login';
            },
            error: function (err) {
                console.log(err);
            }
        })
    });
    
});

$(".buynow").click(function () {
    alert(1);
    window.location.href = "/Cart/ViewCart";
})
function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}

var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $("#btnContinue").off('click').on('click', function () {
            window.location.href = "/Home/Index";
        });
    }
}
cart.init();

$("#qtyItem7823812").change(function () {
    debugger
    var quantity = $(this);
    $.ajax({
        url: "/Cart/Update",
        data: {
            Quantity: $(this).val(),
            productModel: {
                Product: {
                    Product_Id: $(this).data('id')
                }
            }
        },
        dataType: 'html',
        type:'POST'

    })
        .then(function (res) {

            console.log(res);
        })
})
