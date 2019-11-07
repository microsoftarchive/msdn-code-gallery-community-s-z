using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SolidEdge.SelectSet
{
    public static class ObjectExtensions
    {
        public static Type GetInteropType(this System.Object o)
        {
            if (o == null) throw new ArgumentNullException();

            if (Marshal.IsComObject(o))
            {
                IDispatch dispatch = o as IDispatch;
                if (dispatch != null)
                {
                    ITypeLib typeLib = null;
                    ITypeInfo typeInfo = dispatch.GetTypeInfo(0, 0);
                    int index = 0;
                    typeInfo.GetContainingTypeLib(out typeLib, out index);

                    string typeLibName = Marshal.GetTypeLibName(typeLib);
                    string typeInfoName = Marshal.GetTypeInfoName(typeInfo);
                    string typeFullName = String.Format("{0}.{1}", typeLibName, typeInfoName);

                    System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    System.Reflection.Assembly assembly = assemblies.FirstOrDefault(x => x.GetType(typeFullName) != null);

                    if (assembly != null)
                    {
                        return assembly.GetType(typeFullName);
                    }
                }
            }

            return o.GetType();
        }
    }
}
