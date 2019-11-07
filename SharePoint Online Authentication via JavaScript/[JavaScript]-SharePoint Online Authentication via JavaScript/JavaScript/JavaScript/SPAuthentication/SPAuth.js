$.support.cors = true;

function Authenticate(username, password, tenantName) {

    $.ajax({
        'url': 'https://login.microsoftonline.com/extSTS.srf',
        dataType: 'text',
        type: 'POST',
        'data': '<s:Envelope xmlns:s="http://www.w3.org/2003/05/soap-envelope" xmlns:a="http://www.w3.org/2005/08/addressing" xmlns:u="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"><s:Header><a:Action s:mustUnderstand="1">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</a:Action><a:MessageID>urn:uuid:40c1407d-b2a4-4e05-8248-8a92b71102b6</a:MessageID><a:ReplyTo><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo><a:To s:mustUnderstand="1">https://login.microsoftonline.com/extSTS.srf</a:To><o:Security s:mustUnderstand="1" xmlns:o="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"><o:UsernameToken u:Id="uuid-69882db9-2d6b-45d3-b016-c2156cb6c01d-1"><o:Username>' + username + '</o:Username><o:Password Type="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText">' + password + '</o:Password></o:UsernameToken></o:Security></s:Header><s:Body><t:RequestSecurityToken xmlns:t="http://schemas.xmlsoap.org/ws/2005/02/trust"><wsp:AppliesTo xmlns:wsp="http://schemas.xmlsoap.org/ws/2004/09/policy"><a:EndpointReference><a:Address>https://somethingonline.sharepoint.com/_forms/default.aspx?wa=wsignin1.0</a:Address></a:EndpointReference></wsp:AppliesTo><t:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</t:KeyType><t:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</t:RequestType><t:TokenType>urn:oasis:names:tc:SAML:1.0:assertion</t:TokenType></t:RequestSecurityToken></s:Body></s:Envelope>',
        headers: { Accept: "application/soap+xml; charset=utf-8" },
        success: function (result) {
	    var xmlDoc = $.parseXML(result);
	    var xml = $(xmlDoc);
            var binToken = xml.find("wsse\\:BinarySecurityToken").text();
alert(binToken);
            CallSPOnline(binToken, tenantName);
        }
    });
}

function CallSPOnline(binToken, tenantName) {
    var url = "https://" + tenantName + ".sharepoint.com/_forms/default.aspx?wa=wsignin1.0";
    $.support.cors = true;
    $.ajax({
        'url': url,
        dataType: 'text',
        type: 'POST',
        'data': binToken,
        headers: { Accept: "application/x-www-form-urlencoded" },
        success: function (result) {
            $.ajax({
                url: 'https://' + tenantName + '.sharepoint.com/_api/web/AllProperties',
                dataType: 'JSON',
                type: 'GET',
                headers: { Accept: "application/json;odata=verbose" },
                success: function (x) {
                    alert(x.d.vti_x005f_categories);
                }
            });
        }
    });
}