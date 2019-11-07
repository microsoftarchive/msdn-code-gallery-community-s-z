using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Activities.DurableInstancing;
using System.Activities;
using System.Data.SqlClient;
using System.IO;
using System.Activities.Tracking;

namespace NumberGuessWorkflowHost
{
    public partial class WorkflowHostForm : Form
    {
        const string connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=WF45GettingStartedTutorial;Integrated Security=SSPI";
        SqlWorkflowInstanceStore store;
        bool WorkflowStarting;

        public Guid WorkflowInstanceId
        {
            get
            {
                return InstanceId.SelectedIndex == -1 ? Guid.Empty : (Guid)InstanceId.SelectedItem;
            }
        }

        public WorkflowHostForm()
        {
            InitializeComponent();
        }

        private void WorkflowHostForm_Load(object sender, EventArgs e)
        {
            // Initialize the store and configure it so that it can be used for
            // multiple WorkflowApplication instances.
            store = new SqlWorkflowInstanceStore(connectionString);
            WorkflowApplication.CreateDefaultInstanceOwner(store, null, WorkflowIdentityFilter.Any);

            // Set default ComboBox selections.
            NumberRange.SelectedIndex = 0;
            WorkflowType.SelectedIndex = 0;

            ListPersistedWorkflows();
        }

        private void InstanceId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InstanceId.SelectedIndex == -1)
            {
                return;
            }

            // Clear the status window.
            WorkflowStatus.Clear();

            // If there is tracking data for this workflow, display it
            // in the status window.
            if (File.Exists(WorkflowInstanceId.ToString()))
            {
                string status = File.ReadAllText(WorkflowInstanceId.ToString());
                UpdateStatus(status);
            }

            // Get the workflow version and display it.
            // If the workflow is just starting then this info will not
            // be available in the persistence store so do not try and retrieve it.
            if (!WorkflowStarting)
            {
                WorkflowApplicationInstance instance =
                    WorkflowApplication.GetInstance(this.WorkflowInstanceId, store);

                WorkflowVersion.Text =
                    WorkflowVersionMap.GetIdentityDescription(instance.DefinitionIdentity);

                // Unload the instance.
                instance.Abandon();
            }
        }

        private void ListPersistedWorkflows()
        {
            using (SqlConnection localCon = new SqlConnection(connectionString))
            {
                string localCmd =
                    "Select [InstanceId] from [System.Activities.DurableInstancing].[Instances] Order By [CreationTime]";

                SqlCommand cmd = localCon.CreateCommand();
                cmd.CommandText = localCmd;
                localCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        // Get the InstanceId of the persisted Workflow
                        Guid id = Guid.Parse(reader[0].ToString());
                        InstanceId.Items.Add(id);
                    }
                }
            }
        }

        private delegate void UpdateStatusDelegate(string msg);
        public void UpdateStatus(string msg)
        {
            // We may be on a different thread so we need to
            // make this call using BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateStatusDelegate(UpdateStatus), msg);
            }
            else
            {
                if (!msg.EndsWith("\r\n"))
                {
                    msg += "\r\n";
                }
                WorkflowStatus.AppendText(msg);

                WorkflowStatus.SelectionStart = WorkflowStatus.Text.Length;
                WorkflowStatus.ScrollToCaret();
            }
        }

        private delegate void GameOverDelegate();
        private void GameOver()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new GameOverDelegate(GameOver));
            }
            else
            {
                // Remove this instance from the combo box
                InstanceId.Items.Remove(InstanceId.SelectedItem);
                InstanceId.SelectedIndex = -1;
            }
        }

        private void ConfigureWorkflowApplication(WorkflowApplication wfApp)
        {
            // Configure the persistence store.
            wfApp.InstanceStore = store;

            // Add a StringWriter to the extensions. This captures the output
            // from the WriteLine activities so we can display it in the form.
            StringWriter sw = new StringWriter();
            wfApp.Extensions.Add(sw);

            // Add the custom tracking participant with a tracking profile
            // that only emits tracking records for WriteLine activities.
            StatusTrackingParticipant stp = new StatusTrackingParticipant
            {
                TrackingProfile = new TrackingProfile
                {
                    Queries = 
                    {
                        new ActivityStateQuery
                        {
                            ActivityName = "WriteLine",
                            States = { ActivityStates.Executing },
                            Arguments = { "Text" }
                        }
                    }
                }
            };

            wfApp.Extensions.Add(stp);

            wfApp.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
            {
                if (e.CompletionState == ActivityInstanceState.Faulted)
                {
                    UpdateStatus(string.Format("Workflow Terminated. Exception: {0}\r\n{1}",
                        e.TerminationException.GetType().FullName,
                        e.TerminationException.Message));
                }
                else if (e.CompletionState == ActivityInstanceState.Canceled)
                {
                    UpdateStatus("Workflow Canceled.");
                }
                else
                {
                    int Turns = Convert.ToInt32(e.Outputs["Turns"]);
                    UpdateStatus(string.Format("Congratulations, you guessed the number in {0} turns.", Turns));
                }
                GameOver();
            };

            wfApp.Aborted = delegate(WorkflowApplicationAbortedEventArgs e)
            {
                UpdateStatus(string.Format("Workflow Aborted. Exception: {0}\r\n{1}",
                        e.Reason.GetType().FullName,
                        e.Reason.Message));
            };

            wfApp.OnUnhandledException = delegate(WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                UpdateStatus(string.Format("Unhandled Exception: {0}\r\n{1}",
                        e.UnhandledException.GetType().FullName,
                        e.UnhandledException.Message));
                GameOver();
                return UnhandledExceptionAction.Terminate;
            };

            wfApp.PersistableIdle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                // Send the current WriteLine outputs to the status window.
                var writers = e.GetInstanceExtensions<StringWriter>();
                foreach (var writer in writers)
                {
                    UpdateStatus(writer.ToString());
                }
                return PersistableIdleAction.Unload;
            };
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            var inputs = new Dictionary<string, object>();
            inputs.Add("MaxNumber", Convert.ToInt32(NumberRange.SelectedItem));

            WorkflowIdentity identity = null;
            switch (WorkflowType.SelectedItem.ToString())
            {
                case "SequentialNumberGuessWorkflow":
                    identity = WorkflowVersionMap.SequentialNumberGuessIdentity;
                    break;

                case "StateMachineNumberGuessWorkflow":
                    identity = WorkflowVersionMap.StateMachineNumberGuessIdentity;
                    break;

                case "FlowchartNumberGuessWorkflow":
                    identity = WorkflowVersionMap.FlowchartNumberGuessIdentity;
                    break;
            };

            Activity wf = WorkflowVersionMap.GetWorkflowDefinition(identity);

            WorkflowApplication wfApp = new WorkflowApplication(wf, inputs, identity);

            // Add the workflow to the list and display the version information.
            WorkflowStarting = true;
            InstanceId.SelectedIndex = InstanceId.Items.Add(wfApp.Id);
            WorkflowVersion.Text = identity.ToString();
            WorkflowStarting = false;

            // Configure the instance store, extensions, and 
            // workflow lifecycle handlers.
            ConfigureWorkflowApplication(wfApp);

            // Start the workflow.
            wfApp.Run();
        }

        private void EnterGuess_Click(object sender, EventArgs e)
        {
            if (WorkflowInstanceId == Guid.Empty)
            {
                MessageBox.Show("Please select a workflow.");
                return;
            }

            int guess;
            if (!Int32.TryParse(Guess.Text, out guess))
            {
                MessageBox.Show("Please enter an integer.");
                Guess.SelectAll();
                Guess.Focus();
                return;
            }

            WorkflowApplicationInstance instance =
                WorkflowApplication.GetInstance(WorkflowInstanceId, store);

            // Use the persisted WorkflowIdentity to retrieve the correct workflow
            // definition from the dictionary.
            Activity wf =
                WorkflowVersionMap.GetWorkflowDefinition(instance.DefinitionIdentity);

            // Associate the WorkflowApplication with the correct definition
            WorkflowApplication wfApp =
                new WorkflowApplication(wf, instance.DefinitionIdentity);

            // Configure the extensions and lifecycle handlers.
            // Do this before the instance is loaded. Once the instance is
            // loaded it is too late to add extensions.
            ConfigureWorkflowApplication(wfApp);

            // Load the workflow.
            wfApp.Load(instance);

            // Resume the workflow.
            wfApp.ResumeBookmark("EnterGuess", guess);

            // Clear the Guess textbox.
            Guess.Clear();
            Guess.Focus();
        }

        private void QuitGame_Click(object sender, EventArgs e)
        {
            if (WorkflowInstanceId == Guid.Empty)
            {
                MessageBox.Show("Please select a workflow.");
                return;
            }

            WorkflowApplicationInstance instance =
                WorkflowApplication.GetInstance(WorkflowInstanceId, store);

            // Use the persisted WorkflowIdentity to retrieve the correct workflow
            // definition from the dictionary.
            Activity wf = WorkflowVersionMap.GetWorkflowDefinition(instance.DefinitionIdentity);

            // Associate the WorkflowApplication with the correct definition
            WorkflowApplication wfApp =
                new WorkflowApplication(wf, instance.DefinitionIdentity);

            // Configure the extensions and lifecycle handlers
            ConfigureWorkflowApplication(wfApp);

            // Load the workflow.
            wfApp.Load(instance);

            // Terminate the workflow.
            wfApp.Terminate("User resigns.");
        }
    }
}
