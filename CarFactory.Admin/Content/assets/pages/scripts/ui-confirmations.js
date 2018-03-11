var UIConfirmations = function () {

    var handleEvent = function () {
        
        $('#roleDelete').on('confirmed.bs.confirmation', function () {
            var val = $(this).attr('roleid');

            $.ajax({
                url : "/admin/deleteRole",
                type : "post",
                dataType : "json",
                data: {
                    _token:$('input[name="_token"]').val(),
                    roleId:val,
                },
                success : function(msg) {
                    //要执行的代码
                    if(msg.state==1){
                        UIBootstrapGrowl.show('body','操作成功','success');
                        setTimeout("location.reload()", 2000);
                    }
                    else {
                        UIBootstrapGrowl.show('body','操作失败，请联系技术人员'+'错误编号：'+msg.state,'warning');
                    }
                }
            });
        });

        $('#categoryDelete').on('confirmed.bs.confirmation', function () {
            var val = $(this).attr('category');

            $.ajax({
                url : "/admin/deleteCategory",
                type : "post",
                dataType : "json",
                data: {
                    _token:$('input[name="_token"]').val(),
                    id:val,
                },
                success : function(msg) {
                    //要执行的代码
                    if(msg.state==1){
                        UIBootstrapGrowl.show('body','操作成功','success');
                        setTimeout("location.reload()", 2000);
                    }
                    else {
                        UIBootstrapGrowl.show('body','操作失败，请联系技术人员'+'错误编号：'+msg.state,'warning');
                    }
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