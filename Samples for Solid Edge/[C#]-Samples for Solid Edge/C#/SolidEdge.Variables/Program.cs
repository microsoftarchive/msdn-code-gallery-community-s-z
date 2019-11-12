using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Variables
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;
            SolidEdgeFramework.Variables variables = null;
            
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

                // This check is necessary because application.ActiveDocument will throw an
                // exception if no documents are open...
                if (documents.Count > 0)
                {
                    // Attempt to connect to ActiveDocument.
                    document = (SolidEdgeFramework.SolidEdgeDocument)application.ActiveDocument;
                }

                // Make sure we have a document.
                if (document == null)
                {
                    throw new System.Exception("No active document.");
                }

                variables = (SolidEdgeFramework.Variables)document.Variables;

                ProcessVariables(variables);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void ProcessVariables(SolidEdgeFramework.Variables variables)
        {
            SolidEdgeFramework.VariableList variableList = null;
            SolidEdgeFramework.variable variable = null;
            SolidEdgeFrameworkSupport.Dimension dimension = null;
            dynamic variableListItem = null;    // In C#, the dynamic keyword is used so we don't have to call InvokeMember().

            // Get a reference to the variablelist.
            variableList = (SolidEdgeFramework.VariableList)variables.Query(
                pFindCriterium: "*",
                NamedBy: SolidEdgeConstants.VariableNameBy.seVariableNameByBoth,
                VarType: SolidEdgeConstants.VariableVarType.SeVariableVarTypeBoth);

            // Process variables.
            for (int i = 1; i <= variableList.Count; i++)
            {
                // Get a reference to variable item.
                variableListItem = variableList.Item(i);

                // Determine the variable item type.
                SolidEdgeConstants.ObjectType objectType = (SolidEdgeConstants.ObjectType)variableListItem.Type;

                Console.WriteLine("Variable({0}) is of type '{1}'", i, objectType);

                // Process the specific variable item type.
                switch (objectType)
                {
                    case SolidEdgeConstants.ObjectType.igDimension:
                        dimension = (SolidEdgeFrameworkSupport.Dimension)variableListItem;
                        break;
                    case SolidEdgeConstants.ObjectType.igVariable:
                        variable = (SolidEdgeFramework.variable)variableListItem;
                        break;
                    default:
                        // Other SolidEdgeConstants.ObjectType's may exist.
                        break;
                }
            }
        }
    }
}
