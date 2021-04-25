//đối tượng validator
function Validator(options) {

    var selectorRules = {};
    // console.log(options); 

    //Hàm thực  thi validate

    function validate(inputElement, rule) {
        var errorMessage;
        var errorElement = inputElement.parentElement.querySelector(options.errorSelector);

        //lấy ra rules của selector
        var rules = selectorRules[rule.selector];
        //console.log(rules);
        //lặp qua từng rule và kiểm tra
        //nếu có lỗi thì dừng việc kiểm tra
        for (var i = 0; i < rules.length; i++) {
            errorMessage = rules[i](inputElement.value);
            if (errorMessage) {
                break;
            }
        }
        if (errorMessage) {
            errorElement.innerText = errorMessage;
            inputElement.parentElement.classList.add('invalid');
        }
        else {
            errorElement.innerText = '';
            inputElement.parentElement.classList.remove('invalid');
        }
    }

    //lấy element của form cần validate
    var form_element = document.querySelector(options.form);
    //  var form_element = $(options.form);
   // console.log(form_element);
    if (form_element) {
        //khi submit form
        var btnregister = document.querySelector('#btnRegister');
        //console.log(btnregister);
        btnregister.onclick = function (e) {
            e.preventDefault(); 
           //lặp qua từng rule và validate luôn
            options.rules.forEach(function (rule) {
                var inputElement = form_element.querySelector(rule.selector);
                validate(inputElement, rule);
            });

        }


        options.rules.forEach(function (rule) {

            //lưu lại các rules
            if (Array.isArray(selectorRules[rule.selector])) {
                selectorRules[rule.selector].push(rule.test);
            }
            else {
                selectorRules[rule.selector] = [rule.test];
            }

            var inputElement = form_element.querySelector(rule.selector);
            // console.log(inputElement);

            if (inputElement) {
                //xử lý trường hợp blur khỏi input
                inputElement.onblur = function () {
                    // console.log('blur' + rule.selector);
                    //value:inputElement.value
                    //test func : rule.test;
                    validate(inputElement, rule);

                }
                //xử lý mỗi khi người dùng nhập vào input
                inputElement.oninput = function () {
                    var errorElement = inputElement.parentElement.querySelector(options.errorSelector);
                    errorElement.innerText = '';
                    inputElement.parentElement.classList.remove('invalid');
                }

            }


        });
        //console.log(selectorRules);
    }
}
//định nghĩa các rules
//nguyên tắc của các rules:
//1. khi có lỗi => trả ra message lỗi
//2 . khi hợp lệ => trả về undefined
Validator.isRequired = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            return value.trim() ? undefined : message || 'Vui lòng nhập trường này!';
        },
    };
}
Validator.isUser = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            var regex = /^(?=[a-zA-Z0-9._]{3,20}$)(?!.*[_.]{2})[^_.].*[^_.]$/;
            return regex.test(value) ? undefined : message ||'Tên đăng nhập từ 3-20 không chứa các ký tự đặc biệt';
        }
    }
}
Validator.isFullName = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            var regex = /^[a-zA-Z0-9]+([_ -]?[a-zA-Z0-9]){6,40}$/;
            return regex.test(value) ? undefined : message || 'Họ và tên từ 6-40 ký tự không dấu, không chứa các ký tự đặc biệt';
        }
    }
}
Validator.isEmail = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            var regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
            return regex.test(value) ? undefined : message || 'Không đúng định dạng email';

        }
    };
};
Validator.isPhone = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            var regex = /^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/;
            return regex.test(value) ? undefined : message || 'Không đúng định dạng số điện thoại';
        }
    }
}
Validator.isPass = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,16}$/;
            return regex.test(value) ? undefined : message || 'Mật khẩu từ 4-16 ký tự bao gồm chữ hoa, chữ thường và ít nhất 1 chữ số ';
        }
    }
}
Validator.isRe_pass = function (selector,getConfirmPass,message) {
    return {
        selector: selector,
        test: function (value) {
            return value === getConfirmPass() ? undefined : message || 'Giá trị nhập vào không chính xác';
        }
    }

}