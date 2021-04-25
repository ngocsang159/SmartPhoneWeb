$(document).ready(function () {
    //Đăng nhập admin
    $("#btnSignIn").click(function () {
        $.ajax({
            url: "/Admin/Authenticate/Login",
            method: 'POST',
            data: {
                Username: $("#user").val(),
                Password: $("form[name='frmLogin'] [name='Password']").val(),
                Email: $("#user").val(),

            },
            dataType: 'json',
            beforeSend: function () {
                $("#loading-wrapper").show();
            },
            success: function (res) {
                if (res.StatusCode !== 200) {
                    toastr.error(res.ErrorMessage, 'Thông báo!', { positionClass: 'toast-top-center', timeOut: 1000 });
                    return;
                }

                window.location.href = "/Admin/Home/Index";

            },
            error: function (err) {
                console.log(err);
            },
            complete: function () {
                $("#loading-wrapper").hide();
            }

        });

    });
    //Đăng ký tài khoản admin
    $("#btnRegister").click(function () {
        //console.log('a');
        $.ajax({
            url: '/Admin/Authenticate/Register',
            method: 'POST',
            data: {
                Username: $("#user_name_register").val(),
                Email: $("#email_register").val(),
                Phone: $("#phone_register").val(),
                Password: $("#password_register").val(),
                Displayname: $("#display_name_register").val(),
            },
            dataType: 'json',
            success: function (res) {
                if (res.StatusCode == 201) {
                    toastr.error(res.ErrorMessage, 'Thông báo!', { positionClass: 'toast-top-center', timeOut: 1000 });
                    return;
                }
                window.location.href = '/Admin/Authenticate/Login';
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
    //tìm kiếm tên người dùng, tên đăng nhập
    $("#searchNameAccount").click(function () {
        $.ajax({
            url: "/Admin/AccountAdmins/_TableView",
            method: "POST",
            data: {
                Username: $("form[name='searchForm'] [name='ten_dn']").val(),
                Displayname: $("#Display").val()
            },
            dataType: "html",
            success: function (response) {
                console.log(response);
                $("#content-view").html(response);
            },
            error: function () { },
            complete: function () {
                showBoxFunction();
            }
        })
    });
    //tìm kiếm tên danh mục
    $("#searchNameCategory").click(function () {

        $.ajax({
            url: "/Admin/Product_Category/_TableView",
            method: "POST",
            data: {
                Product_CategoryName: $("#srcNameCategory").val()
            },
            dataType: "html",
            success: function (res) {
                $("#content-view").html(res);
            },
            error: function () { },
            complete: function () {
                //   showBoxFunction();
            }
        })
    });
    //tìm kiếm tên loại danh mục
    $("#searchNameCategoryType").click(function () {
        let objsrcCategory_Type = $("form[name='frmCategoryType']").serializeArray();
        //console.log(objsrcCategory_Type);
        let inputCategoty_Type_name = objsrcCategory_Type.reduce(function (o, val) { o[val.name] = val.value; return o }, {});
        console.log(inputCategoty_Type_name);
        $.ajax({
            url: "/Admin/Product_Category_Type/_TableView",
            method: "POST",
            data: inputCategoty_Type_name,
            dataType: "html",
            success: function (res) {
                $("#content-view").html(res);
            },
            error: function () { },
            complete: function () {

            }
        })
    });
    //tìm kiếm tên hãng sản xuât
    $("#searchNameBrand").click(function () {
        $.ajax({
            url: "/Admin/Brands/_TableView",
            method: "POST",
            data: {
                Brand_name: $("#srcNameBrand").val()
            },
            dataType: "html",
            success: function (res) {
                $("#content-view").html(res);
            }, error: function () { },
            complete: function () {

            }
        })
    });
    //Upload avatar  
   
    ///
    $(function () {
        $('.treeview-menu a').filter(function () { return this.href == location.href }).parent().addClass('active').siblings().removeClass('active')
        $('.treeview-menu a').click(function () {
            $(this).parent().addClass('active').siblings().removeClass('active')
        })
    })
      

  

});
$("#fileUpload").change(function (event) {
    debugger
    //var fileUpload = $("#FileUpload1").get(0);
    var files = event.target.files;
    console.log(files); 
    // Create FormData object  
    var fileData = new FormData();
    // Looping over all files and add it to FormData object  
    for (var i = 0; i < files.length; i++) {
        fileData.append(files[i].name, files[i]);
    } console.log(fileData); 
    //// Adding one more key to FormData object  
    //fileData.append('username', ‘Manas’);
    $.ajax({
        url: '/AccountAdmins/UploadImage',
        type: "POST",
        contentType: false, // Not to set any content header  
        processData: false, // Not to process data  
        data: fileData,
        success: function (result) {
            $('.upload-img').attr('src', result); 
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
});

function showBoxFunction(obj)  {

    $('.setting-row').siblings().addClass('d-none');
    let data = $(obj);
    //console.log(data);
    let res = data.attr('data-show-box');
    //console.log($(this).html()); let res = $(this).attr('data-show-box');
    if (res == 0) {
        data.siblings().removeClass('d-none');
        data.attr('data-show-box', '1');

    } else {
        data.siblings().addClass('d-none');
        data.attr('data-show-box', '0');
    }
};

$("#show_camera").click(function () {

    $('.box-camera').siblings('.display').addClass('d-none');
    let res = $(this).attr('data-show-camera');
    if (res == 0) {
        $(this).siblings('.display').removeClass('d-none');
        $(this).attr('data-show-camera', '1');
    }
    else {
        $(this).siblings('.display').addClass('d-none');
        $(this).attr('data-show-camera', '0');
    }
});

$("#dropdown_info").click(function () {
    $('#dropdown_info').siblings('.dropdown-menu').addClass('d-none');
    let res = $(this).attr('data-show-info');
    if (res == 0) {
        $(this).siblings('.dropdown-menu').removeClass('d-none');
        $(this).attr('data-show-info', '1');
    }
    else {
        $(this).siblings('.dropdown-menu').addClass('d-none');
        $(this).attr('data-show-info', '0');
    }

});



  















