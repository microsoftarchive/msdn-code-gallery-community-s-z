'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ConfigurationOptions.vb
'
'  Description: User options for game play
' 
'--------------------------------------------------------------------------


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Used for saving and restoring configuration options.</summary>
	<Serializable>
	Friend Class ConfigurationOptions
		''' <summary>Whether easy cells will be suggested to the user.</summary>
		Public SuggestEasyCells As Boolean
		''' <summary>Whether incorrect values in cells will be pointed out to the user.</summary>
		Public ShowIncorrectCells As Boolean = True
		''' <summary>Whether new puzzles should be created with guaranteed symmetry.</summary>
		Public CreatePuzzlesWithSymmetry As Boolean = True
		''' <summary>Whether users want to be given the option to save their puzzles when they're being overriden.</summary>
		Public PromptOnPuzzleDelete As Boolean = True
		''' <summary>Whether to generate puzzles using parallelism.</summary>
		Public ParallelPuzzleGeneration As Boolean = False
		''' <summary>Whether to generate puzzles using parallelism.</summary>
		Public SpeculativePuzzleGeneration As Boolean = False
	End Class
End Namespace