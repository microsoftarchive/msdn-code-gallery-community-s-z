using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.IO;

namespace DirectoryMonitorWinForm
{
	/// <summary>
	/// Summary description for DirectoryMonitor.
	/// </summary>
	public class DirectoryMonitorForm : System.Windows.Forms.Form
	{

		private static string Path="";
		private static string Filter="";
		private static bool IncludeSubs=false;
		private System.IO.FileSystemWatcher FileMonitor;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Button ButtonStart;
		private System.Windows.Forms.Button ButtonStop;
		private System.Windows.Forms.TextBox directoryToMonitor;
		private System.Windows.Forms.Label Label4;
		private System.Windows.Forms.ComboBox fileFilterList;
		private System.Windows.Forms.CheckBox subdirectoriesAreIncluded;
		
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DirectoryMonitorForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		///	Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.FileMonitor = new System.IO.FileSystemWatcher();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.ButtonStop = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.directoryToMonitor = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.fileFilterList = new System.Windows.Forms.ComboBox();
			this.subdirectoriesAreIncluded = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.FileMonitor)).BeginInit();
			this.SuspendLayout();
			// 
			// FileMonitor
			// 
			this.FileMonitor.EnableRaisingEvents = true;
			this.FileMonitor.NotifyFilter = System.IO.NotifyFilters.FileName;
			this.FileMonitor.SynchronizingObject = this;
			this.FileMonitor.Deleted += new System.IO.FileSystemEventHandler(this.FileMonitor_Changed);
			this.FileMonitor.Renamed += new System.IO.RenamedEventHandler(this.FileMonitor_OnRenamed);
			this.FileMonitor.Changed += new System.IO.FileSystemEventHandler(this.FileMonitor_Changed);
			this.FileMonitor.Created += new System.IO.FileSystemEventHandler(this.FileMonitor_Changed);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(144, 176);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(64, 23);
			this.ButtonStart.TabIndex = 0;
			this.ButtonStart.Text = "Start";
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// ButtonStop
			// 
			this.ButtonStop.Location = new System.Drawing.Point(232, 176);
			this.ButtonStop.Name = "ButtonStop";
			this.ButtonStop.Size = new System.Drawing.Size(64, 23);
			this.ButtonStop.TabIndex = 1;
			this.ButtonStop.Text = "Stop";
			this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// Label1
			// 
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label1.Location = new System.Drawing.Point(16, 8);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(384, 24);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Directory Monitor";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// directoryToMonitor
			// 
			this.directoryToMonitor.Location = new System.Drawing.Point(96, 80);
			this.directoryToMonitor.Name = "directoryToMonitor";
			this.directoryToMonitor.Size = new System.Drawing.Size(312, 20);
			this.directoryToMonitor.TabIndex = 3;
			this.directoryToMonitor.Text = "";
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(16, 32);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(384, 32);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Enter a Directory to Monitor, Select a Filter and then Click \"Start\" to begin the" +
				" monitor.  Click \"Stop\" to end the monitor.";
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(8, 80);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(88, 16);
			this.Label3.TabIndex = 5;
			this.Label3.Text = "Directory:";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Label4
			// 
			this.Label4.Location = new System.Drawing.Point(16, 112);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(72, 16);
			this.Label4.TabIndex = 6;
			this.Label4.Text = "Filter:";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cboFilter
			// 
			this.fileFilterList.Items.AddRange(new object[] {
														   ".txt",
														   ".doc",
														   ".xls"});
			this.fileFilterList.Location = new System.Drawing.Point(96, 112);
			this.fileFilterList.Name = "fileFilterList";
			this.fileFilterList.Size = new System.Drawing.Size(121, 21);
			this.fileFilterList.TabIndex = 7;
			// 
			// checkIncludeSubs
			// 
			this.subdirectoriesAreIncluded.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.subdirectoriesAreIncluded.Location = new System.Drawing.Point(232, 112);
			this.subdirectoriesAreIncluded.Name = "subdirectoriesAreIncluded";
			this.subdirectoriesAreIncluded.Size = new System.Drawing.Size(144, 24);
			this.subdirectoriesAreIncluded.TabIndex = 9;
			this.subdirectoriesAreIncluded.Text = "Include Sub Directories:";
			// 
			// DirMon
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 224);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.subdirectoriesAreIncluded,
																		  this.fileFilterList,
																		  this.Label4,
																		  this.Label2,
																		  this.directoryToMonitor,
																		  this.Label1,
																		  this.ButtonStop,
																		  this.ButtonStart,
																		  this.Label3});
			this.Name = "DirMon";
			this.Text = "Directory Monitor";
			this.Load += new System.EventHandler(this.DirMon_Load);
			((System.ComponentModel.ISupportInitialize)(this.FileMonitor)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new DirectoryMonitorForm());
		}


		private void FileMonitor_OnRenamed(object source, RenamedEventArgs e)
		{
			// Specify what is done when a file is renamed.
			string originalname = e.OldFullPath;
			string renamed = e.FullPath;
			MessageBox.Show("File: "+originalname+" renamed to "+renamed, e.OldName+" Renamed");
		}

		private void FileMonitor_Changed(object sender, System.IO.FileSystemEventArgs e)
		{
			string ChangeType = e.ChangeType.ToString();

			//display a message box for the appropriate changetype.
			if (ChangeType=="Created")
			{
				MessageBox.Show("File: " +  e.FullPath + " " + e.ChangeType, e.Name+" Created");
			}
			else if(ChangeType=="Deleted")
			{
				MessageBox.Show("File: " +  e.FullPath + " " + e.ChangeType, e.Name+" Deleted");
			}
			else if(ChangeType=="Changed")
			{
				MessageBox.Show("File: " +  e.FullPath + " " + e.ChangeType, e.Name+" Changed");
			}
		
		}

		private void ButtonStart_Click(object sender, System.EventArgs e)
		{
			
			if (directoryToMonitor.Text == "")
			{
				MessageBox.Show("Please Enter a Directory");
			}
			else
			{
				//get the configuration properties from the form.
				Path = directoryToMonitor.Text;
			}				
			
			if (fileFilterList.SelectedText != "")
			{
				Filter = fileFilterList.SelectedText.ToString();
			}
			else
			{
				Filter = "*.*";
			}
			
			if (subdirectoriesAreIncluded.Checked == true)
			{
				IncludeSubs = true;
			}
			else
			{
				IncludeSubs = false;
			}
			
			//Set the properties on the monitor.
			FileMonitor.Path = Path.ToString();
			FileMonitor.Filter = Filter.ToString();
			FileMonitor.IncludeSubdirectories = IncludeSubs;
			FileMonitor.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite 
				| NotifyFilters.FileName | NotifyFilters.DirectoryName;
			
			//Begin monitoring.
			FileMonitor.EnableRaisingEvents = true;
	
		}

		private void ButtonStop_Click(object sender, System.EventArgs e)
		{
			//Begin monitoring.
			FileMonitor.EnableRaisingEvents = false;			
		}

		private void DirMon_Load(object sender, System.EventArgs e)
		{
		
		}
		
	}
}

