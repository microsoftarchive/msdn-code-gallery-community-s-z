'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: PuzzleStatus.vb
'
'  Description: Enumeration for the current status of a puzzle.
' 
'--------------------------------------------------------------------------


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>The status of a puzzle state.</summary>
	<Serializable>
	Public Enum PuzzleStatus
		''' <summary>The puzzle state has not been analyzed.</summary>
		Unknown
		''' <summary>The puzzle state does not represent a valid solution nor is it in an inconsistent state.</summary>
		InProgress
		''' <summary>The puzzle state represents a valid solution.</summary>
		Solved
		''' <summary>The puzzle state represents a configuration that is known to be invalid.</summary>
		CannotBeSolved
	End Enum
End Namespace