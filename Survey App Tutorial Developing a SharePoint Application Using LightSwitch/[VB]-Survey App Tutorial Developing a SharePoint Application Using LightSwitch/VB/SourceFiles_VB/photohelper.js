/// <reference path="../GeneratedArtifacts/viewModel.js" />

var API_URL = "../api/photos/";
var errorPrefix = "FAILED::"

function showUploadPopup(screen) {

    screen.showPopup("UploadPhotos").then(function () {
        var errorPrefix = "FAILED::"
        var uploadForm = $("#uploadForm");

        if (uploadForm.length === 0) {
            uploadForm = $(
             '<form id="uploadForm" method="POST" enctype="multipart/form-data" action="' + API_URL + '"  data-ajax="false" target="uploadTargetIFrame">' +
             '   <input name="fileInput" id="fileInput" type="file" size="30" data-theme="c" accept="image/*" multiple="true"/>' +
             '</form>');
            uploadForm.appendTo($uploadControlElement);

            var $uploadTargetIFrame = $('<iframe name="uploadTargetIFrame"  style="width: 0px; height: 0px; border: 0px solid #fff;"></iframe>');
            $uploadControlElement.append($uploadTargetIFrame);
            $uploadTargetIFrame.load(function () {
                if ($.mobile.popup.active) {
                    var serverResponse = null;
                    serverResponse = $uploadTargetIFrame.contents().find("string").text();
                    var uploadedFiles = removeDuplicates(serverResponse.split("\n"));
                    if (uploadedFiles && uploadedFiles.length && completeUpload) {
                        if (serverResponse.substring(0, errorPrefix.length) === errorPrefix) {
                            error(serverResponse);
                        } else {
                            msls.promiseOperation(function (op) {
                                completeUpload(uploadedFiles);
                                op.complete();
                            });
                        }
                    }
                    $.mobile.loading('hide');
                }
            });
        }

        function completeUpload(uploadedFiles) {
            for (var index in uploadedFiles) {
                var photo = screen.Photos.addNew();
                photo.FullImageUrl = uploadedFiles[index];

                var photoNameWithExt = photo.FullImageUrl.substr(photo.FullImageUrl.lastIndexOf('/') + 1);
                var photoNameWithoutExt = photoNameWithExt.substr(0, photoNameWithExt.lastIndexOf("."));
                var photoExt = photoNameWithExt.substr(photoNameWithExt.lastIndexOf(".") + 1,
                                photoNameWithExt.length);
                var photoPathUri = photo.FullImageUrl.substr(0, photo.FullImageUrl.lastIndexOf('/'));

                photo.CreatedDate = new Date();
                photo.NameWithExt = photoNameWithExt;
                photo.ThumbnailUrl = photoPathUri + "/_t/" + photoNameWithoutExt + "_" + photoExt
                    + "." + photoExt;
                photo.OptimizedUrl = photoPathUri + "/_w/" + photoNameWithoutExt + "_" + photoExt
                    + "." + photoExt;
            }
            uploadForm.remove();
            $uploadTargetIFrame.remove();
            screen.closePopup();
        }

        function removeDuplicates(source) {
            var newArray = [];
            for (var index in source) {
                if (source[index]) {
                    newArray.push(source[index]);
                }
            }
            return newArray;
        }

        function onError(e) {
            alert(e);
        };
    });
}

function deleteCurrentPhoto(screen) {
    $.mobile.loading('show');
    if (screen.Photos && screen.Photos.selectedItem) {
        $.ajax({
            url: API_URL + "?url=" + screen.Photos.selectedItem.FullImageUrl,
            cache: false,
            type: 'DELETE',
            contentType: 'application/json; charset=utf-8',
            complete: function () {
                if (screen.Photos && screen.Photos.selectedItem) {
                    screen.Photos.selectedItem.deleteEntity();
                    $.mobile.loading('hide');
                    try {
                        myapp.applyChanges().then(function () {
                            screen.closePopup();
                        });
                    } catch (e) { }
                }
            }
        });
    }
}
