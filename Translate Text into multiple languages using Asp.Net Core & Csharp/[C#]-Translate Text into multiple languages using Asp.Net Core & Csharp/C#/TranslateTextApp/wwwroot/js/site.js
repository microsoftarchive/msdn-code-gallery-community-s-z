// Write your JavaScript code.
$(function () {
    $(document)
        .on('change', '#ddlLangCode', function () {
            var languageCode = $(this).val();
            var enterText = $("#enterText").val();
            if (1 <= $("#enterText").val().trim().length && languageCode != "NA") {

                $('#enterText').removeClass('redBorder');

                var url = '/Home/Index';
                var dataToSend = { "LanguageCode": languageCode, "Text": enterText };
                dataType: "json",
                    $.ajax({
                        url: url,
                        data: dataToSend,
                        type: 'POST',
                        success: function (response) {
                            //update control on View
                            var result = JSON.parse(response);
                            var translatedText = result[0].translations[0].text;
                            $('#translatedText').val(translatedText);
                        }
                    })
            }
            else {
                $('#enterText').addClass('redBorder');
                $('#translatedText').val("");
            }
        });
});