'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ImageManipulation.vb
'
'--------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.Drawing

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
    ''' <summary>Class for manipulating the colors in images.</summary>
    Friend Class ImageManipulation
        ''' <summary>Event that notifies of progress changes in image operations.</summary>
        Public Event ProgressChanged As ProgressChangedEventHandler

        ''' <summary>Implements a b&w + hue-based transformation for an image.</summary>
        ''' <param name="original">The original image.</param>
        ''' <param name="selectedPixels">The location in the original image of the selected pixels for hue
        ''' comparison.</param>
        ''' <param name="epsilon">Allowed hue variation from selected pixels.</param>
        ''' <param name="paths">GraphicPath instances demarcating regions containing possible pixels to be
        ''' left in color.</param>
        ''' <param name="parallel">Whether to run in parallel.</param>
        ''' <returns>The new Bitmap.</returns>
        Public Function Colorize(ByVal original As Bitmap, ByVal selectedPixels As List(Of Point), ByVal epsilon As Integer,
            ByVal paths As List(Of GraphicsPath), ByVal parallel As Boolean) As Bitmap
            ' Create a new bitmap with the same size as the original.
            Dim width = original.Width
            Dim height = original.Height
            Dim colorizedImage As New Bitmap(width, height)

            ' Optimization: For every GraphicsPath, get a bounding rectangle.  This allows for quickly
            ' ruling out pixels that are definitely not containing within the selected region.
            Dim pathsBounds() As Rectangle = Nothing
            If paths IsNot Nothing AndAlso paths.Count > 0 Then
                pathsBounds = New Rectangle(paths.Count - 1) {}
                For i = 0 To pathsBounds.Length - 1
                    pathsBounds(i) = Rectangle.Ceiling(paths(i).GetBounds())
                Next i
            End If

            ' Optimization: Hit-testing against GraphicPaths is relatively slow.  Hit testing
            ' against rectangles is very fast.  As such, appromixate the area of the GraphicsPath
            ' with rectangles which can be hit tested against instead of the paths.  Not quite
            ' as accurate, but much faster.
            Dim compositions As List(Of RectangleF()) = Nothing
            If paths IsNot Nothing AndAlso paths.Count > 0 Then
                compositions = New List(Of RectangleF())(paths.Count)
                Using m As New Matrix()
                    For i = 0 To paths.Count - 1
                        Using r As New Region(paths(i))
                            compositions.Add(r.GetRegionScans(m))
                        End Using
                    Next i
                End Using
            End If

            ' Use FastBitmap instances to provide unsafe/faster access to the pixels
            ' in the original and in the new images.
            Using fastColorizedImage As New FastBitmap(colorizedImage)
                Using fastOriginalImage As New FastBitmap(original)
                    ' Extract the selected hues from the selected pixels.
                    Dim selectedHues As New List(Of Single)(selectedPixels.Count)
                    For Each p In selectedPixels
                        selectedHues.Add(fastOriginalImage.GetColor(p.X, p.Y).GetHue())
                    Next p

                    ' For progress update purposes, figure out how many pixels there
                    ' are in total, and how many constitute 1% so that we can raise
                    ' events after every additional 1% has been completed.
                    Dim totalPixels = height * width
                    Dim pixelsPerProgressUpdate = totalPixels \ 100
                    If pixelsPerProgressUpdate = 0 Then
                        pixelsPerProgressUpdate = 1
                    End If
                    Dim pixelsProcessed = 0

                    ' Pixels close to the selected hue but not close enough may be
                    ' left partially desaturated.  The saturation window determines
                    ' what pixels fall into that range.
                    Const maxSaturationWindow = 10
                    Dim saturationWindow = Math.Min(maxSaturationWindow, epsilon)

                    ' Separated out the body of the loop just to make it easier
                    ' to switch between sequential and parallel for demo purposes.
                    Dim processRow As Action(Of Integer) = Sub(y)
                                                               For x = 0 To width - 1
                                                                   ' Get the color/hue of th epixel.
                                                                   Dim c = fastOriginalImage.GetColor(x, y)
                                                                   Dim pixelHue = c.GetHue()

                                                                   ' Use hit-testing to determine if the pixel is in the selected region.
                                                                   Dim pixelInSelectedRegion = False

                                                                   ' First, if there are no paths, by definition it is in the selected
                                                                   ' region, since the whole image is then selected.
                                                                   If paths Is Nothing OrElse paths.Count = 0 Then
                                                                       pixelInSelectedRegion = True
                                                                   Else
                                                                       ' For each path, first see if the pixel is within the bounding
                                                                       ' rectangle; if it's not, it's not in the selected region.
                                                                       Dim p As New Point(x, y)
                                                                       Dim i = 0
                                                                       Do While i < pathsBounds.Length AndAlso Not pixelInSelectedRegion
                                                                           If pathsBounds(i).Contains(p) Then
                                                                               ' The pixel is within a bounding rectangle, so now
                                                                               ' see if it's within the composition rectangles
                                                                               ' approximating the region.
                                                                               For Each bound In compositions(i)
                                                                                   If bound.Contains(x, y) Then
                                                                                       ' If it is, it's in the region.
                                                                                       pixelInSelectedRegion = True
                                                                                       Exit For
                                                                                   End If
                                                                               Next bound
                                                                           End If
                                                                           i += 1
                                                                       Loop
                                                                   End If

                                                                   ' Now that we know whether a pixel is in the region,
                                                                   ' we can figure out what to do with it.  If the pixel
                                                                   ' is not in the selected region, it needs to be converted
                                                                   ' to grayscale.
                                                                   Dim useGrayscale = True
                                                                   If pixelInSelectedRegion Then
                                                                       ' If it is in the selected region, get the color hue's distance 
                                                                       ' from each target hue.  If that distance is less than the user-selected
                                                                       ' hue variation limit, leave it in color.  If it's greater than the
                                                                       ' variation limit, but within the saturation window of the limit,
                                                                       ' desaturate it proportionally to the distance from the limit.
                                                                       For Each selectedHue In selectedHues
                                                                           ' A hue wheel is 360 degrees. If you pick two points on a wheel, there
                                                                           ' will be two distances between them, depending on which way you go around
                                                                           ' the wheel from one to the other (unless they're exactly opposite from
                                                                           ' each other on the wheel, the two distances will be different).  We always
                                                                           ' want to do our work based on the smaller of the two distances (e.g. a hue
                                                                           ' with the value 359 is very, very close to a hue with the value 1).  So,
                                                                           ' we take the absolute value of the difference between the two hues.  If that
                                                                           ' distance is 180 degrees, then both distances are the same, so it doesn't
                                                                           ' matter which we go with. If that difference is less than 180 degrees, 
                                                                           ' we know this must be the smaller of the two distances, since the sum of the 
                                                                           ' two distances must add up to 360.  If, however, it's larger than 180, it's the
                                                                           ' longer distance, so to get the shorter one, we have to subtract it from 360.
                                                                           Dim distance = Math.Abs(pixelHue - selectedHue)
                                                                           If distance > 180 Then
                                                                               distance = 360 - distance
                                                                           End If

                                                                           If distance <= epsilon Then
                                                                               useGrayscale = False
                                                                               Exit For
                                                                           ElseIf (distance - epsilon) / saturationWindow < 1.0F Then
                                                                               useGrayscale = False
                                                                               c = ColorFromHsb(pixelHue, c.GetSaturation() * (1.0F - ((distance - epsilon) / maxSaturationWindow)),
                                                                                        c.GetBrightness())
                                                                               Exit For
                                                                           End If
                                                                       Next selectedHue
                                                                   End If

                                                                   ' Set the pixel color into the new image.
                                                                   If useGrayscale Then
                                                                       c = ToGrayscale(c)
                                                                   End If
                                                                   fastColorizedImage.SetColor(x, y, c)
                                                               Next x

                                                               ' Notify any listeners of our progress, if enough progress has been made.
                                                               Interlocked.Add(pixelsProcessed, width)
                                                               OnProgressChanged(CInt(Fix(100 * pixelsProcessed / CDbl(totalPixels))))
                                                           End Sub

                    ' Copy over every single pixel, and possibly transform it in the process.
                    If parallel Then
                        System.Threading.Tasks.Parallel.For(0, height, processRow)
                    Else
                        For y = 0 To height - 1
                            processRow(y)
                        Next y
                    End If
                End Using
            End Using

            ' We're done creating the image.  Return it.
            Return colorizedImage
        End Function

        ''' <summary>Notifies any ProgressChanged subscribers of a progress update.</summary>
        ''' <param name="progressPercentage">The progress percentage.</param>
        Private Sub OnProgressChanged(ByVal progressPercentage As Integer)
            RaiseEvent ProgressChanged(Me, New ProgressChangedEventArgs(progressPercentage, Nothing))
        End Sub

        ''' <summary>Converts a color to grayscale.</summary>
        ''' <param name="c">The color to convert.</param>
        ''' <returns>The grayscale color.</returns>
        Private Shared Function ToGrayscale(ByVal c As Color) As Color
            Dim luminance = CInt(Fix(0.299 * c.R + 0.587 * c.G + 0.114 * c.B))
            Return Color.FromArgb(luminance, luminance, luminance)
        End Function

        ''' <summary>HSB to RGB color conversion.</summary>
        ''' <param name="h">The color's hue.</param>
        ''' <param name="s">The color's saturation.</param>
        ''' <param name="b">The color's brightness.</param>
        ''' <returns>The RGB color for the supplied HSB values.</returns>
        ''' <remarks>
        ''' Based on Chris Jackson's conversion routine from:
        ''' http://blogs.msdn.com/cjacks/archive/2006/04/12/575476.aspx
        ''' </remarks>
        Private Shared Function ColorFromHsb(ByVal h As Single, ByVal s As Single, ByVal b As Single) As Color
            If 0.0F > h OrElse 360.0F < h Then
                Throw New ArgumentOutOfRangeException("h")
            End If
            If 0.0F > s OrElse 1.0F < s Then
                Throw New ArgumentOutOfRangeException("s")
            End If
            If 0.0F > b OrElse 1.0F < b Then
                Throw New ArgumentOutOfRangeException("b")
            End If

            If 0 = s Then
                Return Color.FromArgb(CInt(Fix(b * 255)), CInt(Fix(b * 255)), CInt(Fix(b * 255)))
            End If

            Dim fMax, fMid, fMin As Single
            Dim iSextant, iMax, iMid, iMin As Integer

            If 0.5 < b Then
                fMax = b - (b * s) + s
                fMin = b + (b * s) - s
            Else
                fMax = b + (b * s)
                fMin = b - (b * s)
            End If

            iSextant = CInt(Fix(h / 60.0F))
            If 300.0F <= h Then
                h -= 360.0F
            End If
            h /= 60.0F
            h -= 2.0F * CSng(Math.Floor(((iSextant + 1.0F) Mod 6.0F) / 2.0F))
            If 0 = iSextant Mod 2 Then
                fMid = h * (fMax - fMin) + fMin
            Else
                fMid = fMin - h * (fMax - fMin)
            End If

            iMax = CInt(Fix(fMax * 255))
            iMid = CInt(Fix(fMid * 255))
            iMin = CInt(Fix(fMin * 255))

            Select Case iSextant
                Case 1
                    Return Color.FromArgb(iMid, iMax, iMin)
                Case 2
                    Return Color.FromArgb(iMin, iMax, iMid)
                Case 3
                    Return Color.FromArgb(iMin, iMid, iMax)
                Case 4
                    Return Color.FromArgb(iMid, iMin, iMax)
                Case 5
                    Return Color.FromArgb(iMax, iMin, iMid)
                Case Else
                    Return Color.FromArgb(iMax, iMid, iMin)
            End Select
        End Function
    End Class
End Namespace