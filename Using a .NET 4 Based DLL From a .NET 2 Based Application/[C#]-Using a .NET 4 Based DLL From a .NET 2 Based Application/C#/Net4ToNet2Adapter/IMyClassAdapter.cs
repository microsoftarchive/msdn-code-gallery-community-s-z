using System;
using System.Runtime.InteropServices;

namespace Net4ToNet2Adapter
{
    [ComVisible(true)]
    [Guid("E36BBF07-591E-4959-97AE-D439CBA392FB")]
    public interface IMyClassAdapter
    {
        void DoNet4Action();
    }
}
