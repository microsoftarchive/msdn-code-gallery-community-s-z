using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WcfService.Service1Client client = new TestClient.WcfService.Service1Client())
            {
                string value = client.GetData(10);
                Console.WriteLine(value);
                Console.ReadLine();
            }
        }
    }
}
