using System;
using System.Runtime.InteropServices;
using Net4Assembly;

namespace Net4ToNet2Adapter
{
    [ComVisible(true)]
    [Guid("A6574755-925A-4E41-A01B-B6A0EEF72DF0")]
    public class MyClassAdapter : IMyClassAdapter
    {
        private MyClass _myClass = new MyClass();

        public void DoNet4Action()
        {
            _myClass.DoNet4Action();
        }
    }
}
