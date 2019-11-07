'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Graph.vb
'
'--------------------------------------------------------------------------

Namespace BabyNames
	Partial Public Class Window1
		Inherits Window
		Private Sub InitializeQueries()
            Dim numProcs = CInt(Fix(slProcessorsToUse.Value))

			' SEQUENTIAL QUERY
            _sequentialQuery = From b In _babies
                               Where b.Name.Equals(_userQuery.Name, StringComparison.InvariantCultureIgnoreCase) AndAlso
                                     b.State = _userQuery.State AndAlso
                                     b.Year >= YEAR_START AndAlso b.Year <= YEAR_END
                               Order By b.Year
                               Select b

			' PARALLEL QUERY
            _parallelQuery = From b In _babies.AsParallel().WithDegreeOfParallelism(numProcs)
                             Where b.Name.Equals(_userQuery.Name, StringComparison.InvariantCultureIgnoreCase) AndAlso
                                   b.State = _userQuery.State AndAlso
                                   b.Year >= YEAR_START AndAlso b.Year <= YEAR_END
                             Order By b.Year
                             Select b
		End Sub
	End Class
End Namespace