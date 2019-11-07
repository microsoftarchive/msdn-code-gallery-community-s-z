using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Networking;
using Windows.Storage.Streams;

namespace Cubisoft.Winrt.Ftp.Tests
{
    [TestClass]
    public class FunctionalTests
    {
        private const string m_Host = "exampleftp.com";
        private readonly NetworkCredential m_Credentials = new NetworkCredential("can", "fenerbahce");

        private const string PathToSet = "/";

        private const string FolderToCreate = "Temp";

        private const string FileToCreate = "Temp.txt";

        private FtpClient CreateFtpClient()
        {
            var ftpClient = new FtpClient();

            ftpClient.Credentials = m_Credentials;
            ftpClient.HostName = new HostName(m_Host);
            ftpClient.ServiceName = "21";

            return ftpClient;
        }

        [TestMethod]
        public async Task TestConnectAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestConnectAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            Assert.IsTrue(ftpClient.IsConnected);
            Assert.IsFalse(ftpClient.Capabilities == FtpCapability.NONE);

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }


        [TestMethod]
        public async Task TestDisconnectAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestDisconnectAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            await ftpClient.DisconnectAsync();

            Assert.IsFalse(ftpClient.IsConnected);

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }


        [TestMethod]
        public async Task TestSetDataTypeAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestSetDataTypeAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");


            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            await ftpClient.SetDataTypeAsync(FtpDataType.Binary);

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestGetWorkingDirectoryAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestGetWorkingDirectoryAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            var workingDirectory = await ftpClient.GetWorkingDirectoryAsync();

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestSetWorkingDirectoryAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestSetWorkingDirectoryAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            if (!(await ftpClient.DirectoryExistsAsync(PathToSet)))
                Assert.Inconclusive("The working directory cannot set to non-existent directory : {0}", PathToSet);

            await ftpClient.SetWorkingDirectoryAsync(PathToSet);

            var workingDirectory = await ftpClient.GetWorkingDirectoryAsync();

            Assert.AreEqual(PathToSet.Trim('/'), workingDirectory.Trim('/'));

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestDirectoryExistsAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestSetWorkingDirectoryAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            if (!(await ftpClient.DirectoryExistsAsync(PathToSet)))
                Assert.Inconclusive("The working directory cannot set to non-existent directory : {0}", PathToSet);

            await ftpClient.SetWorkingDirectoryAsync(PathToSet);

            var workingDirectory = await ftpClient.GetWorkingDirectoryAsync();

            Assert.AreEqual(PathToSet.Trim('/'), workingDirectory.Trim('/'));

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestGetModfiedTimeAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestDirectoryExistsAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            var fileContent = "Here is the text to insert";
            string testFilePath = PathToSet + FolderToCreate + "/" + FileToCreate;

            await CreateTestFile(ftpClient, testFilePath, fileContent);

            var result = await ftpClient.GetModifiedTimeAsync(testFilePath);

            Assert.IsTrue(result > DateTime.MinValue, "The modified time  \"{0}\" is not correct", result);

            if (await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate))
            {
                await ftpClient.DeleteDirectoryAsync(PathToSet + FolderToCreate, true);
            }

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestGetFileSizeAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestDirectoryExistsAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            var fileContent = "Here is the text to insert";
            string testFilePath = PathToSet + FolderToCreate + "/" + FileToCreate;

            await CreateTestFile(ftpClient, testFilePath, fileContent);

            var result = await ftpClient.GetFileSizeAsync(testFilePath);

            Assert.IsTrue(result > 0, "The file size  \"{0}\" is not correct", result);

            if (await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate))
            {
                await ftpClient.DeleteDirectoryAsync(PathToSet + FolderToCreate, true);
            }

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestGetListingAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestGetListing");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            var result = await ftpClient.GetListingAsync();

            Assert.IsTrue(result.Count > 0);

            Assert.IsTrue(result.All(item => !string.IsNullOrEmpty(item.Name)));

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestCreateDirectoryAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestCreateDirectoryAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            await ftpClient.CreateDirectoryAsync(PathToSet + FolderToCreate);

            var result = await ftpClient.GetListingAsync(PathToSet);

            Assert.IsTrue(result.Any(item => item.Name == FolderToCreate && item.Type == FtpFileSystemObjectType.Directory));

            if (await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate))
            {
                await ftpClient.DeleteDirectoryAsync(PathToSet + FolderToCreate, true);
            }

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestCreateFileAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestCreateFileAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            if (!(await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate)))
                await ftpClient.CreateDirectoryAsync(PathToSet + FolderToCreate);

            string testFilePath = PathToSet + FolderToCreate + "/" + FileToCreate;

            if (await ftpClient.FileExistsAsync(testFilePath))
                await ftpClient.DeleteFileAsync(testFilePath);

            using (var stream = await ftpClient.OpenWriteAsync(testFilePath))
            {
                var bytes = Encoding.UTF8.GetBytes("Here is the text to insert");

                await stream.WriteAsync(bytes.AsBuffer());
                await stream.FlushAsync();
            }

            var fileExists = await ftpClient.FileExistsAsync(testFilePath);
            Assert.IsTrue(fileExists, "Uploaded file could not be found");

            if (await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate))
            {
                await ftpClient.DeleteDirectoryAsync(PathToSet + FolderToCreate, true);
            }

            await ftpClient.DisconnectAsync();


            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestRetrieveFileAsync01()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestCreateFileAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");



            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            var fileContent = "Here is the text to insert";
            string testFilePath = PathToSet + FolderToCreate + "/" + FileToCreate;
            await CreateTestFile(ftpClient, testFilePath, fileContent);

            var actualValue = string.Empty;

            using (var stream = await ftpClient.OpenReadAsync(testFilePath))
            {
                var buffer = new byte[512].AsBuffer();

                var resultingBuffer = await stream.ReadAsync(buffer, 512, InputStreamOptions.Partial);

                actualValue = Encoding.UTF8.GetString(resultingBuffer.ToArray(), 0, (int)resultingBuffer.Length);
            }

            var dataStreamResult = await ftpClient.CloseDataStreamAsync(null);

            await ftpClient.SetWorkingDirectoryAsync("/");

            Assert.AreEqual(fileContent, actualValue, "Stored content: {0} and retrieved content {1} are different", fileContent, actualValue);

            if (await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate))
            {
                await ftpClient.DeleteDirectoryAsync(PathToSet + FolderToCreate, true);
            }

            await ftpClient.DisconnectAsync();

            System.Diagnostics.Debug.WriteLine("-----------------------------------");

        }

        private static async Task CreateTestFile(FtpClient ftpClient, string testFilePath, string fileContent)
        {
            if (!(await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate)))
                await ftpClient.CreateDirectoryAsync(PathToSet + FolderToCreate);


            if (await ftpClient.FileExistsAsync(testFilePath))
                await ftpClient.DeleteFileAsync(testFilePath);

            using (var stream = await ftpClient.OpenWriteAsync(testFilePath))
            {
                var bytes = Encoding.UTF8.GetBytes(fileContent);
                await stream.WriteAsync(bytes.AsBuffer());
                await stream.FlushAsync();
            }
        }

        [TestMethod]
        public async Task TestRetrieveFileAsync02()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestCreateFileAsync 02");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var fileContent = "Here is the text to insert";

            var i = 9;
            while (i > 0)
            {
                fileContent += fileContent;
                i--;
            }

            string testFilePath = PathToSet + FolderToCreate + "/" + FileToCreate;

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            if (!(await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate)))
                await ftpClient.CreateDirectoryAsync(PathToSet + FolderToCreate);


            if (await ftpClient.FileExistsAsync(testFilePath))
                await ftpClient.DeleteFileAsync(testFilePath);

            using (var stream = await ftpClient.OpenWriteAsync(testFilePath))
            {
                var bytes = Encoding.UTF8.GetBytes(fileContent);

                await stream.WriteAsync(bytes.AsBuffer());
                await stream.FlushAsync();
            }

            var storageFile = await ftpClient.RetrieveFileAsync(testFilePath);

            await ftpClient.SetWorkingDirectoryAsync("/");

            string actualValue = await Windows.Storage.FileIO.ReadTextAsync(storageFile);

            Assert.AreEqual(fileContent, actualValue, "Stored content: {0} and retrieved content {1} are different", fileContent, actualValue);

            if (await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate))
            {
                await ftpClient.DeleteDirectoryAsync(PathToSet + FolderToCreate, true);
            }

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestDeleteDirectoryAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestDeleteDirectoryAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            await ftpClient.CreateDirectoryAsync(PathToSet + FolderToCreate);

            var result = await ftpClient.GetListingAsync(PathToSet);

            if (!result.Any(item => item.Name == FolderToCreate && item.Type == FtpFileSystemObjectType.Directory))
                Assert.Inconclusive("The folder to be deleted could not be found");

            await ftpClient.DeleteDirectoryAsync(PathToSet + FolderToCreate);

            Assert.IsFalse(await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate));

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }

        [TestMethod]
        public async Task TestDeleteFileAsync()
        {
            System.Diagnostics.Debug.WriteLine("-----------------------------------");
            System.Diagnostics.Debug.WriteLine("TestDeleteFileAsync");
            System.Diagnostics.Debug.WriteLine("-----------------------------------");

            const string testFilePath = PathToSet + FolderToCreate + "/" + FileToCreate;

            var ftpClient = CreateFtpClient();

            await ftpClient.ConnectAsync();

            if (!ftpClient.IsConnected) Assert.Inconclusive("No connection could be made to the FTP server {0}:{1}", m_Host, "21");

            if (!(await ftpClient.DirectoryExistsAsync(PathToSet + FolderToCreate)))
                await ftpClient.CreateDirectoryAsync(PathToSet + FolderToCreate);

            if (!(await ftpClient.FileExistsAsync(testFilePath)))
            {
                using (var stream = await ftpClient.OpenWriteAsync(testFilePath))
                {
                    var bytes = Encoding.UTF8.GetBytes("Here is the text to insert");

                    await stream.WriteAsync(bytes.AsBuffer());
                    await stream.FlushAsync();
                }
            }

            if (!(await ftpClient.FileExistsAsync(testFilePath)))
                Assert.Inconclusive("File to be deleted could not be found/created");

            await ftpClient.DeleteFileAsync(testFilePath);

            Assert.IsFalse(await ftpClient.FileExistsAsync(testFilePath));

            System.Diagnostics.Debug.WriteLine("-----------------------------------");
        }
    }
}
