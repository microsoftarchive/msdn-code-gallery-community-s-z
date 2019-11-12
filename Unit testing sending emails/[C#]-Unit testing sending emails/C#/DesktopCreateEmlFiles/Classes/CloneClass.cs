using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCreateEmlFiles
{
    public static class ExtensionMethods
    {
        public static T DeepClone<T>(this T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
    public static class CloneClass
    {
        /// <summary>
        /// Clones a object via shallow copy
        /// </summary>
        /// <typeparam name="T">Object Type to Clone</typeparam>
        /// <param name="sender">Object to Clone</param>
        /// <returns>New Object reference</returns>
        public static T CloneObject<T>(this T sender) where T : class
        {
            if (sender == null) return null;
            System.Reflection.MethodInfo inst = sender.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (inst != null)
                return (T)inst.Invoke(sender, null);
            else
                return null;
        }
    }
}
