'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: RayTracer.vb
'
'--------------------------------------------------------------------------

Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Generic

Friend Class RayTracer
    Private screenWidth, screenHeight As Integer
    Private viewWidth, viewHeight As Integer
    Private Const MaxDepth As Integer = 5

    Public Sub New(ByVal screenWidth As Integer, ByVal screenHeight As Integer)
        Me.screenWidth = screenWidth
        Me.screenHeight = screenHeight
    End Sub

    Friend Sub RenderSequential(ByVal scene As Scene, ByVal rgb As Int32())
        ' Renders the scene sequentially using a standard Visual Basic For loop
        For y = 0 To screenHeight - 1
            Dim stride = y * screenWidth
            Dim camera = scene.Camera
            For x = 0 To screenWidth - 1
                Dim color = TraceRay(New Ray(camera.Position, GetPoint(x, y, camera)), scene, 0)
                rgb(x + stride) = color.ToInt32()
            Next
        Next
    End Sub

    Friend Sub RenderParallel(ByVal scene As Scene, ByVal rgb As Int32(), ByVal options As ParallelOptions)
        ' Renders the scene in parallel using a Parallel Extensions Parallel.For
        Parallel.For(0, screenHeight, options,
            Sub(y)
                Dim stride = y * screenWidth
                Dim camera = scene.Camera
                For x = 0 To screenWidth - 1
                    Dim color = TraceRay(New Ray(camera.Position, GetPoint(x, y, camera)), scene, 0)
                    rgb(x + stride) = color.ToInt32()
                Next
            End Sub)
    End Sub

    Friend Sub RenderParallelShowingThreads(ByVal scene As Scene, ByVal rgb As Int32(), ByVal options As ParallelOptions)
        Dim id = 0
        Parallel.For(0, screenHeight, options, Function() GetHueShift(Interlocked.Increment(id)),
            Function(y, state, hue)
                Dim stride = y * screenWidth
                Dim camera = scene.Camera
                For x = 0 To screenWidth - 1
                    Dim color = TraceRay(New Ray(camera.Position, GetPoint(x, y, camera)), scene, 0)
                    color.ChangeHue(hue)
                    rgb(x + stride) = color.ToInt32()
                Next
                Return hue
            End Function,
            Sub(hue)
                Interlocked.Decrement(id)
            End Sub)
    End Sub

    Private _numToHueShiftLookup As New Dictionary(Of Integer, Double)
    Private _rand As New Random()

    Private Function GetHueShift(ByVal id As Integer) As Double
        Dim shift As Double
        SyncLock _numToHueShiftLookup
            If Not _numToHueShiftLookup.TryGetValue(id, shift) Then
                shift = _rand.NextDouble()
                _numToHueShiftLookup.Add(id, shift)
            End If
        End SyncLock
        Return shift
    End Function

    Friend ReadOnly DefaultScene As Scene = CreateDefaultScene()

    Private Shared Function CreateDefaultScene() As Scene
        Dim things = New SceneObject() {
                  New Sphere(New Vector(-0.5, 1, 1.5), 0.5, Surfaces.MatteShiny),
                  New Sphere(New Vector(0, 1, -0.25), 1, Surfaces.Shiny),
                  New Plane(New Vector(0, 1, 0), 0, Surfaces.CheckerBoard)}

        Dim lights = New Light() {
              New Light(New Vector(-2, 2.5, 0), New Color(0.5, 0.45, 0.41)),
              New Light(New Vector(2, 4.5, 2), New Color(0.99, 0.95, 0.8))}

        Dim eye = Camera.Create(New Vector(2.75, 2, 3.75), New Vector(-0.6, 0.5, 0))

        Return New Scene(things, lights, eye)
    End Function

    Private Function MinIntersection(ByVal ray As Ray, ByVal scene As Scene) As ISect
        Dim min As ISect = Nothing
        For Each obj In scene.Things
            Dim isect = obj.Intersect(ray)
            If isect IsNot Nothing Then
                If min Is Nothing OrElse min.Dist > isect.Dist Then min = isect
            End If
        Next
        Return min
    End Function

    Private Function TestRay(ByVal ray As Ray, ByVal scene As Scene) As Double
        Dim sect = MinIntersection(ray, scene)
        If sect Is Nothing Then Return 0
        Return sect.Dist
    End Function

    Private Function TraceRay(ByVal ray As Ray, ByVal scene As Scene, ByVal depth As Integer) As Color
        Dim sect = MinIntersection(ray, scene)
        If sect Is Nothing Then Return Color.Background
        Return Shade(sect, scene, depth)
    End Function

    Private Function GetNaturalColor(ByVal thing As SceneObject, ByVal pos As Vector, ByVal norm As Vector, ByVal rd As Vector, ByVal scene As Scene) As Color
        Dim ret = New Color(0, 0, 0)
        For Each light In scene.Lights
            Dim ldis = Vector.Minus(light.Position, pos)
            Dim livec = Vector.Norm(ldis)
            Dim neatIsect = TestRay(New Ray(pos, livec), scene)
            Dim isInShadow = Not (neatIsect > Vector.Mag(ldis) OrElse neatIsect = 0)
            If Not isInShadow Then
                Dim illum = Vector.Dot(livec, norm)
                Dim lcolor = If(illum > 0, Color.Times(illum, light.Color), New Color(0, 0, 0))
                Dim specular = Vector.Dot(livec, Vector.Norm(rd))
                Dim scolor = If(specular > 0, Color.Times(Math.Pow(specular, thing.Surface.Roughness), light.Color), New Color(0, 0, 0))
                ret = Color.Plus(ret, Color.Plus(Color.Times(thing.Surface.Diffuse(pos), lcolor),
                                                 Color.Times(thing.Surface.Specular(pos), scolor)))
            End If
        Next
        Return ret
    End Function

    Private Function GetReflectionColor(ByVal thing As SceneObject, ByVal pos As Vector, ByVal norm As Vector, ByVal rd As Vector, ByVal scene As Scene, ByVal depth As Integer) As Color
        Return Color.Times(thing.Surface.Reflect(pos), TraceRay(New Ray(pos, rd), scene, depth + 1))
    End Function

    Private Function Shade(ByVal isect As ISect, ByVal scene As Scene, ByVal depth As Integer) As Color
        Dim d = isect.Ray.Direction
        Dim pos = Vector.Plus(Vector.Times(isect.Dist, isect.Ray.Direction), isect.Ray.Start)
        Dim normal = isect.Thing.Normal(pos)
        Dim reflectDir = Vector.Minus(d, Vector.Times(2 * Vector.Dot(normal, d), normal))
        Dim ret = Color.Plus(Color.DefaultColor, GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene))
        If depth >= MaxDepth Then Return Color.Plus(ret, New Color(0.5, 0.5, 0.5))
        Return Color.Plus(ret, GetReflectionColor(isect.Thing, Vector.Plus(pos, Vector.Times(0.001, reflectDir)), normal, reflectDir, scene, depth))
    End Function

    Private Function RecenterX(ByVal x As Double) As Double
        Return (x - (screenWidth / 2.0)) / (2.0 * screenWidth)
    End Function

    Private Function RecenterY(ByVal y As Double) As Double
        Return -(y - (screenHeight / 2.0)) / (2.0 * screenHeight)
    End Function

    Private Function GetPoint(ByVal x As Double, ByVal y As Double, ByVal camera As Camera) As Vector
        Return Vector.Norm(Vector.Plus(camera.Forward, Vector.Plus(Vector.Times(RecenterX(x), camera.Right),
                                                                   Vector.Times(RecenterY(y), camera.Up))))
    End Function
End Class