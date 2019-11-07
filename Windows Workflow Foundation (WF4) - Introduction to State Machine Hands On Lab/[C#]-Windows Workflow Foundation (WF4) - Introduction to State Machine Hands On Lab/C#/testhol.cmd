@Echo Off
@Echo Testing HOL Exercise 1 - Begin
Echo - All tests should fail for Begin exercise
mstest /testmetadata:".\Exercise 1\Begin\AtmStateMachine.vsmdi" /testlist:"Exercise 1"
if not ErrorLevel 1 goto :EOF

@Echo Testing HOL Exercise 1 - End
mstest /testmetadata:".\Exercise 1\End\AtmStateMachine.vsmdi" /testlist:"Exercise 1"
if ErrorLevel 1 goto :EOF

@Echo Testing HOL Exercise 2 - Begin
mstest /testmetadata:".\Exercise 2\Begin\AtmStateMachine.vsmdi" /testlist:"Exercise 1"
if ErrorLevel 1 goto :EOF

@Echo Testing HOL Exercise 2 - End
mstest /testmetadata:".\Exercise 2\End\AtmStateMachine.vsmdi" /testlist:"Exercise 1" /testlist:"Exercise 2"
if ErrorLevel 1 goto :EOF

@Echo Testing HOL Exercise 3 - Begin
mstest /testmetadata:".\Exercise 3\Begin\AtmStateMachine.vsmdi" /testlist:"Exercise 1" /testlist:"Exercise 2"
if ErrorLevel 1 goto :EOF

@Echo Testing HOL Exercise 3 - End
mstest /testmetadata:".\Exercise 3\End\AtmStateMachine.vsmdi" /testlist:"Exercise 1" /testlist:"Exercise 2" /testlist:"Exercise 3"
if ErrorLevel 1 goto :EOF

@Echo Testing HOL Exercise 4 - Begin
mstest /testmetadata:".\Exercise 4\Begin\AtmStateMachine.vsmdi" /testlist:"Exercise 1" /testlist:"Exercise 2" /testlist:"Exercise 3"
if ErrorLevel 1 goto :EOF

@Echo Testing HOL Exercise 4 - End
mstest /testmetadata:".\Exercise 4\End\AtmStateMachine.vsmdi" /testlist:"Exercise 1" /testlist:"Exercise 2" /testlist:"Exercise 3" /testlist:"Exercise 4"
if ErrorLevel 1 goto :EOF

