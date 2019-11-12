using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Activities;

namespace WizardActivityPack.Activities
{
    public static class ExtentionMethods
    {
        public static Stack<T> ToStack<T>(this List<T> c) where T : class
        {
            Stack<T> stack = new Stack<T>();
            if (c != null)
            {
                foreach (T t in c)
                {
                    stack.Push(t);
                }
            }
            return stack;
        }
        public static ReadOnlyCollection<T> ToReadonlyCollection<T>(this Stack<T> st) where T : class
        {
            List<T> list = st.ToList();
            return new ReadOnlyCollection<T>(list);


        }
        
        public static string ToPlainString(this Queue<int> q)
        {
            StringBuilder sb = new StringBuilder();
            if (q != null)
            {
                int[] vals = q.ToArray<int>();

                for (int i = 0; i < vals.Length; i++)
                {
                    sb.Append(vals[i]);
                    if (i != vals.Length - 1)
                        sb.Append("_");
                }
            }
            return sb.ToString();
        }
        public static Queue<int> ToQueue(this string s)
        {

            Queue<int> q = new Queue<int>();
            if (!string.IsNullOrEmpty(s))
            {
                string[] vals = s.Split('_');
                for (int i = 0; i < vals.Length; i++)
                {
                    q.Enqueue(Convert.ToInt32(vals[i]));

                }
            }
            return q;
        }
        public static void Update(this ExecutionProperties properties, string name, object value)
        {
            properties.Remove(name);
            properties.Add(name, value);
        }
    }
}
