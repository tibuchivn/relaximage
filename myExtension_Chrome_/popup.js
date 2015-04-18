// Copyright (c) 2012 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

var PopupController = function () {
    //$('#imgDisplay').attr('src', 'http://photo.depvd.com/14/002/04/ph_Xprhg3FZA8_65YtZ1eC_no.jpg');
    //$.getJSON("http://dvd.tibuchivn.com/Home/GenerateRandomImage", function (response) {
    //    //debugger;
    //    $('#imgDisplay').attr('src', response.Name);
    //});
    //TODO: for host
    var vSpeedChangeImage = localStorage["SpeedChangeImage"];
    if (vSpeedChangeImage <= 0 || vSpeedChangeImage == undefined) {
        vSpeedChangeImage = 1500;
    }

    var vAmountPerClick = localStorage["AmountPerClick"];
    if (vAmountPerClick <= 0 || vAmountPerClick == undefined) {
        vAmountPerClick = 10;
    }
    //$('#lblDebug').html(vSpeedChangeImage + " & " + vAmountPerClick);
    
    $.getJSON("http://dvd.tibuchivn.com/Home/GenerateRandomImage/" + vAmountPerClick , function (lstImg) {
        var iCuser = 0;
        $.each(lstImg, function (i, value) {
            $('#divContentLoop').append("<input type='hidden' id=" + iCuser + " value= " + value.Name + " key='"+ value.Id +"' />");
            iCuser += 1;
        });
        //debugger;
        $('#hdfTotalImages').val(iCuser);
        $('#imgDisplay').attr('index', 0);
        $('#imgDisplay').attr('src', lstImg[0].Name);
        //Call interval
       
        setInterval(vLoop, vSpeedChangeImage);
    });
    //TODO: for local
    //$.getJSON("http://demodepvd.com/Home/GenerateRandomImage", function (lstImg) {
    //    var iCuser = 0;
    //    $.each(lstImg, function (i, value) {
    //        $('#divContentLoop').append("<input type='hidden' id=" + iCuser + " value= " + value.Name + " />");
    //        iCuser += 1;
    //    });
    //    //debugger;
    //    $('#hdfTotalImages').val(iCuser);
    //    $('#imgDisplay').attr('index', 0);
    //    $('#imgDisplay').attr('src', lstImg[0].Name);
    //    //Call interval
    //    setInterval(vLoop, 1500);
    //});
};

var vLoop = function changeImage() {
    var v1 = parseInt($('#imgDisplay').attr("index"), 10);
    var v = v1 + 1;
    //alert(v);
    $("#imgDisplay").attr("src", $('#' + v).val());
    $("#imgDisplay").attr("index", v);
    
    $('#lnkDetail').attr('href', 'http://dvd.tibuchivn.com/Home/detail/' + $('#' + v).attr('key') );

    var tmp = $('#hdfTotalImages').val();
    if (v + 1 == tmp) {
        $("#imgDisplay").attr("index", 0);
    }
}

document.addEventListener('DOMContentLoaded', function () {
  window.PC = new PopupController();
});


