$(document).ready(function () {
    $('.bought-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });
});

function markCompleted(checkbox) {
    checkbox.disabled = true;
    var row = checkbox.closest('tr'); $(row).addClass('bought');
    var form = checkbox.closest('form'); form.submit();
}