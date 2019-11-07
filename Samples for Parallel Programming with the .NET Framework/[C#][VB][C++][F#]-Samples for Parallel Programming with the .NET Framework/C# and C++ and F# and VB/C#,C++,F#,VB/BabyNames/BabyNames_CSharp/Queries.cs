//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Graph.cs
//
//--------------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows;

namespace BabyNames
{
    public partial class Window1 : Window
    {
        private void InitializeQueries()
        {
            int numProcs = (int)slProcessorsToUse.Value;

            // SEQUENTIAL QUERY
            _sequentialQuery = from b in _babies
                               where b.Name.Equals(_userQuery.Name, StringComparison.InvariantCultureIgnoreCase) &&
                                     b.State == _userQuery.State &&
                                     b.Year >= YEAR_START && b.Year <= YEAR_END
                               orderby b.Year
                               select b;

            // PARALLEL QUERY
            _parallelQuery = from b in _babies.AsParallel().WithDegreeOfParallelism(numProcs)
                             where b.Name.Equals(_userQuery.Name, StringComparison.InvariantCultureIgnoreCase) &&
                                   b.State == _userQuery.State &&
                                   b.Year >= YEAR_START && b.Year <= YEAR_END
                             orderby b.Year
                             select b;
        }
    }
}