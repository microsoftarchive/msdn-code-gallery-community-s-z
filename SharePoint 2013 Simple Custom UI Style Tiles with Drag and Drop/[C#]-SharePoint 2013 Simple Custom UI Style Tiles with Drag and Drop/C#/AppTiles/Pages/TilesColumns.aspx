<%@ Page language="C#" MasterPageFile="~masterurl/default.master" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
     
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>

</asp:Content>

<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <div style="padding: 20px;">
        How many columns for Live Tiles?
        <input type="text" id="txtColumn" name="_txtColumn" value=" " />
        <input type="button" id="btColumn" name="_btColumn" onclick="UpdatePropertyBag($('#txtColumn').val())" value="OK" />
    </div>
    <script type="text/javascript">
        var webProps;
        $(document).ready(function () {
            SP.SOD.executeFunc('sp.js', 'SP.ClientContext', GetProperties());
        });
        function GetProperties() {
           
            var clientContext = SP.ClientContext.get_current();
            var oWebsite = clientContext.get_web();
            clientContext.load(oWebsite);
            webProps = oWebsite.get_allProperties();
            clientContext.load(webProps, 'vti_TilesColumns');
            clientContext.executeQueryAsync(successHandler, errorHandler);
        }
        
        function successHandler() {

            $('#txtColumn').val(webProps.get_item('vti_TilesColumns'));
            
        }
        function success() {
            
            SP.UI.Notify.addNotification('Update!', false);
            window.frameElement.cancelPopUp();
        }
        function Closewindow() {
            SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, 'Ok clicked');

        }

        function errorHandler() {
            alert('Error!');
            SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked');
            return false;
        }
        function UpdatePropertyBag(ColValue) {
            var clientContext = SP.ClientContext.get_current();
            var oWebsite = clientContext.get_web();
            var webProps = oWebsite.get_allProperties();
            webProps.set_item('vti_TilesColumns', ColValue);
            oWebsite.update();
            clientContext.executeQueryAsync(success, errorHandler);
        }
    </script>
</asp:Content>
