var virMgmt = virMgmt || {};
virMgmt = function () {
    "use strict";
}();

$(function() {
    "use strict";
    $("body").on('click', '.btn:not(.create)', function() {
        var action = this.id;
        $.ajax({
            url: '/Lookup/Management/Get' + action,
            cache: false,
            success: function(data) {
                $('#typeContext').html(data);
            }
        });
    });

    $("body").on('click', '.create', function () {
        var action = this.id;       
        $.ajax({
            url: '/Lookup/Management/Create' + action,
            cache: false,
            success: function (data) {
                $('#typeContext').html(data);
            }
        });
    });
    
    /************* FORM POST ***********************/
    $("body").on('submit', 'form', function (event) {
        var action = this.id;
        $(this).attr('action', '/Lookup/Management/Create' + action);

        $('#' + action).ajaxSubmit({
            target: '#typeContext'
        });

        event.preventDefault();
    });

    $("body").on('click', 'img', function () {
        $('#imgPreview').html('<img src="/Lookup/Management/GetImage?imageGuid=' + this.id + '&isThumb=false" />');
        $(".modal").modal('show');
    });

    $('body').on('click', '.icon-edit', function() {
        var action = this.id;
        var id = $(this).attr('data-id');
        $.get('/Lookup/Management/Create' + action + '?id=' + id, function (data) {
            $('#typeContext').html(data);
        });
    });

});