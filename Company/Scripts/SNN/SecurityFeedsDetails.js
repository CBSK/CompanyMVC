$(document).ready(function () {
    var currentDate = new Date();
    // $('#DatePickerInputID').val($.datepicker.formatDate('dd-MM-yyyy', orderdate));
    // orderdate = $('#DatePickerInputID').val();
    var twoDigitMonth = currentDate.getMonth() + "";
    if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;
    var twoDigitDate = currentDate.getDate() + "";
    if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;

    var orderdate = twoDigitDate + "/" + twoDigitMonth + "/" + currentDate.getFullYear();
    Loadtabledata1();
 // Loadtabledata();
     
});

function Loadtabledata1() {
     
    $.ajax({
        type: "POST",
        url: "/SecurityFeeds/GridTable",
        async: false,
        cache: false,
        success: function (data) {
             
          //  $('#datatable_fixed_column tbody').empty();
            var table = '<table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%">' +
                 '<thead>' +
                 '<tr>' +
                 '<th></th >' +
                '<th class="hasinput">' +
                '<input type="text" class="form-control" placeholder="Title" />' +
                '</th >' +
                '<th class="hasinput icon-addon">' +
                '<input id="dateselect_filter" type="text" placeholder="Open Date" class="form-control datepicker" data-dateformat="dd/mm/yy">' +
                '<label for="dateselect_filter" class="glyphicon glyphicon-calendar no-margin padding-top-15" rel="tooltip" title="" data-original-title="Filter Date"></label>' +
                '</th>' +
              '<th></th >' +
                '<th></th >' +
                '</tr>' +
                 '<tr>' +
                 '<th>ImagePath </th>' +
                 '<th>ContentTitle</th>' +
                 '<th>CreatedOn</th>' +
                 '<th>ContentDescription</th>';
            table = table + '<th style="text-align:center;">Action</th>';
            table = table + '</tr></thead><tbody>';

            $.each(data, function (i, item) {
                table = table + '<tr><td>' + item.ImagePath + '</td>';
                table = table + '<td><b>' + item.ContentTitle + '</b></td>';
                table = table + '<td>' + moment(item.CreatedOn).format("DD/MM/YYYY") + '</td>';
                table = table + '<td>' + item.ContentDescription + '</td>';
                table = table + '<td class="text-center sorting_1"><div class="btn-group"><a data-original-title="Edit" onclick="EditSecurityFeedID(\'' + item.SecurityFeedID + '\')"   title="" ><i class="fa fa-pencil-square-o"></i></a></div>&nbsp;&nbsp;<div class="btn-group"><a data-original-title="Delete" onclick="DeleteSecurityFeedID(\'' + item.SecurityFeedID + '\')" title="Delete" ><i class="fa fa-trash-o"></i></a></div></td>';
                table = table + '</tr>';
            });
             
            table = table + '</tbody></table>';
            $('#divlist').html(table);

             var responsiveHelper_dt_basic = undefined;
            var responsiveHelper_datatable_fixed_column = undefined;
              var responsiveHelper_datatable_col_reorder = undefined;
              var responsiveHelper_datatable_tabletools = undefined;

            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */
           // if (!$.fn.DataTable.isDataTable('#datatable_fixed_column'))
                 
                var otable = $('#datatable_fixed_column').DataTable({
                    //"bFilter": false,
                    //"bInfo": false,
                    //"bLengthChange": false
                    //"bAutoWidth": false,
                    //"bPaginate": false,
                    //"bStateSave": true // saves sort state using localStorage
                    //"aoColumnDefs": [{
                    //    "aTargets": [0],
                    //    "mRender": function (data, type, full) {
                    //        //  
                    //        if (data == "true") {
                    //            return '<div id="divItemImage" style="width:55px;height:50px" class="top" ><img id="image-to-place" class="img-responsive thumbnail" src="' + data + '"/></div>';
                    //        } else {
                    //            return '<div id="divItemImage" style="width:55px;height:50px" class="top" ><img id="image-to-place" class="img-responsive thumbnail" src="/Content/img/download.jpg"/></div>';
                    //        }
                    //    }
                    //},
                    //],
                    "aoColumnDefs": [{
                       "aTargets": [0],
                        "mRender": function (data, type, full) {
                              
                            
                                return '<img id="image-to-place" style="width:55px;height:50px" class="img-responsive thumbnail" src="' + data + '"/>';
                           
                        }
                    },
                    ],
                    //"rowCallback": function (row, data, index) {
                    //    $('td:eq(0)', row).html('<img id="image-to-place" style="width:55px;height:50px" class="img-responsive thumbnail" src="' + data + '"/>');
                    //},
                    "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
                    "t" +
                    "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                    "autoWidth": true,
                    "oLanguage": {
                        "sSearch": '<span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>'
                    },
                    "preDrawCallback": function () {
                        // Initialize the responsive datatables helper once.
                        if (!responsiveHelper_datatable_fixed_column) {
                            responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($('#datatable_fixed_column'), breakpointDefinition);
                        }
                    },
                    "rowCallback": function (nRow) {
                        responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                    },
                    "drawCallback": function (oSettings) {
                        responsiveHelper_datatable_fixed_column.respond();
                    }

                });


            // Apply the filter
            $("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });

            $('#dateselect_filter').datepicker({
                dateFormat: 'dd/mm/yy',
                prevText: '<i class="fa fa-chevron-left"></i>',
                nextText: '<i class="fa fa-chevron-right"></i>',
                onSelect: function (selectedDate) {
                    $('#dateselect_filter').datepicker('option', 'minDate', selectedDate);
                }
            });


            /* END COLUMN FILTER */


        },
        error: function (data) { }
    });
}
function Loadtabledata()
{
     
    $.ajax({
        type: "POST",
        url: "/SecurityFeeds/GridTable",
        success: function (data) {
             
           // $('#datatable_fixed_column tbody').empty();
            $.each(data, function (i, item) {
                var rows = "<tr >"
                    + "<td><div id='divItemImage' style='width:55px;height:50px' class='top' ><img id='image-to-place' class='img-responsive thumbnail' src='" + item.ImagePath + "'/></div></td>"
                    + "<td><b>" + item.ContentTitle + "</b></td>"
                    + "<td>" + moment(item.CreatedOn).format("DD/MM/YYYY") + "</td>"
                    + "<td>" + item.ContentDescription + "</td>"
                    + '<td class="text-center sorting_1"><div class="btn-group"><a data-original-title="Edit" onclick="EditSecurityFeedID(\'' + item.SecurityFeedID + '\')"   title="" ><i class="fa fa-pencil-square-o"></i></a></div>&nbsp;&nbsp;<div class="btn-group"><a data-original-title="Delete" onclick="DeleteSecurityFeedID(\'' + item.SecurityFeedID + '\')" title="Delete" ><i class="fa fa-trash-o"></i></a></div></td>'
                    + "</tr>";
                $('#datatable_fixed_column tbody').append(rows);
            });

            // var responsiveHelper_dt_basic = undefined;
            var responsiveHelper_datatable_fixed_column = undefined;
            //  var responsiveHelper_datatable_col_reorder = undefined;
            //  var responsiveHelper_datatable_tabletools = undefined;

            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */
            if (!$.fn.DataTable.isDataTable('#datatable_fixed_column'))
                var otable = $('#datatable_fixed_column').DataTable({
                    //"bFilter": false,
                    //"bInfo": false,
                    //"bLengthChange": false
                    //"bAutoWidth": false,
                    //"bPaginate": false,
                    //"bStateSave": true // saves sort state using localStorage
                    //"aoColumnDefs": [{
                    //    "aTargets": [4],
                    //    "mRender": function (data, type, full) {
                    //        //  
                    //        if (data == "true") {
                    //            return '<input type=\"checkbox\" checked value="' + data + '" disabled>';
                    //        } else {
                    //            return '<input type=\"checkbox\" value="' + data + '" disabled>';
                    //        }
                    //    }
                    //}, 
                    //],
                    "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
                    "t" +
                    "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                    "autoWidth": true,
                    "oLanguage": {
                        "sSearch": '<span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>'
                    },
                    "preDrawCallback": function () {
                        // Initialize the responsive datatables helper once.
                        if (!responsiveHelper_datatable_fixed_column) {
                            responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($('#datatable_fixed_column'), breakpointDefinition);
                        }
                    },
                    "rowCallback": function (nRow) {
                        responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                    },
                    "drawCallback": function (oSettings) {
                        responsiveHelper_datatable_fixed_column.respond();
                    }

                });


            // Apply the filter
            $("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });

            $('#dateselect_filter').datepicker({
                dateFormat: 'dd/mm/yy',
                prevText: '<i class="fa fa-chevron-left"></i>',
                nextText: '<i class="fa fa-chevron-right"></i>',
                onSelect: function (selectedDate) {
                    $('#dateselect_filter').datepicker('option', 'minDate', selectedDate);
                }
            });


            /* END COLUMN FILTER */


        },
        error: function (data) { }
    });
}
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
    //                alert("Security News Deleted");
    //                Loadtabledata();
    //            },
    //            error: function (errormessage) {
    //                alert(errormessage.responseText);
    //            }
    //        });

    //    }
    //    else {
    //        alert("");
    //    }
        
    //}
