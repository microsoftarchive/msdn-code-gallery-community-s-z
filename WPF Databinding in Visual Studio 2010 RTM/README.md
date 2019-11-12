# WPF Databinding in Visual Studio 2010 RTM
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- WPF
- Entity Framework
## Topics
- Data Binding
## Updated
- 02/17/2011
## Description

<table border="0" cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td>
<p><strong>Remarque&nbsp;:&nbsp;</strong><em>cet exemple cible Microsoft .NET Framework&nbsp;3.5.</em></p>
</td>
</tr>
</tbody>
</table>
<p>Cet exemple Windows Presentation Framework utilise un Entity Data Model pour connecter un syst&egrave;me OMS (Order Management System) simple dans une base de donn&eacute;es SQL Server. L'exemple contient plusieurs formulaires WPF, illustrant chacun diverses
 fonctionnalit&eacute;s de liaison de donn&eacute;es. Il comporte les &eacute;l&eacute;ments suivants&nbsp;:</p>
<ul>
<li>Un exemple de base de donn&eacute;es SQL Server&nbsp;: OMS. Le script SQL inclus dans l'exemple permet de cr&eacute;er et de remplir la base de donn&eacute;es.
</li><li>Une couche d'acc&egrave;s aux donn&eacute;es. Ce projet de biblioth&egrave;que de classes comporte un Entity Data Model (EDM) qui est mapp&eacute; aux tables de la base de donn&eacute;es. Une logique de validation est &eacute;galement incluse.
</li><li>Le projet d'application WPF. Il utilise la couche d'acc&egrave;s aux donn&eacute;es et affiche les donn&eacute;es. Le projet contient plusieurs formulaires qui illustrent diff&eacute;rents aspects des formulaires WPF li&eacute;s aux donn&eacute;es, notamment&nbsp;:
</li></ul>
<p>o&nbsp;&nbsp;&nbsp;&nbsp;Liste simple d'&eacute;l&eacute;ments</p>
<p>o&nbsp;&nbsp;&nbsp;&nbsp;DataGrid</p>
<p>o&nbsp;&nbsp;&nbsp;&nbsp;Mode D&eacute;tails avec boutons de navigation</p>
<p>o&nbsp;&nbsp;&nbsp;&nbsp;Ma&icirc;tre/d&eacute;tails</p>
<p>o&nbsp;&nbsp;&nbsp;&nbsp;Tables de correspondance</p>
<p>o&nbsp;&nbsp;&nbsp;&nbsp;Mise en forme et validation</p>
<p>&nbsp;</p>
<h3>Pour ex&eacute;cuter cet exemple</h3>
<div>
<p>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ouvrez l'exemple de projet.</p>
<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sous le n&oelig;ud Solution, d&eacute;veloppez le dossier&nbsp;<em>&Eacute;l&eacute;ments de solution</em>, puis ouvrez&nbsp;<em>CreateDatabaseOMS.sql</em>.</p>
<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cliquez avec le bouton droit sur l'&eacute;diteur TSQL, puis s&eacute;lectionnez&nbsp;<strong>Ex&eacute;cuter SQL</strong>&nbsp;dans le menu contextuel qui s'affiche.</p>
<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Lorsque vous &ecirc;tes invit&eacute; &agrave; s&eacute;lectionner une connexion, choisissez ou cr&eacute;ez une connexion &agrave; votre serveur SQL Server.</p>
<p>5.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fermez l'&eacute;diteur TSQL</p>
<p>6.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appuyez sur F5 pour g&eacute;n&eacute;rer et ex&eacute;cuter l'exemple</p>
</div>
<h1>Configuration requise</h1>
<div>
<ul>
<li>Microsoft SQL Server&nbsp;2005 ou version ult&eacute;rieure </li></ul>
</div>
