using Microsoft.ConfigurationManagement.ManagementProvider;
using Microsoft.ConfigurationManagement.ManagementProvider.WqlQueryEngine;
using sccm = Microsoft.ConfigurationManagement.ApplicationManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SystemsManagementServer.DesiredConfigurationManagement;
using Microsoft.ConfigurationManagement.DesiredConfigurationManagement;
using Microsoft.SystemsManagementServer.DesiredConfigurationManagement.Expressions;
using Microsoft.ConfigurationManagement.DesiredConfigurationManagement.ExpressionOperators;
using Microsoft.ConfigurationManagement.AdminConsole.AppManFoundation;
using Microsoft.ConfigurationManagement.ApplicationManagement.Serialization;
using Microsoft.ConfigurationManagement.AdminConsole.DesiredConfigurationManagement;
using System.Globalization;
using Microsoft.ConfigurationManagement.ApplicationManagement;
using Microsoft.SystemsManagementServer.DesiredConfigurationManagement.Rules;
using System.IO;
namespace TestCM2012App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ////connect to sccm
            this.sccmConnection.Connect(Environment.MachineName);
            ////retrieve the current applications and add them to the supersedence/dependency drop downs
            string wmiQuery = "SELECT * FROM SMS_Application WHERE SMS_APPLICATION.IsLatest = 1";
            WqlQueryResultsObject applicationResults = this.sccmConnection.QueryProcessor.ExecuteQuery(wmiQuery) as WqlQueryResultsObject;
            foreach (WqlResultObject appReference in applicationResults)
            {
                this.cmbSuperseded.Items.Add(appReference["LocalizedDisplayName"].StringValue);
                this.cmbDependency.Items.Add(appReference["LocalizedDisplayName"].StringValue);
            }

            ////get the global conditions and them to the global conditions drop down
            string condtionQuery = string.Format("SELECT * FROM SMS_GlobalCondition");
            WqlQueryResultsObject queryResults = this.sccmConnection.QueryProcessor.ExecuteQuery(condtionQuery) as WqlQueryResultsObject;
            foreach (IResultObject condition in queryResults)
            {
                ////retireve the lazy properties from the global condition
                condition.Get();
                ////load into wrapper objects so we can read out the properties in more detail
                DcmObjectWrapper wraper = DcmObjectWrapper.WrapExistingConfigurationItem(condition) as DcmObjectWrapper;
                ComplexSetting conditionSettings = wraper.InnerConfigurationItem.Settings;
                if (conditionSettings.ChildSimpleSettings.Any())
                {
                    ////if the condition contains simplechild settings assume this is a registry setting
                    RegistrySetting registrySetting = conditionSettings.ChildSimpleSettings[0] as RegistrySetting;
                    if (registrySetting != null)
                    {
                        ScalarDataType type = registrySetting.SettingDataType as ScalarDataType;
                        ////only add string based registry conditions
                        if (type == ScalarDataType.String)
                        {
                            this.cmbConditions.Items.Add(registrySetting.Name);
                        }
                    }
                }
            }

            ////get the available distribution point groups and add them to the drop down
            string dpgQuery = "Select * From SMS_DistributionPointGroup";
            WqlQueryResultsObject dpgs = this.sccmConnection.QueryProcessor.ExecuteQuery(dpgQuery) as WqlQueryResultsObject;
            foreach (WqlResultObject dpg in dpgs)
            {
                this.cmbDPGNames.Items.Add(dpg["Name"].StringValue);
            }

            ////get a list of the avialable collections
            string collectionQuery = "SELECT * FROM SMS_Collection";
            WqlQueryResultsObject collections = this.sccmConnection.QueryProcessor.ExecuteQuery(collectionQuery) as WqlQueryResultsObject;
            foreach (WqlResultObject collection in collections)
            {
                this.cmbCollection.Items.Add(collection.PropertyList["Name"]);
            }

            if (this.cmbSuperseded.Items.Count > 0)
            {
                this.cmbSuperseded.SelectedIndex = 0;
                this.cmbDependency.SelectedIndex = 0;
            }

            if (this.cmbConditions.Items.Count > 0)
            {
                this.cmbConditions.SelectedIndex = 0;
            }

            if (this.cmbDPGNames.Items.Count > 0)
            {
                this.cmbDPGNames.SelectedIndex = 0;
            }

            if (this.cmbCollection.Items.Count > 0)
            {
                this.cmbCollection.SelectedIndex = 0;
            }
        }

        private void btnMSI_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMSILocation.Text))
            {
                if (File.Exists(txtMSILocation.Text))
                {
                    Type installerType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
                    WindowsInstaller.Installer installer = Activator.CreateInstance(installerType) as WindowsInstaller.Installer;

                    ////read out the contents of the msi based on the msi location (txtMSILocation.Text)
                    WindowsInstaller.Database db = installer.OpenDatabase(txtMSILocation.Text, 0);

                    ////select properties from the MSI and set text boxes with those values
                    string query = "SELECT Value FROM Property WHERE Property='ProductName'";
                    WindowsInstaller.View view = db.OpenView(query);
                    view.Execute(null);
                    this.txtAppName.Text = view.Fetch().StringData[1];
                    query = "SELECT Value FROM Property WHERE Property='ProductVersion'";
                    view = db.OpenView(query);
                    view.Execute(null);
                    this.txtSoftwareVersion.Text = view.Fetch().StringData[1];
                    query = "SELECT Value FROM Property WHERE Property='Manufacturer'";
                    view = db.OpenView(query);
                    view.Execute(null);
                    this.txtManufacturer.Text = view.Fetch().StringData[1];
                    query = "SELECT Value FROM Property WHERE Property='ProductCode'";
                    view = db.OpenView(query);
                    view.Execute(null);
                    this.txtProductCode.Text = view.Fetch().StringData[1];
                    installer = null;

                    ////dynamically build the install command based on the MSI properties
                    FileInfo file = new FileInfo(txtMSILocation.Text);
                    this.txtInstallCommandLine.Text = string.Format("MSI Install - msiexec /i {0} /q", file.Name);
                    this.txtUninstallCommandLine.Text = "MSI Uninstall - msiexec /x " + this.txtProductCode.Text + " /q";
                }
                else
                {
                    MessageBox.Show("File not found");
                }
            }
            else
            {
                MessageBox.Show("Please specify MSI location");
            }
        }

        private WqlConnectionManager sccmConnection = new WqlConnectionManager();

        private void SaveApplication(Microsoft.ConfigurationManagement.ApplicationManagement.Application applicationRequest)
        {
            //// Initialize application wrapper and factory for creating the SMS Provider application object.
            ApplicationFactory applicationFactory = new ApplicationFactory();
            AppManWrapper applicationWrapper = AppManWrapper.Create(this.sccmConnection, applicationFactory) as AppManWrapper;
            //// Set the application into the provider object.
            applicationWrapper.InnerAppManObject = applicationRequest;
            applicationFactory.PrepareResultObject(applicationWrapper);
            applicationWrapper.InnerResultObject.Put();
        }

        /// <summary>
        /// Sets the named scope for SCCM request.
        /// </summary>
        private void SetNamedScopeForSCCMRequest()
        {
            ////need to set the scope for the application request
            WqlResultObject smsIdentification = this.sccmConnection.GetClassObject("sms_identification") as WqlResultObject;
            string id = smsIdentification.ExecuteMethod("GetSiteID", null)["SiteID"].StringValue.Replace("{", string.Empty).Replace("}", string.Empty);
            NamedObject.DefaultScope = "ScopeId_" + id;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtAppName.Text) && !string.IsNullOrEmpty(this.txtManufacturer.Text) && !string.IsNullOrEmpty(this.txtProductCode.Text) && !string.IsNullOrEmpty(this.txtSoftwareVersion.Text) && !string.IsNullOrEmpty(this.txtMSILocation.Text))
            {
                if (!string.IsNullOrEmpty(this.txtSCCMApplicationName.Text))
                {
                    SetNamedScopeForSCCMRequest();
                    ////create a new application object and use the properties from the msi to set some of the properties
                    sccm.Application applicationRequest = new sccm.Application();
                    applicationRequest.Publisher = this.txtManufacturer.Text;
                    applicationRequest.SoftwareVersion = this.txtSoftwareVersion.Text;
                    applicationRequest.Title = this.txtSCCMApplicationName.Text;
                    applicationRequest.Version = 1;
                    applicationRequest.DisplayInfo.DefaultLanguage = CultureInfo.CurrentCulture.Name;
                    applicationRequest.AutoInstall = true;
                    applicationRequest.Description = string.Format("Created using code for app {0}", this.txtSCCMApplicationName.Text);
                    applicationRequest.ReleaseDate = DateTime.Now.ToString();

                    sccm.AppDisplayInfo displayInformation = new sccm.AppDisplayInfo();
                    displayInformation.Title = this.txtAppName.Text;
                    displayInformation.Language = CultureInfo.CurrentCulture.Name;
                    displayInformation.Publisher = this.txtManufacturer.Text;
                    applicationRequest.DisplayInfo.Add(displayInformation);
                    ////save the application in order to persist information
                    SaveApplication(applicationRequest);
                }
                else
                {
                    MessageBox.Show("Please specify an application name for SCCM.");
                }
            }
            else
            {
                MessageBox.Show("Please populate MSI properties");
            }
        }

        /// <summary>
        /// Gets the name of the application from.
        /// </summary>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="onlyLatest">if set to <c>true</c> [only latest].</param>
        /// <returns></returns>
        private sccm.Application GetApplicationFromName(string applicationName)
        {
            WqlResultObject appReference = GetApplicationWQLFromName(applicationName);
            if (appReference != null)
            {
                ////load all the properties for the application object so it can be loaded into an AppManWrapper to retrive application
                appReference.Get();
                ApplicationFactory applicationFactory = new ApplicationFactory();
                AppManWrapper applicationWrapper = AppManWrapper.WrapExisting(appReference, applicationFactory) as AppManWrapper;
                return applicationWrapper.InnerAppManObject as sccm.Application;
            }

            return null;
        }

        private WqlResultObject GetApplicationWQLFromName(string applicationName)
        {
                ////get the application based on the display name
            string wmiQuery = string.Format("SELECT * FROM SMS_Application WHERE SMS_APPLICATION.IsLatest = 1 AND LocalizedDisplayName='{0}'", applicationName.Trim());
            WqlQueryResultsObject applicationResults = this.sccmConnection.QueryProcessor.ExecuteQuery(wmiQuery) as WqlQueryResultsObject;
            ////return the first instance of the application found based on the query - note this assumes the name is unique!
            foreach (WqlResultObject appReference in applicationResults)
            {
                return appReference;
            }

            ////didn't find anything with the name
            return null;
        }

        private void btnCreateInstallerandDt_Click(object sender, EventArgs e)
        {
            ////Setup the installer and it's contents
            Content content = new Content();
            MsiInstaller msiInstaller = new MsiInstaller();

            FileInfo file = new FileInfo(txtMSILocation.Text);
            content.Location = file.Directory.FullName;
            ////use the msi folders location as the content source for the application package
            content = ContentImporter.CreateContentFromFolder(file.Directory.FullName);
            ////set the command that will run to install on a clients desktop
            msiInstaller.InstallCommandLine = txtInstallCommandLine.Text;
            msiInstaller.UninstallCommandLine = txtUninstallCommandLine.Text;
            ContentRef contentReferenece = new ContentRef(content);
            content.OnFastNetwork = ContentHandlingMode.Download;
            content.OnSlowNetwork = ContentHandlingMode.DoNothing;
            content.FallbackToUnprotectedDP = false;
            ////configure other properties - for instance the produce code which by default is used to detect whether the application is already installed
            msiInstaller.Contents.Add(content);
            msiInstaller.InstallContent = contentReferenece;
            msiInstaller.DetectionMethod = DetectionMethod.ProductCode;
            msiInstaller.ProductCode = txtProductCode.Text;
            msiInstaller.SourceUpdateProductCode = txtProductCode.Text;
            msiInstaller.ExecutionContext = sccm.ExecutionContext.System;
            msiInstaller.Contents[0].PinOnClient = false;
            msiInstaller.Contents[0].PeerCache = false;
            msiInstaller.UserInteractionMode = UserInteractionMode.Normal;
            msiInstaller.MaxExecuteTime = 120;
            msiInstaller.ExecuteTime = 0;

            ////Add a deployment type to the application using the installer details created above

            sccm.DeploymentType dt = new sccm.DeploymentType(msiInstaller, "MSI", NativeHostingTechnology.TechnologyId);
            dt.Title = txtSCCMApplicationName.Text;
            dt.Version = 1;
            ////retrieve tha application here to then add the deployment type to ot
            sccm.Application application = GetApplicationFromName(txtSCCMApplicationName.Text);
            application.DeploymentTypes.Add(dt);
            ////resave the application
            SaveApplication(application);
        }

        private void btnSupersedeApplication_Click(object sender, EventArgs e)
        {
            ////retrieve app that was created
            sccm.Application application = GetApplicationFromName(txtSCCMApplicationName.Text);
            ////retrieve application that will be superseded
            sccm.Application appToSupersede = GetApplicationFromName(cmbSuperseded.Items[cmbSuperseded.SelectedIndex] as string);

            sccm.DeploymentType dt = application.DeploymentTypes[0];
            sccm.DeploymentType ssdt = appToSupersede.DeploymentTypes[0];
            //// Define an intent expression to describe the realtionship between the applications
            DeploymentTypeIntentExpression intentExpression = new DeploymentTypeIntentExpression(appToSupersede.Scope, appToSupersede.Name, (int)appToSupersede.Version, ssdt.Scope, ssdt.Name, (int)ssdt.Version, DeploymentTypeDesiredState.Prohibited, true);
            //// Define a deployment type rule to contain the expression
            DeploymentTypeRule deploymentRule = new DeploymentTypeRule(NoncomplianceSeverity.None, null, intentExpression);
            ////  Add to Supersedes collection. 
            dt.Supersedes.Add(deploymentRule);

            SaveApplication(application);
        }

        private void btnAddDependency_Click(object sender, EventArgs e)
        {
            ////retrieve the application that requires a dependency
            sccm.Application application = GetApplicationFromName(txtSCCMApplicationName.Text);
            ////retrieve the application that will form a dependency
            sccm.Application dependencyApplication = GetApplicationFromName(cmbDependency.Items[cmbDependency.SelectedIndex] as string);
            sccm.DeploymentType dependencydeploymentType = dependencyApplication.DeploymentTypes[0];
            // define operands in an intent expression and add the information to the dependency
            CustomCollection<DeploymentTypeIntentExpression> operand = new CustomCollection<DeploymentTypeIntentExpression>();
            operand.Add(new DeploymentTypeIntentExpression(dependencyApplication.Scope, dependencyApplication.Name, dependencyApplication.Version.Value, dependencydeploymentType.Scope, dependencydeploymentType.Name, dependencydeploymentType.Version.Value, DeploymentTypeDesiredState.Required, true));
            ////create an expression (and/or) for multiple dependencies and then use in a rule which is added to the dependencies collection of the application's deployment type
            DeploymentTypeExpression expression = new DeploymentTypeExpression(ExpressionOperator.And, operand);
            DeploymentTypeRule dependencyRule = new DeploymentTypeRule("Dependency_" + Guid.NewGuid().ToString("B"), NoncomplianceSeverity.Critical, null, expression);
            application.DeploymentTypes[0].Dependencies.Add(dependencyRule);

            SaveApplication(application);
        }

        private void btnAddRequirement_Click(object sender, EventArgs e)
        {
            this.SetNamedScopeForSCCMRequest();
            ////retrieve the global condition to be associated by name
            WqlQueryResultsObject results = this.sccmConnection.QueryProcessor.ExecuteQuery(string.Format("SELECT * FROM SMS_GlobalCondition Where LocalizedDisplayName = '{0}'", cmbConditions.Items[cmbConditions.SelectedIndex])) as WqlQueryResultsObject;
            IResultObject result = null;
            foreach (IResultObject item in results)
            {
                result = item;
                break;
            }
            ////retrieve the application to add the global condition onto be name
            sccm.Application application = GetApplicationFromName(txtSCCMApplicationName.Text);
            if (result != null && application != null && application.DeploymentTypes.Any())
            {
                ////need to get all the information for the result otherwise the call to the dcmobjectwrapper wont work
                result.Get();
                ////Get the full id from the property of the result object
                string ciuniqueid = result.PropertyList["CI_UniqueID"];
                ////It will contain the scope and ID which, both of which are needed seperately so split them on their seperator
                string[] ids = ciuniqueid.Split("/".ToCharArray());
                string scope = ids[0];
                string id = ids[1];
                
                ////wrap up the wmi object in a wrapper object so it is possible to read out particular seetings
                DcmObjectWrapper dcmwrapper = DcmObjectWrapper.WrapExistingConfigurationItem(result) as DcmObjectWrapper;
                ComplexSetting complexsettings = dcmwrapper.InnerConfigurationItem.Settings;
                string name = complexsettings.ChildSimpleSettings[0].LogicalName;

                ////create the operands object which will set up ther comparison information
                CustomCollection<ExpressionBase> operands = new CustomCollection<ExpressionBase>();
                ////Add the reference information to the global setting - note the assumption it is a string (this could also be read out of the object above)
                GlobalSettingReference setting = new GlobalSettingReference(scope, id, ScalarDataType.String, name, ConfigurationItemSettingSourceType.CIM);
                setting.SettingSourceType = ConfigurationItemSettingSourceType.Registry;
                setting.MethodType = ConfigurationItemSettingMethodType.Value;
                ////add the value into the value for the registry entry, note this example just focuses on string registry settings
                ConstantValue value = new ConstantValue(txtRequirementValue.Text, ScalarDataType.String);
                operands.Add(setting);
                operands.Add(value);
                ////for this example this requirement will check to see if something is of a particular value
                Expression exp = new Expression(ExpressionOperator.IsEquals, operands);
                ////Create a rule to add to the deplyment types requirement list
                Microsoft.SystemsManagementServer.DesiredConfigurationManagement.Rules.Rule rule = new Microsoft.SystemsManagementServer.DesiredConfigurationManagement.Rules.Rule("Rule_" + Guid.NewGuid().ToString("B").Replace("{", string.Empty).Replace("}", string.Empty), Microsoft.SystemsManagementServer.DesiredConfigurationManagement.Rules.NoncomplianceSeverity.None, null, exp);
                application.DeploymentTypes[0].Requirements.Add(rule);
                ////save the changes back to SCCM
                SaveApplication(application);
            }
        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            WqlResultObject application = GetApplicationWQLFromName(txtSCCMApplicationName.Text);
            if (application != null)
            {
                ////get the package ids associated with the application
                string packageQuery = "SELECT PackageID FROM SMS_ObjectContentInfo WHERE ObjectID='" + application.PropertyList["ModelName"] + "'";
                IResultObject packages = this.sccmConnection.QueryProcessor.ExecuteQuery(packageQuery);
                List<string> idList = new List<string>();
                if (packages != null)
                {
                    foreach (IResultObject package in packages)
                    {
                        idList.Add(package.PropertyList["PackageID"]);
                    }
                }

                ////return the selected distribution point group
                string dpgQuery = string.Format(CultureInfo.InvariantCulture, "Select * From SMS_DistributionPointGroup Where Name = '{0}'", cmbDPGNames.Items[cmbDPGNames.SelectedIndex]);
                WqlQueryResultsObject dpgresults = this.sccmConnection.QueryProcessor.ExecuteQuery(dpgQuery) as WqlQueryResultsObject;
                WqlResultObject result = null;
                foreach (WqlResultObject dpgresult in dpgresults)
                {
                    result = dpgresult;
                }

                if (result != null)
                {
                    ////send them to the distribution point group
                    Dictionary<string, object> methodParams = new Dictionary<string, object>();
                    methodParams["PackageIDs"] = idList.ToArray();
                    result.ExecuteMethod("AddPackages", methodParams);
                }
            }
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            ////retrieve the application
            WqlResultObject application = GetApplicationWQLFromName(txtSCCMApplicationName.Text);

            if (application != null)
            {
                ////get the collection we want to apply to the deployment
                string collectionQuery = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM SMS_Collection Where Name = '{0}'", cmbCollection.Items[cmbCollection.SelectedIndex]);
                WqlQueryResultsObject collections = this.sccmConnection.QueryProcessor.ExecuteQuery(collectionQuery) as WqlQueryResultsObject;
                WqlResultObject result = null;
                foreach (WqlResultObject collection in collections)
                {
                    result = collection;
                }

                ////create an assignment (deployment) using the application and collection details
                if (result != null)
                {
                    IResultObject applicationAssignment = this.sccmConnection.CreateInstance("SMS_ApplicationAssignment");
                    DateTime time = DateTime.Now;
                    //// assign the application information to the assignment
                    applicationAssignment["ApplicationName"].StringValue = application.PropertyList["LocalizedDisplayName"];
                    applicationAssignment["AssignedCI_UniqueID"].StringValue = application.PropertyList["CI_UniqueID"];
                    applicationAssignment["AssignedCIs"].IntegerArrayValue = new int[] { int.Parse(application.PropertyList["CI_ID"]) };
                    applicationAssignment["AssignmentName"].StringValue = this.txtSCCMApplicationName.Text + "_Deployment";
                    ////use the collection name
                    applicationAssignment["CollectionName"].StringValue = result.PropertyList["Name"];
                    applicationAssignment["DisableMomAlerts"].BooleanValue = true;
                    applicationAssignment["AssignmentDescription"].StringValue = "Created by a web form application";
                    applicationAssignment["EnforcementDeadline"].DateTimeValue = time;
                    applicationAssignment["NotifyUser"].BooleanValue = false;
                    applicationAssignment["OfferFlags"].LongValue = 1;
                    applicationAssignment["DesiredConfigType"].LongValue = 1;
                    applicationAssignment["OverrideServiceWindows"].BooleanValue = false;
                    applicationAssignment["RebootOutsideOfServiceWindows"].BooleanValue = false;
                    applicationAssignment["RequireApproval"].BooleanValue = false;
                    applicationAssignment["StartTime"].DateTimeValue = time;
                    applicationAssignment["SuppressReboot"].LongValue = 0;
                    ////use the collection id
                    applicationAssignment["TargetCollectionID"].StringValue = result.PropertyList["CollectionID"];
                    applicationAssignment["UseGMTTimes"].BooleanValue = false;
                    applicationAssignment["UserUIExperience"].BooleanValue = false;
                    applicationAssignment["WoLEnabled"].BooleanValue = false;
                    applicationAssignment["LocaleID"].LongValue = 1033;
                    applicationAssignment.Put();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ////before deleting the application we need to delete any deployments we created
            string deploysql = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM SMS_ApplicationAssignment WHERE AssignmentName='{0}'", this.txtSCCMApplicationName.Text + "_Deployment");
            WqlQueryResultsObject deployments = this.sccmConnection.QueryProcessor.ExecuteQuery(deploysql) as WqlQueryResultsObject;
            foreach (WqlResultObject deployment in deployments)
            {
                deployment.Delete();
            }

            ////as the app maybe have been saved a few times it is necessary to retrive all versions
            string query = string.Format("SELECT * FROM SMS_Application WHERE LocalizedDisplayName='{0}'", txtSCCMApplicationName.Text);
            WqlQueryResultsObject applications = this.sccmConnection.QueryProcessor.ExecuteQuery(query) as WqlQueryResultsObject;
            List<WqlResultObject> applicationList = new List<WqlResultObject>();
            ////sort the list so that the older versions of the application are deleted first, trying to delete the latest version without deleteing the older ones results in an error
            foreach (WqlResultObject application in applications)
            {
                applicationList.Add(application);
            }

            applicationList = applicationList.OrderBy(item => item["CIVersion"].LongValue).ToList();
            foreach (WqlResultObject application in applicationList)
            {
                ////if it is the latest version then it must be retired before deletion
                if (application["IsLatest"].BooleanValue == true)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters["Expired"] = true;
                    application.ExecuteMethod("SetIsExpired", parameters);
                    application.Get();
                }

                ////delete the application
                application.Delete();
            }
        }
    }
}
