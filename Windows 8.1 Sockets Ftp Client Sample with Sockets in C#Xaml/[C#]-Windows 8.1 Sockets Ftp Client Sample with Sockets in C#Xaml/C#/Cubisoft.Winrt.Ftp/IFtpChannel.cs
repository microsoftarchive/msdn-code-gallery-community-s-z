using System.Threading.Tasks;
using Cubisoft.Winrt.Ftp.Messages;

namespace Cubisoft.Winrt.Ftp
{
    public interface IFtpChannel
    {
        Task<FtpFeaturesResponse> GetFeaturesAsync();

        Task<FtpResponse> SetOptionsAsync(string option);

        Task<FtpResponse> SetDataTypeAsync(FtpDataType dataType);

        Task<FtpResponse> SetDirectoryAsync(string path);

        Task<FtpGetDirectoryResponse> GetDirectoryAsync();

        Task<FtpResponse> CreateDirectoryAsync(string path);

        Task<FtpResponse> DeleteDirectoryAsync(string path);

        Task<FtpFileSizeResponse> GetFileSizeAsync(string path);

        Task<FtpModifiedTimeResponse> GetModifiedTimeAsync(string path);

        Task<FtpResponse> DeleteFileAsync(string path);

        Task<FtpGetListingResponse> GetListingAsync(string path = null);

        Task<T> ExecuteAsync<T>(FtpRequest request) where T : FtpResponse;
    }
}
