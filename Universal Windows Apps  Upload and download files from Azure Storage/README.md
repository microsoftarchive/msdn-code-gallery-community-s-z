# Universal Windows Apps : Upload and download files from Azure Storage
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Windows Azure Storage
## Topics
- How to
## Updated
- 09/24/2014
## Description

<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Sample code to download and upload files to Azure Storage from Universal Windows Apps.</p>
<p>&nbsp;</p>
<p>For more details please click here <a href="http://blogs.msdn.com/b/webapps/archive/2014/09/24/upload-and-download-files-from-azure-storage.aspx">
http://blogs.msdn.com/b/webapps/archive/2014/09/24/upload-and-download-files-from-azure-storage.aspx</a></p>
<h2>Introduction to Universal Windows Apps</h2>
<p>Visual Studio template for Universal Windows Apps allows developers to build Windows Store App and Phone App in a single Visual Studio solution. This Visual Studio solution includes three projects, project for design and feature experiences unique to Store
 App, second project for Phone App and third project for shared code.&nbsp; For more details on Universal Apps template in Visual Studio please click
<a href="http://blogs.msdn.com/b/visualstudio/archive/2014/04/14/using-visual-studio-to-build-universal-xaml-apps.aspx" target="_blank">
here</a></p>
<p>The project ending with .Windows is for Store App, project ending with .WindowsPhone is for Phone App and .Shared is for shared code.</p>
<p>In the Shared Project, use following #defines to write specific code for Phone App or Store App</p>
<p>&nbsp;</p>
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:527ae271-82e7-4f24-ad29-15b9a2110679" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:424px; height:137px; background-color:#e1e1e1; overflow:visible"><div><span style="color:#000000">
</span><span style="color:#0000ff">#if</span><span style="color:#000000"> WINDOWS_PHONE_APP</span><span style="color:#000000">
    </span><span style="color:#008000">//</span><span style="color:#008000"> For Windows Phone App</span><span style="color:#008000">
</span><span style="color:#0000ff">#elif</span><span style="color:#000000"> WINDOWS_APP</span><span style="color:#000000">
    </span><span style="color:#008000">//</span><span style="color:#008000"> For Windows Store App</span><span style="color:#008000">
</span><span style="color:#0000ff">#else</span><span style="color:#000000">
    </span><span style="color:#008000">//</span><span style="color:#008000">  Error</span><span style="color:#008000">
</span><span style="color:#0000ff">#endif</span><span style="color:#000000">
</span></div></pre>
</div>
<h2>Introduction to Azure Storage</h2>
<p>Azure Storage is storage in cloud which is accessible from anywhere in the world, from any type of application, whether it&rsquo;s running in the cloud, on the desktop, on an on-premises server, or on a mobile or tablet device. Azure Storage support four
 types of storage : Blob Storage, Table Storage, Queue Storage and File Storage. For more details please click
<a href="http://azure.microsoft.com/en-us/documentation/articles/storage-introduction/" target="_blank">
here</a>.</p>
<h2>Steps to create Azure Storage</h2>
<p>&nbsp;</p>
<ol>
<li>Login to Azure Portal @ <a title="https://manage.windowsazure.com/" href="https://manage.windowsazure.com/">
https://manage.windowsazure.com/</a> </li><li>Click on New at the bottom left </li><li>Select Data Services | Storage | Quick Create and enter URL </li><li>Next create container, click on Create a Container in the Storage | UniversalAppAzureStorage | Container tab
</li><li>Enter a name for container as shown below </li><li>Click on Manage Access Keys in the Dashboard tab and copy the Storage Account Name and Primary Access Key
</li></ol>
<h2>Steps to create Universal Windows App</h2>
<p>&nbsp;</p>
<ol>
<li>Open Visual Studio </li><li>Click on File | New </li><li>Select Templates | Visual C# | Store Apps | Universal Apps | Hub App </li><li>Now install NuGet Package for Azure Store </li><li>Right click on the .Windows project and select Manage NuGet Packages </li><li>In the search window type Azure Storage </li><li>Click on Install button for Azure Storage </li><li>Now install the Azure Storage NuGet Package on .WindowsPhone project </li><li>Right click on the .WindowsPhone project and select Manage NuGet Packages </li><li>In the search window type Azure Storage and click on the install button </li><li>Now lets right code for uploading file to Azure Storage </li><li>Open App.xaml.cs file in the .Shared Project </li><li>Copy this below upload function
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:ee847ce1-bdbd-4e57-9fff-899e350a19e0" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:668px; height:706px; background-color:#e1e1e1; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div><span style="color:#000000">       
       </span><span style="color:#0000ff">private</span><span style="color:#000000"> async Task</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">int</span><span style="color:#000000">&gt;</span><span style="color:#000000"> UploadToAzureStorage()
        {
            </span><span style="color:#0000ff">try</span><span style="color:#000000">
            {
                </span><span style="color:#008000">//</span><span style="color:#008000">  create Azure Storage</span><span style="color:#008000">
</span><span style="color:#000000">                CloudStorageAccount storageAccount </span><span style="color:#000000">=</span><span style="color:#000000"> CloudStorageAccount.Parse(</span><span style="color:#800000">&quot;</span><span style="color:#800000">DefaultEndpointsProtocol=https;AccountName=universalappazurestorage;AccountKey=&lt;your key&gt;</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a blob client.</span><span style="color:#008000">
</span><span style="color:#000000">                CloudBlobClient blobClient </span><span style="color:#000000">=</span><span style="color:#000000"> storageAccount.CreateCloudBlobClient();

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a container </span><span style="color:#008000">
</span><span style="color:#000000">                CloudBlobContainer container </span><span style="color:#000000">=</span><span style="color:#000000"> blobClient.GetContainerReference(</span><span style="color:#800000">&quot;</span><span style="color:#800000">containerone</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a block blob</span><span style="color:#008000">
</span><span style="color:#000000">                CloudBlockBlob blockBlob </span><span style="color:#000000">=</span><span style="color:#000000"> container.GetBlockBlobReference(</span><span style="color:#800000">&quot;</span><span style="color:#800000">filename</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a local file</span><span style="color:#008000">
</span><span style="color:#000000">                StorageFile file </span><span style="color:#000000">=</span><span style="color:#000000"> await ApplicationData.Current.LocalFolder.CreateFileAsync(</span><span style="color:#800000">&quot;</span><span style="color:#800000">filename</span><span style="color:#800000">&quot;</span><span style="color:#000000">, CreationCollisionOption.ReplaceExisting);

                </span><span style="color:#008000">//</span><span style="color:#008000">  copy some txt to local file</span><span style="color:#008000">
</span><span style="color:#000000">                MemoryStream ms </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">new</span><span style="color:#000000"> MemoryStream();
                DataContractSerializer serializer </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">new</span><span style="color:#000000"> DataContractSerializer(</span><span style="color:#0000ff">typeof</span><span style="color:#000000">(</span><span style="color:#0000ff">string</span><span style="color:#000000">));
                serializer.WriteObject(ms, </span><span style="color:#800000">&quot;</span><span style="color:#800000">Hello Azure World!!</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#0000ff">using</span><span style="color:#000000"> (Stream fileStream </span><span style="color:#000000">=</span><span style="color:#000000"> await file.OpenStreamForWriteAsync())
                {
                    ms.Seek(</span><span style="color:#800080">0</span><span style="color:#000000">, SeekOrigin.Begin);
                    await ms.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }

                </span><span style="color:#008000">//</span><span style="color:#008000">  upload to Azure Storage </span><span style="color:#008000">
</span><span style="color:#000000">                await blockBlob.UploadFromFileAsync(file);

                </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">1</span><span style="color:#000000">;
            }
            </span><span style="color:#0000ff">catch</span><span style="color:#000000">
            {
                </span><span style="color:#008000">//</span><span style="color:#008000">  return error</span><span style="color:#008000">
</span><span style="color:#000000">                </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">;
            }
        }</span></div></pre>
</div>
</li><li>Now copy this below download function
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:5b37c089-cca5-49b5-81d3-cf277222357b" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:554px; height:596px; background-color:#e1e1e1; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div><span style="color:#000000">
        </span><span style="color:#0000ff">private</span><span style="color:#000000"> async Task</span><span style="color:#000000">&lt;</span><span style="color:#0000ff">int</span><span style="color:#000000">&gt;</span><span style="color:#000000"> DownloadFromAzureStorage()
        {
            </span><span style="color:#0000ff">try</span><span style="color:#000000">
            {
                </span><span style="color:#008000">//</span><span style="color:#008000">  create Azure Storage</span><span style="color:#008000">
</span><span style="color:#000000">                CloudStorageAccount storageAccount </span><span style="color:#000000">=</span><span style="color:#000000"> CloudStorageAccount.Parse(</span><span style="color:#800000">&quot;</span><span style="color:#800000">DefaultEndpointsProtocol=https;AccountName=universalappazurestorage;AccountKey=&lt;your key&gt;</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a blob client.</span><span style="color:#008000">
</span><span style="color:#000000">                CloudBlobClient blobClient </span><span style="color:#000000">=</span><span style="color:#000000"> storageAccount.CreateCloudBlobClient();

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a container </span><span style="color:#008000">
</span><span style="color:#000000">                CloudBlobContainer container </span><span style="color:#000000">=</span><span style="color:#000000"> blobClient.GetContainerReference(</span><span style="color:#800000">&quot;</span><span style="color:#800000">containerone</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a block blob</span><span style="color:#008000">
</span><span style="color:#000000">                CloudBlockBlob blockBlob </span><span style="color:#000000">=</span><span style="color:#000000"> container.GetBlockBlobReference(</span><span style="color:#800000">&quot;</span><span style="color:#800000">filename</span><span style="color:#800000">&quot;</span><span style="color:#000000">);

                </span><span style="color:#008000">//</span><span style="color:#008000">  create a local file</span><span style="color:#008000">
</span><span style="color:#000000">                StorageFile file </span><span style="color:#000000">=</span><span style="color:#000000"> await ApplicationData.Current.LocalFolder.CreateFileAsync(</span><span style="color:#800000">&quot;</span><span style="color:#800000">filename_from_azure</span><span style="color:#800000">&quot;</span><span style="color:#000000">, CreationCollisionOption.ReplaceExisting);

                </span><span style="color:#008000">//</span><span style="color:#008000">  download from Azure Storage</span><span style="color:#008000">
</span><span style="color:#000000">                await blockBlob.DownloadToFileAsync(file);

                </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">1</span><span style="color:#000000">;
            }
            </span><span style="color:#0000ff">catch</span><span style="color:#000000">
            {
                </span><span style="color:#008000">//</span><span style="color:#008000">  return error</span><span style="color:#008000">
</span><span style="color:#000000">                </span><span style="color:#0000ff">return</span><span style="color:#000000"> </span><span style="color:#800080">0</span><span style="color:#000000">;
            }
        }</span></div></pre>
</div>
</li><li>Now call these two functions
<div class="wlWriterEditableSmartContent" id="scid:9D7513F9-C04C-4721-824A-2B34F0212519:341ae9b1-b415-4b45-ab6a-df8207e36c5e" style="float:none; margin:0px; display:inline; padding:0px">
<pre style="width:696px; height:319px; background-color:#e1e1e1; white-space:pre-wrap; word-wrap:break-word; overflow:visible"><div><span style="color:#000000">
        </span><span style="color:#0000ff">protected</span><span style="color:#000000"> async </span><span style="color:#0000ff">override</span><span style="color:#000000"> </span><span style="color:#0000ff">void</span><span style="color:#000000"> OnLaunched(LaunchActivatedEventArgs e)
        {
</span><span style="color:#0000ff">#if</span><span style="color:#000000"> DEBUG</span><span style="color:#000000">
            </span><span style="color:#0000ff">if</span><span style="color:#000000"> (<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.Debugger.IsAttached.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Debugger.IsAttached">System.Diagnostics.Debugger.IsAttached</a>)
            {
                </span><span style="color:#0000ff">this</span><span style="color:#000000">.DebugSettings.EnableFrameRateCounter </span><span style="color:#000000">=</span><span style="color:#000000"> </span><span style="color:#0000ff">true</span><span style="color:#000000">;
            }
</span><span style="color:#0000ff">#endif</span><span style="color:#000000">
            </span><span style="color:#0000ff">int</span><span style="color:#000000"> r </span><span style="color:#000000">=</span><span style="color:#000000"> await UploadToAzureStorage();
            </span><span style="color:#0000ff">if</span><span style="color:#000000"> (r </span><span style="color:#000000">==</span><span style="color:#000000"> </span><span style="color:#800080">1</span><span style="color:#000000">)
            {
                await DownloadFromAzureStorage();
            }

            Frame rootFrame </span><span style="color:#000000">=</span><span style="color:#000000"> Window.Current.Content </span><span style="color:#0000ff">as</span><span style="color:#000000"> Frame;</span></div></pre>
</div>
</li><li>Run the Windows Store App and check the files local storage </li><li>To get the path of the local storage, look at the Path variable value of the StorageFile
</li></ol>
