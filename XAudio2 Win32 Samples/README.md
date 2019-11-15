# XAudio2 Win32 Samples
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Win32
- DirectX
- DirectX SDK
## Topics
- Audio and video
## Updated
- 10/12/2015
## Description

<p>The latest version of this sample is hosted on <a href="https://github.com/walbourn/directx-sdk-samples">
GitHub</a>.</p>
<p>This is a collection of the DirectX SDK's original XAudio2 samples updated to use Visual Studio 2012 and the Windows SDK 8.0 without any dependencies on legacy DirectX SDK content. These samples are Win32 desktop DirectX 11.0 applications for Windows 8,
 Windows 7, and Windows Vista Service Pack 2 with the DirectX 11.0 runtime.</p>
<p><strong>This is based on the the legacy DirectX SDK (June 2010) Win32 desktop samples running on Windows Vista, Windows 7, and Windows 8.x. This is not intended for use with Windows Store apps or Windows RT, although the techniques are applicable.</strong></p>
<p><em>For Windows Store samples using XAudio2, see <a href="http://code.msdn.microsoft.com/windowsapps/Basic-Audio-Sample-9a5bb0b7">
XAudio2 audio file playback sample</a> and <a href="http://code.msdn.microsoft.com/windowsapps/XAudio2-Stream-Effect-3f95c8f2">
XAudio2 audio stream effect sample</a></em></p>
<h1>Description</h1>
<h2>XAudio2BasicSound</h2>
<p><img id="101076" src="http://i1.code.msdn.s-msft.com/xaudio2-win32-samples-024b3933/image/file/101076/1/xaudio2basicsound.png" alt="" width="90" height="45"></p>
<p>This sample demonstrates the XAudio2 API by showing you how to initialize the XAudio2 engine, create a mastering voice, and play sample files.</p>
<p>The basic steps taken by the sample are as follows:</p>
<ol>
<li>Initialize the XAudio2 engine by calling the XAudio2Create method. At this point, you can set some basic run-time parameters, and set the notification callback.
</li><li>Create a mastering voice using the IXAudio2::CreateMasteringVoice method. This method controls the final mix format used for all audio processing within the application.
</li><li>Create and play three WAV files.
<ol>
<li>Locate the WAV file to load. </li><li>Read in the WAV file and sample data using a sample helper class. </li><li>Create a source voice based on the format of the loaded WAV file. By default, the source voice will be linked to the first created mastering voice, so you don't need a voice send list.
</li><li>To submit data to the source voice, create an XAUDIO2_BUFFER structure, specifying some play parameters.
</li><li>Submit data to the source voice by means of the function IXAudio2SourceVoice::SubmitSourceBuffer. Note that the sample data is not duplicated by XAudio2, so the pAudioData buffer must remain available for the duration of play.
</li><li>Start playback of the source voice, and perform a simple loop to detect when the playback has completed.
</li><li>Clean up the source voice and associated sample data. </li></ol>
</li><li>Clean up by releasing the XAudio2 engine. </li></ol>
<h2>XAudio2AsyncStream</h2>
<p><img id="101077" src="http://i1.code.msdn.s-msft.com/xaudio2-win32-samples-024b3933/image/file/101077/1/xaudio2basicsound.png" alt="" width="90" height="45"></p>
<p>This sample shows you how to play streaming audio using asynchronous file I/O&nbsp; and the XAudio2 API.</p>
<p><em>Note: Originally called &quot;XAudio2BasicStream&quot; in the legacy DirectX SDK.</em></p>
<p>Playing streaming audio with XAudio2 is very easy. You do not need to create extra threads or maintain tight control of timing. Most of the hard work is already done for you by the file system and XAudio2. The file system handles loading data in the background,
 while XAudio2 manages the audio hardware, and makes sure that it receives a steady stream of data. The XAudio2 system even allows you to queue up data buffers, which eliminates the worry about getting too far ahead of the audio. Your only job is to direct
 this process.</p>
<p>First, you must decide on two important values:</p>
<ol>
<li>The amount of data to request from the file system at a given time. </li><li>The number of data buffers to queue up for playback. </li></ol>
<p>The exact values you use for these variables will depend on two factors: the amount of memory you want to use for streaming, and the load that the rest of your application places on the CPU and storage system. For instance, if other parts of your application
 make heavy use of the hard drive, then less hard drive capacity will be available for streaming audio. In this case, you will need to increase your buffer size or the number of buffers used.</p>
<p>Next, create the XAudio2 engine and a playback voice. The XAudio2BasicSound sample demonstrates how to do this.</p>
<p>After everything is set up, the streaming process is relatively straightforward:</p>
<ol>
<li>Call ReadFile to start an asynchronous read. </li><li>When the read finishes, check the number of buffers in the playback queue. </li><li>As soon as the number of buffers in the playback queue falls below your predetermined maximum value, submit the data you received from the last asynchronous read.
</li><li>Call ReadFile again to start another read. </li></ol>
<p>There are two basic conditions that must be monitored during stream playback: the status of the file reads, and the number of buffers in the playback queue. Of course, it would be inefficient to poll these conditions continuously. There are many different
 ways to notify you when these conditions have changed, so that you can move to the next stage in the streaming process. This sample shows one of the simpler ways to track these conditions.</p>
<p>Note that in order to use asynchronous buffered file I/O, the source data must be aligned to the size of the disk sector. This is the fastest way to read data on&nbsp;Windows platforms. General .WAV files do not meet this requirement, so this sample uses
 XACTBLD to prepare the sample .WAV files into a wave bank. By using the streaming wave bank property, XACTBLD aligns the audio data to meet the alignment requirement for async I/O. The sample parses the wave bank file to determine the format and position of
 the audio data. It then reopens the file for an asynchronous unbuffered read that uses this extracted information. The XACT runtime is not used by this sample. Any custom audio tool can provide audio data to meet the alignment requirement, such as the XWBTOOL
 included in this package.</p>
<h2>XAudio2Sound3D</h2>
<p><img id="101079" src="http://i1.code.msdn.s-msft.com/xaudio2-win32-samples-024b3933/image/file/101079/1/xaudio2sound3d.png" alt="" width="90" height="70"></p>
<p>This sample shows you how to use the X3DAudio API with XAudio2 for playing spatialized audio.</p>
<p>The following is a quick overview of the basic steps taken by the sample:</p>
<ol>
<li>Initialize the XAudio2 engine and a mastering voice. Also, using the sample framework, initialize selected UI elements.
</li><li>Initialize the X3DAudio library with a speaker channel configuration that matches the mastering voice channel count.
</li><li>Create a submix voice and attach a reverb effect. The reverb effect parameter set is provided by using the I3DL2 preset conversion routine. For simplicity, the submix voice runs at the native output rate, and sends its output to the mastering voice.
</li><li>Create and start playing a single (mono) source voice as a looping sound, sending its output directly to the mastering voice and to the reverb submix voice.
</li><li>Represent and control the X3DAudio emitter and listener objects on a simplified X/Z grid to demonstrate spatialized audio.
<ol>
<li>Draw the current positions of the emitter and listener at each frame of rendering.
</li><li>Apply parameter control changes to update the UI elements during each frame. </li><li>Perform spatialized audio computations and updates during each frame update.
<ul>
<li>Based on frame-elapsed time, update the emitter and listener objects with new positions and velocity information.
</li><li>Call the X3DAudioCalculate method to compute the resulting DSP control settings.
</li><li>Pass DSP settings to the source voice via the IXAudio2Voice::SetOutputMatrix and IXAudio2SourceVoice::SetFrequencyRatio functions.
</li></ul>
</li></ol>
</li></ol>
<h2>XAudio2CustomAPO</h2>
<p><img id="101080" src="http://i1.code.msdn.s-msft.com/xaudio2-win32-samples-024b3933/image/file/101080/1/xaudio2customapo.png" alt="" width="90" height="70"></p>
<p>This sample shows you how to create and use custom APOs with XAudio2.</p>
<p>The sample creates a simple XAudio2 playback graph, adding a series of custom APOs to the playing source voice:</p>
<ul>
<li><em>SimpleAPO </em>applies a simple gain factor by multiplying the sample values processed.
</li><li><em>MonitorAPO </em>passes the audio data to the main thread by way of a lock-free communication channel for visualization by the application.
</li></ul>
<p>The APOs are implemented by using a helper template class, SampleAPOBase, that handles shared registration, class factory, and parameter handling operations. Use of this template class is not required, but it is used to simplfy the sample.</p>
<h2>XAudio2Enumerate (<em>NEW</em>)</h2>
<p><img id="101090" src="http://i1.code.msdn.s-msft.com/xaudio2-win32-samples-024b3933/image/file/101090/1/xaudio2basicsound.png" alt="" width="90" height="45"></p>
<p>This sample shows how to enumerate audio devices and initialize an XAudio2 mastering voice for a specific device.</p>
<h2>XAudio2MFStream (<em>NEW</em>)</h2>
<p><img id="101141" src="http://i1.code.msdn.s-msft.com/xaudio2-win32-samples-024b3933/image/file/101141/1/xaudio2basicsound.png" alt="" width="90" height="45"></p>
<p>This samples uses <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms694197.aspx">
Media Foundation</a> to decode a media audio file (which could be compressed with any number of codecs) and streams it through an XAudio2 voice. This technique is most useful for XAudio 2.8 on Windows 8.x which only supports PCM and ADPCM, and not more agressive
 lossy compressed schemes which are supported by Media Foundation.</p>
<p>Note that this assumes you&nbsp;need to perform some kind of further processing, 3D positioning, or APO to the streamed audio. If it is just being played back in the background, it would be more efficient to make use of IMFMediaSession to play the audio
 directly potentially with hardware offload.</p>
<h2>XAudio2WaveBank&nbsp;(<em>NEW)</em></h2>
<p><img id="101078" src="http://i1.code.msdn.s-msft.com/xaudio2-win32-samples-024b3933/image/file/101078/1/xaudio2basicsound.png" alt="" width="90" height="45"></p>
<p>This sample shows how to play in-memory audio using an XACT-style wave bank.</p>
<p>XACT wave banks are a binary file containing 1 or more .WAV files packaged together along with metadata information. The XAudio2AsyncStream sample makes use of XACT streaming wave banks, while this sample uses XACT in-memory wave banks.</p>
<p>The XACT runtime is not used by this sample. The audio data can be authored using the XACT tool in the legacy DirectX SDK, or with the XWBTOOL in this package.</p>
<h2>Utilities</h2>
<ul>
<li>The Common folder contains a <strong>WAVFileReader</strong>.h/.cpp module which can be used to load a .WAV file for playback with XAudio2. It optionally returns loop-point information as well as supporting the standard PCM, MS-ADPCM, and WAVEFORMATEXTENSIBLE
 formats supported by XAudio2. </li></ul>
<p>&nbsp;</p>
<ul>
<li>The Common folder contains a <strong>WaveBankReader</strong>.h/.cpp module which is&nbsp;used&nbsp;by the XAudio2AsyncStream and XAudio2WaveBank samples. It is used to parse XACT3-style wave banks.
</li></ul>
<p>&nbsp;</p>
<ul>
<li>The <strong>XBWTool</strong> command-line tool is a simple way to build XACT-style wave banks without using the legacy DirectX SDK's XACT tool or XACTBLD command-line tool. It can be used to build .xwb files suitable for both the XAudio2AsyncStream or XAudio2WaveBank
 samples, and are binary compatible with the XACT3 DirectX SDK (June 2010) wave bank format. This tool cannot generate XACT sound banks.
</li></ul>
<h1>Dependancies</h1>
<p>A build using the standard vcxproj files with VS 2012 or VS 2013 will make Win32 desktop applications that are compatible with Windows 8.x. They use the built-in XAudio 2.8 DLLs. The resulting binaries are not compatible with Windows Vista or Windows 7,
 although there are alternative project files included that will support Windows Vista and Windows 7.</p>
<p>XAudio2Sound3D and XAudio2CustomAPO are both DXUT-based samples. DXUT-based samples typically make use of runtime HLSL compilation. Build-time compilation is recommended for all production Direct3D applications, but for experimentation and samples development
 runtime HLSL compiliation is preferred. Therefore, the D3DCompile*.DLL must be available in the search path when these programs are executed.</p>
<ul>
<li>When using the Windows 8.x SDK and targeting Windows Vista or later, you can include the D3DCompile_46 or D3DCompile_47 DLL side-by-side with your application copying the file from the REDIST folder.
</li></ul>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.0\Redist\D3D\arm, x86 or x64</pre>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.1\Redist\D3D\arm, x86 or x64</pre>
<h1>Building for&nbsp;Windows Vista / Windows 7</h1>
<p>XAudio 2.7 supports Windows Vista, Windows 7, and Windows 8.x&nbsp;but requires the legacy DirectX SDK. These samples can build with VS 2012 or VS 2013 using the legacy DirectX SDK for down-level support. The *_DXSDK.vcxproj files are set up to include the
 needed references to DXSDK_DIR paths, and include setting the _WIN32_WINNT value to 0x0600 for down-level support.</p>
<p>Due to header-name collision, various #include statements will need to be updated to reflect the install path of the legacy DirectX SDK on your system.</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a>&nbsp;&nbsp;</p>
<h1>Building with Visual Studio 2013</h1>
<p>This sample can be modified to build with Visual Studio 2013 using the Windows 8.1 SDK. Set the Platform Toolset to &quot;v120&quot; for all configurations, and obtain the latest DXUT package. Remove the &quot;DXUT_2012.vcxproj&quot;&nbsp; &amp; &quot;DXUTOpt_2012.vcxproj&quot; references,
 add the projects &quot;DXUT_2013.vcxproj&quot; &amp; &quot;DXUTOpt_2013.vcxproj&quot;, and add new References to these projects.</p>
<p>You can also allow VS 2013 to upgrade the projects in place.</p>
<h1>Version History</h1>
<p>July 28, 2014 - Updated for DXUT July 2014 releas, some minor fixes</p>
<p>December 5, 2013 - Updated XAudio2MFStream to use async ReadSample, some minor fixes for common code</p>
<p>November 20, 2013 - Updated XAudio2MFStream to work on Windows Vista SP2 with KB 2117917 installed</p>
<p>November 14, 2013 - Initial release</p>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/05/15/learning-xaudio2.aspx">Learning XAudio2</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/04/02/xaudio2-and-windows-8-consumer-preview.aspx">XAudio2 and Windows 8</a>&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/09/14/dxut-for-win32-desktop-update.aspx">DXUT for Win32 Desktop Update</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
