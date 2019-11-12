# Universal Windows Apps : Upload and download files from OneDrive
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- OneDrive
## Topics
- How to
## Updated
- 09/24/2014
## Description

<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Here is sample code to download and upload files to OneDrive&nbsp; from Universal Windows Apps.</p>
<p>For more details please click here <a href="http://blogs.msdn.com/b/webapps/archive/2014/09/24/upload-and-download-files-from-onedrive.aspx">
http://blogs.msdn.com/b/webapps/archive/2014/09/24/upload-and-download-files-from-onedrive.aspx</a></p>
<h2>Introduction to Universal Windows Apps</h2>
<p>Visual Studio template for Universal Windows Apps allows developers to build Windows Store App and Phone App in a single Visual Studio solution. This Visual Studio solution includes three projects, project for design and feature experiences unique to Store
 App, second project for Phone App and third project for shared code.&nbsp; For more details on Universal Apps template in Visual Studio please click
<a href="http://blogs.msdn.com/b/visualstudio/archive/2014/04/14/using-visual-studio-to-build-universal-xaml-apps.aspx" target="_blank">
here</a></p>
<p>The project ending with .Windows is for Store App, project ending with .WindowsPhone is for Phone App and .Shared is for shared code.</p>
<p>In the Shared Project, use following #defines to write specific code for Phone App or Store App</p>
<div class="wlWriterSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:527ae271-82e7-4f24-ad29-15b9a2110679" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="overflow:visible; height:137px; width:424px; background-color:#e1e1e1"><div>
<span style="color:#000000">
</span><span style="color:#0000ff">#if</span><span style="color:#000000"> WINDOWS_PHONE_APP</span><span style="color:#000000">
    </span><span style="color:#008000">//</span><span style="color:#008000"> For Windows Phone App</span><span style="color:#008000">
</span><span style="color:#0000ff">#elif</span><span style="color:#000000"> WINDOWS_APP</span><span style="color:#000000">
    </span><span style="color:#008000">//</span><span style="color:#008000"> For Windows Store App</span><span style="color:#008000">
</span><span style="color:#0000ff">#else</span><span style="color:#000000">
    </span><span style="color:#008000">//</span><span style="color:#008000">  Error</span><span style="color:#008000">
</span><span style="color:#0000ff">#endif</span><span style="color:#000000">
</span></div></pre>
</div>
<h2>Introduction to OneDrive</h2>
<p>Microsoft OneDrive is cloud-based storage solution for all your applications&rsquo; end-users' information, files, and folders. For more details please click
<a href="http://msdn.microsoft.com/onedrive" target="_blank">here</a>.</p>
<p>Use Azure Storage as cloud-based storage solution for all your applications&rsquo; files that are common to all end-users. For more details please click
<a href="http://blogs.msdn.com/b/webapps/archive/2014/09/24/upload-and-download-files-from-azure-storage.aspx" target="_blank">
here</a>.</p>
<h2>Steps to create Universal Windows App</h2>
<p>&nbsp;</p>
<ol>
<li>Open Visual Studio </li><li>Click on File | New </li><li>Select Templates | Visual C# | Store Apps | Universal Apps | Hub App </li><li>Now install NuGet Package for OneDrive </li><li>Right click on the .Windows project and select Manage NuGet Packages </li><li>In the search textbox type Live SDK and select package created by Microsoft </li><li>Click on Install button for Live SDK </li><li>Now install the OneDrive (Live SDK) NuGet Package on .WindowsPhone project </li><li>Right click on the .WindowsPhone project and select Manage NuGet Packages </li><li>In the search textbox type Live SDK and click on the install button on package created by Microsoft
</li><li>Now lets right code for uploading file to OneDrive </li><li>Open App.xaml.cs file in the .Shared Project </li><li>Copy this below upload function
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:006af07a-81e0-4418-8cbe-513a42e283a3" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:668px; height:950px; background-color:#e1e1e1; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div><span style="color:#000000">
    LiveConnectClient liveClient;
    </span><span style="color:#0000ff">private</span><span style="color:#000000"> async Task</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">int</span><span style="color:#000000">&gt;</span><span style="color:#000000"> UploadFileToOneDrive()
    {
        </span><span style="color:#0000ff">try</span><span style="color:#000000">
        {
            </span><span style="color:#008000">//</span><span style="color:#008000">  create OneDrive auth client</span><span style="color:#008000">
</span><span style="color:#000000">            var authClient </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">new</span><span style="color:#000000"> LiveAuthClient();
            
            </span><span style="color:#008000">//</span><span style="color:#008000">  ask for both read and write access to the OneDrive</span><span style="color:#008000">
</span><span style="color:#000000">            LiveLoginResult result </span><span style="color:#000000">=</span><span style="color:#000000"> await authClient.LoginAsync(</span><span style="color:#0000ff">new</span><span style="color:#000000"> </span><span style="color:#0000ff">string</span><span style="color:#000000">[] { </span><span style="color:#800000">&quot;</span><span style="color:#800000">wl.skydrive</span><span style="color:#800000">&quot;</span><span style="color:#000000">, </span><span style="color:#800000">&quot;</span><span style="color:#800000">wl.skydrive_update</span><span style="color:#800000">&quot;</span><span style="color:#000000"> });
            
            </span><span style="color:#008000">//</span><span style="color:#008000">  if login successful </span><span style="color:#008000">
</span><span style="color:#000000">            </span><span style="color:#0000ff">if</span><span style="color:#000000"> (result.Status </span><span style="color:#000000">==</span><span style="color:#000000"> LiveConnectSessionStatus.Connected)
            {
                </span><span style="color:#008000">//</span><span style="color:#008000">  create a OneDrive client</span><span style="color:#008000">
</span><span style="color:#000000">                liveClient </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">new</span><span style="color:#000000"> LiveConnectClient(result.Session);
                
                </span><span style="color:#008000">//</span><span style="color:#008000">  create a local file</span><span style="color:#008000">
</span><span style="color:#000000">                StorageFile file </span><span style="color:#000000">=</span><span style="color:#000000"> await ApplicationData.Current.LocalFolder.CreateFileAsync(</span><span style="color:#800000">&quot;</span><span style="color:#800000">filename</span><span style="color:#800000">&quot;</span><span style="color:#000000">, CreationCollisionOption.ReplaceExisting);

                </span><span style="color:#008000">//</span><span style="color:#008000">  copy some txt to local file</span><span style="color:#008000">
</span><span style="color:#000000">                MemoryStream ms </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">new</span><span style="color:#000000"> MemoryStream();
                DataContractSerializer serializer </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">new</span><span style="color:#000000"> DataContractSerializer(</span><span style="color:#0000ff">typeof</span><span style="color:#000000">(</span><span style="color:#0000ff">string</span><span style="color:#000000">));
                serializer.WriteObject(ms, </span><span style="color:#800000">&quot;</span><span style="color:#800000">Hello OneDrive World!!</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#0000ff">using</span><span style="color:#000000"> (Stream fileStream </span><span style="color:#000000">=</span><span style="color:#000000"> await file.OpenStreamForWriteAsync())
                {
                    ms.Seek(</span><span style="color:#800080">0</span><span style="color:#000000">, SeekOrigin.Begin);
                    await ms.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a folder</span><span style="color:#008000">
</span><span style="color:#000000">                </span><span style="color:#0000ff">string</span><span style="color:#000000"> folderID </span><span style="color:#000000">=</span><span style="color:#000000"> await GetFolderID(</span><span style="color:#800000">&quot;</span><span style="color:#800000">folderone</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#0000ff">if</span><span style="color:#000000"> (</span><span style="color:#0000ff">string</span><span style="color:#000000">.IsNullOrEmpty(folderID))
                {
                    </span><span style="color:#008000">//</span><span style="color:#008000">  return error</span><span style="color:#008000">
</span><span style="color:#000000">                    </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">;
                }

                </span><span style="color:#008000">//</span><span style="color:#008000">  upload local file to OneDrive</span><span style="color:#008000">
</span><span style="color:#000000">                await liveClient.BackgroundUploadAsync(folderID, file.Name, file, OverwriteOption.Overwrite);
                
                </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">1</span><span style="color:#000000">;
            }
        }
        </span><span style="color:#0000ff">catch</span><span style="color:#000000">
        {
        }
        </span><span style="color:#008000">//</span><span style="color:#008000">  return error</span><span style="color:#008000">
</span><span style="color:#000000">        </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">;
    }</span></div></pre>
</div>
</li><li>Copy this below code to create a folder on OneDrive
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:c19de8ca-ad61-443f-9107-1fdd1a7a9ca9" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:668px; height:750px; background-color:#e1e1e1; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div style="color:#000000">
    <span style="color:#0000ff">public</span><span style="color:#000000"> async Task</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">string</span><span style="color:#000000">&gt;</span><span style="color:#000000"> GetFolderID(</span><span style="color:#0000ff">string</span><span style="color:#000000"> folderName)
    {
        </span><span style="color:#0000ff">try</span><span style="color:#000000">
        {
            </span><span style="color:#0000ff">string</span><span style="color:#000000"> queryString </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#800000">&quot;</span><span style="color:#800000">/files?filter=folders</span><span style="color:#800000">&quot;</span><span style="color:#000000">;
            </span><span style="color:#008000">//</span><span style="color:#008000">  get all folders</span><span style="color:#008000">
</span><span style="color:#000000">            LiveOperationResult loResults </span><span style="color:#000000">=</span><span style="color:#000000"> await liveClient.GetAsync(queryString);
            dynamic folders </span><span style="color:#000000">=</span><span style="color:#000000"> loResults.Result;

            </span><span style="color:#0000ff">foreach</span><span style="color:#000000"> (dynamic folder </span><span style="color:#0000ff">in</span><span style="color:#000000"> folders.data)
            {
                </span><span style="color:#0000ff">if</span><span style="color:#000000"> (</span><span style="color:#0000ff">string</span><span style="color:#000000">.Compare(folder.name, folderName, StringComparison.OrdinalIgnoreCase) </span><span style="color:#000000">==</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">)
                {
                    </span><span style="color:#008000">//</span><span style="color:#008000">  found our folder</span><span style="color:#008000">
</span><span style="color:#000000">                    </span><span style="color:#0000ff">return</span><span style="color:#000000"> folder.id;
                }
            }

            </span><span style="color:#008000">//</span><span style="color:#008000">  folder not found

            </span><span style="color:#008000">//</span><span style="color:#008000">  create folder</span><span style="color:#008000">
</span><span style="color:#000000">            Dictionary</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">string</span><span style="color:#000000">, </span><span style="color:#0000ff">object</span><span style="color:#000000">&gt;</span><span style="color:#000000"> folderDetails </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">new</span><span style="color:#000000"> Dictionary</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">string</span><span style="color:#000000">, </span><span style="color:#0000ff">object</span><span style="color:#000000">&gt;</span><span style="color:#000000">();
            folderDetails.Add(</span><span style="color:#800000">&quot;</span><span style="color:#800000">name</span><span style="color:#800000">&quot;</span><span style="color:#000000">, folderName);
            loResults </span><span style="color:#000000">=</span><span style="color:#000000"> await liveClient.PostAsync(</span><span style="color:#800000">&quot;</span><span style="color:#800000">me/skydrive</span><span style="color:#800000">&quot;</span><span style="color:#000000">, folderDetails);
            folders </span><span style="color:#000000">=</span><span style="color:#000000"> loResults.Result;

            </span><span style="color:#008000">//</span><span style="color:#008000"> return folder id</span><span style="color:#008000">
</span><span style="color:#000000">            </span><span style="color:#0000ff">return</span><span style="color:#000000"> folders.id;
        }
        </span><span style="color:#0000ff">catch</span><span style="color:#000000">
        {
            </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#0000ff">string</span><span style="color:#000000">.Empty;
        }
    }</span></div></pre>
</div>
</li><li>Now copy this below download function
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:d0449593-55a9-425c-86d7-011e3d98d990" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:668px; height:950px; background-color:#e1e1e1; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div style="color:#000000">
    <span style="color:#0000ff">public</span><span style="color:#000000"> async Task</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">int</span><span style="color:#000000">&gt;</span><span style="color:#000000"> DownloadFileFromOneDrive()
    {
        </span><span style="color:#0000ff">try</span><span style="color:#000000">
        {
            </span><span style="color:#0000ff">string</span><span style="color:#000000"> fileID </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">string</span><span style="color:#000000">.Empty;

            </span><span style="color:#008000">//</span><span style="color:#008000">  get folder ID</span><span style="color:#008000">
</span><span style="color:#000000">            </span><span style="color:#0000ff">string</span><span style="color:#000000"> folderID </span><span style="color:#000000">=</span><span style="color:#000000"> await GetFolderID(</span><span style="color:#800000">&quot;</span><span style="color:#800000">folderone</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

            </span><span style="color:#0000ff">if</span><span style="color:#000000"> (</span><span style="color:#0000ff">string</span><span style="color:#000000">.IsNullOrEmpty(folderID))
            {
                </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">; </span><span style="color:#008000">//</span><span style="color:#008000"> doesnt exists</span><span style="color:#008000">
</span><span style="color:#000000">            }

            </span><span style="color:#008000">//</span><span style="color:#008000">  get list of files in this folder</span><span style="color:#008000">
</span><span style="color:#000000">            LiveOperationResult loResults </span><span style="color:#000000">=</span><span style="color:#000000"> await liveClient.GetAsync(folderID </span><span style="color:#000000">&#43;</span><span style="color:#000000"> </span><span style="color:#800000">&quot;</span><span style="color:#800000">/files</span><span style="color:#800000">&quot;</span><span style="color:#000000">);
            List</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">object</span><span style="color:#000000">&gt;</span><span style="color:#000000"> folder </span><span style="color:#000000">=</span><span style="color:#000000"> loResults.Result[</span><span style="color:#800000">&quot;</span><span style="color:#800000">data</span><span style="color:#800000">&quot;</span><span style="color:#000000">] </span><span style="color:#0000ff">as</span><span style="color:#000000"> List</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">object</span><span style="color:#000000">&gt;</span><span style="color:#000000">;

            </span><span style="color:#008000">//</span><span style="color:#008000">  search for our file </span><span style="color:#008000">
</span><span style="color:#000000">            </span><span style="color:#0000ff">foreach</span><span style="color:#000000"> (</span><span style="color:#0000ff">object</span><span style="color:#000000"> fileDetails </span><span style="color:#0000ff">in</span><span style="color:#000000"> folder)
            {
                IDictionary</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">string</span><span style="color:#000000">, </span><span style="color:#0000ff">object</span><span style="color:#000000">&gt;</span><span style="color:#000000"> file </span><span style="color:#000000">=</span><span style="color:#000000"> fileDetails </span><span style="color:#0000ff">as</span><span style="color:#000000"> IDictionary</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">string</span><span style="color:#000000">, </span><span style="color:#0000ff">object</span><span style="color:#000000">&gt;</span><span style="color:#000000">;
                </span><span style="color:#0000ff">if</span><span style="color:#000000"> (</span><span style="color:#0000ff">string</span><span style="color:#000000">.Compare(file[</span><span style="color:#800000">&quot;</span><span style="color:#800000">name</span><span style="color:#800000">&quot;</span><span style="color:#000000">].ToString(), </span><span style="color:#800000">&quot;</span><span style="color:#800000">filename</span><span style="color:#800000">&quot;</span><span style="color:#000000">, StringComparison.OrdinalIgnoreCase) </span><span style="color:#000000">==</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">)
                {
                    </span><span style="color:#008000">//</span><span style="color:#008000">  found our file</span><span style="color:#008000">
</span><span style="color:#000000">                    fileID </span><span style="color:#000000">=</span><span style="color:#000000"> file[</span><span style="color:#800000">&quot;</span><span style="color:#800000">id</span><span style="color:#800000">&quot;</span><span style="color:#000000">].ToString();
                    </span><span style="color:#0000ff">break</span><span style="color:#000000">;
                }
            }

            </span><span style="color:#0000ff">if</span><span style="color:#000000"> (</span><span style="color:#0000ff">string</span><span style="color:#000000">.IsNullOrEmpty(fileID))
            {
                </span><span style="color:#008000">//</span><span style="color:#008000">  file doesnt exists</span><span style="color:#008000">
</span><span style="color:#000000">                </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">;
            }

            </span><span style="color:#008000">//</span><span style="color:#008000">  create local file</span><span style="color:#008000">
</span><span style="color:#000000">            StorageFile localFile </span><span style="color:#000000">=</span><span style="color:#000000"> await ApplicationData.Current.LocalFolder.CreateFileAsync(</span><span style="color:#800000">&quot;</span><span style="color:#800000">filename_from_onedrive</span><span style="color:#800000">&quot;</span><span style="color:#000000">, CreationCollisionOption.ReplaceExisting);

            </span><span style="color:#008000">//</span><span style="color:#008000">  download file from OneDrive</span><span style="color:#008000">
</span><span style="color:#000000">            await liveClient.BackgroundDownloadAsync(fileID </span><span style="color:#000000">&#43;</span><span style="color:#000000"> </span><span style="color:#800000">&quot;</span><span style="color:#800000">/content</span><span style="color:#800000">&quot;</span><span style="color:#000000">, localFile);

            </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">1</span><span style="color:#000000">;
        }
        </span><span style="color:#0000ff">catch</span><span style="color:#000000">
        {
        }
        </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">;
    }</span></div></pre>
</div>
</li><li>Now call these two functions
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:9ecfe426-a80e-476f-b582-76823f422419" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:668px; height:350px; background-color:#e1e1e1; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div style="color:#000000">
    <span style="color:#0000ff">protected</span><span style="color:#000000"> async </span><span style="color:#0000ff">override</span><span style="color:#000000"> </span><span style="color:#0000ff">void</span><span style="color:#000000"> OnLaunched(LaunchActivatedEventArgs e)
    {
</span><span style="color:#0000ff">#if</span><span style="color:#000000"> DEBUG</span><span style="color:#000000">
        </span><span style="color:#0000ff">if</span><span style="color:#000000"> (<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.Debugger.IsAttached.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Debugger.IsAttached">System.Diagnostics.Debugger.IsAttached</a>)
        {
            </span><span style="color:#0000ff">this</span><span style="color:#000000">.DebugSettings.EnableFrameRateCounter </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">true</span><span style="color:#000000">;
        }
</span><span style="color:#0000ff">#endif</span><span style="color:#000000">
        </span><span style="color:#0000ff">int</span><span style="color:#000000"> r </span><span style="color:#000000">=</span><span style="color:#000000"> await UploadFileToOneDrive();
        </span><span style="color:#0000ff">if</span><span style="color:#000000">( r</span><span style="color:#000000">==</span><span style="color:#000000"> </span><span style="color:#800080">1</span><span style="color:#000000">)
        {
            await DownloadFileFromOneDrive();
        }

        Frame rootFrame </span><span style="color:#000000">=</span><span style="color:#000000"> Window.Current.Content </span><span style="color:#0000ff">as</span><span style="color:#000000"> Frame;</span></div></pre>
</div>
</li><li>Run the Windows Store App </li><li>Did you get any errors ?
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:bd06067c-b6a0-4582-9493-4448f039c1d1" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:668px; height:350px; background-color:#ef9b8f; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div style="color:#000000">
{<span style="color:#800000">&quot;</span><span style="color:#800000">Object reference not set to an instance of an object.</span><span style="color:#800000">&quot;</span><span style="color:#000000">}
   
   at Microsoft.Live.ResourceHelper.GetString(String name)
   at Microsoft.Live.TailoredAuthClient.</span><span style="color:#000000">&lt;</span><span style="color:#000000">AuthenticateAsync</span><span style="color:#000000">&gt;</span><span style="color:#000000">d__0.MoveNext()
</span><span style="color:#000000">---</span><span style="color:#000000"> End of stack trace from previous location </span><span style="color:#0000ff">where</span><span style="color:#000000"> exception was thrown </span><span style="color:#000000">---</span><span style="color:#000000">
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Runtime.CompilerServices.TaskAwaiter.aspx" target="_blank" title="Auto generated link to System.Runtime.CompilerServices.TaskAwaiter">System.Runtime.CompilerServices.TaskAwaiter</a>`</span><span style="color:#800080">1</span><span style="color:#000000">.GetResult()
   at Microsoft.Live.LiveAuthClient.</span><span style="color:#000000">&lt;</span><span style="color:#000000">ExecuteAuthTaskAsync</span><span style="color:#000000">&gt;</span><span style="color:#000000">d__8.MoveNext()
</span><span style="color:#000000">---</span><span style="color:#000000"> End of stack trace from previous location </span><span style="color:#0000ff">where</span><span style="color:#000000"> exception was thrown </span><span style="color:#000000">---</span><span style="color:#000000">
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Runtime.CompilerServices.TaskAwaiter.aspx" target="_blank" title="Auto generated link to System.Runtime.CompilerServices.TaskAwaiter">System.Runtime.CompilerServices.TaskAwaiter</a>`</span><span style="color:#800080">1</span><span style="color:#000000">.GetResult()
   at UniversalAppOneDrive.App.</span><span style="color:#000000">&lt;</span><span style="color:#000000">UploadFileToOneDrive</span><span style="color:#000000">&gt;</span><span style="color:#000000">d__a.MoveNext()

</span></div></pre>
</div>
</li><li>This error usually indicates our current Windows Store App is not associated to an App Name in the store
</li><li>To associate our current app with the Store, right click on .Windows project, select Store | Associate App with the Store&hellip;
</li><li>Sign in with your developer account and register the app name </li><li>Now run the Windows Store App again </li><li>This time Microsoft Account UI will ask end user permission to allow your app to access their OneDrive
<div></div>
<div></div>
</li></ol>
