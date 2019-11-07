// base url for the ajax call to service
var baseUrl = "http://localhost:54976/RestServiceImpl.svc/";
 
//Ajax request function for making ajax calling through other object 
function AjaxRequest(baseurl, type, callbackResponse, parameterString) {
    this.BaseURL = baseurl;
    this.Type = type;
    this.Callback = callbackResponse;
    this.createXmlRequestObject();
    this.ParemeterString = parameterString;
}

// Create XMLHTTP OBJECT
AjaxRequest.prototype.createXmlRequestObject = function() {
    if (window.ActiveXObject) { // INTERNET EXPLORER
        try {
            this.xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (e) {
            this.xmlHttp = false;
        }
    }
    else { // OTHER BROWSERS
        try {
            this.xmlHttp = new XMLHttpRequest()
        } catch (f) {
            this.xmlHttp = false;
        }
    }

    if (!this.xmlHttp) { // RETURN THE OBJECT OR DISPLAY ERROR
        alert('there was an error creating the xmlhttp object');
    } else {
        //return this.xmlhttp;
    }
}

AjaxRequest.prototype.MakeRequest = function() {
    try {

        // PROCEED ONLY IF OBJECT IS NOT BUSY       
        if (this.xmlHttp.readyState === 4 || this.xmlHttp.readyState === 0) {

            // EXECUTE THE PAGE ON THE SERVER AND PASS QUERYSTRING
            this.xmlHttp.open(this.Type, this.BaseURL, false);

            var that = this;
            // DEFINE METHOD TO HANDLE THE RESPONSE
            this.xmlHttp.onreadystatechange = function() {
                try {

                    // MOVE FORWARD IF TRANSACTION COMPLETE
                    alert(that.xmlHttp.readyState);
                    if (that.xmlHttp.readyState == 4) {
                        alert(that.xmlHttp.status);
                        // STATUS OF 200 INDICATES COMPLETED CORRECTLY
                        if (that.xmlHttp.status == 200) {

                            // WILL HOLD THE XML DOCUMENT
                            var xmldoc;
                            if (window.ActiveXObject) { // INTERNET EXPLORER
                                xmldoc = new ActiveXObject("Microsoft.XMLDOM");
                                xmldoc.async = "false";
                                that.Callback(that.xmlHttp.responseText);
                            }
                            else { // OTHER BROWSERS
                                //writeMessage("MakeRequest", that.xmlHttp.responseText);
                                that.Callback(that.xmlHttp.responseText);
                            }
                        }
                    }
                }
                catch (e)
                { alert(e) }
            }

            switch (this.Type) {
                case "GET":
                    //this.xmlHttp.setRequestHeader("Content-type", "application/json");
                    // MAKE CALL
                    this.xmlHttp.send(this.BaseURL);
                    break;
                case "POST":
                    this.xmlHttp.setRequestHeader("Content-type", "application/json");
                    this.xmlHttp.send(this.ParemeterString)
            }

        }
        else {
            // IF CONNECTION IS BUSY, WAIT AND RETRY
            setTimeout('GetAllAppsService', 5000);
        }
    } catch (e) {
        alert(e);
    }

}


function getDataFromthroughClass() {
    var objSync = new AuthenticateLogin();
    //string name, string email, string phoneNo, string gender, string country)
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var phone = document.getElementById("phone").value;
    var language = document.getElementById("language").value;
    var gender = document.getElementById("gender").value;
    var country = document.getElementById("country").value;
    objSync.SendDetailsToServer(new Array(
                                                                new Array("name", name),
                                                                new Array("email", email),
                                                                new Array("language", language),
                                                                new Array("phoneno", phone),
                                                                new Array("gender", gender),
                                                                new Array("country", country),
                                                                new Array("image", y)));
}


function AuthenticateLogin() {
}

function pareseDate(varDateString){
	
	try
	{
		var myDate = new Date(parseInt(varDateString.replace(/\/+Date\(([\d+-]+)\)\/+/, '$1')));  
		return myDate;	
	}
	catch(err)
	{
		//writeMessage('parseStringToDateTime err',err);
	}

}


AuthenticateLogin.prototype.SendDetailsToServer = function(parameters, localId) {

    var url = baseUrl + "SignUpUser";
    var parameterString = "{";

    for (var i = 0; i < parameters.length; i++) {
        parameterString = parameterString + '"'
                  + parameters[i][0] + '":"'
                  + parameters[i][1] + '" ,';
    }

    parameterString = parameterString.slice(0, parameterString.length - 1);
    //writeMessage("AddNewReminderToServer", "Local id : "+localId);
    parameterString = parameterString + "}";
    var ajaxRequestObject = new AjaxRequest(url, "POST", function(responseText) {
        var jsonobj = eval('(' + responseText + ')');
        var result = jsonobj.SignUpUserResult;
        if (result == "Successful") {
            alert("SuccessfullyMail sent and you will redirect to login Page");
            window.location = "http://localhost:54976/UI/latestLogin.htm";
        }
        else {
            alert("Message sending Fail! Please try again");
            window.location.reload(true);
        }
        //        writeMessage("handleresponse", jsonstr);
        //        writeMessage(" -> local id :", ajaxRequestObject.TempItemID);
    }, parameterString);

    ajaxRequestObject.TempItemID = localId;
    //writeMessage("AddNewReminderToServer", "Local id in ajax object : " + ajaxRequestObject.TempItemID);
    ajaxRequestObject.MakeRequest();

}

