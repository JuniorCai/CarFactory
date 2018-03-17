var UIConfirmations = function () {

    var handleEvent = function () {
        
        $('.roleDelete').on('confirmed.bs.confirmation', function () {
            var val = $(this).attr('roleid');
            var editRole = { id: val };

            abp.ajax({
                url: "/admin/roles/deleteRole",
                data: JSON.stringify(editRole)
                // , header: {"x-xsrf-token":abp.security.antiForgery.getToken}
            }).done(function (data) {
                //要执行的代码
                if (data.success == true) {
                    UIBootstrapGrowl.show('body', '操作成功', 'success');
                    setTimeout(function () {
                        location.reload();
                    }, 2000);
                } else {
                    UIBootstrapGrowl.show('body', '操作失败，请联系技术人员', 'warning');
                }
            });
        });


        $('.categoryDelete').on('confirmed.bs.confirmation', function () {
            var val = $(this).attr('category');
            var editCategory = { id: val };

            abp.ajax({
                url: "/admin/CategoryManage/delCategory",
                data: JSON.stringify(editCategory)
                // , header: {"x-xsrf-token":abp.security.antiForgery.getToken}
            }).done(function(data) {
                //要执行的代码
                if (data.result.success == true) {
                    UIBootstrapGrowl.show('body', '操作成功', 'success');
                    setTimeout(function () {
                        location.reload();
                    }, 2000);
                } else {
                    UIBootstrapGrowl.show('body', '操作失败，请联系技术人员', 'warning');
                }
            });

//            $.ajax({
//                url: "/admin/CategoryManage/delCategory",
//                type : "post",
//                dataType : "json",
//                data: {
//                    _token: $('input[name="__RequestVerificationToken"]').val(),
//                    id:val
//                },
//                success : function(msg) {
//                    //要执行的代码
//                    if(msg.state==1){
//                        UIBootstrapGrowl.show('body','操作成功','success');
//                        setTimeout("location.reload()", 2000);
//                    }
//                    else {
//                        UIBootstrapGrowl.show('body','操作失败，请联系技术人员'+'错误编号：'+msg.state,'warning');
//                    }
//                }
//            });
        });

        // $('#bs_confirmation_demo_1').on('canceled.bs.confirmation', function () {
        //     alert('You canceled action #1');
        // });
        //
        // $('#bs_confirmation_demo_2').on('confirmed.bs.confirmation', function () {
        //     alert('You confirmed action #2');
        // });
        //
        // $('#bs_confirmation_demo_2').on('canceled.bs.confirmation', function () {
        //     alert('You canceled action #2');
        // });
    }


    return {
        //main function to initiate the module
        init: function () {

           handleEvent();

        }

    };

}();

jQuery(document).ready(function() {    
   UIConfirmations.init();
});