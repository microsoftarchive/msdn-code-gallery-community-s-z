'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: NQueens.vb
'
'--------------------------------------------------------------------------

Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics

''' <summary>
''' Counts how many ways there are to place N queens on an N x N chessboard so that no two queens
''' attack each other.
''' </summary>
Public Class NQueensSolver
    Public Shared Function Sequential(ByVal n As Integer) As Integer
        Return New NQueensState(n).CountSolutions()
    End Function

    Public Shared Function Parallel(ByVal n As Integer) As Integer
        Dim statesAfterOneMove(n - 1) As NQueensState
        For row = 0 To n - 1
            statesAfterOneMove(row) = New NQueensState(n)
            statesAfterOneMove(row).PlaceQueen(row)
        Next

        Return (From q In statesAfterOneMove.AsParallel()
                Select q.CountSolutions()).Sum()
    End Function

    Class NQueensState
        Private m_rows() As Boolean        ' m_rows[i] = does row i contain a queen?
        Private m_fwDiagonals() As Boolean ' m_fwDiagonals[i] = does forward diagonal i contain a queen?
        Private m_bwDiagonals() As Boolean ' m_bwDiagonals[i] = does backward diagonal i contain a queen?
        Private m_size As Integer ' Size of the chessboard
        Private m_col As Integer   ' Column with the smallest index that does not contain a queen, 0 <= m_col < m_size

        Public Sub New(ByVal size As Integer)
            m_size = size
            ReDim m_rows(size - 1)
            ReDim m_fwDiagonals(2 * size - 2)
            ReDim m_bwDiagonals(2 * size - 2)
            m_col = 0
        End Sub

        Public Function CountSolutions() As Integer
            If m_col = m_size Then Return 1
            Dim answer = 0
            For row = 0 To m_size - 1
                If PlaceQueen(row) Then
                    answer = answer + CountSolutions()
                    RemoveQueen(row)
                End If
            Next
            Return answer
        End Function

        Public Function PlaceQueen(ByVal row As Integer) As Boolean
            If Not m_rows(row) AndAlso Not m_fwDiagonals(row + m_col) AndAlso Not m_bwDiagonals(row - m_col + m_size - 1) Then
                m_rows(row) = True
                m_fwDiagonals(row + m_col) = True
                m_bwDiagonals(row - m_col + m_size - 1) = True
                m_col = m_col + 1
                Return True
            End If
            Return False
        End Function

        Private Sub RemoveQueen(ByVal row As Integer)
            m_col = m_col - 1
            m_rows(row) = False
            m_fwDiagonals(row + m_col) = False
            m_bwDiagonals(row - m_col + m_size - 1) = False
        End Sub
    End Class
End Class