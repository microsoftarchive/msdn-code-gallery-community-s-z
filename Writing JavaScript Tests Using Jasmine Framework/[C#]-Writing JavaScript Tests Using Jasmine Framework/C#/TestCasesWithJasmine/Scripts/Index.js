var indexPage = {};
$(function () {
    $("#dtStartDate").datepicker();
    $("#dtEndDate").datepicker();
    $("#dtEndDate").on("change leave", function () {
        if (indexPage.validationFunctions.isNullValue(indexPage.validationFunctions.getStartDateSelectedValue())
            && indexPage.validationFunctions.isNullValue(indexPage.validationFunctions.getEndDateSelectedValue())) {
            alert("The values can't be null!.");
        } else {
            indexPage.validationFunctions.isEndDateGreaterStart();
        }
    });
});

indexPage.validationFunctions = (function () {
    return {
        getStartDateSelectedValue: function () {
            return $("#dtStartDate").val();
        },
        getEndDateSelectedValue: function () {
            return $("#dtEndDate").val();
        },
        isNullValue: function (selVal) {
            if (selVal.trim() == "") {
                return true;
            }
            else {
                return false;
            }
        },
        isNullValueWithUIElements: function () {
            if (indexPage.validationFunctions.isNullValue(indexPage.validationFunctions.getStartDateSelectedValue())
            && indexPage.validationFunctions.isNullValue(indexPage.validationFunctions.getEndDateSelectedValue())) {
                alert("The values can't be null!.");
            }
        },
        isEndDateGreaterStart: function () {
            var startDate = new Date(indexPage.validationFunctions.getStartDateSelectedValue());
            var endDate = new Date(indexPage.validationFunctions.getEndDateSelectedValue());
            if (startDate < endDate) {
                return true;
            }
            else {
                alert("End date must be greater than start date!.")
                return false;
            }
        }
    }
}(jQuery));