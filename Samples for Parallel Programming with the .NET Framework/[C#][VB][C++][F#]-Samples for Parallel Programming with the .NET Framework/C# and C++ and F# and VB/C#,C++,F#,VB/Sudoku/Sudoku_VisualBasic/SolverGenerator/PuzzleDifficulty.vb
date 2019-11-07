'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: PuzzleDifficulty.vb
'
'  Description: Puzzle difficulty enumeration.
' 
'--------------------------------------------------------------------------


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>The level of difficulty for a puzzle.</summary>
	<Serializable>
	Public Enum PuzzleDifficulty
		''' <summary>An easy puzzle.</summary>
		Easy
		''' <summary>A medium puzzle.</summary>
		Medium
		''' <summary>A hard puzzle.</summary>
		Hard
		''' <summary>A very puzzle.</summary>
		VeryHard
		''' <summary>An unsolvable puzzle, either because it has multiple solutions or no solutions.</summary>
		Invalid
	End Enum
End Namespace