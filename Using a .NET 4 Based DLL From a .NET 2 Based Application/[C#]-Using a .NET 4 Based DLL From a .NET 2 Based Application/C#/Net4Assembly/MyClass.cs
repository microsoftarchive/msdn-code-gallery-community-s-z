using System;

namespace Net4Assembly
{
    public class MyClass
    {
        public void DoNet4Action()
        {
            Console.WriteLine("CLR version from DLL: {0}", Environment.Version);
        }
    }
}
