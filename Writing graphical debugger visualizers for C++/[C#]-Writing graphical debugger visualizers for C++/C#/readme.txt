Vector Visualizer Sample

Overview
  This sample project demonstrates how to create a simple native visualizer for std::vector<int> objects.
  Note that this sample code is provided to illustrate a concept and should not be used in applications or Web sites, as 
  it may not illustrate the safest coding practices.

  The following sections briefly explains the steps involved in creating such a visualizer.

1. Create project based on Visual Studio Package template
  The visualizer code must be contained in a package which will be loaded by the debugger when needed. You can create
  your visualizer project based on the "Visual Studio Package" template to help with this.

2. Add NativeVisualizer asset
  To register the visualizer with the debugger a NativeVisualizer asset (an xml file) needs to be added to the project.
  This file should also be included in the extension manifest and the VSIX. Debugger reads the entries in this file
  to match types viewed in the debugger with the registered UI visualizers. 

  A UI visualizer is identified by a service Id - Id pair. Service Id is the GUID of the service exposed by the visualizer
  package, Id is a unique identifier that can be used to differentiate visualizers if a service provides more than one visualizer.
  MenuName attribute is what the users see as the name of the visualizer when they list the visualizers for an object.
  Each type defined in the native visualizer file must explicitly list the UI visualizers that can display them. 

  VectorVisualizer.xml file in this project is a NativeVisualizer asset. The extension manifest also contains an <Asset> entry for this file.
	
2. Create a service
  The created package must provide a service with the GUID specified in the NativeVisualizer asset file and must be
  added to the service container. The relevant code that does this is in VectorVisualizerPackage.cs.

3. Implement IVsCppDebugUIVisualizer
  The service object exposed by the package must implement IVsCppDebugUIVisualizer interface which will be called by the debugger when
  user requests the visualizer on an object. VectorVisualizerService.cs contains the implementation of that interface.




