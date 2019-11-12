$(function () {
    $('#artistDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 200,
        modal: true,
        title: 'Add Artist',
        buttons: {
            'Save': function () {
                var createArtistForm = $('#createArtistForm');
                if (createArtistForm.valid()) {
                    $.post(createArtistForm.attr('action'), createArtistForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new artist to the dropdown list and select it
                            $('#ArtistId').append(
                                    $('<option></option>')
                                        .val(data.Artist.ArtistId)
                                        .html(data.Artist.Name)
                                        .prop('selected', true)  // Selects the new Artist in the DropDown LB
                                );
                            $('#artistDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancel': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#artistAddLink').click(function () {
        var createFormUrl = $(this).attr('href');  
        $('#artistDialog').html('')
        .load(createFormUrl, function () {  
            // The createArtistForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createArtistForm');
            $('#artistDialog').dialog('open');
        });

        return false;
    });
});	