var TodayDate = null;
var ckeditor = null;
var ckeditorvalue = null;
var securityFeedID = 0;
var createdOn = null;
var exdate = null;
var PreimageUrl = null;

var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-XXXXXXXX-X']);
_gaq.push(['_trackPageview']);

$(document).ready(function () {
    debugger;
   // ckeditor = CKEDITOR.instances.editor1.getData();
    ckeditor = CKEDITOR.replace('txtdescription', {
       height: '250px', startupFocus: true, 
    });
   // ckeditorvalue = CKEDITOR.instances['txtdescription'].document.getBody().getText();
    var currentdate = new Date();
    var datetime = + currentdate.getDate() + "/"
                + (currentdate.getMonth() + 1) + "/"
                + currentdate.getFullYear() + " "
                + currentdate.getHours() + ":"
                + currentdate.getMinutes() + ":"
                + currentdate.getSeconds();
     exdate =   +(currentdate.getMonth() + 1) + "/"
                + currentdate.getDate() + "/"
                + (currentdate.getFullYear()+1);
   
    $("#txttodate").val(datetime);
     TodayDate = datetime;
     SecurityFeedID = $("#SecurityFeedID").val();
    
     if (SecurityFeedID != 0 || SecurityFeedID > 0) {
         $('#SecurityFeedID').change();
     }
     else {
         $("#expirydate").val(exdate);
     }
     $('#loading').hide();
});

$('#SecurityFeedID').change(function (e) {
     
     securityFeedID = $('#SecurityFeedID').val();
    $this = $(e.target);
    $.ajax({
        type: "GET",
        url: "/SecurityFeedsEntry/GetSecurityFeedsByID?SecurityFeedID=" + securityFeedID,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //var formatData = ej.parseJSON(data);

            var ContentTitle = data.ContentTitle;
            createdOn = moment(data.CreatedOn).format("MM/DD/YYYY hh:mm:ss A");
            var ContentDescription = data.ContentDescription;
            var ImagePath = data.ImagePath;
            var Status = data.Status;
            var expirydate = moment(data.ExpiryOn).format("MM/DD/YYYY");

             
            $("#txttitle").val(data.ContentTitle);
            $('#txttodate').val(moment(data.CreatedOn).format("MM/DD/YYYY hh:mm:ss A"));
            // var url = $("#image-to-place").attr("src").replace('"' + data.ImagePath + '"');
            $("#image-to-place").attr("src", data.ImagePath);
            PreimageUrl = data.ImagePath;
            CKEDITOR.instances['txtdescription'].setData(data.ContentDescription);
            $("#expirydate").val(moment(data.ExpiryOn).format("MM/DD/YYYY"));
           
        }
    });
});
function CKupdate() {
    for (instance in CKEDITOR.instances) {
        CKEDITOR.instances['ckeditor'].updateElement();
    }
    CKEDITOR.instances['ckeditor'].setData('');
}

$("#btnCancel").click(function () {
     
    $("#txttitle").val("");
    $('#Files').val(null);
    $("#image-to-place").attr("src", "/Content/img/download.jpg");
    CKEDITOR.instances['txtdescription'].setData('');
 //   $("#showhiddenmsgupload").text('');
     
});
$("#btnAddNewsSave").click(function () {
    debugger;
    $('#loading').show();
    if (Validation()) {
        var DocObj = null;
        var createdby = $('#loginUserID').val();
        var expirydate = $("#expirydate").val();
        //var Description = $("#txtdescription").val();
        debugger;

        var Description = ckeditor.document.getBody().getText();
        //var Descriptionvalue = ckeditorvalue;
        var Filename = null;
        //$("#showhiddenmsg").text('');
        //$("#showhiddenmsgupload").hide();
        //$("#showhiddenmsgaddnews").hide();
        Filename = PreimageUrl;

        var Title = $("#txttitle").val();
        var fileUpload = $("#Files").get(0);
        var files = fileUpload.files;
        // Create FormData object
        var Istop = 0;
        var fileData = new FormData();
        // Looping over all files and add it to FormData object
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        fileData.append(Title, 'Manas');
        var id = SecurityFeedID;
        $.ajax({
            url: '/SecurityFeedsEntry/UploadFiles',
            type: "POST",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: fileData,
            complete: "complete",
            async: false,
            success: function (result) {
                if (result != "") {
                     
                    //  $("#txtDocumentName").val(result);
                    Filename = "/media/images/" + result;

                    $('#FileBrowse').find("*").prop("disabled", true);
                    showSuccess('Image Uploaded Successfully');
                   
                }

            },
            error: function (err) {
                console.log(err);
                
                alert(err.statusText);
            }
        });
         
        DocObj = {
            SecurityFeedID: 0,
            ContentTitle: '',
            ContentDescription: '',
            ImagePath: '',
            Status: '',
            CreatedBy: '',
            CreatedOn: '',
            UpdatedBy: '',
            ExpiryOn: '',
            // UpdatedOn: $("#txttodate").val(),

        }
         
        if (securityFeedID == 0)
        {
            DocObj.SecurityFeedID = securityFeedID;
            DocObj.ContentTitle = $("#txttitle").val();
            DocObj.ContentDescription = Description;
            DocObj.ImagePath = Filename;
            DocObj.Status = 'true';
            DocObj.CreatedBy = createdby;
            DocObj.CreatedOn = createdOn;
            DocObj.UpdatedBy = createdby;
            DocObj.ExpiryOn = expirydate;
        }
        else
        {
            DocObj.SecurityFeedID = securityFeedID;
            DocObj.ContentTitle = $("#txttitle").val();
            DocObj.ContentDescription = Description;
            DocObj.ImagePath = Filename;
            DocObj.Status = 'true';
            DocObj.CreatedBy = createdby;
            DocObj.CreatedOn = createdOn;
            DocObj.UpdatedBy = createdby;
            DocObj.ExpiryOn = expirydate;
        }
        

         

        if (DocObj != null) {
             $.ajax({
                url: '/SecurityFeedsEntry/SaveNews',
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(DocObj),
                //data: { DocObj: DocObj },
                dataType: "json",
                success: function (data) {
                     // showSuccess('News Message Posted');
                    window.location.href = "/SecurityFeeds/Index";
                    //$("#txttitle").val("");
                    //$('#Files').val(null);
                    //$("#image-to-place").attr("src", "/Content/img/download.jpg");
                    //CKEDITOR.instances['txtdescription'].setData('');
               },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (errormessage) {

                    validator.showErrors(errormessage.responseText);
                    alert(errormessage.responseText);
                }
            });
        }
        $('#loading').hide();
        showSuccess('Successfully Posted New Cyber Security News');
        $("#txttitle").val("");
        $('#Files').val(null);
        $("#image-to-place").attr("src", "/Content/img/download.jpg");
        CKEDITOR.instances['txtdescription'].setData('');
    }
    else {
        $('#loading').hide();
        showError("Error! Please Fill all mandatory fields  ")
    }
  
    
});

function Validation() {
     
    if (MasterValidation()) {
            return true;
    }
    else { return false; }

}

function MasterValidation() {
    debugger;
    //var editor_val = CKEDITOR.instances['txtdescription'].document.getBody().getText();
    var editor_val = CKEDITOR.instances['txtdescription'].getData();
    var inp = $("#txttitle").val();
    //if (inp.length > 0)
    //{
    //    showError('Enter News Title');
    //    return;
    //}
  
    if ($('#txttitle').val() == "") {
        showError('Enter News Title');
        return;
    }
    if ($('#expirydate').val() == "") {
        showError('Must Select News Expirydate');
        return;
    }
    //if ($('#Files').val() == "") {
    //    showError('Must Select Image');
    //    return;
    //}
    if (editor_val == "") {
        showError('Editor value cannot be empty!');
        return;
    }
  return true;
}


function complete(args) {
     
    if (args.files) {
         
        $("#previewimgae").attr("src", "/Content/OrderDocument/" + args.files.name);
        $("#Filename").val(args.files.name.toString());
        $("#FileExtention ").val("/Content/OrderDocument/");
        //$("#UploadDefault").hide();
        $("#ImageName").val(String(args.files.name))
        if (prevobj)
            prevobj.open();
        else
             
        {

        }
    }
}
(function () {
    var ga = document.createElement('script');
    ga.type = 'text/javascript';
    ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(ga, s);
});

function readURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image-to-place').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#Files").change(function () {
    readURL(this);
});

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
