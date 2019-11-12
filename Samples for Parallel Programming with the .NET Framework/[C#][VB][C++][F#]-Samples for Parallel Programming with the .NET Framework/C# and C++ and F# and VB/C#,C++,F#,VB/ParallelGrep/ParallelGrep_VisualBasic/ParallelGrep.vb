'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ParallelGrep.vb
'
'--------------------------------------------------------------------------
Imports System
Imports System.IO
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading

Friend Class ParallelGrep
	Shared Sub Main(ByVal args() As String)
		' Parse command-line switches
        Dim recursive = args.Contains("/s")
        Dim ignoreCase = args.Contains("/i")

		' Get the regex and file wildcards from the command-line
        Dim nonSwitches = From arg In args
                          Where arg.FirstOrDefault() <> "/"c
                          Select arg
		Dim regexString = nonSwitches.FirstOrDefault()
		Dim wildcards = nonSwitches.Skip(1)

		' Create thread-local Regex instances, to prevent contention on Regex's internal lock
        Dim regex = New ThreadLocal(Of Regex)(Function() New Regex(regexString, RegexOptions.Compiled Or
                                                         (If(ignoreCase, RegexOptions.IgnoreCase, RegexOptions.None))))

		' Get the list of files to be examined
        Dim files = From wc In wildcards
                    Let dirName = Path.GetDirectoryName(wc)
                    Let fileName = Path.GetFileName(wc)
                    From file In Directory.EnumerateFiles(If(String.IsNullOrWhiteSpace(dirName), ".", dirName),
                                                          If(String.IsNullOrWhiteSpace(fileName), "*.*", fileName),
                                                          If(recursive, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly))
                    Select file

		Try
			' Traverse the specified files in parallel, and run each line through the Regex, collecting line number info
			' for each match (the Zip call counts the lines in each file)

            Dim matches = From file In files.AsParallel().AsOrdered().WithMergeOptions(ParallelMergeOptions.NotBuffered)
                          From line In System.IO.File.ReadLines(file).
                            Zip(Enumerable.Range(1, Integer.MaxValue), Function(s, i) New With {Key .Num = i, Key .Text = s, Key .File = file})
                          Where regex.Value.IsMatch(line.Text)
                          Select line
			For Each line In matches
				Console.WriteLine("{0}:{1} {2}", line.File, line.Num, line.Text)
			Next line
		Catch ae As AggregateException
            ae.Handle(Function(e)
                          Console.WriteLine(e.Message)
                          Return True
                      End Function)
		End Try
	End Sub
End Class