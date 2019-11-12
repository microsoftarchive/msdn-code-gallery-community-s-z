using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Assembly.Occurrences
{
    /// <summary>
    /// Console application demonstrating how to work with SolidEdgeAssembly Occurrences.
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeAssembly.AssemblyDocument assemblyDocument = null;
            SolidEdgeAssembly.Occurrences occurrences = null;

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

                Console.WriteLine("Creating a new assembly document.");

                // Create a new assembly document.
                assemblyDocument = (SolidEdgeAssembly.AssemblyDocument)
                    documents.Add("SolidEdge.AssemblyDocument");

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                // Get a reference to the Occurrences collection.
                occurrences = assemblyDocument.Occurrences;

                AddOccurrenceByFilename(occurrences);
                AddWithTransform(occurrences);
                AddWithMatrix(occurrences);

                Console.WriteLine("Switching to ISO view.");

                ReportOccurrences(occurrences);

                // Switch to ISO view.
                application.StartCommand(
                    (SolidEdgeFramework.SolidEdgeCommandConstants)
                        SolidEdgeConstants.AssemblyCommandConstants.AssemblyViewISOView);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void AddOccurrenceByFilename(SolidEdgeAssembly.Occurrences occurrences)
        {
            SolidEdgeAssembly.Occurrence occurrence = null;

            // Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
            DirectoryInfo programDirectory = new DirectoryInfo(GetSolidEdgeInstallPath());

            // Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'.
            DirectoryInfo trainingDirectory = new DirectoryInfo(Path.Combine(programDirectory.FullName, "Training"));

            FileInfo fileInfo = new FileInfo(Path.Combine(trainingDirectory.FullName, "Coffee Pot.par"));

            if (fileInfo.Exists)
            {
                // Add the base feature at 0 (X), 0 (Y), 0 (Z).
                occurrence = occurrences.AddByFilename(fileInfo.FullName);

                Console.WriteLine("Added '{0}' using AddByFilename().", fileInfo.FullName);
            }
            else
            {
                throw new FileNotFoundException("File not found.", fileInfo.FullName);
            }
        }

        static void AddWithTransform(SolidEdgeAssembly.Occurrences occurrences)
        {
            SolidEdgeAssembly.Occurrence occurrence = null;

            // Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
            DirectoryInfo programDirectory = new DirectoryInfo(GetSolidEdgeInstallPath());

            // Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'.
            DirectoryInfo trainingDirectory = new DirectoryInfo(Path.Combine(programDirectory.FullName, "Training"));

            string[] filenames = 
            {
                "strainer.asm",
                "handle.par",
            };

            // {OriginX, OriginY, OriginZ, AngleX, AngleY, AngleZ}
            // Origin in meters.
            // Angle in radians.
            double[,] transforms = new double[,]
				{
                    {0, 0, 0.02062, 0, 0, 0},               // strainer.asm
                    {-0.06943, -0.00996, 0.05697, 0, 0, 0}, // handle.par
				};

            // Add each occurrence in array.
            for (int i = 0; i <= transforms.GetUpperBound(0); i++)
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(trainingDirectory.FullName, filenames[i]));

                if (fileInfo.Exists)
                {
                    // Add the new occurrence using a transform.
                    occurrence = occurrences.AddWithTransform(
                        OccurrenceFileName: fileInfo.FullName,
                        OriginX: transforms[i, 0],
                        OriginY: transforms[i, 1],
                        OriginZ: transforms[i, 2],
                        AngleX: transforms[i, 3],
                        AngleY: transforms[i, 4],
                        AngleZ: transforms[i, 5]);

                    Console.WriteLine("Added '{0}' using AddWithTransform().", fileInfo.FullName);
                }
                else
                {
                    throw new FileNotFoundException("File not found.", fileInfo.FullName);
                }
            }
        }

        static void AddWithMatrix(SolidEdgeAssembly.Occurrences occurrences)
        {
            SolidEdgeAssembly.Occurrence occurrence = null;

            // Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
            DirectoryInfo programDirectory = new DirectoryInfo(GetSolidEdgeInstallPath());

            // Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'.
            DirectoryInfo trainingDirectory = new DirectoryInfo(Path.Combine(programDirectory.FullName, "Training"));

            FileInfo fileInfo = new FileInfo(Path.Combine(trainingDirectory.FullName, "Strap Handle.par"));

            // A single-dimension array that defines a valid transformation matrix. 
            double[] m = 
            {
                1.0,
                0.0,
                0.0,
                0.0,
                0.0,
                1.0,
                0.0,
                0.0,
                0.0,
                0.0,
                1.0,
                0.0,
                0.0,
                0.0,
                0.07913,
                1.0
            };

            // Convert from double[] to System.Array.
            Array matrix = m;
            
            if (fileInfo.Exists)
            {
                // Add the new occurrence using a matrix.
                occurrence = occurrences.AddWithMatrix(
                    OccurrenceFileName: fileInfo.FullName,
                    Matrix: ref matrix);

                Console.WriteLine("Added '{0}' using AddWithMatrix().", fileInfo.FullName);
            }
            else
            {
                throw new FileNotFoundException("File not found.", fileInfo.FullName);
            }            
        }

        static void ReportOccurrences(SolidEdgeAssembly.Occurrences occurrences)
        {
            SolidEdgeAssembly.Occurrence occurrence = null;

            Console.WriteLine();

            for (int i = 1; i <= occurrences.Count; i++)
            {
                occurrence = occurrences.Item(i);

                // Allocate a new array to hold transform.
                double[] transform = new double[6];

                // Allocate a new array to hold matrix.
                Array matrix = Array.CreateInstance(typeof(double), 16);
                
                // Get the occurrence transform.
                occurrence.GetTransform(
                    OriginX: out transform[0],
                    OriginY: out transform[1],
                    OriginZ: out transform[2],
                    AngleX: out transform[3],
                    AngleY: out transform[4],
                    AngleZ: out transform[5]);

                // Get the occurrence matrix.
                occurrence.GetMatrix(ref matrix);

                // Convert from System.Array to double[].  double[] is easier to work with.
                double[] m = matrix.OfType<double>().ToArray();

                // Report the occurrence transform.
                Console.WriteLine("{0} transform:", occurrence.Name);
                Console.WriteLine("OriginX: {0} (meters)", transform[0]);
                Console.WriteLine("OriginY: {0} (meters)", transform[1]);
                Console.WriteLine("OriginZ: {0} (meters)", transform[2]);
                Console.WriteLine("AngleX: {0} (radians)", transform[3]);
                Console.WriteLine("AngleY: {0} (radians)", transform[4]);
                Console.WriteLine("AngleZ: {0} (radians)", transform[5]);
                Console.WriteLine();

                // Report the occurrence matrix.
                Console.WriteLine("{0} matrix:", occurrence.Name);
                Console.WriteLine("|{0}, {1}, {2}, {3}|",
                    m[0],
                    m[1],
                    m[2],
                    m[3]);
                Console.WriteLine("|{0}, {1}, {2}, {3}|",
                    m[4],
                    m[5],
                    m[6],
                    m[7]);
                Console.WriteLine("|{0}, {1}, {2}, {3}|",
                    m[8],
                    m[9],
                    m[10],
                    m[11]);
                Console.WriteLine("|{0}, {1}, {2}, {3}|",
                    m[12],
                    m[13],
                    m[14],
                    m[15]);

                Console.WriteLine();
            }
        }

        static string GetSolidEdgeInstallPath()
        {
            SEInstallDataLib.SEInstallData installData = new SEInstallDataLib.SEInstallData();

            // Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
            DirectoryInfo programDirectory = new DirectoryInfo(installData.GetInstalledPath());

            // Get path to Solid Edge installation directory.  Typically, 'C:\Program Files\Solid Edge XXX'.
            DirectoryInfo installationDirectory = programDirectory.Parent;

            return installationDirectory.FullName;
        }
    }
}