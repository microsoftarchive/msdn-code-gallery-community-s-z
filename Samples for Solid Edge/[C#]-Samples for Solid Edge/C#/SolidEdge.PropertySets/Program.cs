using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.PropertySets
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;
            SolidEdgeFramework.PropertySets propertySets = null;

            try
            {
                Console.WriteLine("Registering OleMessageFilter.");

                // Register with OLE to handle concurrency issues on the current thread.
                OleMessageFilter.Register();

                Console.WriteLine("Connecting to Solid Edge.");

                // Connect to or start Solid Edge.
                application = SolidEdgeUtils.Connect(true);

                // Make sure user can see the GUI.
                application.Visible = true;

                // Bring Solid Edge to the foreground.
                application.Activate();

                // Get a reference to the Documents collection.
                documents = application.Documents;

                // Note: these two will throw exceptions if no document is open.
                //application.ActiveDocument
                //application.ActiveDocumentType;

                if (documents.Count > 0)
                {
                    // Get a reference to the documents collection.
                    document = (SolidEdgeFramework.SolidEdgeDocument)application.ActiveDocument;
                }
                else
                {
                    throw new System.Exception("No document open.");
                }

                propertySets = (SolidEdgeFramework.PropertySets)document.Properties;

                ProcessPropertySets(propertySets);

                AddCustomProperties(propertySets);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void ProcessPropertySets(SolidEdgeFramework.PropertySets propertySets)
        {
            SolidEdgeFramework.Properties properties = null;

            for (int i = 1; i <= propertySets.Count; i++)
            {
                properties = propertySets.Item(i);

                Console.WriteLine("PropertSet '{0}'.", properties.Name);

                ProcessProperties(properties);
            }
        }

        static void ProcessProperties(SolidEdgeFramework.Properties properties)
        {
            //SolidEdgeFramework.Property property = null;
            dynamic property = null;  // Using dynamic so that property.Value works.

            for (int i = 1; i <= properties.Count; i++)
            {
                System.Runtime.InteropServices.VarEnum nativePropertyType = System.Runtime.InteropServices.VarEnum.VT_EMPTY;
                Type runtimePropertyType = null;

                object value = null;
                
                try
                {
                    property = properties.Item(i);
                    nativePropertyType = (System.Runtime.InteropServices.VarEnum)property.Type;

                    // May throw an exception...
                    value = property.Value;
                    
                    if (value != null)
                    {
                        runtimePropertyType = value.GetType();
                    }
                }
                catch (System.Exception ex)
                {
                    value = ex.Message;
                }

                Console.WriteLine("\t{0} = '{1}' ({2} | {3}).", property.Name, value, nativePropertyType, runtimePropertyType);
            }
        }

        static void AddCustomProperties(SolidEdgeFramework.PropertySets propertySets)
        {
            SolidEdgeFramework.Properties properties = null;

            properties = propertySets.Item("Custom");

            Console.WriteLine("Adding custom properties.");

            properties.Add("My String", "Hello world!");
            properties.Add("My Integer", 338);
            properties.Add("My Boolean", true);
            properties.Add("My DateTime", DateTime.Now);
        }
    }
}
