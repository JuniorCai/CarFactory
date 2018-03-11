var TableDatatablesAjax = function () {

    var initPickers = function () {
        //init date pickers
        $('.date-picker').datepicker({
            rtl: App.isRTL(),
            autoclose: true,
            format:'yyyy-mm-dd'
        });
    }
    var handleDataTableList = function () {
        var pageUrl = $("#listTable").attr("pager")+"getDataPager";
        var grid = new Datatable();

        grid.init({
            src: $("#listTable"),
            onSuccess: function (grid, response) {
                // grid:        grid object
                // response:    json object of server side ajax response
                // execute some code after table records loaded
            },
            onError: function (grid) {
                // execute some code on network or other general error
            },
            onDataLoad: function(grid) {
                // execute some code on ajax data load
            },

            dataTable: { // here you can define a typical datatable settings from http://datatables.net/usage/options

                // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
                // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/scripts/datatable.js).
                // So when dropdowns used the scrollable div should be removed.
                //"dom": "<'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'<'table-group-actions pull-right'>>r>t<'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'>>",

                "dom": "<'row'<'col-md-8 col-sm-12'i><'col-md-4 col-sm-12'<'table-group-actions pull-right'>>r>t<'row'<'col-md-8 col-sm-12'i><'col-md-4 col-sm-12'>>",

                "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.

                "pageLength": 1, // default record count per page

                "ajax": {
                    "url": pageUrl, // ajax source"/admin/reports/getDataPager"
                },
                "order": [
                    [1, "asc"]
                ],// set first column as a default sort by asc,

                "language": {
                    "loadingRecords": "请稍等 ...",
                    "zeroRecords": "没有相关数据",
                    "emptyTable": "没有相关数据",
                    "info": "显示总数 _TOTAL_ 中的 _START_ 到 _END_",//Showing _START_ to _END_ of _TOTAL_ entries
                },

                scrollY: 400,
                deferRender:    true,
                scroller: {
                    loadingIndicator: true
                }
            }
        });

        //列表搜索栏---搜索按钮
        grid.getTableWrapper().on('click','.filter-submit',function(e){
            e.preventDefault();
            //grid.setAjaxParam('_token',$('input[name="_token"]').val());
            getTableFilterParam();
            grid.submitFilter();
        });

        function getTableFilterParam()
        {
            var filterArray = grid.getTableWrapper().find('.filter:first .form-control:input');

            filterArray.each(function(i,data){
                var paramName = $(data).attr('name');
                if(paramName!=undefined&&$.trim(paramName)!="")
                {
                    var paramV = $.trim($(data).val());
                    grid.setAjaxParam(paramName,paramV);

                }
            });



        }

        //列表搜索栏---重置按钮
        grid.getTableWrapper().on('click','.filter-cancel',function(e){
            e.preventDefault();
            grid.resetFilter();
        });

        // handle group actionsubmit button click
        grid.getTableWrapper().on('click', '.table-group-action-submit', function (e) {
            e.preventDefault();
            var action = $(".table-group-action-input", grid.getTableWrapper());
            if (action.val() != "" && grid.getSelectedRowsCount() > 0) {
                grid.setAjaxParam("customActionType", "group_action");
                grid.setAjaxParam("customActionName", action.val());
                grid.setAjaxParam("id", grid.getSelectedRows());
                grid.getDataTable().ajax.reload();
                grid.clearAjaxParams();
            } else if (action.val() == "") {
                App.alert({
                    type: 'danger',
                    icon: 'warning',
                    message: '请选择操作项',
                    container: grid.getTableWrapper(),
                    place: 'prepend'
                });
            } else if (grid.getSelectedRowsCount() === 0) {
                App.alert({
                    type: 'danger',
                    icon: 'warning',
                    message: '未选择需要更改的记录',
                    container: grid.getTableWrapper(),
                    place: 'prepend'
                });
            }
        });

        //grid.setAjaxParam("customActionType", "group_action");
        //grid.getDataTable().ajax.reload();
        //grid.clearAjaxParams();


    }

    return {

        //main function to initiate the module
        init: function () {

            initPickers();

            handleDataTableList();
        }

    };

}();

jQuery(document).ready(function() {
    TableDatatablesAjax.init();
});