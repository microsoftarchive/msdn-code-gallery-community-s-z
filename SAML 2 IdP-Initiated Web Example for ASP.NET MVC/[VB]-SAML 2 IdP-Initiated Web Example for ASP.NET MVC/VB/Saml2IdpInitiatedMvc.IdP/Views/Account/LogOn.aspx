<%@ Page Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Saml2IdpInitiatedMvc.Models.LogOnModel)" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
	Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Log On</h2>
	<p>
		This MVC application will illustrate how to use UltimateSaml for SAML 2.0 in a MVC Application.<br />
				Use the following credentials to login to the Identity Provider:<br /><br />
				User Name: <b>iuser</b><br />
				Password: <b>password</b><br />
				<br />
	</p>

	<%
	Using Html.BeginForm()
	%>
		<%:Html.ValidationSummary(True, "Login was unsuccessful. Please correct the errors and try again.")%>
		<div>
			<fieldset>
				<legend>Account Information</legend>

				<div class="editor-label">
					<%:Html.LabelFor(Function(m) m.UserName)%>
				</div>
				<div class="editor-field">
					<%:Html.TextBoxFor(Function(m) m.UserName)%>
					<%:Html.ValidationMessageFor(Function(m) m.UserName)%>
				</div>

				<div class="editor-label">
					<%:Html.LabelFor(Function(m) m.Password)%>
				</div>
				<div class="editor-field">
					<%:Html.PasswordFor(Function(m) m.Password)%>
					<%:Html.ValidationMessageFor(Function(m) m.Password)%>
				</div>

				<div class="editor-label">
					<%:Html.CheckBoxFor(Function(m) m.RememberMe)%>
					<%:Html.LabelFor(Function(m) m.RememberMe)%>
				</div>

				<p>
					<input type="submit" value="Log On" />
				</p>
			</fieldset>
		</div>
	<%
	End Using
	%>
</asp:Content>