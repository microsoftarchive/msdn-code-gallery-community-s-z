'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: EditDistance.vb
'
'--------------------------------------------------------------------------

Imports System.Text
Imports System.Threading.Algorithms

Namespace EditDistance
    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            Dim rand As New Random()
            Dim sw As New Stopwatch()
            Dim result As Integer
            Do
                Dim s1 = GenerateRandomString(rand)
                Dim s2 = GenerateRandomString(rand)

                sw.Restart()
                result = SerialEditDistance(s1, s2)
                sw.Stop()
                Console.WriteLine("Serial  :" & vbTab & "{0}" & vbTab & "{1}", result, sw.Elapsed)

                sw.Restart()
                result = ParallelEditDistance(s1, s2)
                sw.Stop()
                Console.WriteLine("Parallel:" & vbTab & "{0}" & vbTab & "{1}", result, sw.Elapsed)

                Console.WriteLine("-------------------------------------------------------")
                GC.Collect()
            Loop
        End Sub

        Private Shared Function GenerateRandomString(ByVal rand As Random) As String
            Const LEN = 10000
            Dim sb As New StringBuilder(LEN)
            For i = 0 To LEN - 1
                sb.Append(ChrW(AscW("a") + rand.Next(0, 26)))
            Next i
            Return sb.ToString()
        End Function

        Private Shared Function SerialEditDistance(ByVal s1 As String, ByVal s2 As String) As Integer
            Dim dist(s1.Length, s2.Length) As Integer
            For i = 0 To s1.Length
                dist(i, 0) = i
            Next i
            For j = 0 To s2.Length
                dist(0, j) = j
            Next j

            For i = 1 To s1.Length
                For j = 1 To s2.Length
                    dist(i, j) = If((s1.Chars(i - 1) = s2.Chars(j - 1)), dist(i - 1, j - 1), 1 + Math.Min(dist(i - 1, j),
                            Math.Min(dist(i, j - 1), dist(i - 1, j - 1))))
                Next j
            Next i
            Return dist(s1.Length, s2.Length)
        End Function

        Private Shared Function ParallelEditDistance(ByVal s1 As String, ByVal s2 As String) As Integer
            Dim dist(s1.Length, s2.Length) As Integer
            For i = 0 To s1.Length
                dist(i, 0) = i
            Next i
            For j = 0 To s2.Length
                dist(0, j) = j
            Next j
            Dim numBlocks = Environment.ProcessorCount * 4

            ParallelAlgorithms.Wavefront(s1.Length, s2.Length, numBlocks, numBlocks,
                                         Sub(start_i, end_i, start_j, end_j)
                                             For i = CType(start_i, Integer) + 1 To CType(end_i, Integer)
                                                 For j = CType(start_j, Integer) + 1 To CType(end_j, Integer)
                                                     dist(i, j) = If((s1.Chars(i - 1) = s2.Chars(j - 1)),
                                                                     dist(i - 1, j - 1),
                                                                     1 + Math.Min(dist(i - 1, j),
                                                                     Math.Min(dist(i, j - 1), dist(i - 1, j - 1))))
                                                 Next j
                                             Next i
                                         End Sub)

            Return dist(s1.Length, s2.Length)
        End Function
    End Class
End Namespace