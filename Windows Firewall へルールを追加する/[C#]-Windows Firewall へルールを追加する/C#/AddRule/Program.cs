using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetFwTypeLib;

namespace AddRule
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the FwPolicy2 object.
            Type NetFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2",false);
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(NetFwPolicy2Type);

            // Get the Rules object
            INetFwRules RulesObject = fwPolicy2.Rules; 

            int CurrentProfiles = fwPolicy2.CurrentProfileTypes;

            // Create a Rule Object.
            Type NetFwRuleType = Type.GetTypeFromProgID("HNetCfg.FWRule",false);
            INetFwRule NewRule = (INetFwRule)Activator.CreateInstance(NetFwRuleType);
    
            NewRule.Name = "Outbound_Rule";
            NewRule.Description = "Allow outbound network traffic from my Application over TCP port 4000";
            NewRule.ApplicationName = @"%systemDrive%\Program Files\MyApplication.exe";
            NewRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            NewRule.LocalPorts = "4000";
            NewRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            NewRule.Enabled = true  ;
            NewRule.Grouping = "@firewallapi.dll,-23255";
            NewRule.Profiles = CurrentProfiles;
            NewRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
        
            // Add a new rule
            RulesObject.Add(NewRule);

        }
    }
}
