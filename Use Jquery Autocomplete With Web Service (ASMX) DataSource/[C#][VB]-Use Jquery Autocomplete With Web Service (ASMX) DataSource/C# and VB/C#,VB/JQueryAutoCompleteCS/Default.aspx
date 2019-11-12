<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JQueryAutoCompleteCS.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JQuery Samples AutoComplete</title>
    <script src="Scripts/jquery-2.0.0.min.js"></script>
    <script src="Scripts/jquery-ui-1.10.3.min.js"></script>
    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="Content/themes/base/jquery.ui.autocomplete.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#AutoCompleteText").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/WebService/AutoCompleteWebService.asmx/GetRandomStrings",
                        dataType: "json",
                        data: "{'Value':'" + request.term + "'}",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.Name + '(' + item.Value + ')',
                                    value: item.Value,
                                    name: item.Name
                                }
                            }))
                        }
                    });
                },
                minLength: 2,
                select: function (event, ui) {
                    //TO TEST PURPOSE ONLY
                    log(ui.item ? "Selected: " + ui.item.label + " Value: " + ui.item.value + " Name: " + ui.item.name : "Nothing selected, input was " + this.value);

                },

                open: function () {
                    $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                },
                close: function () {
                    $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });

        });
        function log(message) {
            $("<div/>").text(message).prependTo("#log");
            $("#log").attr("scrollTop", 0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="AutoCompleteText" type="text" />

        </div>
        <div class="ui-widget" style="margin-top: 2em; font-family: Arial">
            Selection Result Log (Test Purpose Only):
	<div id="log" style="height: 200px; width: 500px; overflow: auto;" class="ui-widget-content"></div>
        </div>
    </form>
</body>
</html>
