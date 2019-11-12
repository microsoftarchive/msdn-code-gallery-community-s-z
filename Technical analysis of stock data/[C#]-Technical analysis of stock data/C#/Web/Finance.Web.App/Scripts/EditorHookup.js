/// <reference path="jquery-1.5.1.js" />
/// <reference path="jquery-ui-1.8.11.js" />

$(document).ready(function () {
	function getDateYymmdd(value) {
		if (value == null)
			return null;
		return $.datepicker.parseDate("yy-mm-dd", value);
	}
	$('.date').each(function () {
		var minDate = getDateYymmdd($(this).data("val-rangedate-min"));
		var maxDate = getDateYymmdd($(this).data("val-rangedate-max"));
		$(this).datepicker({
			dateFormat: "dd-mm-yy",  // hard-coding uk date format, but could embed this as an attribute server-side (based on the current culture)
			minDate: minDate,
			maxDate: maxDate
		});
	});
});