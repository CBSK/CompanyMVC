var securityfeedid = 0;
var dataTable = {
    otable: null,
    initializeDatatable: function () {
        var responsiveHelper_datatable_fixed_column = undefined;
        var $tablea = $(".table-striped");
        dataTable.otable = $tablea.DataTable(
            {
                //"dom": '<"row view-filter"<"col-sm-12"<"pull-left"f><"pull-right"l><"clearfix">>>t<"row view-pager"<"col-sm-12"<"pull-left"i><"pull-right"p>>>',
                // "sDom": "<'top'<'col-sm-6'<'pull-left'f>><'col-sm-6'<'pull-right'l>>r>" +
                "sDom": "<'top'<'col-6 pull-left'<'pull-left'f>><'col-6 pull-right'<'pull-right'l>>r>" +
                "t" +
                "<'bottom'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>r>",
                "autoWidth": false,
                "oLanguage": {
                    "sSearch": '<span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>',
                    "sProcessing": "<img src='../Content/img/generatorphp-thumb.gif'>"
                },
                "scrollX": false,
                "paging": true,
                "searching": { "regex": true },
           
                processing: true,
                serverSide: true,
                ajax:
                {
                    url: "/SecurityFeeds/GridTable",
                    type: "POST",
                },
                "columns":
                [
                    {
                        "data": "ImagePath",
                        render: function (data, type, row) {

                            return '<td class="text-center sorting_1"><div class="btn-group"><img style="width:55px;height:50px" class="img-responsive thumbnail" src="' +
                            row.ImagePath
                            + '"></div></td > ';
                        }
                    },
                    { "data": "ContentTitle" },
                    { "data": "DisplayCreatedOn" },
                    { "data": "ContentDescription" },
                    {
                        "data": "SecurityFeedID",
                        render: function (data, type, row) {

                            return '<td class="text-center sorting_1"><div class="btn-group"><a data-original-title="Edit" href="#" onclick="EditSecurityFeedID(' +
                                row.SecurityFeedID
                                + ')"   title="" ><i class="fa fa-pencil-square-o"></i></a></div>&nbsp;<div class="btn-group"><a data-original-title="Delete" href="#"  onclick="DeleteSecurityFeedID(' +
                                row.SecurityFeedID
                                + ')" title="Delete" ><i class="fa fa-trash-o"></i></a></div></td > ';
                        }
                    }
                ],
                "order": [
                    [2, "desc"]
             ],
                fixedHeader: {
                    header: true,
                    footer: true
                }
            })
    },
    getData: function () {
        if (dataTable.otable == null)
            dataTable.initializeDatatable();
        else
            dataTable.otable.ajax.reload();
    }
};
$(document).ready(function () {
    debugger;
    SecurityFeedId = $('#HdnSecurityFeedId').val();
    if (SecurityFeedId != 0) {

    }
    else {
        SecurityFeedId = 0;
        //BindDropDown();
    }
    dataTable.getData();
    $('#loading').hide();
});
function EditSecurityFeedID(SecurityFeedID) {
    debugger;
    var url = "../SecurityFeedsEntry/Add?SecurityFeedID=" + SecurityFeedID;

    window.location.href = url;

}

function DeleteSecurityFeedID(SecurityFeedID) {
    debugger;
    var Key = SecurityFeedID;
    if (Key != 0 || Key != null) {
        alert("Do you want Delete this News:" + SecurityFeedID);
        $('#loading').show();
        $.ajax({

            url: "/SecurityFeeds/Delete?key=" + Key,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $('#loading').hide();
                showSuccess("Cyber Security No:" + SecurityFeedID + " News has Deleted");
                window.location.href = "../SecurityFeeds/Index";
            },
            error: function (errormessage) {
                showError(errormessage.responseText);
            }
        });

    }
    else {
        showError("Posted News does not deleted.. If you want to delete this post .. Please check ..");
    }
    $('#loading').hide();
}

function showError(msg) {

    $('.msgDiv').html('');
    // $.LoadingOverlay("hide");
    //$('.msgDiv').html('<div class="alert alert-danger alert-dismissable"> <button aria-hidden="true" data-dismiss="alert" class="close" type="button">×</button>' + msg + '</div>');
    $('.msgDiv').html('<div class="alert alert-info fade in"> <button class="close" data-dismiss="alert" type="button">×</button><i class="fa-fw fa fa-info"></i><strong>' + msg + '</strong></div>');
    $('html, body').animate({ scrollTop: 0 }, 800);
}
function showSuccess(msg) {
    $('.msgDiv').html('');
    // $.LoadingOverlay("hide");
    $('.msgDiv').html('<div class="alert alert-success fade in"><button class="close" data-dismiss="alert" type="button">×</button><i class="fa-fw fa fa-check"></i><strong>' + msg + '</strong> </div>');
    $('html, body').animate({ scrollTop: 0 }, 800);
}
//////////////////////////////////////////////////////////////////////////////////////

//$(document).ready(function () {
//    var currentDate = new Date();
//    var twoDigitMonth = currentDate.getMonth() + "";
//    if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;
//    var twoDigitDate = currentDate.getDate() + "";
//    if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;

//    var orderdate = twoDigitDate + "/" + twoDigitMonth + "/" + currentDate.getFullYear();
//    Loadtabledata1();

//});
//function Loadtabledata1() {
//    debugger;
//    $.ajax({
//        type: "POST",
//        url: "/SecurityFeeds/GridTable",
//        async: false,
//        cache: false,
//        processing: true,
//        serverSide: true,
//        success: function (data) {
//            var table = '<table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%">' +
//                 '<thead>' +
//                 '<tr>' +
//                 '<th></th >' +
//                '<th class="hasinput">' +
//                '<input type="text" class="form-control" placeholder="Title" />' +
//                '</th >' +
//                //'<th class="hasinput icon-addon">' +
//                //'<input id="dateselect_filter" type="text" placeholder="Open Date" class="form-control datepicker" data-dateformat="dd/mm/yy">' +
//                //'<label for="dateselect_filter" class="glyphicon glyphicon-calendar no-margin padding-top-15" rel="tooltip" title="" data-original-title="Filter Date"></label>' +
//                //'</th>' +
//              '<th></th >' +
//                '<th></th >' +
//                '<th></th >' +
//                '</tr>' +
//                 '<tr>' +
//                 '<th data-hide="phone,tablet">Image </th>' +
//                 '<th data-class="expand">Title</th>' +
//                 '<th data-hide="phone,tablet">CreatedOn</th>' +
//                 '<th data-hide="phone,tablet">Description</th>';
//            table = table + '<th style="text-align:center;">Action</th>';
//            table = table + '</tr></thead><tbody>';

//            $.each(data, function (i, item) {
//                table = table + '<tr><td>' + item.ImagePath + '</td>';
//                table = table + '<td><b>' + item.ContentTitle + '</b></td>';
//                table = table + '<td>' + moment(item.CreatedOn).format("DD/MM/YYYY") + '</td>';
//                table = table + '<td><i>' + item.ContentDescription + '</i></td>';
//                table = table + '<td class="text-center sorting_1"><div class="btn-group"><a data-original-title="Edit" onclick="EditSecurityFeedID(\'' + item.SecurityFeedID + '\')"   title="" ><i class="fa fa-pencil-square-o"></i></a></div>&nbsp;&nbsp;<div class="btn-group"><a data-original-title="Delete" onclick="DeleteSecurityFeedID(\'' + item.SecurityFeedID + '\')" title="Delete" ><i class="fa fa-trash-o"></i></a></div></td>';
//                table = table + '</tr>';
//            });

//            table = table + '</tbody></table>';
//            $('#divlist').html(table);

//            var responsiveHelper_dt_basic = undefined;
//            var responsiveHelper_datatable_fixed_column = undefined;
//            var responsiveHelper_datatable_col_reorder = undefined;
//            var responsiveHelper_datatable_tabletools = undefined;

//            var breakpointDefinition = {
//                tablet: 1024,
//                phone: 480
//            };

//            /* COLUMN FILTER  */

//            var otable = $('#datatable_fixed_column').DataTable({
//                "aoColumnDefs": [{
//                    "aTargets": [0],
//                    "mRender": function (data, type, full) {


//                        return '<img id="image-to-place" style="width:55px;height:50px" class="img-responsive thumbnail" src="' + data + '"/>';

//                    }
//                },
//                ],
//                "order": [
//                     [2, "desc"]
//                ],
//                "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
//                "t" +
//                "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
//                "autoWidth": true,
//                "oLanguage": {
//                    "sSearch": '<span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>'
//                },
//                "preDrawCallback": function () {
//                    if (!responsiveHelper_datatable_fixed_column) {
//                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($('#datatable_fixed_column'), breakpointDefinition);
//                    }
//                },
//                "rowCallback": function (nRow) {
//                    responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
//                },
//                "drawCallback": function (oSettings) {
//                    responsiveHelper_datatable_fixed_column.respond();
//                }

//            });


//            // Apply the filter
//            $("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

//                otable
//                    .column($(this).parent().index() + ':visible')
//                    .search(this.value)
//                    .draw();

//            });

//            $('#dateselect_filter').datepicker({
//                dateFormat: 'dd/mm/yy',
//                prevText: '<i class="fa fa-chevron-left"></i>',
//                nextText: '<i class="fa fa-chevron-right"></i>',
//                onSelect: function (selectedDate) {
//                    $('#dateselect_filter').datepicker('option', 'minDate', selectedDate);
//                }
//            });


//            /* END COLUMN FILTER */


//        },
//        error: function (data) { }
//    });
//}

//function EditSecurityFeedID(SecurityFeedID) {
//    var url = "../SecurityFeedsEntry/Add?SecurityFeedID=" + SecurityFeedID;

//    window.location.href = url;

//}

//function DeleteSecurityFeedID(SecurityFeedID) {

//    var Key = SecurityFeedID;
//    if (Key != 0 || Key != null) {
//        alert("Do you want Delete this News:" + SecurityFeedID);

//        $.ajax({

//            url: "/SecurityFeeds/Delete?key=" + Key,
//            type: "POST",
//            contentType: "application/json;charset=UTF-8",
//            dataType: "json",
//            success: function (result) {
//                //alert("Security News Deleted");

//                showSuccess("Cyber Security No:" + SecurityFeedID + " News has Deleted");
//                Loadtabledata1();
//            },
//            error: function (errormessage) {
//                // alert(errormessage.responseText);
//                showError(errormessage.responseText);
//            }
//        });

//    }
//    else {
//        showError("Posted News does not deleted.. If you want to delete this post .. Please check ..");
//    }

//}

//function showError(msg) {

//    $('.msgDiv').html('');
//    // $.LoadingOverlay("hide");
//    //$('.msgDiv').html('<div class="alert alert-danger alert-dismissable"> <button aria-hidden="true" data-dismiss="alert" class="close" type="button">×</button>' + msg + '</div>');
//    $('.msgDiv').html('<div class="alert alert-info fade in"> <button class="close" data-dismiss="alert" type="button">×</button><i class="fa-fw fa fa-info"></i><strong>' + msg + '</strong></div>');
//    $('html, body').animate({ scrollTop: 0 }, 800);
//}
//function showSuccess(msg) {
//    $('.msgDiv').html('');
//    // $.LoadingOverlay("hide");
//    $('.msgDiv').html('<div class="alert alert-success fade in"><button class="close" data-dismiss="alert" type="button">×</button><i class="fa-fw fa fa-check"></i><strong>' + msg + '</strong> </div>');
//    $('html, body').animate({ scrollTop: 0 }, 800);
//}