$(function () {
    var skiprow = 1; 
    $(document).on('click', '#loadmore', function () {
        $.ajax({
            method: "GET",
            url: "/home/loadmore",
            data: {
                skiprow: skiprow
            },
            success: function (result) {
                $('#recentworks').append(result);
                skiprow++;
            }
        })
    })
})