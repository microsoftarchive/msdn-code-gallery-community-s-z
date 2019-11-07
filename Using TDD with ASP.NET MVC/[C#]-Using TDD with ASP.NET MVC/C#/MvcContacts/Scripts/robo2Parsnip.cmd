cls
set rXD=/XD  obj FREEZE App_data Content Properties Scripts bin Views
set opt=/E /V /NP /R:0 /W:0
set rXF=/XF  *.obj *.chm *.lib *.pch *.pdb *.ibd  *.i  *.ldf  *.pdb *.pst *.tmp  Global.* *.csproj* Web.* *.designer *.edmx Web.config* *.Designer.*
set targetDir=\\riande2\C$\sdTree\Samples\Dev10\Web.Net\MVCTDD\CS
mkdir %targetDir%

robocopy ..\..\MvcContacts.Tests\Controllers %targetDir% %opt% %rXD% %rXF%
robocopy ..\..\MvcContacts.Tests\Models %targetDir% %opt% %rXD% %rXF%

robocopy ..\ %targetDir% %opt% %rXD% %rXF%

REM robocopy ..\Controllers %targetDir% %opt% %rXD% %rXF%
REM robocopy ..\Models %targetDir% %opt% %rXD% %rXF%


pause
