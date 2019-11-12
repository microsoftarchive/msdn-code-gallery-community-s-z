<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="4" cellspacing="4" width="50%" align="center">
        <tr>
            <td align="center">
                <span style="font-family: 'Trebuchet MS'">(Se já possuir uma conta clique aqui =&gt; <a href="Login.aspx">Entrar</a> )
                </span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelEmail" runat="server" Text="Email:" CssClass="BlackText" Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVUserEMail" runat="server" ForeColor="Red" Display="None"
                    ControlToValidate="TextBoxEmail" ErrorMessage="Informe um e-mail válido.">Email</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="REVUserEMail" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxEmail"
                        ErrorMessage="Informe corretamente o E-Mail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Senha:" CssClass="BlackText" 
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                    Display="None" ControlToValidate="TextBoxPassword" ErrorMessage="Informe a senha.">password</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                    ControlToValidate="TextBoxPassword" ErrorMessage="A senha deve ter de 4 a 15 letras (Não são permitidos espaços)"
                    ValidationExpression="\S{4,15}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Confirme a Senha:" CssClass="BlackText"
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxRetypePassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                    Display="None" ControlToValidate="TextBoxRetypePassword" ErrorMessage="Confirme a senha.">Retype password</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CVPassword" runat="server" Display="None" ControlToValidate="TextBoxRetypePassword"
                    ErrorMessage="Re-type Password doesn't match" ControlToCompare="TextBoxPassword"></asp:CompareValidator>
                <asp:RegularExpressionValidator ID="revPWDRange" runat="server" Display="None" ControlToValidate="TextBoxRetypePassword"
                    ErrorMessage="A senha deve ter de 4 até 15 letras (Não use espaços)" ValidationExpression="\S{4,15}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nome:" CssClass="BlackText" 
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxName" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                    Display="None" ControlToValidate="TextBoxName" ErrorMessage="Informe a senha.">Name</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="País:" CssClass="BlackText" 
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxCountry" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Sobre você :" CssClass="BlackText"
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxComment" runat="server" Width="250px" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblPhotoSideHeading" runat="server" CssClass="BlackText" Width="200px">Url 
                da foto:</asp:Label>
                <input id="UploadUserPhoto" type="file" runat="server" width="300px" />
            </td>
        </tr>
        <tr>
            <td height="20px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="ButtonMakeProfile" runat="server" Text="Registrar" OnClick="ButtonMakeProfile_Click"
                    Width="170px" CssClass="flashit" Font-Bold="true" Font-Size="14pt" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Verifique as informações:"
        ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
</asp:Content>
