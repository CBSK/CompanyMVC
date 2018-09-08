String.prototype.endsWith = function(suffix) {
   return this.indexOf(suffix, this.length - suffix.length) !== -1;
};

var doAjax_params_default = {
    'url': null,
    'requestType': "GET",
    'contentType': "application/x-www-form-urlencoded; charset=UTF-8",
    'dataType': "json",
    'data': {},
    'beforeSendCallbackFunction': null,
    'successCallbackFunction': null,
    'completeCallbackFunction': null,
    'errorCallBackFunction': null
};

function OpenNextTab(control) {
    //alert("call");

    hideLoader();
    //var elements = $("#tabContents").find('li'), tempIndex, txt = "next"; //control.innerText.trim().toLowerCase();
    //if (txt == "previous" && elements.index($("#tabContents").find('.ui-tabs-active')) != 0)
    //    tempIndex = elements.index($("#tabContents").find('.ui-tabs-active')) - 1;
    //else if (txt == "next" && elements.index($("#tabContents").find('.ui-tabs-active')) != elements.length - 1)
    //    tempIndex = elements.index($("#tabContents").find('.ui-tabs-active')) + 1;
    //(tempIndex != -1) && !(tempIndex > elements.length - 1) && $(elements[tempIndex]).trigger("click");
    var txt = "next";
    if (txt == "next") {
        var indx = parseInt(parseInt($(this).data("tab-index")) + parseInt(1));

        //$('#tabContents').tabs("option", "active", indx);
        var selected = $("#tabContents").tabs("option", "active");
        console.log("indx=" + selected);
        //$("#tabContents").tabs("option", "selected", selected);
        $("#tabContents").tabs("option", "active", selected + 1);
    }

}

function doAjax(doAjax_params) {

    var url = doAjax_params['url'];
    var requestType = doAjax_params["requestType"];
    var contentType = doAjax_params["contentType"];
    var dataType = doAjax_params["dataType"];
    var data = doAjax_params["data"];
    var beforeSendCallbackFunction = doAjax_params["beforeSendCallbackFunction"];
    var successCallbackFunction = doAjax_params["successCallbackFunction"];
    var completeCallbackFunction = doAjax_params["completeCallbackFunction"];
    var errorCallBackFunction = doAjax_params["errorCallBackFunction"];

    //make sure that url ends with '/'
    /*if(!url.endsWith("/")){
     url = url + "/";
    }*/

    $.ajax({
        url: url,
        crossDomain: false,
        type: requestType,
        contentType: contentType,
        dataType: dataType,
        data: data,
        beforeSend: function(jqXHR, settings) {
            if (typeof beforeSendCallbackFunction === "function") {
                beforeSendCallbackFunction();
            }
        },
        success: function(data1, textStatus, jqXHR) {    
            if (typeof successCallbackFunction === "function") {
                successCallbackFunction(data1);
            }
        },
        error: function(jqXHR, textStatus, errorThrown) {
            if (typeof errorCallBackFunction === "function") {
                errorCallBackFunction(errorThrown);
            }

        },
        complete: function(jqXHR, textStatus) {
            if (typeof completeCallbackFunction === "function") {
                completeCallbackFunction();
            }
        },
        global: false
    });
}





function showMessage(message,type) {
    $.notify({message:message}, {
        animate: {
            enter: 'animated bounceIn',
            exit: 'animated bounceOut'
        }, type: type, allow_dismiss:false
    });

}

function displayLoader() {
    $(".loader").show();
}

function hideLoader() {
    $(".loader").hide();

}
$(document).ajaxStart(function (event, request, settings) {
    //showLoading();
});

$(document).ajaxComplete(function (event, request, settings) {
    //   
    //  hideLoading();
});

function isEmail(email) {
    //  
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

//--- Delete Confirm Message
function DeleteConfirm() {
    var def = $.Deferred();
    bootbox.confirm({
        message: "Are you sure want to delete this record?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: def.resolve
    });
    return def.promise().then(function (result) {
        return result;
    });
}


