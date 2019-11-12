using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplication_cs
{
    public interface ICountable
    {
        int Count { get; }
    }

    public class Sample4 : ICountable
    {
        private static int count;
        public int Count { get { return count; } }

        private readonly string name;

        public Sample4(string name) { this.name = name; }

        public void Method()
        {
            count++;
            Console.WriteLine("Total count {0} incremented by {1}", count, name);
        }
    }
    public class Company
    { }

    public class C1
    {
        public C1()
        {
            var demo = new Sample4("");
            
        }
    }

}
