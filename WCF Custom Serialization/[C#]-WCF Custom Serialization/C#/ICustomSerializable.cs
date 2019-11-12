using System.IO;

namespace OptimizedSerialization
{
    public interface ICustomSerializable
    {
        void WriteTo(Stream stream);
        void InitializeFrom(Stream stream);
    }
}
