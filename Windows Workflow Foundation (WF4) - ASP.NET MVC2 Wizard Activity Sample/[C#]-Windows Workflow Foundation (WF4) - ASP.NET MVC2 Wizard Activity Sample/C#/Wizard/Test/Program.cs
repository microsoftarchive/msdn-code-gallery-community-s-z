using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

using WizardActivityPack.Activities;
using System.Collections.ObjectModel;
using WizardActivityPack.WorkflowHost;
namespace Test
{

    class Program
    {
        static void Main(string[] args)
        {


            IDictionary<string, object> output = new Dictionary<string, object>() {};

            //Workflow1 wf = new Workflow1();
            //Activity1 wf = new Activity1();
            Wizard wf = new Wizard();
            WizardHost host = new WizardHost(wf);
            Dictionary<string, object> input = new Dictionary<string, object>();
            input["Input"] = "Step3";
            Console.WriteLine("--------WorkFlow Output Started------------");

            output = host.Start(input);
            Console.WriteLine("--------WorkFlow Output Ended------------");
            CustomBookmark currentbm = host.GetCurrentBookmark();
            bool Continue=true;
            while (Continue)
            {
               
                
                Console.WriteLine("Select a command from below.");
                Console.WriteLine("1: Start");
                if(currentbm.HasNext) Console.WriteLine("2: Next");
                if (currentbm.HasBack) Console.WriteLine("3: Back");
                Console.WriteLine("4: GoTo  (Enter Step ID after a space)");
                Console.WriteLine("0: Exit");
                 string[] inputstr= Console.ReadLine().Split(' ');

                 String cmd = inputstr[0];
                    
                Console.WriteLine("--------WorkFlow Output Started------------");
                switch(cmd){
                    case "1":
                        host.Start(input);
                        break;
                    case "2":
                        host.Next(input);
                        break;
                    case "3":
                        host.Back(input);
                        break;
                    case "4":
                        string stepid = inputstr[1];
                        host.GoTo(input, new CustomBookmark { StepID = stepid });
                        break;
                    case "0":
                        Continue = false;
                        break;
                    default:
                        Console.WriteLine("Command Not Supported");
                        break;
                }
                List<CustomBookmark> bmlist = host.GetBookmarkHistory();
                currentbm = host.GetCurrentBookmark();
               // if (currentbm.StepID == "2") input["Input"] = "Step3";
                Console.WriteLine("--------WorkFlow Output Ended . Step ID :"+currentbm.StepID +" ------------");
            }
        
                       
        }

        
    }
}
