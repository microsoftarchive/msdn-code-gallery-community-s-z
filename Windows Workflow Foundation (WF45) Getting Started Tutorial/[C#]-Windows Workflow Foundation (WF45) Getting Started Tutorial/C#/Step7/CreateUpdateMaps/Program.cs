using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.Activities.Statements;
using System.IO;
using System.Xaml;
using System.Reflection;
using System.Activities.XamlIntegration;
using System.Activities.DynamicUpdate;
using System.Runtime.Serialization;
using Microsoft.CSharp.Activities;

namespace CreateUpdateMaps
{
    class Program
    {
        const string mapPath = @"..\..\..\PreviousVersions";
        const string definitionPath = @"..\..\..\NumberGuessWorkflowActivities_du";

        static void Main(string[] args)
        {
            // Create the update maps for the changes needed to the v1 activities
            // so they match the v2 activities.
            CreateSequentialUpdateMap();
            CreateFlowchartUpdateMap();
            CreateStateMachineUpdateMap();
        }

        private static ActivityBuilder StartUpdate(string name)
        {
            // Create the XamlXmlReaderSettings.
            XamlXmlReaderSettings readerSettings = new XamlXmlReaderSettings()
            {
                // In the XAML the "local" namespace referes to artifacts that come from 
                // the same project as the XAML. When loading XAML if the currently executing 
                // assembly is not the same assembly that was referred to as "local" in the XAML
                // LocalAssembly must be set to the assembly containing the artifacts.
                // Assembly.LoadFile requires an absolute path so convert this relative path
                // to an absolute path.
                LocalAssembly = Assembly.LoadFile(
                    Path.GetFullPath(Path.Combine(mapPath, "NumberGuessWorkflowActivities_v1.dll")))
            };

            string path = Path.Combine(definitionPath, name);
            XamlXmlReader xamlReader = new XamlXmlReader(path, readerSettings);

            // Load the workflow definition into an ActivityBuilder.
            ActivityBuilder wf = XamlServices.Load(
                ActivityXamlServices.CreateBuilderReader(xamlReader))
                as ActivityBuilder;

            // PrepareForUpdate makes a copy of the workflow definition in the
            // ActivityBuilder that is used for comparison when the update
            // map is created.
            DynamicUpdateServices.PrepareForUpdate(wf);

            return wf;
        }

        private static void CreateUpdateMaps(ActivityBuilder wf, string name)
        {
            // Create the UpdateMap.
            DynamicUpdateMap map =
                DynamicUpdateServices.CreateUpdateMap(wf);

            // Serialize it to a file.
            string path = Path.Combine(mapPath, name);
            DataContractSerializer sz = new DataContractSerializer(typeof(DynamicUpdateMap));
            using (FileStream fs = System.IO.File.Open(path, FileMode.Create))
            {
                sz.WriteObject(fs, map);
            }
        }

        private static void SaveUpdatedDefinition(ActivityBuilder wf, string name)
        {
            string xamlPath = Path.Combine(definitionPath, name);
            StreamWriter sw = File.CreateText(xamlPath);
            XamlWriter xw = ActivityXamlServices.CreateBuilderWriter(
                new XamlXmlWriter(sw, new XamlSchemaContext()));
            XamlServices.Save(xw, wf);
            sw.Close();
        }

        private static void CreateStateMachineUpdateMap()
        {
            ActivityBuilder wf = StartUpdate("StateMachineNumberGuessWorkflow.xaml");

            // Get a reference to the root StateMachine activity.
            StateMachine sm = wf.Implementation as StateMachine;

            // Update the Text of the two WriteLine activities that write the
            // results of the user's guess. They are contained in the workflow as the
            // Then and Else action of the If activity in sm.States[1].Transitions[1].Action.
            If guessLow = sm.States[1].Transitions[1].Action as If;

            // Update the "too low" message.
            WriteLine tooLow = guessLow.Then as WriteLine;
            tooLow.Text = new CSharpValue<string>("Guess.ToString() + \" is too low.\"");

            // Update the "too high" message.
            WriteLine tooHigh = guessLow.Else as WriteLine;
            tooHigh.Text = new CSharpValue<string>("Guess.ToString() + \" is too high.\"");

            // Create the new WriteLine that displays the closing message.
            WriteLine wl = new WriteLine
            {
                Text = new CSharpValue<string>("Guess.ToString() + \" is correct. You guessed it in \" + Turns.ToString() + \" turns.\"")
            };

            // Add it as the Action for the Guess Correct transition. The Guess Correct
            // transition is the first transition of States[1]. The transitions are listed
            // at the bottom of the State activity designer.
            sm.States[1].Transitions[0].Action = wl;

            // Create the update map.
            CreateUpdateMaps(wf, "StateMachineNumberGuessWorkflow.map");

            // Save the updated workflow definition.
            SaveUpdatedDefinition(wf, "StateMachineNumberGuessWorkflow_du.xaml");
        }

        private static void CreateFlowchartUpdateMap()
        {
            ActivityBuilder wf = StartUpdate("FlowchartNumberGuessWorkflow.xaml");

            // Get a reference to the root Flowchart activity.
            Flowchart fc = wf.Implementation as Flowchart;

            // Update the Text of the two WriteLine activities that write the
            // results of the user's guess. They are contained in the workflow as the
            // True and False action of the "Guess < Target" FlowDecision, which is
            // Nodes[4].
            FlowDecision guessLow = fc.Nodes[4] as FlowDecision;

            // Update the "too low" message.
            FlowStep trueStep = guessLow.True as FlowStep;
            WriteLine tooLow = trueStep.Action as WriteLine;
            tooLow.Text = new CSharpValue<string>("Guess.ToString() + \" is too low.\"");

            // Update the "too high" message.
            FlowStep falseStep = guessLow.False as FlowStep;
            WriteLine tooHigh = falseStep.Action as WriteLine;
            tooHigh.Text = new CSharpValue<string>("Guess.ToString() + \" is too high.\"");

            // Add the new WriteLine that displays the closing message.
            WriteLine wl = new WriteLine
            {
                Text = new CSharpValue<string>("Guess.ToString() + \" is correct. You guessed it in \" + Turns.ToString() + \" turns.\"")
            };

            // Create a FlowStep to hold the WriteLine.
            FlowStep closingStep = new FlowStep
            {
                Action = wl
            };

            // Add this new FlowStep to the True action of the 
            // "Guess == Guess" FlowDecision
            FlowDecision guessCorrect = fc.Nodes[3] as FlowDecision;
            guessCorrect.True = closingStep;

            // Add the new FlowStep to the Nodes collection.
            // If closingStep was replacing an existing node then
            // we would need to remove that Step from the collection.
            // In this example there was no existing True step to remove.
            fc.Nodes.Add(closingStep);

            // Create the update map.
            CreateUpdateMaps(wf, "FlowchartNumberGuessWorkflow.map");

            //  Save the updated workflow definition.
            SaveUpdatedDefinition(wf, "FlowchartNumberGuessWorkflow_du.xaml");
        }

        private static void CreateSequentialUpdateMap()
        {
            ActivityBuilder wf = StartUpdate("SequentialNumberGuessWorkflow.xaml");

            // Get a reference to the root activity in the workflow.
            Sequence rootSequence = wf.Implementation as Sequence;

            // Update the Text of the two WriteLine activities that write the
            // results of the user's guess. They are contained in the workflow as the
            // Then and Else action of the "Guess < Target" If activity.
            // Sequence[1]->DoWhile->Body->Sequence[2]->If->Then->If
            DoWhile gameLoop = rootSequence.Activities[1] as DoWhile;
            Sequence gameBody = gameLoop.Body as Sequence;
            If guessCorrect = gameBody.Activities[2] as If;
            If guessLow = guessCorrect.Then as If;
            WriteLine tooLow = guessLow.Then as WriteLine;
            tooLow.Text = new CSharpValue<string>("Guess.ToString() + \" is too low.\"");
            WriteLine tooHigh = guessLow.Else as WriteLine;
            tooHigh.Text = new CSharpValue<string>("Guess.ToString() + \" is too high.\"");

            // Add the new WriteLine that displays the closing message.
            WriteLine wl = new WriteLine
            {
                Text = new CSharpValue<string>("Guess.ToString() + \" is correct. You guessed it in \" + Turns.ToString() + \" turns.\"")
            };

            // Insert it as the third activity in the root sequence
            rootSequence.Activities.Insert(2, wl);

            // Create the update map.
            CreateUpdateMaps(wf, "SequentialNumberGuessWorkflow.map");

            // Save the updated workflow definition.
            SaveUpdatedDefinition(wf, "SequentialNumberGuessWorkflow_du.xaml");
        }
    }
}
