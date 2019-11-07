// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Linq;
using NorthwindEFModel;

namespace ConfigOnlyInjection
{
    /// <summary>
    /// This sample demonstrates how to add tracing to an application just by modifiying its configuration file.
    /// See 'App.config' and 'NorthwindEFModel.WithTracing.ssdl' for an explanation.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Customers.ToList();
            }
        }
    }
}
