using System;
using Net4ToNet2Adapter;

namespace Net2Assembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CLR version from EXE: {0}", Environment.Version);
            
            Type myClassAdapterType = Type.GetTypeFromProgID("Net4ToNet2Adapter.MyClassAdapter");
            object myClassAdapterInstance = Activator.CreateInstance(myClassAdapterType);
            IMyClassAdapter myClassAdapter = (IMyClassAdapter)myClassAdapterInstance;
            myClassAdapter.DoNet4Action();
        }
    }
}
