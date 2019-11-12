# Utilizzo della Classe Mail per l'invio di messaggi di posta elettronica
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- VB.Net
- .NET Framework 4.0
- Windows General
## Topics
- Send Email
- Windows Forms
- Windows
## Updated
- 10/09/2011
## Description

<h1>Introduction</h1>
<div><em><span class="hps" title="Fai clic per visualizzare le traduzioni alternative">This application example</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">uses the class</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Mail</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">this</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">namespace</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.aspx" target="_blank" title="Auto generated link to System.Net">System.Net</a></span><span title="Fai clic per visualizzare le traduzioni alternative">.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">This</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">example describes</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">how to implement</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">all its methods</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">for sending</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">emails</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">For</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">more information</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">on</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Class</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Mail will</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">refer</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to this&nbsp;<a href="http://msdn.microsoft.com/it-it/library/system.net.mail.aspx">link</a></span><span title="Fai clic per visualizzare le traduzioni alternative">.</span></em></div>
<h1><span>Building the Sample</span></h1>
<div><em><span class="hps" title="Fai clic per visualizzare le traduzioni alternative">In order to</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">test the example</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">on your</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">PC</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">you need to have</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">installed</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">NetFramework4.0</span></em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div><em><span class="hps" title="Fai clic per visualizzare le traduzioni alternative">The</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Mail.aspx" target="_blank" title="Auto generated link to System.Net.Mail">System.Net.Mail</a> class</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">contains</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">within it</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the necessary classes</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to</span>
<span class="hps x_x_atn" title="Fai clic per visualizzare le traduzioni alternative">
send e-</span><span title="Fai clic per visualizzare le traduzioni alternative">mail</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and through</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the SMTP server</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">which receives</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">incoming</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">mail message</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and then</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">later</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">send the message</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to that recipient.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">There is</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">also the class of</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">attachment</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">with which</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">you</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">can include</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">e-mail</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">attachments.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">The example of</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">more than</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">ability to send</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">e-mail messages</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">allows you to send</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">attachments</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">together</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and moreover</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">can store</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">all email addresses</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">within a variable</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">in the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">setting</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of type</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">StringCollection</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">System.Collection.Specializated</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">belong</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to the namespace</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span><br>
<br>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Start the application and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">specify</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">your</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">e-mail address</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and password</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">for identification</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and authentication</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to your</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">mail server</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">must</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">also specify the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">SMTP</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">mail</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">server</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">using</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the example</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">SMTP.live.com</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">For</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">other servers</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">need</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to be aware</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of the server name</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and port</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">for SMTP transactions</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span><br>
<br>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">After that, the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">mail recipients</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">or</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">which to send the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">email,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">then the object</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">that</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the message title</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">will show</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">that the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">deatinatario</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">in</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">their</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">mail box</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and the body</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">message, that</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">when</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the recipient</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">opens</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the message</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">visualzzer&agrave;</span><span title="Fai clic per visualizzare le traduzioni alternative">-mail</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">received</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span><br>
<br>
&nbsp; <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
It</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
can send</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
the message</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
(Cc</span><span title="Fai clic per visualizzare le traduzioni alternative">) with</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the appropriate</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">text box</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and attachments.</span><br>
<br>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">There</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">will also be</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">pilsanti</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">who will run the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Cc</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and To</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">DropDown</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Combobox</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">for</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">selection</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">e-mail</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Add</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a button</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to the contacts</span><span title="Fai clic per visualizzare le traduzioni alternative">, which</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">will add</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the new</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">email address</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">in the settings of</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the variable</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to make it</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">available to the user</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Remove</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">contacts</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and a button</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">on the contrary</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">effetture&agrave;</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the cancellation</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">contents of the variable</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">in application settings.</span><br>
<br>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Here is</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the code</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">in VB.NET</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span></em></div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__com">'dll&nbsp;.netFramework</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Net.Mail&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.IO&nbsp;
&nbsp;
<span class="visualBasic__com">'Classe&nbsp;FrmEmail</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;FrmEmail&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Istanzio&nbsp;una&nbsp;variabile&nbsp;per&nbsp;la&nbsp;spedizione&nbsp;dei&nbsp;messaggi&nbsp;di&nbsp;posta&nbsp;elettronica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myMessage&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;MailMessage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Istanzio&nbsp;una&nbsp;variabile&nbsp;per&nbsp;il&nbsp;protocollo&nbsp;SMTP</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myClient&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SmtpClient()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Load&nbsp;del&nbsp;Form&nbsp;FrmEmail</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;FrmEmail_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Se&nbsp;la&nbsp;variabile&nbsp;d'impostazione&nbsp;address&nbsp;none&nbsp;nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.address&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;l'iterazione&nbsp;e&nbsp;popolo&nbsp;le&nbsp;combobox&nbsp;cbxTo&nbsp;e&nbsp;cbxCc&nbsp;con&nbsp;gli&nbsp;indirizzi&nbsp;di&nbsp;posta&nbsp;memorizzati</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;myAddress&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.address&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Aggiungo&nbsp;i&nbsp;relativi&nbsp;indirizzi&nbsp;di&nbsp;posta&nbsp;mediante&nbsp;metodo&nbsp;Add&nbsp;delle&nbsp;combobox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.cbxTo.Items.Add(myAddress)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.cbxCc.Items.Add(myAddress)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Iterazione&nbsp;successiva</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Altrimenti</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Creo&nbsp;una&nbsp;nuova&nbsp;variabile&nbsp;StringCollection&nbsp;address&nbsp;nelle&nbsp;impostazioni&nbsp;dell'applicazione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.address&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;System.Collections.Specialized.StringCollection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Effettuo&nbsp;il&nbsp;salvataggio&nbsp;delle&nbsp;impostazioni&nbsp;dell'applicazione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.Save()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;pulsnate&nbsp;btnInvia</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnInvia_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnInvia.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;il&nbsp;valore&nbsp;di&nbsp;txtTo&nbsp;termina&nbsp;con&nbsp;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;txtTo.Text.EndsWith(<span class="visualBasic__string">&quot;;&quot;</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Elimina&nbsp;l'ultimo&nbsp;carattere&nbsp;;&nbsp;dal&nbsp;contenuto&nbsp;di&nbsp;txtTo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtTo.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.txtTo.Text.TrimEnd(<span class="visualBasic__string">&quot;;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Dichiaro&nbsp;un&nbsp;arraylist&nbsp;per&nbsp;spedizione&nbsp;Email&nbsp;a&nbsp;pi&ugrave;&nbsp;destinatari</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;emailMultiple&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>()&nbsp;=&nbsp;txtTo.Text.Split(<span class="visualBasic__string">&quot;;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Impoosto&nbsp;la&nbsp;porta&nbsp;per&nbsp;le&nbsp;transazioni&nbsp;SMTP</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myClient.Port&nbsp;=&nbsp;<span class="visualBasic__string">&quot;587&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Imposto&nbsp;il&nbsp;nome&nbsp;dell'host&nbsp;utilizzato&nbsp;per&nbsp;le&nbsp;transazioni&nbsp;SMTP</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myClient.Host&nbsp;=&nbsp;<span class="visualBasic__string">&quot;smtp.live.com&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Disabilito&nbsp;le&nbsp;credenziali&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myClient.UseDefaultCredentials&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Imposto&nbsp;le&nbsp;credenziali&nbsp;per&nbsp;l'autenticazione&nbsp;del&nbsp;Mittente</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myClient.Credentials&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.NetworkCredential.aspx" target="_blank" title="Auto generated link to System.Net.NetworkCredential">System.Net.NetworkCredential</a>(txtFrom.Text,&nbsp;txtPassword.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Imposto&nbsp;l'indirizzo&nbsp;del&nbsp;Mittente</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMessage.From&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;MailAddress(txtFrom.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Specifico&nbsp;l'oggetto&nbsp;del&nbsp;messaggio&nbsp;di&nbsp;posta</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMessage.Subject&nbsp;=&nbsp;txtOggetto.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;la&nbsp;codifica&nbsp;del&nbsp;contenuto&nbsp;del&nbsp;messaggio</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMessage.BodyEncoding&nbsp;=&nbsp;System.Text.Encoding.UTF8&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Qui&nbsp;si&nbsp;imposta&nbsp;il&nbsp;corpo&nbsp;del&nbsp;messaggio&nbsp;di&nbsp;posta&nbsp;,&nbsp;il&nbsp;contenuto</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMessage.Body&nbsp;=&nbsp;txtBody.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Imposta&nbsp;la&nbsp;crittografia&nbsp;di&nbsp;connessione&nbsp;specificando&nbsp;che&nbsp;la&nbsp;connessione&nbsp;SMTP&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'utilizza&nbsp;SSL</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myClient.EnableSsl&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;l'iterazione&nbsp;per&nbsp;la&nbsp;spedizione&nbsp;di&nbsp;messaggi&nbsp;di&nbsp;posta&nbsp;a&nbsp;pi&ugrave;&nbsp;destinatari</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;destinatari&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;emailMultiple&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Aggiungo&nbsp;l'indirizzo&nbsp;di&nbsp;posta&nbsp;elettronica&nbsp;del&nbsp;o&nbsp;dei&nbsp;destinatari</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMessage.<span class="visualBasic__keyword">To</span>.Add(destinatari)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Invio&nbsp;il&nbsp;messaggio&nbsp;di&nbsp;posta&nbsp;al&nbsp;o&nbsp;ai&nbsp;destinatari</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myClient.Send(myMessage)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Effettuo&nbsp;la&nbsp;cancellazione&nbsp;del&nbsp;destinatario</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMessage.<span class="visualBasic__keyword">To</span>.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Iterazione&nbsp;successiva</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'In&nbsp;caso&nbsp;di&nbsp;eccezzione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Visualizza&nbsp;messaggio&nbsp;a&nbsp;utente</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnAggiungi</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnAggiungi_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnAggiungi.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;il&nbsp;TextBox&nbsp;txtCc&nbsp;contiene&nbsp;caratteri</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;<span class="visualBasic__keyword">Me</span>.txtCc.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;l'utente&nbsp;decide&nbsp;di&nbsp;inserire&nbsp;un&nbsp;nuovo&nbsp;contatto</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Aggiungere&nbsp;il&nbsp;contatto&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtCc.Text,&nbsp;Application.ProductName.ToString,&nbsp;MessageBoxButtons.YesNo)&nbsp;=&nbsp;DialogResult.Yes&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Aggiungo&nbsp;alla&nbsp;variabile&nbsp;di&nbsp;impostazione&nbsp;address&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtCc</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.address.Add(<span class="visualBasic__keyword">Me</span>.txtCc.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Effettuo&nbsp;il&nbsp;salvataggio&nbsp;delle&nbsp;impostazioni&nbsp;dell'applicazione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.Save()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Altrimrnti</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;il&nbsp;TextBox&nbsp;txtTo&nbsp;contiene&nbsp;caratteri</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;<span class="visualBasic__keyword">Me</span>.txtTo.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;l'utente&nbsp;decide&nbsp;di&nbsp;inserire&nbsp;un&nbsp;nuovo&nbsp;contatto</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Aggiungere&nbsp;il&nbsp;contatto&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtTo.Text,&nbsp;Application.ProductName.ToString,&nbsp;MessageBoxButtons.YesNo)&nbsp;=&nbsp;DialogResult.Yes&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Aggiungo&nbsp;alla&nbsp;variabile&nbsp;di&nbsp;impostazione&nbsp;address&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtTo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.address.Add(<span class="visualBasic__keyword">Me</span>.txtTo.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Effettuo&nbsp;il&nbsp;salvataggio&nbsp;delle&nbsp;impostazioni&nbsp;dell'applicazione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.Save()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnEliminaContatti</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnEliminaContatti_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnEliminaContatti.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;l'utente&nbsp;decide&nbsp;di&nbsp;rimuovere&nbsp;tutti&nbsp;i&nbsp;contatti&nbsp;di&nbsp;posta</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Si&nbsp;desidera&nbsp;canlellare&nbsp;tutti&nbsp;i&nbsp;contatti?&quot;</span>,&nbsp;Application.ProductName.ToString,&nbsp;MessageBoxButtons.YesNo)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Rimuovo&nbsp;dlla&nbsp;variabile&nbsp;di&nbsp;impostazione&nbsp;address&nbsp;tutti&nbsp;i&nbsp;contatti&nbsp;memorizzati</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.address.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Effettuo&nbsp;il&nbsp;salvataggio&nbsp;delle&nbsp;impostazioni&nbsp;dell'applicazione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.Save()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Rimuovo&nbsp;dalle&nbsp;combobox&nbsp;cbxCc&nbsp;e&nbsp;cbxTo&nbsp;i&nbsp;contatti</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbxCc.Items.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbxTo.Items.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Avvvisa&nbsp;l'utente&nbsp;delle&nbsp;rimozione&nbsp;dei&nbsp;contatti</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;I&nbsp;contatti&nbsp;sono&nbsp;stati&nbsp;rimossi&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnCc</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnCc_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnCc.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;il&nbsp;DroppedDwwn&nbsp;del&nbsp;combobox&nbsp;cbxCc</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.cbxCc.DroppedDown&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnTo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnTo_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnTo.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;il&nbsp;DroppedDwwn&nbsp;del&nbsp;combobox&nbsp;cbxTo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.cbxTo.DroppedDown&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnAllega</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnAllega_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnAllega.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;l'utente&nbsp;conferma&nbsp;la&nbsp;scelta&nbsp;dei&nbsp;file&nbsp;da&nbsp;allegare&nbsp;con&nbsp;pulsante&nbsp;ok</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ofd.ShowDialog()&nbsp;=&nbsp;DialogResult.OK&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;l'iterazione&nbsp;della&nbsp;variabile&nbsp;allegat&nbsp;e&nbsp;recupero&nbsp;i&nbsp;file&nbsp;selezionati&nbsp;dall'utente</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;allegat&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;ofd.FileNames&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Visualizzo&nbsp;ad&nbsp;utente&nbsp;l'elenco&nbsp;del&nbsp;o&nbsp;dei&nbsp;file&nbsp;selezionati&nbsp;come&nbsp;allegato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtAllegati.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.FileInfo.aspx" target="_blank" title="Auto generated link to System.IO.FileInfo">System.IO.FileInfo</a>(allegat).Name&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;Attachment</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;allegato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Net.Mail.Attachment(allegat)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Aggiungo&nbsp;l'allegato&nbsp;o&nbsp;gli&nbsp;allegati&nbsp;al&nbsp;messaggio&nbsp;di&nbsp;posta&nbsp;elettronica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myMessage.Attachments.Add(allegato)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Iterazione&nbsp;successiva</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;click&nbsp;del&nbsp;pulsante&nbsp;btnEsci</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnEsci_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnEsci.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Esce&nbsp;e&nbsp;chiude&nbsp;l'applicazione&nbsp;Email</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;SelectedIndexChanged&nbsp;del&nbsp;combobox&nbsp;cbxCc</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;cbxCc_SelectedIndexChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;cbxCc.SelectedIndexChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;il&nbsp;contenuto&nbsp;del&nbsp;combobox&nbsp;cbxCc&nbsp;non&nbsp;e&nbsp;vuoto</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.cbxCc.Text&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Visualizzo&nbsp;su&nbsp;TextBox&nbsp;txtCc&nbsp;il&nbsp;valore&nbsp;attuale&nbsp;di&nbsp;cbxCc</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtCc.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__keyword">Me</span>.cbxCc.Text&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;SelectedIndexChanged&nbsp;del&nbsp;combobox&nbsp;cbxTo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;cbxTo_SelectedIndexChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;cbxTo.SelectedIndexChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Se&nbsp;il&nbsp;contenuto&nbsp;del&nbsp;combobox&nbsp;cbxTo&nbsp;non&nbsp;e&nbsp;vuoto</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.cbxTo.Text&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Visualizzo&nbsp;su&nbsp;TextBox&nbsp;txtTo&nbsp;il&nbsp;valore&nbsp;attuale&nbsp;di&nbsp;cbxTo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtTo.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__keyword">Me</span>.cbxTo.Text&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
<h1>More Information</h1>
<div><em>For more information&nbsp; <a href="http://community.visual-basic.it/carmelolamonica/">
http://community.visual-basic.it/carmelolamonica/</a></em></div>
