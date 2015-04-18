$(function () {
   var vSpeed = localStorage["SpeedChangeImage"]  ;
   var vAmount = localStorage["AmountPerClick"];
    if (vSpeed == null || vSpeed < 1000)
        vSpeed = 3000;
    if (vAmount == null || vAmount < 10)
        vAmount = 50;
    $('#selectSpeed').val(vSpeed);
    $('#selectAmountImage').val(vAmount);
});

// Saves options to chrome.storage
function save_options() {
     
    localStorage["SpeedChangeImage"] = $('#selectSpeed').val();
    localStorage["AmountPerClick"] = $('#selectAmountImage').val();
    $('#status').html("Options saved.");
    setTimeout(function () {
        $('#status').html("");
    }, 3000);
}

// Restores select box and checkbox state using the preferences
// stored in chrome.storage.
function restore_options() {
    // Use default value color = 'red' and likesColor = true.
    localStorage["SpeedChangeImage"] = 1500;
    localStorage["AmountPerClick"] = 10;
}
document.addEventListener('DOMContentLoaded', restore_options);
document.getElementById('save').addEventListener('click',save_options);