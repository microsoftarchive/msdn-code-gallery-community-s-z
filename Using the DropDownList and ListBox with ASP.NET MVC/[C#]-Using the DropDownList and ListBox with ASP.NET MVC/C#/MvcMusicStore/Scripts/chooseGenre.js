$(function () {
    $('#genreDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Add Genre',
        buttons: {
            'Save': function () {
                var createGenreForm = $('#createGenreForm');
                if (createGenreForm.valid()) {
                    $.post(createGenreForm.attr('action'), createGenreForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#GenreId').append(
                                    $('<option></option>')
                                        .val(data.Genre.GenreId)
                                        .html(data.Genre.Name)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#genreDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancel': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#genreAddLink').click(function () {
        var createFormUrl = $(this).attr('href');  
        $('#genreDialog').html('')
        .load(createFormUrl, function () {  
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createGenreForm');
            $('#genreDialog').dialog('open');
        });

        return false;
    });
});	