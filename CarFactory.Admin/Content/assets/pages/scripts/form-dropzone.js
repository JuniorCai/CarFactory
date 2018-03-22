var FormDropzone = function () {


    return {
        //main function to initiate the module
        init: function () {

            var dropzone = new Dropzone("#dropzoneContainer",
                {
                    maxFiles: 10,
                    maxFilesize: 1,
                    acceptedFiles: ".gif,.png,.bmp,.jpg,.jepg",
                    autoProcessQueue: false,
                    uploadMultiple:true,
                    dictDefaultMessage: "点击选择上传的图片",
                    dictFallbackMessage: "当前浏览器不支持该上传插件，请使用其他浏览器",
                    dictFileTooBig: "文件过大({{filesize}}MiB). 单个文件大小限制: {{maxFilesize}}MiB.",
                    dictInvalidFileType: "只支持（.gif,.png,.bmp,.jpg,.jepg）类型的图片",
                    dictResponseError: "服务器返回 {{statusCode}} code.",
                    dictUploadCanceled: "上传已取消.",
                    dictCancelUploadConfirmation: "确定取消图片上传?",
                    dictRemoveFile: "移除",
                    dictMaxFilesExceeded: "超出最大图片上传数量.",
                    init: function () {
                        var submitButton = document.querySelector("#saveBanner");
                        myDropzone = this; // closure

                    //为上传按钮添加点击事件
                        submitButton.addEventListener("click",
                            function() {
                                //手动上传所有图片
                                myDropzone.processQueue();
                            });
                        this.on("completemultiple", function(file, serverResponse) {
                            if (serverResponse.success == true) {

                            } else {
                                
                            }
                            }),
                        this.on("addedfile",
                            function (file) {
                                // Create the remove button
                                var removeButton =
                                    Dropzone.createElement(
                                        "<a href='javascript:;' class='btn red btn-sm btn-block'>移除</a>");

                                // Capture the Dropzone instance as closure.
                                var _this = this;

                                // Listen to the click event
                                removeButton.addEventListener("click",
                                    function (e) {
                                        // Make sure the button click doesn't submit the form:
                                        e.preventDefault();
                                        e.stopPropagation();

                                        // Remove the file preview.
                                        _this.removeFile(file);
                                        // If you want to the delete the file on the server as well,
                                        // you can do the AJAX request here.
                                    });

                                // Add the button to the file preview element.
                                file.previewElement.appendChild(removeButton);
                            });
                    }
                });
        }
    };
}();

jQuery(document).ready(function () {
    FormDropzone.init();
});
