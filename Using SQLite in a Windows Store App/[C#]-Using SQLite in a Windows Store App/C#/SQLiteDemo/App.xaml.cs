using System;
using System.IO;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SQLiteDemo.Models;
using SQLiteDemo.Views;
using SQLiteDemo.Common;

namespace SQLiteDemo
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static string DBPath = string.Empty;
        public static int CurrentCustomerId { get; set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Get a reference to the SQLite database
                DBPath = Path.Combine(
                    Windows.Storage.ApplicationData.Current.LocalFolder.Path, "customers.s3db");
                // Initialize the database if necessary
                using (var db = new SQLite.SQLiteConnection(DBPath))
                {
                    // Create the tables if they don't exist
                    db.CreateTable<Customer>();
                    db.CreateTable<Project>();
                }

                ResetData();

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        private void ResetData()
        {
            using (var db = new SQLite.SQLiteConnection(DBPath))
            {
                // Empty the Customer and Project tables 
                db.DeleteAll<Customer>();
                db.DeleteAll<Project>();

                // Add seed customers and projects
                var newCustomer = new Customer()
                {
                    Name = "Adventure Works",
                    City = "Bellevue",
                    Contact = "Mu Han"
                };
                db.Insert(newCustomer);

                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Expense Reports",
                    Description = "Windows Store app",
                    DueDate = DateTime.Today.AddDays(4)
                });
                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Time Reporting",
                    Description = "Windows Store app",
                    DueDate = DateTime.Today.AddDays(14)
                });
                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Project Management",
                    Description = "Windows Store app",
                    DueDate = DateTime.Today.AddDays(24)
                });


                newCustomer = new Customer()
                {
                    Name = "Contoso",
                    City = "Seattle",
                    Contact = "David Hamilton"
                };
                db.Insert(newCustomer);

                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Soccer Scheduling",
                    Description = "Windows Phone app",
                    DueDate = DateTime.Today.AddDays(6)
                });

                newCustomer = new Customer()
                {
                    Name = "Fabrikam",
                    City = "Redmond",
                    Contact = "Guido Pica"
                };
                db.Insert(newCustomer);

                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Product Catalog",
                    Description = "MVC4 app",
                    DueDate = DateTime.Today.AddDays(30)
                });

                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Expense Reports",
                    Description = "Windows Store app",
                    DueDate = DateTime.Today.AddDays(-3)
                });

                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Expense Reports",
                    Description = "Windows Phone app",
                    DueDate = DateTime.Today.AddDays(45)
                });

                newCustomer = new Customer()
                {
                    Name = "Tailspin Toys",
                    City = "Kent",
                    Contact = "Michelle Alexander"
                };
                db.Insert(newCustomer);

                db.Insert(new Project()
                {
                    CustomerId = newCustomer.Id,
                    Name = "Kids Game",
                    Description = "Windows Store app",
                    DueDate = DateTime.Today.AddDays(60)
                });

            }
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}
