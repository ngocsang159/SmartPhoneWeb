
//AccountAdmin
//Edit
function Edit_Ad(id) {
    $.ajax({
        url: "/AccountAdmins/Edit",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-acc").html(res);
            $("#myModal-account").modal('show');
        }
    })
};
function Edit_Acc() {
    //debugger
    //var form = $("#frmEdit").serialize().split("&");

    //var input = {};

    //$.each(form, function (key, value) {
    //    var data = value.split('=');
    //    input[data[0]] = decodeURIComponent(data[1]);
    //});

    //console.log(input);
    // debugger
    let objArr = $('#frmEdit').serializeArray();
    console.log(objArr);
    let input = objArr.reduce(function (o, val) { o[val.name] = val.value; return o }, {});

    console.log(input);

    $.ajax({
        url: "/Admin/AccountAdmins/Edit",
        method: "POST",
        data: input,
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                console.log(res);
                $("#myModal-account").html('hide');
                window.location.reload();
            }
        }
    })
}
//Details
function GetDetails_Ad(id) {
    $.ajax({
        url: "/AccountAdmins/Details",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-acc").html(res);
            $("#myModal-account").modal('show');
        }

    })
}
//Delete
function Delete_Ad(id) {
    $.ajax({
        url: "/AccountAdmins/Delete",
        method: "GET",
        data: {
            id: id,
        },
        dataType: "html",
        success: function (res) {
            $("#content-modal-acc").html(res);
            $("#myModal-account").modal('show');
        }
    })
}
function Del_Ad() {
    $.ajax({
        url: "/Admin/AccountAdmins/Delete",
        method: "POST",
        data: {
            ID: $("#ID").val()
        },
        dataType: "json",
        success: function (res) {
            console.log(res);
            if (res.data == true) {
                swal({
                    title: "Xóa Thành Công!",
                    icon: "success",
                });
                $("#myModal-account").modal('hide');
                window.location.reload();
            }

        }
    })
}

//Category
//Create
function GetCreate(id) {
    $.ajax({
        url: "/Product_Category/Create",
        data: { id: id },
        method: "GET",
        dataType: "html",
        success: function (res) {
            $("#content-modal-category").html(res);
            $("#myModal-Category").modal('show');
        }
    })
};
function CreateCategory() {
    let objArrCategory = $('#frmCreateCategory').serializeArray();
    //console.log(objArrCategory);
    let input = objArrCategory.reduce(function (o, val) { o[val.name] = val.value; return o }, {});
    debugger
    //console.log(input);
    $.ajax({
        url: "/Admin/Product_Category/Create",
        data: input,
        method: "POST",
        dataType: 'json',
        success: function (res) {
            if (res.StatusCode == 201) {
                toastr.error(res.ErrorMessage, "Thông báo!", { timeOut: "3000", positionClass: "toast-top-right" })
                return;
            }
            if (res == false) {
                toastr.error("Đăng ký không thành công ", "Thông báo", { timeOut: "5000", positionClass: "toast-top-center" })
            }
            $("#myModal-Category").modal('hide');
            window.location.reload();

        }
    })
};
//edit
function Edit_Cate(id) {

    $.ajax({
        url: "/Product_Category/Edit",
        data: { id: id },
        method: "GET",
        dataType: "html",
        success: function (res) {
            $("#content-modal-category").html(res);
            $("#myModal-Category").modal('show');
        }
    })
};
function Edit_Category() {
    let objCategory = $("#frmEditCategory").serializeArray();
    //console.log(objCategory);
    let inputCategory = objCategory.reduce(function (o, val) { o[val.name] = val.value; return o }, {});
    console.log(inputCategory);
    debugger
    $.ajax({
        url: "/Admin/Product_Category/Edit",
        method: "POST",
        data: inputCategory,
        dataType: 'json',
        success: function (res) {
            if (res.data == true) {
                toastr.success("Chỉnh sửa thành công", { timeOut: "5000", positionClass: "toast-top-center" })// chưa hoàn thành
                $("#myModal-Category").modal('hide');

            }
        },
        complete: function () {
            window.location.reload();
        }

    })
}
//details
function GetDetails_Cate(id) {
    $.ajax({
        url: "/Product_Category/Details",
        data: { id: id },
        method: "GET",
        dataType: "html",
        success: function (res) {
            $("#content-modal-category").html(res);
            $("#myModal-Category").modal('show');
        }
    })
}

//Delete
function Delete_Cate(id) {
    $.ajax({
        url: "/Product_Category/Delete",
        data: { id: id },
        method: "GET",
        dataType: "html",
        success: function (res) {
            $("#content-modal-category").html(res);
            $("#myModal-Category").modal('show');
        }
    })
}

function Del_Category() {
    debugger
    $.ajax({
        url: "/Admin/Product_Category/Delete",
        method: "POST",
        data: {
            Product_CategoryId: $("#Product_CategoryId").val()
        },
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Category").modal('hide');
                window.location.reload();
            }
        },
        complete: function () {
            //window.location.reload();
        }


    })
}
//category_type
function GetDetails_Cate_Type(id) {
    alert(1);
    $.ajax({
        url: "/Product_Category_Type/Details",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-category_Type").html(res);
            $("#myModal-Category_Type").modal('show');
        }
    })
}
function GetCreateType(id) {
    alert(1);
    $.ajax({
        url: "/Product_Category_Type/Create",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-category_Type").html(res);
            $("#myModal-Category_Type").modal('show');
        }
    })
}
function CreateCategory_Type() {
    //var a = $("#Product_CategoryId").val();
    //console.log(a);
    let objCategory_Type = $("#frmCreateCategoryType").serializeArray();
    //console.log(objCategory_Type);
    let inputCategory_Type = objCategory_Type.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    console.log(inputCategory_Type);
    $.ajax({
        url: "/Admin/Product_Category_Type/Create",
        method: "POST",
        data: inputCategory_Type,
        //{ Product_CategoryId: $("#Product_CategoryId").val() },
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Category_Type").modal('hide');
                window.location.reload();
            }
        }

    })
};
function Delete_Cate_Type(id) {
    $.ajax({
        url: "/Product_Category_Type/Delete",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-category_Type").html(res);
            $("#myModal-Category_Type").modal('show');
        }
    })
};
function Del_Category_Type() {
    alert(1);
    $.ajax({
        url: "/Admin/Product_Category_Type/Delete",
        method: "POST",
        data: {
            id: $("#Product_Category_TypeId").val()
        },
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Category_Type").modal('hide');
                window.location.reload();
            }
        }
    })
};
function Edit_Cate_Type(id) {
    $.ajax({
        url: "/Product_Category_Type/Edit",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-category_Type").html(res);
            $("#myModal-Category_Type").modal('show');
        }
    })
};
function Edit_Category_Type() {
    var objCategoryTypeEdit = $("#frmEditCategoryType").serializeArray();
    console.log(objCategoryTypeEdit);
    let inputCategoryTypeEdit = objCategoryTypeEdit.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    console.log(inputCategoryTypeEdit);
    $.ajax({
        url: "/Admin/Product_Category_Type/Edit",
        data: inputCategoryTypeEdit,
        method: "POST",
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Category_Type").modal('hide');
                window.location.reload();
            }
        }
    })
};

//Brands
//Details
function GetDetails_Brand(id) {
    alert(1);
    $.ajax({
        url: "/Brands/Details",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-brand").html(res);
            $("#myModal-Brand").modal('show');
        }
    })
};
//Create
function GetCreateBrands(id) {
    $.ajax({
        url: "/Brands/Create",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-brand").html(res);
            $("#myModal-Brand").modal('show');
        }
    })
};
function Create_Brand() {
    let objBrands = $("#frmCreateBrands").serializeArray();
    let inputBrands = objBrands.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    console.log(inputBrands);
    $.ajax({
        url: "/Admin/Brands/Create",
        method: "POST",
        data: inputBrands,
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Brand").modal('hide');
                window.location.reload();
            }
        }
    })
};
//Edit
function GetEdit_Brand(id) {
    $.ajax({
        url: "/Brands/Edit",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-brand").html(res);
            $("#myModal-Brand").modal('show');
        }
    })
};
function Edit_Brand() {
    let objEditBrand = $("#frmEditBrand").serializeArray();
    let inputEditBrand = objEditBrand.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    console.log(inputEditBrand);
    $.ajax({
        url: "/Admin/Brands/Edit",
        method: "POST",
        data: inputEditBrand,
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Brand").modal('hide');
                window.location.reload();
            }
        }
    })
};
//Delete
function GetDelete_Brand(id) {
    $.ajax({
        url: "/Brands/Delete",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-brand").html(res);
            $("#myModal-Brand").modal('show');
        }
    })
};
function Del_Brand() {
    $.ajax({
        url: "/Admin/Brands/Delete",
        method: "POST",
        data: {
            id: $("#Brand_id").val()
        },
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Brand").modal('hide');
                window.location.reload();
            }
        }
    })
};

//Products
//Create
function GetCreateProducts() {
    $.ajax({
        url: "/Products/Create",
        method: "GET",
        dataType: "html",
        success: function (res) {
            window.location.href = "/Admin/Products/Create";
        }
    })
};
function Exit_Product() {
    window.location.href = "/Admin/Products/Index";
}
function Create_Product() {
    debugger
    //lấy dữ liệu từ editor Description
    var description = CKEDITOR.instances['Description'].getData();
    //Lấy dữ liệu từ editor Product_infor
    var product_infor = CKEDITOR.instances['Product_Infor'].getData();
    let objCreateProduct = $("#frmCreateProduct").serializeArray();
    let inputCreateProduct = objCreateProduct.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    inputCreateProduct["Description"] = description;
    inputCreateProduct["Product_Infor"] = product_infor;
    console.log(inputCreateProduct);
    $.ajax({
        url: "/Admin/Products/Create",
        type: "POST",
        dataType: "json",
        data: inputCreateProduct,
        // not to process data 
        success: function (res) {
            if (res.data == true) {
                window.location.href = "/Admin/Products/Index";
            }
        },
        error: function (error) {
            console.log(error);
        },
        complete: function () {

        }
    });
}
//Edit
function GetEdit_Product(id) {
    debugger
    $.ajax({
        url: "/Products/Edit",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function () {
            window.location.href = "/Products/Edit/" + id;
        },
        complete: function (res) {
            $("#EditProduct").html(res);
        },
    })
};
function Edit_Product() {
    debugger
    var description = CKEDITOR.instances['Description'].getData();
    //Lấy dữ liệu từ editor Product_infor
    var product_infor = CKEDITOR.instances['Product_Infor'].getData();
    let objEditProduct = $("#frmEditProduct").serializeArray();
    let inputEditProduct = objEditProduct.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    inputEditProduct["Description"] = description;
    inputEditProduct["Product_Infor"] = product_infor;
    console.log(inputEditProduct);
    $.ajax({
        url: "/Admin/Products/Edit",
        type: "POST",
        data: inputEditProduct,
        // not to process data 
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                toastr.success('Chỉnh sửa thành công', { positionClass: 'toast-top-center', timeOut: 1000 });
                window.location.href = "/Admin/Products/Index";
            }
        },
        error: function (error) {
            console.log(error);
        },
        complete: function () {

        }
    })
};

//Details
function GetDetails_Product(id) {
    $.ajax({
        url: "/Products/Details",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            window.location.href = "/Products/Details/" + id;
        }
    })
};
//Delete
function GetDelete_Product(id) {
    $.ajax({
        url: "/Products/Delete",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-product").html(res),
                $("#myModal-Product").modal('show')
        }
    })
};
function Del_Product() {
    debugger
    $.ajax({
        url: "/Admin/Products/Delete",
        type: "POST",
        data: {
            product_id: $("#Product_Id").val()
        },
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Product").modal('hide');
                window.location.reload();
            }
        }
    })

};


//Product_color
//Create
function GetCreateColor(id) {
    $.ajax({
        url: "/Product_Color/Create",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Color").html(res);
            $("#myModal-Color").modal('show');
        }

    })
}


function Product_ColorCreate() {
    let objColor = $("#frmCreateProductColor").serializeArray();
    let inputobjColor = objColor.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    $.ajax({
        url: "/Admin/Product_Color/Create",
        method: "POST",
        data: inputobjColor,
        dataType: "json",
        success: function (res) {
            if (res.data) {
                $("#myModal-Color").modal('hide');
                window.location.reload();
            }
        }
    })
}
//Edit
function GetEdit_Color(id) {
    $.ajax({
        url: "/Product_Color/Edit",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Color").html(res);
            $("#myModal-Color").modal('show');
        }
    })
};
function Edit_Product_Color() {
    debugger
    let objColor = $("#frmEditProductColor").serializeArray();
    let inputObjColor = objColor.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    $.ajax({
        url: "/Admin/Product_Color/Edit",
        method: "POST",
        data: inputObjColor,
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Color").modal('hide');
                toastr.success('Chỉnh sửa thành công', { positionClass: 'toast-top-center', timeOut: 1000 });
                window.setTimeout(function () {
                    location.reload();
                }, 1000);
            }
        }
    })
};


//Details
function GetDetails_Color(id) {
    alert(1);
    $.ajax({
        url: "/Product_Color/Details",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Color").html(res);
            $("#myModal-Color").modal('show');
        }
    })

};
//Delete
function GetDelete_Color(id) {
    $.ajax({
        url: "/Product_Color/Delete",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Color").html(res);
            $("#myModal-Color").modal('show');
        }
    })
};
function Del_Product_Color() {
    $.ajax({
        url: "/Admin/Product_Color/Delete",
        method: "POST",
        data: {
            id: $("#Color_Id").val()
        },
        success: function (res) {
            if (res.data) {
                $("#myModal-Color").modal('hide');
                window.location.reload();
            }
        }
    })
};

///Thông số kỹ thuật
//Create
function GetProductSpe(id) {
    $.ajax({
        url: "/Product_Specifications/Create",
        method: "GET",
        data: id,
        dataType: "html",
        success: function (res) {
            $("#content-modal-Specifications").html(res);
            $("#myModal-Specifications").modal('show');
        }

    })
};
function Product_SpeCreate() {
    let objProduct_SpeCreate = $("#frmCreateProductSpe").serializeArray();
    let inputObjSpeCreate = objProduct_SpeCreate.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    $.ajax({
        url: "/Admin/Product_Specifications/Create",
        method: "POST",
        data: inputObjSpeCreate,
        dataType: "Json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Specifications").modal('hide');
                location.reload();
            }
        }
    })
};
//Edit
function GetEdit_Specification(id) {
    $.ajax({
        url: "/Product_Specifications/Edit",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Specifications").html(res);
            $("#myModal-Specifications").modal('show');
        }

    })
};
function Edit_Product_Spe() {
    let objSpecification = $("#frmEditProductSpe").serializeArray();
    let inputObjSpeEdit = objSpecification.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    $.ajax({
        url: "/Admin/Product_Specifications/Edit",
        method: "POST",
        data: inputObjSpeEdit,
        dataType: "Json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Specifications").modal('hide');
                location.reload();
            }
        }
    })
};
//Details
function GetDetails_Specification(id) {
    $.ajax({
        url: "/Product_Specifications/Details",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Specifications").html(res);
            $("#myModal-Specifications").modal('show');
        }

    })
};
//Delete
function GetDelete_Specification(id) {
    $.ajax({
        url: "/Product_Specifications/Delete",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Specifications").html(res);
            $("#myModal-Specifications").modal('show');
        }

    })
};

function Del_Product_Spe() {
    $.ajax({
        url: "/Admin/Product_Specifications/Delete",
        method: "POST",
        data: {
            id: $("#Specification_Id").val(),
        },
        dataType: "Json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Specifications").modal('hide');
                location.reload();
            }
        }
    })
};

//Customer
//Create
function GetCreateCustomers() {
    $.ajax({
        url: "/Customers/Create",
        type: "GET",
        dataType: "html",
        success: function (res) {
            $("#content-modal-Customer").html(res);
            $("#myModal-Customer").modal('show');
        }
    })
};
function CreateCustomer() {
    debugger
    let objCustomer = $("#frmCreateCustomer").serializeArray();
    let inputObjCustomer = objCustomer.reduce(function (o, val) { o[val.name] = val.value; return o; }, {});
    var districtId = $("#DistrictId").val();
    console.log(districtId);
    inputObjCustomer["DistrictId"] = districtId;
    console.log(inputObjCustomer);
    $.ajax({
        url: "/Admin/Customers/Create",
        method: "POST",
        data: inputObjCustomer,
        dataType: "json",
        success: function (res) {
            if (res.data = true) {
                $("#myModal-Customer").modal('hide');
                window.location.reload();
            }
        },
        error: function (res) { },
        complete: function () { }
    })

};
////Edit
function GetEdit_Customer(id) {
    $.ajax({
        url: "/Customers/Edit",
        type: "GET",
        data: {
            id: id,
            //ProvinceId: provinceId
        },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Customer").html(res);
            $("#myModal-Customer").modal('show');
            //$("#DistrictId").html('')
        },
        error: function (res) {

        },
        complete: function () {

        }

    })
};
function Edit_Customer() {
    debugger
    let objEditCustomer = $("#frmEditCustomer").serializeArray();
    let inputEditCustomer = objEditCustomer.reduce(function (o, val) { o[val.name] = [val.value]; return o; }, {});
    var districtId = $("#DistrictId").val();
    inputEditCustomer["DistrictId"] = districtId;
    console.log(inputEditCustomer);
    $.ajax({
        url: "/Admin/Customers/Edit",
        method: "post",
        data: inputEditCustomer,
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Customer").modal('hide');
                window.location.reload();
            }
        },
        error: function (res) { },
        complete: function () { }
    })

};

//Details
function GetDetails_Customer(id) {
    $.ajax({
        url: "/Customers/Details",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Customer").html(res);
            $("#myModal-Customer").modal('show');
        }
    })
};
////Delete
function GetDelete_Customer(id) {
    $.ajax({
        url: "/Customers/Delete",
        method: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Customer").html(res);
            $("#myModal-Customer").modal('show');
        }
    })
};

function Del_Customer() {
    $.ajax({
        url: "/Admin/Customers/Delete",
        method: "POST",
        data: { id: $("#Customer_id").val() },
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Customer").modal('hide');
                window.location.reload();
            }
        }

    })
};

//Product_Image
//Create
function GetCreateImage() {
 
    $.ajax({
        url: "/Product_image/Create",
        type: "GET",
        dataType: "html",
        success: function (res) {
            $("#content-modal-Image").html(res);
          
            $("#myModal-Image").modal('show');
        }
    })

};
function Product_ImageCreate() {
    let objImage = $("#frmCreateProductImage").serializeArray();
    let objInputImage = objImage.reduce(function (o, val) { o[val.name] = [val.value]; return o; }, {});
    console.log(objInputImage);

    $.ajax({
        url: "/Admin/Product_image/Create",
        method: "POST",
        data: objInputImage,
        dataType: "json",
        success: function (res) {
            if (res.data== true) {
                $("#myModal-Image").modal('hide');
                window.location.reload();
            }
            
        }
    })
};
//CKFinder
function OpenCKFinder() {
    var finder = new CKFinder();
    finder.selectActionFunction = function (url) {
        $("#Image").val(url);
    }
    finder.popup();
};  
//Edit

function GetEdit_Image(id) {
    $.ajax({
        url: "/Product_image/Edit",
        type: "GET",
        data: {id:id},
        dataType: "html",
        success: function (res) {
            $("#content-modal-Image").html(res);
            $("#myModal-Image").modal('show');
        }
    })
};
function Edit_Product_Image() {
    let objImage = $("#frmEditProductImage").serializeArray();
    let inputEditImage = objImage.reduce(function (o, val) { o[val.name] = [val.value]; return o; }, {});
    console.log(inputEditImage);
    $.ajax({
        url: "/Admin/Product_image/Edit",
        method: "POST",
        data: inputEditImage,
        dataType: "json",
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Image").modal('hide');
                window.location.reload();
            }

        }
    })
};
//details
function GetDetails_Image(id) {
    $.ajax({
        url: "/Product_image/Details",
        type: "GET",
        data: {id:id},
        dataType: "html",
        success: function (res) {
            $("#content-modal-Image").html(res);
            $("#myModal-Image").modal('show');
        }
    })

}
//Delete
function GetDelete_Image(id) {
    $.ajax({
        url: "/Product_image/Delete",
        type: "GET",
        data: {id:id},
        dataType: "html",
        success: function (res) {
            $("#content-modal-Image").html(res);
            $("#myModal-Image").modal('show');
        }
    })

};
function Del_Product_Image() {
    $.ajax({
        url: "/Admin/Product_image/Delete",
        type: "POST",
        data: { id: $("#Image_Id").val() },
        dataType: "json",
        success: function (res) {
            if (res.data = true) {
                $("#myModal-Image").modal('hide');
                window.location.reload();
            }
        }
    });
};

//Banner
//Create
function GetCreateBanner() {
    $.ajax({
        url: "/Banners/Create",
        type: "GET",
        dataType: "html",
        success: function (res) {
            $("#content-modal-Banner").html(res);
            $("#myModal-Banner").modal('show');
        }
    })
};
function BannerCreate() {
  
    let objBanner = $("#frmCreateBanner").serializeArray();
    let inputobjBanner = objBanner.reduce(function (o, val) { o[val.name] = [val.value]; return o; }, {});
    $.ajax({
        url: "/Admin/Banners/Create",
        type: "POST",
        data: inputobjBanner,
        dataType: "json",
   
        success: function (res) {
            if (res.data == true) {
                $("#myModal-Banner").modal('hide');
                window.location.reload();
            }      
        }
    })
};
//Edit
function GetEdit_Banner(id) {
    $.ajax({
        url: "/Banners/Edit",
        type: "GET",
        data: {id:id},
        dataType: "html",
        success: function (res) {
            $("#content-modal-Banner").html(res);
            $("#myModal-Banner").modal('show');
        }
    })
};
function Banner_Edit() {
    let objBanner = $("#frmEditBanner").serializeArray();
    let inputobjBanner = objBanner.reduce(function (o, val) { o[val.name] = [val.value]; return o; }, {});
    $.ajax({
        url: "/Admin/Banners/Edit",
        type: "POST",
        data: inputobjBanner,
        dataType: "json",
        success: function (res) {
            if (res.data = true) {
                $("#myModal-Banner").modal('hide');
                window.location.reload();
            }
        }
    })
};
//Details
function GetDetails_Banner(id) {
    $.ajax({
        url: "/Banners/Details",
        type: "GET",
        data: { id: id },
        dataType: "html",
        success: function (res) {
            $("#content-modal-Banner").html(res);
            $("#myModal-Banner").modal('show');
        }
    })
};
//Delete
function GetDelete_Banner(id) {
    $.ajax({
        url: "/Banners/Delete",
        type: "GET",
        data: {id:id},
        dataType: "html",
        success: function (res) {
            $("#content-modal-Banner").html(res);
            $("#myModal-Banner").modal('show');
        }
    })
};
function Banner_Del() {
    $.ajax({
        url: "/Admin/Banners/Delete",
        type: "POST",
        data: { id: $("#Banner_Id").val() },
        dataType: "json",
        success: function (res) {
            if (res.data = true) {
                $("#myModal-Banner").modal('hide');
                window.location.reload();
            }
        }
    })
};





