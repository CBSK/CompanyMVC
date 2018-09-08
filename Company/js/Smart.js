//<![CDATA[

$(document).ready(function () {
    $('#list thead tr#filterrow th').each(function () {
        var title = $('#list thead  tr#filterrow th').eq($(this).index()).text();
        if (title != "T") {
            $(this).html('<input type="text" onclick="stopPropagation(event);" />');
        } else {
            $(this).html('');
        }
    });

    $("#list thead tr#filterrow input").on('keyup change', function () {
        table1
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();
    });

    $("#list thead tr#filterrow input").on('keyup change', function () {
        table2
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();
    });

    $("#list thead tr#filterrow input").on('keyup change', function () {
        table3
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();
    });
    $("#list thead tr#filterrow input").on('keyup change', function () {
        table4
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();
    });
    //var table = $('#list').DataTable({
    //	orderCellsTop: true,
    //	"scrollX": true
    //});
    var table1 = $('#list.company').DataTable({
        orderCellsTop: true,

        "lengthMenu": [[5, 10, 50, -1], [5, 10, 50, "All"]],
        "pagingType": "full_numbers",
        "scrollX": true,
        "columnDefs": [{
            "targets": [6],
            "orderable": false
        }]
    });


    $('#list.company tbody').on('click', 'tr', function () {
        
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table1.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    var table2 = $('#list.dept').DataTable({
        orderCellsTop: true,

        "lengthMenu": [[5, 10, 50, -1], [5, 10, 50, "All"]],
        "pagingType": "full_numbers",
        "scrollX": true,
        "columnDefs": [{
            "targets": [2],
            "orderable": false
        }]
    });
    var table2 = $('#list.admin').DataTable({
        orderCellsTop: true,
        "scrollX": false,
        "lengthMenu": [[5, 2, 50, -1], [5, 2, 50, "All"]],
        "pagingType": "full_numbers",
        "columnDefs": [{
            "targets": [1, 12],
            "orderable": false
        }]
    });
    var table3 = $('#list.dashboard,#list.viewCredit1').DataTable({
        orderCellsTop: true,
        "scrollX": false,
        "lengthMenu": [[25, 15, 50, -1], [25, 15, 50, "All"]],
        "pagingType": "full_numbers",
        "columnDefs": [{
            "targets": [0],
            "orderable": false
        }]
    });
    var table4 = $('#list.creditDetails').DataTable({
        orderCellsTop: true,
        "scrollX": false,
        "lengthMenu": [[25, 15, 50, -1], [25, 15, 50, "All"]],
        "pagingType": "full_numbers",
        "columnDefs": [{
            "targets": [0, 9],
            "orderable": false
        }]
    });

    // Apply the filter
    //    $('#list_filter').html('');
    //  $('body').show();
    //$('#list tr.header').css('display', 'none');
});
function stopPropagation(evt) {
    if (evt.stopPropagation !== undefined) {
        evt.stopPropagation();
    } else {
        evt.cancelBubble = true;
    }
}

function xlsExport(fileName) {
    var old = $("select[name=list_length]").val();
    var table = $('#list').DataTable();
    table.page.len(-1).draw();
    //$("select[name=list_length]").val(-1);

    $("#list").table2excel({
        // exclude CSS class
        exclude: ".noExl",
        name: "Client Details",
        filename: fileName //do not include extension
    });
    table.page.len(old).draw();
    $("select[name=list_length]").val(old);
}
//]]>