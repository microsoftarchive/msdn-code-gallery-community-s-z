# SHA-1 Console App
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Win32
## Topics
- Cryptography
- File hashing
## Updated
- 11/01/2011
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This is a console mode app to hash files using SHA-1. Pass the file name as command line parameter, and the app will try to hash the file, printing its SHA-1 hash digest.</span></p>
<p><span style="font-size:small">(This can be useful e.g. when downloading files, to verify their autenticity; MSDN Subscriber Downloads currently use SHA-1.)</span></p>
<p><span style="font-size:small"><br>
</span></p>
<h1>Building the Sample</h1>
<p><span style="font-size:small">This is a console mode app, written in native C&#43;&#43;, using Visual Studio 2010. It uses modern C&#43;&#43;, STL and Win32 Platform SDK. No additional libraries (e.g. ATL) are used; so, it should be possible to build this app also with
 the Express Edition of Visual Studio 2010 (which doesn't include ATL).</span></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">This app uses <a title="MSDN page on CNG" href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376210(v=VS.85).aspx" target="_blank">
Windows Cryptography API Next Generation (CNG)</a>. This native C API is wrapped in C&#43;&#43; classes, using modern techniques like
<a title="RAII" href="http://en.wikipedia.org/wiki/Resource_Acquisition_Is_Initialization" target="_blank">
RAII</a> to manage raw CNG handles. Errors are signaled using C&#43;&#43; exceptions instead of return codes (like HRESULT or NTSTATUS).</span></p>
<p><span style="font-size:small">The <strong>CryptAlgorithmProvider</strong> C&#43;&#43; class wraps the cryptographic algorithm provider handle (<em>BCRYPT_ALG_HANDLE</em>): the constructor of the class calls
<a title="MSDN documentation on BCryptOpenAlgorithmProvider()." href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa375479(v=vs.85).aspx" target="_blank">
BCryptOpenAlgorithmProvider</a>, and the destructor calls <a title="MSDN documentation on BCryptCloseAlgorithmProvider()." href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa375377(v=vs.85).aspx" target="_blank">
BCryptCloseAlgorithmProvider</a>.&nbsp;</span></p>
<p><span style="font-size:small">The <strong>CryptHashObject</strong>&nbsp;C&#43;&#43; class wraps the crypt hash object handle (<em>BCRYPT_HASH_HANDLE</em>), and related C API functions (e.g.
<a title="MSDN documentation on BCryptHashData()." href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa375468(v=vs.85).aspx" target="_blank">
BCryptHashData</a>, <a title="MSDN documentation on BCryptFinishHash()." href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa375443(v=vs.85).aspx" target="_blank">
BCryptFinishHash</a>...).</span></p>
<p><span style="font-size:small">Hashing files with these helper classes is easy:</span></p>
<ol>
<li><span style="font-size:small">An instance of <em>CryptAlgorithmProvider</em> is created.</span>
</li><li><span style="font-size:small">The aforementioned instance is used to create a
<em>CryptHashObject</em>.</span> </li><li><span style="font-size:small"><em>CryptHashObject::HashData()</em> method is called in a loop, to hash chunks of data read from file into a memory buffer.</span>
</li><li><span style="font-size:small">When there is no more data from file, <em>CryptHashObject::FinishHash()</em> method is called.</span>
</li><li><span style="font-size:small">The hash digest string is returned by <em>CryptHashObject::HashDigest()</em> method.</span>
</li></ol>
<p><span style="font-size:small">(For an example of C&#43;&#43; code implementing the above steps, see the body of the function
<em>HashFileSHA1()</em>. For simplicity, all the code is contained in a single source file: &quot;SHA1.cpp&quot;.)</span></p>
<p><span style="font-size:small"><br>
</span></p>
