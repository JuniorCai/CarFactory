var ComponentsEditors = function () {


    //font edit only
    var handleSummernote = function (editorContainer,isUseMedia) {
        if(isUseMedia)
        {
            $("#"+editorContainer).summernote({
                height: 500,
                callbacks:{
                    onImageUpload:function(files){
                        var formdata = new FormData();
                        formdata.append("image", files[0]);
                        $.ajax({
                            data : formdata,
                            type : "POST",
                            url: "/admin/products/upload", //图片上传出来的url，返回的是图片上传后的路径，http格式
                            cache : false,
                            contentType : false,
                            processData : false,
                            dataType : "json",
                            success: function(data) {//data是返回的hash,key之类的值，key是定义的文件名
                                if(data.result.success==true)
                                {
                                    var img = $('<img>');
                                    img.attr('src', data.result.path);
                                    $('#' + editorContainer).summernote('insertImage', data.result.path);
                                }
                                else
                                {
                                    UIBootstrapGrowl.show('.note-editing-area','上传图片失败','warning');
                                }
                            },
                            error:function(){
                                alert("上传失败");
                            }
                        });
                    }
                }
            });
        }
        else
        {
            $("#"+editorContainer).summernote({
                height: 500,
                toolbar:[
                    ['style', ['style','bold', 'italic', 'underline', 'clear']],
                    ['font', ['strikethrough', 'superscript', 'subscript']],
                    ['fontname', ['fontname']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']]
                ]
            });
        }
        //API:
        //var sHTML = $('#summernote_1').code(); // get code
        //$('#summernote_1').destroy(); // destroy
    }

    var handleSummernoteWithImage = function(){
        $('#summernoteWithImage').summernote({
            height: 500,
            callbacks:{
                onImageUpload:function(files){
                    var formdata = new FormData();
                    formdata.append("image", files[0]);
                    formdata.append('_token',$('input[name="_token"]').val());
                    $.ajax({
                        data : formdata,
                        type : "POST",
                        url : "/admin/upload", //图片上传出来的url，返回的是图片上传后的路径，http格式
                        cache : false,
                        contentType : false,
                        processData : false,
                        dataType : "json",
                        success: function(data) {//data是返回的hash,key之类的值，key是定义的文件名
                            if(data.state==1)
                            {
                                var img = $('<img>');
                                img.attr('src',data.path);
                                $('#summernoteWithImage').summernote('insertImage',data.path);
                            }
                            else
                            {
                                UIBootstrapGrowl.show('.note-editing-area','上传图片失败','warning');
                            }
                        },
                        error:function(){
                            alert("上传失败");
                        }
                    });
                }
            }
        });
    }

    return {
        //main function to initiate the module
        init: function () {
            var useMedia = $('div.summernote').attr("useMedia")==1;
            var container = $('div.summernote').attr("id");
            handleSummernote(container,useMedia);
            //handleSummernoteWithImage();
        }
    };

}();

jQuery(document).ready(function() {    
   ComponentsEditors.init(); 
});