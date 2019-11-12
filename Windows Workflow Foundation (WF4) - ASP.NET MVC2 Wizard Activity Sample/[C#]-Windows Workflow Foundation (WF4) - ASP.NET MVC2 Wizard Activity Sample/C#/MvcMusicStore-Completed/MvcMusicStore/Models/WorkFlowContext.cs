using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Web.Mvc;
namespace MvcMusicStore.Models
{
    public class WorkFlowContext
    {
        public Request Request { get; set; }
        public IPrincipal User{ get; set; }
        public string ViewName { get; set; }
        public ViewDataDictionary ViewData { get; set; }
        public WorkFlowContext()
        {
            Request = new Request();
            
        }
    }
}
public class Request {
    public Dictionary<string, string> Items { get; set; }
    public Request()
        {
            Items = new Dictionary<string, string>();
        }

        public void AddItem(string key, string value)
        {

            Remove(key);
            Items.Add(key, value);
        }
        public object Get(string key)
        {
            return Items[key];
        }
        public string Get<T>(string key) 
        {
            try
            {
                return Items[key];
            }
            catch 
            {
                return string.Empty;
            }
        }
        public bool Contains(string key)
        {
            return Items.ContainsKey(key);
        }
        public void Remove(string key)
        {
            if (Items.ContainsKey(key)) Items.Remove(key);
        }
}