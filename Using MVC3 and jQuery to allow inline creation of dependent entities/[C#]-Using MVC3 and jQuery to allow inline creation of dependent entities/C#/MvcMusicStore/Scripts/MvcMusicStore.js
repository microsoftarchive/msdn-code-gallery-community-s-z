(function (MvcMusicStore, $, undefined) {

   // declare function on our MvcMusicStore object 
   MvcMusicStore.AppendAddButtons = function (container) {

      // find select elements with a data-val-required attribute 
      $(container).find("select[data-val-required]").each(function (index, element) {
      
         var input = this, entityName = input.name.replace("Id", ""); 
      
         $(this).after(
            $("<input/>")
               .attr({ "type": "button", "value": "Add" })
               .addClass("button")
               .css({ "margin-left": 5 })
               .click(function () {

                  $.ajax( 
                     "/" + entityName + "/Create", 
                     { 
                        type: "GET", 
                        contentType: "text/html; charset=utf-8", 
                        success: function (data, textStatus, jqXHR) { 
 
                           var newDialog = $("<div></div>"), newDialogContent = $("<div></div>"); 
 
                           newDialog.append(newDialogContent); 
 
                           newDialogContent.html($("<form></form>").html(data)); 
                         
                           var dialogButtons = { 
                              "save": function () { 
 
                                 var form = $(this).dialog("widget").find("form"), 
                                    postData = form.serialize(); 
                                    dialog = this; 
 
                                 $.ajax(
                                    "/" + entityName + "/Create", 
                                    { 
                                    "type": "POST", 
                                    "data": postData, 
                                    "success": function (data, textStatus, jqXHR) { 
                                       $(element).append($("<option></option>").attr("value", data[element.name]).text(data.Name)); 
                                       $(element).val(data[element.name]); 
                                       $(this).dialog("close"); 
 
                                       }, 
                                    "statusCode": { 
                                       404: function () { 
                                          alert("Not found"); 
                                          }, 
                                       401: function () { 
                                          alert("Unauthorised"); 
                                          } 
                                       }, 
                                    "error": function (jqXHR, textStatus, errorThrown) { 
                                       if(jqXHR.statusCode != 401 && jqXHR.statusCode != 401){ 
                                          alert("Unhandled error: " + errorThrown); 
                                          } 
                                       } 
                                    }); 
 
                                 }, 
                              "cancel": function () { 
                                 $(this).dialog("close"); 
                                 }, 
                              } 
 
                           newDialog.dialog({ "width": 335, "buttons": dialogButtons, "title": "Create " + entityName}); 
                           }, 
                        error: function (jqXhr, textStatus, errorThrown) { 
                           alert("boo!"); 
                        } 
                      } 
                  );

               })
            );
      });
   }

})(window.MvcMusicStore = window.MvcMusicStore || {}, jQuery);

// call function after document has finished loading 
$(document).ready(function () {
   MvcMusicStore.AppendAddButtons(document);
});
