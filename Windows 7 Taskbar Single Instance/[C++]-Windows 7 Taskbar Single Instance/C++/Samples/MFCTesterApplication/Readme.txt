This sample application demostrates using the Single Instance recipe library.

* The first instance of the application will open a Win32 named pipe and act as a server.
* Subsequest instances will connect to the named pipe and will pass their command-line arguments
  to the first instance, and will then quit.
* A user callback function in the first application instance will be invoked with those arguments.

Instructions:
* Compile & Run the sample on a Windows 7 machine.
* Right-click the taskbar button of the application, and choose a desired status from the jump-list.
  Watch as the application's state changes.
  