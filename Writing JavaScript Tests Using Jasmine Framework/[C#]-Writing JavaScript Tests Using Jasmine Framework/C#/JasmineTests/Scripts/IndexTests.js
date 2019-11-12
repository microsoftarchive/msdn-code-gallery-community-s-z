describe("Includes validations for index page", function () {
    var indexPage;
    beforeEach(function () {
        indexPage = window.indexPage.validationFunctions;
        window.alert = jasmine.createSpy("alert").and.callFake(function () { });
    });

    it("Check for null values", function () {
        // We are going to pass "" (null) value to the function
        var retVal = indexPage.isNullValue("");
        expect(retVal).toBeTruthy();
    });

    it("Spy call for datepicker date validation", function () {
        //Start date as 2015-03-25
        spyOn(indexPage, "getStartDateSelectedValue").and.returnValue("2015-03-25");
        //End date as 2015-03-24
        spyOn(indexPage, "getEndDateSelectedValue").and.returnValue("2015-03-24");
        var retVal = indexPage.isEndDateGreaterStart();
        expect(retVal).toBeFalsy();
    });

    it("Spy call for datepicker date validation toBeTruthy", function () {
        //Start date as 2015-03-25
        spyOn(indexPage, "getStartDateSelectedValue").and.returnValue("2015-03-25");
        //End date as 2015-03-26
        spyOn(indexPage, "getEndDateSelectedValue").and.returnValue("2015-03-26");
        var retVal = indexPage.isEndDateGreaterStart();
        expect(retVal).toBeTruthy();
    }); 

});