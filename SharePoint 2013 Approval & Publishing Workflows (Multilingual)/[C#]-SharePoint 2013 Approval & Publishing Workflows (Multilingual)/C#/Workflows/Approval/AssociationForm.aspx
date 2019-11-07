<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WorkflowServices" Namespace="Microsoft.SharePoint.WorkflowServices.ApplicationPages" Assembly="Microsoft.SharePoint.WorkflowServices.ApplicationPages, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="/_layouts/15/CustomApprovalWorkflows/scripts/jquery-1.8.2.min.js"></script>
    <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:CustomApprovalWorkflows,page_workflowinit_title%>" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
    <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:CustomApprovalWorkflows,page_workflowinit_title%>" />
</asp:Content>

<%--    
        IMPORTANT NOTE: 
        Be sure to update the InitiationUrl property value to the URL of the custom initiation form.  
        The InitiationUrl property can be updated from the workflow's property grid.
--%>

<asp:Content ID="Content5" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<%--    
        The following sample code creates a simple custom workflow Association Form that allows users to 
    set workflow parameter values when adding or editing a list workflow association. 
--%>

    <WorkflowServices:WorkflowAssociationFormContextControl ID="WorkflowAssociationFormContextControl1" runat="server" />
    
    <h1><label id="wfHeader"></label></h1>

    <div>
         <table style="width:80%">
    <tr>
      <td style="width:40%; vertical-align:top;">
          <asp:Label ID="Label1" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_approvers%>"></asp:Label>
          </td>
        <td style="width:60%; vertical-align:top;">
        <SharePoint:PeopleEditor AllowEmpty="false" ValidatorEnabled="true" MultiSelect="true" ID="spApprovers" runat="server" SelectionSet="User, SPGroup" AutoPostBack="false" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_approvers_description%>"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label3" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_duration%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <input id="txtDurationDays" type="text" value="7" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_duration_description%>"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label5" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_endonfirstapproval%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <input id="chkFirstApproval" type="checkbox" /><asp:Label ID="Label6" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_endonfirstapproval_description%>"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label9" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_enablecontentapproval%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <input id="chkContentApproval" type="checkbox" /><asp:Label ID="Label10" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_enablecontentapproval_description%>"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label11" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_tasktitle%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <input id="txtTaskTitle" type="text" size="100" />
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label13" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_taskassignmentemailsubject%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <input id="txtTaskAssignmentEmailSubject" type="text" size="100" />
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label12" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_taskassignmentemailbodyhtml%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <textarea id="txtTaskAssignmentEmailBody" cols="100" rows="5"><asp:Literal runat="server" ID="litTaskAssignedBody" Text="<%$Resources:CustomApprovalWorkflows,workflow_ApprovalTaskAssignedEmailBodyHtml%>"></asp:Literal></textarea>
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label14" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_taskcancellationemailsubject%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <input id="txtTaskCancelEmailSubject" type="text" size="100" />
      </td>
    </tr>   
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label15" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_taskcancellationemailbodyhtml%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <textarea id="txtTaskCancelEmailBody" cols="100" rows="5"><asp:Literal runat="server" ID="litTaskCancelledBody" Text="<%$Resources:CustomApprovalWorkflows,workflow_ApprovalTaskCancelledEmailBodyHtml%>"></asp:Literal></textarea>
      </td>
    </tr>
             <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label16" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_taskoverdueemailsubject%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <input id="txtTaskOverdueEmailSubject" type="text" size="100" />
      </td>
    </tr>   
    <tr>
      <td style="vertical-align:top;">
          <asp:Label ID="Label17" runat="server" Text="<%$Resources:CustomApprovalWorkflows,label_workflowinitform_taskoverdueemailbodyhtml%>"></asp:Label>
          </td>
        <td style="vertical-align:top;">
            <textarea id="txtTaskOverdueEmailBody" cols="100" rows="5"><asp:Literal runat="server" ID="litTaskOverdueBody" Text="<%$Resources:CustomApprovalWorkflows,workflow_ApprovalTaskOverdueEmailBodyHtml%>"></asp:Literal></textarea>
      </td>
    </tr>
    <tr>
        <td></td>
        <td style="vertical-align:top;">
            <button id="Save" onclick="return runAssocWFTask()"><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:CustomApprovalWorkflows,button_workflowform_save%>" /></button>&nbsp;
            <button id="Cancel" onclick="location.href = cancelRedirectUrl; return false;"><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:CustomApprovalWorkflows,button_workflowform_cancel%>" /></button></td>
    </tr>
  </table>
<div id="divCompletionStatus" style="display:none">
    <asp:Literal runat="server" ID="litCompletionStatus" Text="<%$Resources:CustomApprovalWorkflows,workflow_approvaltaskstatus_completed%>"></asp:Literal>
    </div>
<div id="divTaskTitle" style="display:none">
    <asp:Literal runat="server" ID="litTaskTitle" Text="<%$Resources:CustomApprovalWorkflows,workflow_ApprovalTaskDefaultTitle%>"></asp:Literal>
</div>
<div id="divTaskAssignedSubject" style="display:none">
    <asp:Literal runat="server" ID="litTaskAssignedSubject" Text="<%$Resources:CustomApprovalWorkflows,workflow_ApprovalTaskAssignedEmailSubject%>"></asp:Literal>
</div>
<div id="divTaskCancelledSubject" style="display:none">
    <asp:Literal runat="server" ID="litTaskCancelledSubject" Text="<%$Resources:CustomApprovalWorkflows,workflow_ApprovalTaskCancelledEmailSubject%>"></asp:Literal>
</div>
<div id="divTaskOverdueSubject" style="display:none">
    <asp:Literal runat="server" ID="litTaskOverdueSubject" Text="<%$Resources:CustomApprovalWorkflows,workflow_ApprovalTaskOverdueEmailSubject%>"></asp:Literal>
</div>
        <script type="text/javascript">
            var errorMessage = "An error occured when saving the workflow association.";
            var dlg = null;
            var complete = 0;
            var CID_O15WorkflowTask = "0x0108003365C4474CAE8C42BCE396314E88E51F";

            // ---------- Entry point from Save button click ----------
            function runAssocWFTask() {
                // Resolve users in user fields before running validation
                var peoplePickerDict = SPClientPeoplePicker.SPClientPeoplePickerDict;
                for (var pickerId in peoplePickerDict) {
                    peoplePickerDict[pickerId].AddUnresolvedUserFromEditor(false);
                    peoplePickerDict[pickerId].ResolveAllUsers();
                }

                var form = SPClientForms.ClientFormManager.GetClientForm('Workflow');
                if (form.SubmitClientForm()) {
                    // Validation errors, don't submit the form yet. 
                    return false;
                }

                var button = document.getElementById("Save");
                var cb = new SP.Utilities.CommandBlock(null, associateWF, assocComplete);
                var task = new SP.Utilities.Task(button, SP.Utilities.Task.TaskType.autoCancel, 0, cb, inProgressDialog, null, null);
                task.start();

                return false;
            }

            function assocComplete() {
                if (dlg != null) {
                    dlg.close();
                }
            }

            function inProgressDialog() {
                if (dlg == null) {
                    

                    dlg = SP.UI.ModalDialog.showWaitScreenWithNoClose("associating workflow", "Approval workflow association", null, null);
                }
            }

            // ---------- Save workflow association ----------
            function associateWF(state, pauseFunction) {
                if (complete != 0)
                    return complete;

                var historyListId = "";
                var taskListId = "";
                var metadata = new Object();

                // Get form input values and set workflow in-argument values
                var html = $("#ctl00_PlaceHolderMain_spApprovers_upLevelDiv");
                var approvers = $("#divEntityData", html).attr("key");
                if (approvers && approvers.length > 0) {
                    metadata['Approvers'] = approvers;
                }
                else {
                    alert("Approvers field cannot be empty");
                    return;
                }

                var intDurationDays = document.getElementById("txtDurationDays").value;
                if (intDurationDays) {
                    var intValue = parseInt(intDurationDays);
                    if (intValue && intValue > 0) {
                        metadata['Duration'] = intValue;
                    }
                }

                var boolFirstApproval = document.getElementById("chkFirstApproval");
                if (boolFirstApproval) {
                    metadata['EndonFirstApproval'] = boolFirstApproval.checked;
                }

                var boolContentApproval = document.getElementById("chkContentApproval");
                if (boolContentApproval) {
                    metadata['EnableContentApproval'] = boolContentApproval.checked;
                }

                var strTaskTitle = document.getElementById("txtTaskTitle").value;
                if (strTaskTitle && strTaskTitle.length > 0) {
                    metadata['TaskTitle'] = strTaskTitle;
                }

                var strTaskAssignEmailSubject = document.getElementById("txtTaskAssignmentEmailSubject").value;
                if (strTaskAssignEmailSubject && strTaskAssignEmailSubject.length > 0) {
                    metadata['TaskAssignmentEmailSubject'] = strTaskAssignEmailSubject;
                }

                var strTaskAssignEmailBody = document.getElementById("txtTaskAssignmentEmailBody").value;
                if (strTaskAssignEmailBody && strTaskAssignEmailBody.length > 0) {
                    metadata['TaskAssignmentEmailBodyHtml'] = strTaskAssignEmailBody;
                }

                var strTaskCancelEmailSubject = document.getElementById("txtTaskCancelEmailSubject").value;
                if (strTaskCancelEmailSubject && strTaskCancelEmailSubject.length > 0) {
                    metadata['TaskCancellationEmailSubject'] = strTaskCancelEmailSubject;
                }

                var strTaskCancelEmailBody = document.getElementById("txtTaskCancelEmailBody").value;
                if (strTaskCancelEmailBody && strTaskCancelEmailBody.length > 0) {
                    metadata['TaskCancellationEmailBodyHtml'] = strTaskCancelEmailBody;
                }

                var strTaskOverdueEmailSubject = document.getElementById("txtTaskOverdueEmailSubject").value;
                if (strTaskOverdueEmailSubject && strTaskOverdueEmailSubject.length > 0) {
                    metadata['TaskOverdueEmailSubject'] = strTaskOverdueEmailSubject;
                }

                var strTaskOverdueEmailBody = document.getElementById("txtTaskOverdueEmailBody").value;
                if (strTaskOverdueEmailBody && strTaskOverdueEmailBody.length > 0) {
                    metadata['TaskOverdueEmailBodyHtml'] = strTaskOverdueEmailBody;
                }

                var strCompletionStatus = document.getElementById("divCompletionStatus").innerText;
                if (strCompletionStatus && strCompletionStatus.length > 0) {
                    metadata['TaskCompletionStatus'] = strCompletionStatus;
                }

                var context = SP.ClientContext.get_current();
                var web = context.get_web();
                var wfManager = SP.WorkflowServices.WorkflowServicesManager.newObject(context, web);

                var newHistoryList = null;
                var taskList = null;

                // Set history list id. If new list, create new first.
                if (historyListName) {
                    if (historyListName[0] == 'z') {
                        // Need to create new history list for the association
                        historyListName = historyListName.substring(1); //remove the 'z'
                        var listCreationInfo = new SP.ListCreationInformation();
                        listCreationInfo.set_templateType(SP.ListTemplateType.workflowHistory);
                        listCreationInfo.set_title(historyListName);
                        listCreationInfo.set_description(historyListDescription);
                        newHistoryList = web.get_lists().add(listCreationInfo);
                        context.load(newHistoryList, 'Id');
                    }
                    else {
                        // Get history list 
                        historyListId = historyListName;
                    }
                }

                // Set task list id. If new list, create new first. 
                if (taskListName) {
                    if (taskListName[0] == 'z') {
                        // Need to create new task list for the association
                        taskListName = taskListName.substring(1); 
                        var listCreationInfo = new SP.ListCreationInformation();
                        listCreationInfo.set_templateType(SP.ListTemplateType.tasksWithTimelineAndHierarchy);
                        listCreationInfo.set_title(taskListName);
                        listCreationInfo.set_description(taskListDescription);
                        taskList = web.get_lists().add(listCreationInfo);
                    }
                    else {
                        var listCollection = web.get_lists();
                        taskList = listCollection.getById(taskListName);
                    }
                    context.load(taskList, 'Id');
                    var contentTypeCollection = web.get_availableContentTypes();
                    var contentType = contentTypeCollection.getById(CID_O15WorkflowTask);
                    context.load(contentType, 'Name');
                    var taskListContentTypeCollection = taskList.get_contentTypes();
                    context.load(taskListContentTypeCollection, 'Include(Name)');
                }

                //  Check if task list contains the OOTB SharePoint 2013 Workflow Task content type

                context.executeQueryAsync(function (sender, args) {

                    complete = 0.66;

                    if (newHistoryList != null) {
                        historyListId = newHistoryList.get_id().toString();
                    }
                    taskListId = taskList.get_id().toString();

                    metadata["HistoryListId"] = historyListId;
                    metadata["TaskListId"] = taskListId;

                    var eventTypes = new Array();
                    if (autoStartCreate) {
                        eventTypes.push("ItemAdded");
                    }
                    if (autoStartChange) {
                        eventTypes.push("ItemUpdated");
                    }
                    if (allowManual) {
                        eventTypes.push("WorkflowStart");
                    }

                    // If workflow association exists, then we will update its subscription information. Otherwise, it's a new association, and we will add the new subscription.

                    if (subscriptionId != null && subscriptionId != "") {
                        // Updating an existing subscription
                        var subscription = wfManager.getWorkflowSubscriptionService().getSubscription(subscriptionId);
                        subscription.set_name(workflowName);
                        subscription.set_eventTypes(eventTypes);
                        for (var key in metadata) {
                            subscription.setProperty(key, metadata[key]);
                        }
                        // Publish
                        wfManager.getWorkflowSubscriptionService().publishSubscription(subscription);
                        context.executeQueryAsync(
                            function (sender, args) {
                                // Success
                                complete = 1;
                                location.href = redirectUrl;
                            },
                            function (sender, args) {
                                // Error occured
                                complete = 1;
                                alert(errorMessage + " " + args.get_message());
                            }
                        );
                    }
                    else {
                        // Add new workflow association
                        var newSubscription = SP.WorkflowServices.WorkflowSubscription.newObject(context);
                        newSubscription.set_definitionId(definitionId);
                        newSubscription.set_eventSourceId(eventSourceId);
                        newSubscription.set_eventTypes(eventTypes);
                        newSubscription.set_name(workflowName);
                        for (var key in metadata) {
                            newSubscription.setProperty(key, metadata[key]);
                        }
                        // Publish
                        wfManager.getWorkflowSubscriptionService().publishSubscriptionForList(newSubscription, listId);

                        context.executeQueryAsync(
                            function (sender, args) {
                                // Success
                                complete = 1;
                                location.href = redirectUrl;
                            },
                            function (sender, args) {
                                // Error occured
                                complete = 1;
                                alert(errorMessage + " " + args.get_message());
                            }
                        );
                    }
                },
                function (sender, args) {
                    // Error occured
                    complete = 1;
                    alert(errorMessage + " " + args.get_message());
                })

                complete = 0.33;
                return complete;
            }

            function setHeader() {
                var headerLabel = document.getElementById('wfHeader');
                if (headerLabel != null)
                    headerLabel.innerText = headerString;

                loadExistingSubscriptionInfo();
            }

            function loadExistingSubscriptionInfo() {
                if (subscriptionId != null && subscriptionId != "") {
                    var context = SP.ClientContext.get_current();
                    var web = context.get_web();
                    var wfManager = SP.WorkflowServices.WorkflowServicesManager.newObject(context, web);

                    var subscription = wfManager.getWorkflowSubscriptionService().getSubscription(subscriptionId);

                    context.load(subscription, 'PropertyDefinitions');
                    context.executeQueryAsync(
                        function (sender, args) {
                            var params = new Object();
                            //Find initiation data to be passed to workflow.
                            var properties = subscription.get_propertyDefinitions();
                            if (properties != null && properties != 'undefined' && properties != "") {
                                if (properties.Approvers != null) {
                                    var div = $("#ctl00_PlaceHolderMain_spApprovers_upLevelDiv");
                                    if (div != null) {
                                        div[0].innerText = properties.Approvers.toString();
                                    }
                                    var txtBox = $("#ctl00_PlaceHolderMain_spApprovers_downlevelTextBox");
                                    if (txtBox != null) {
                                        txtBox.innerText = properties.Approvers.toString();
                                    }
                                }

                                if (properties.Duration != null) {
                                    document.getElementById("txtDurationDays").value = properties.Duration.toString();
                                }

                                if (properties.EndonFirstApproval != null) {
                                    var boolFirstApproval = document.getElementById("chkFirstApproval");
                                    if (boolFirstApproval) {
                                        boolFirstApproval.checked = properties.EndonFirstApproval.toString() == "true" || properties.EndonFirstApproval == "1";
                                    }
                                }

                                if (properties.EnableContentApproval != null) {
                                    var boolContentApproval = document.getElementById("chkContentApproval");
                                    if (boolContentApproval) {
                                        boolContentApproval.checked = properties.EnableContentApproval.toString() == "true" || properties.EndonFirstApproval == "1";
                                    }
                                }

                                if (properties.TaskTitle != null) {
                                    document.getElementById("txtTaskTitle").value = properties.TaskTitle.toString();
                                }

                                if (properties.TaskAssignmentEmailSubject != null) {
                                    document.getElementById("txtTaskAssignmentEmailSubject").value = properties.TaskAssignmentEmailSubject.toString();
                                }

                                if (properties.TaskAssignmentEmailBodyHtml != null) {
                                    document.getElementById("txtTaskAssignmentEmailBody").value = properties.TaskAssignmentEmailBodyHtml.toString();
                                }

                                if (properties.TaskCancellationEmailSubject != null) {
                                    document.getElementById("txtTaskCancelEmailSubject").value = properties.TaskCancellationEmailSubject.toString();
                                }

                                if (properties.TaskCancellationEmailBodyHtml != null) {
                                    document.getElementById("txtTaskCancelEmailBody").value = properties.TaskCancellationEmailBodyHtml.toString();
                                }

                                if (properties.TaskOverdueEmailSubject != null) {
                                    document.getElementById("txtTaskOverdueEmailSubject").value = properties.TaskOverdueEmailSubject.toString();
                                }

                                if (properties.TaskOverdueEmailBodyHtml != null) {
                                    document.getElementById("txtTaskOverdueEmailBody").value = properties.TaskOverdueEmailBodyHtml.toString();
                                }
                            }
                        });
                }
                else {
                    var strTaskTitle = document.getElementById("divTaskTitle").innerText;
                    var strTaskAssignedSubject = document.getElementById("divTaskAssignedSubject").innerText;
                    var strTaskCancelledSubject = document.getElementById("divTaskCancelledSubject").innerText;
                    var strTaskOverdueSubject = document.getElementById("divTaskOverdueSubject").innerText;

                    if (strTaskTitle && strTaskTitle.length > 0) {
                        document.getElementById("txtTaskTitle").value = strTaskTitle;
                    }

                    if (strTaskAssignedSubject && strTaskAssignedSubject.length > 0) {
                        document.getElementById("txtTaskAssignmentEmailSubject").value = strTaskAssignedSubject;
                    }
                    
                    if (strTaskCancelledSubject && strTaskCancelledSubject.length > 0) {
                        document.getElementById("txtTaskCancelEmailSubject").value = strTaskCancelledSubject;
                    }
                    
                    if (strTaskOverdueSubject && strTaskOverdueSubject.length > 0) {
                        document.getElementById("txtTaskOverdueEmailSubject").value = strTaskOverdueSubject;
                    }
                }
            }

            Sys.Application.add_load(setHeader);
    </script>
</div>
</asp:Content>