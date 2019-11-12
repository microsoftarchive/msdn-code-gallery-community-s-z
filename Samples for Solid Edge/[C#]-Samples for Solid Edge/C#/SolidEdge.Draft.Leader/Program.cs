using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Draft.Leader
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeDraft.DraftDocument draftDocument = null;
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeFrameworkSupport.TextBoxes textBoxes = null;
            SolidEdgeFrameworkSupport.TextBox textBox = null;
            SolidEdgeFrameworkSupport.Leaders leaders = null;
            SolidEdgeFrameworkSupport.Leader leader = null;
            SolidEdgeFrameworkSupport.DimStyle dimStyle = null;

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

                // Get a reference to the documents collection.
                documents = application.Documents;

                // Create a new draft document.
                draftDocument = (SolidEdgeDraft.DraftDocument)documents.Add("SolidEdge.DraftDocument");

                // Get a reference to the active sheet.
                sheet = draftDocument.ActiveSheet;

                // Get a reference to the TextBoxes collection.
                textBoxes = (SolidEdgeFrameworkSupport.TextBoxes)sheet.TextBoxes;

                Console.WriteLine("Creating a new textbox. ");

                // Add a new text box.
                textBox = textBoxes.Add(0.25, 0.25, 0);
                textBox.TextScale = 1;
                textBox.VerticalAlignment = SolidEdgeFrameworkSupport.TextVerticalAlignmentConstants.igTextHzAlignVCenter;
                textBox.Text = "Leader";

                // Get a reference to the Leaders collection.
                leaders = (SolidEdgeFrameworkSupport.Leaders)sheet.Leaders;

                Console.WriteLine("Creating a new leader. ");

                // Add a new leader.
                leader = leaders.Add(0.225, 0.225, 0, 0.25, 0.25, 0);
                dimStyle = leader.Style;
                dimStyle.FreeSpaceTerminatorType = SolidEdgeFrameworkSupport.DimTermTypeConstants.igDimStyleTermFilled;
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }
    }
}
