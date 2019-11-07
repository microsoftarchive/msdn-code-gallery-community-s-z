@Echo Off
@Echo Building HOL Exercise 1 - Begin
msbuild ".\Exercise 1\Begin\AtmStateMachine.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

@Echo Building HOL Exercise 1 - End
msbuild ".\Exercise 1\End\AtmStateMachine-Ex1End.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

@Echo Building HOL Exercise 2 - Begin
msbuild ".\Exercise 2\Begin\AtmStateMachine-Ex2Begin.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

@Echo Building HOL Exercise 2 - End
msbuild ".\Exercise 2\End\AtmStateMachine-Ex2End.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

@Echo Building HOL Exercise 3 - Begin
msbuild ".\Exercise 3\Begin\AtmStateMachine-Ex3Begin.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

@Echo Building HOL Exercise 3 - End
msbuild ".\Exercise 3\End\AtmStateMachine-Ex3End.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

@Echo Building HOL Exercise 4 - Begin
msbuild ".\Exercise 4\Begin\AtmStateMachine-Ex4Begin.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

@Echo Building HOL Exercise 4 - End
msbuild ".\Exercise 4\End\AtmStateMachine-Ex4End.sln" /p:Configuration=Debug /t:Rebuild
if ErrorLevel 1 goto :EOF

