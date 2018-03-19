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

        $('.userDelete').on('confirmed.bs.confirmation', function () {
            var val = $(this).attr('itemid');
            var editUser = { id: val };

            abp.ajax({
                url: "/admin/users/delUser",
                data: JSON.stringify(editUser)
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

        $('.resetPwd').on('confirmed.bs.confirmation', function () {
            var val = $("#Id").val();
            var resetModel = { userid: val };

            abp.ajax({
                url: "/admin/users/reset",
                data: JSON.stringify(resetModel)
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