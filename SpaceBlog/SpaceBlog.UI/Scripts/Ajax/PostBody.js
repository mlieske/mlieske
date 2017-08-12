$(document).ready(function() {
    $('body').click(function() {
        $('#bodyPost')["0"].value = $("#subject_ifr")["0"].offsetParent.firstChild.childNodes[2].childNodes["0"].contentDocument.activeElement.innerHTML;
    });

});