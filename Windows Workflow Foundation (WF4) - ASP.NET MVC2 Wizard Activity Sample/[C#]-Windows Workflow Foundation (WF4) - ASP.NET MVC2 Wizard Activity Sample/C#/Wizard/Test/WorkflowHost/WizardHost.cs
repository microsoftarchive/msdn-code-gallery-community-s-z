using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WizardActivityPack.Activities;
using System.Activities;

namespace WizardActivityPack.WorkflowHost
{
    public class WizardHost
    {
        Activity wizard;
        List<CustomBookmark> history;
        public WizardHost(Activity _wizard)
        {
            wizard = _wizard;

        }

        public List<CustomBookmark> GetBookmarkHistory()
        {

            return this.history;
        }
        public CustomBookmark GetCurrentBookmark()
        {

            return this.history.Last();
        }
        public IDictionary<string, object> Start(Dictionary<string, object> input)
        {
            IDictionary<string, object> output = ProcessCommand(Command.Start,input ,null);
            return output;

        }
        public IDictionary<string, object> Next(Dictionary<string, object> input)
        {
            IDictionary<string, object> output = ProcessCommand(Command.Next, input, null);
            return output;

        }
        public IDictionary<string, object> Back(Dictionary<string, object> input)
        {
            IDictionary<string, object> output = ProcessCommand(Command.Back, input, null);
            return output;

        }
        public IDictionary<string, object> GoTo(Dictionary<string, object> input,CustomBookmark bm)
        {
            IDictionary<string, object> output = ProcessCommand(Command.GoTo, input, bm);
            return output;

        }
        private IDictionary<string, object> ProcessCommand(Command cmd, Dictionary<string, object> input, CustomBookmark bm)
        {
            input = input ?? new Dictionary<string, object> { };

            input["BookmarkHistory"] = history;
            input["Action"] = cmd;
            input["Bookmark"] = bm;
            IDictionary<string, object> output = WorkflowInvoker.Invoke(wizard, input);
            history = output["BookmarkHistory"] as List<CustomBookmark>;
            return output;
        }
    }
}
