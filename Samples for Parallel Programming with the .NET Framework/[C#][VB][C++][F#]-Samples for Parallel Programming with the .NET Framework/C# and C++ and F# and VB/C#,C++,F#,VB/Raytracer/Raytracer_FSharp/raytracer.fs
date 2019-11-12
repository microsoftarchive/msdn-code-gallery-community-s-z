//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: raytracer.fs
//
//--------------------------------------------------------------------------

#light

module Raytracer_FSharp

open System
open System.Windows.Forms
open System.Drawing
open System.Threading
open System.Threading.Tasks

type Vector(x:float, y:float, z:float) = 
    member this.X = x
    member this.Y = y
    member this.Z = z
    static member ( * ) (k, (v:Vector)) = Vector(k*v.X, k*v.Y, k*v.Z)
    static member ( - ) (v1:Vector, v2:Vector) = Vector(v1.X-v2.X, v1.Y-v2.Y, v1.Z-v2.Z)
    static member ( + ) (v1:Vector, v2:Vector) = Vector(v1.X+v2.X, v1.Y+v2.Y, v1.Z+v2.Z)
    static member Dot (v1:Vector, v2:Vector) = v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z
    static member Mag (v:Vector) = sqrt(v.X*v.X + v.Y*v.Y + v.Z*v.Z)
    static member Norm (v:Vector) = 
        let mag = Vector.Mag v
        let div = if mag = 0.0 then infinity else 1.0/mag 
        div * v
    static member Cross (v1:Vector, v2:Vector) = 
        Vector(v1.Y * v2.Z - v1.Z * v2.Y,
               v1.Z * v2.X - v1.X * v2.Z,
               v1.X * v2.Y - v1.Y * v2.X)

type Color(r:float, g:float, b:float) = 
    static member private floatToInt c = let c' = int (255.0 * c) in if c' > 255 then 255 else c'
    static member private legalize d = if d > 1.0 then 1.0 else d
    member this.R = r
    member this.G = g
    member this.B = b
    member this.ToDrawingColor () = System.Drawing.Color.FromArgb(this.ToInt())
    member this.ToInt () = (Color.floatToInt b) ||| (Color.floatToInt g <<< 8) ||| (Color.floatToInt r <<< 16) ||| (255 <<< 24)
    member this.ShiftHue(hue) = 
        let c = this.ToDrawingColor()
        let h,s,l = hue, 0.9, ((float(c.GetBrightness()) - 0.5) * 0.5) + 0.5
        match s,l with
        | _, 0.0 -> Color(0.0,0.0,0.0)
        | 0.0, _ -> Color(float l,float l,float l)
        | s,l -> 
            let temp2 = if l <= 0.5 then l * (1.0 + s) else l + s - (l * s)
            let temp1 = 2.0 * l - temp2
            let convert x =
                let x = if x < 0.0 then x + 1.0 elif x > 1.0 then x - 1.0 else x
                if x < 1.0/6.0 then temp1 + (temp2 - temp1) * x* 6.0
                elif x < 1.0/2.0 then temp2
                elif x< 2.0/3.0 then (temp1 + (temp2 - temp1) * ((2.0/3.0) - x))
                else temp1
            let c1,c2,c3 = (convert(h + 1.0/3.0), convert(h), convert(h - 1.0/3.0))
            new Color(c1, c2, c3)        
    static member Scale (k, v:Color) = Color(k*v.R, k*v.G, k*v.B)
    static member ( + ) (v1:Color, v2:Color) = Color(v1.R+v2.R, v1.G+v2.G, v1.B+v2.B)
    static member ( * ) (v1:Color, v2:Color) = Color(v1.R*v2.R, v1.G*v2.G, v1.B*v2.B)
    static member Background = Color(0.0,0.0,0.0)
    static member DefaultColor = Color(0.0,0.0,0.0)
    
type Ray = 
    { Start: Vector; 
      Dir: Vector}

type Surface = 
    abstract Diffuse: Vector -> Color; 
    abstract Specular: Vector -> Color; 
    abstract Reflect: Vector -> double; 
    abstract Roughness : double

type Intersection = 
    { Thing: SceneObject; 
      Ray: Ray; 
      Dist: double}

and SceneObject = 
    abstract Surface : Surface
    abstract Intersect : Ray -> Intersection option
    abstract Normal : Vector -> Vector

let Sphere(center, radius, surface) =
    let radius2 = radius * radius
    { new SceneObject with 
        member this.Surface = surface
        member this.Normal pos = Vector.Norm(pos - center)
        member this.Intersect (ray : Ray)  =
            let eo = center - ray.Start
            let v = Vector.Dot(eo, ray.Dir)
            let dist = 
                if (v<0.0) 
                then 0.0
                else let disc = radius2 - (Vector.Dot(eo,eo) - (v*v))
                     if disc < 0.0
                     then 0.0
                     else v - (sqrt(disc))
            if dist = 0.0 
            then None
            else Some {Thing = this; Ray = ray; Dist = dist} 
    }

let Plane(norm, offset, surface) =           
    { new SceneObject with
        member this.Surface = surface
        member this.Normal pos = norm
        member this.Intersect (ray) =
            let denom = Vector.Dot(norm, ray.Dir)
            if denom > 0.0
            then None
            else let dist = (Vector.Dot(norm, ray.Start) + offset) / (-denom) 
                 Some { Thing = this; Ray = ray; Dist = dist }
    }

type Camera(pos : Vector, lookAt : Vector) = 
    let forward = Vector.Norm(lookAt - pos)
    let down = Vector(0.0,-1.0,0.0)
    let right = 1.5 * Vector.Norm(Vector.Cross(forward, down))
    let up = 1.5 * Vector.Norm(Vector.Cross(forward, right))
    member c.Pos     = pos
    member c.Forward = forward
    member c.Up      = up
    member c.Right   = right

type Light = 
    { Pos : Vector;
      Color : Color }
           
type Scene = 
    { Things : SceneObject list;
      Lights : Light list;
      Camera : Camera }
    
type RayTracer(screenWidth, screenHeight) = 

    let maxDepth = 5

    let Intersections ray scene =
        scene.Things
        |> List.choose (fun obj -> obj.Intersect(ray))
        |> List.sortBy (fun inter-> inter.Dist)
        
    let TestRay (ray, scene)=
        match Intersections ray scene with
        | [] -> None
        | isect::_ -> Some isect.Dist
        
    let rec TraceRay (ray,scene,depth : int) = 
        match Intersections ray scene with
        | [] -> Color.Background
        | isect::_ -> Shade isect  scene  depth
    
    and Shade isect scene depth = 
        let d = isect.Ray.Dir
        let pos = isect.Dist * d + isect.Ray.Start
        let normal = isect.Thing.Normal(pos)
        let reflectDir = d - 2.0 * Vector.Dot(normal, d) * normal
        let naturalcolor = Color.DefaultColor +
                           GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene)
        let reflectedColor = if depth >= maxDepth
                             then Color(0.5,0.5,0.5)
                             else GetReflectionColor(isect.Thing, pos + (0.001*reflectDir), normal, reflectDir, scene, depth)
        naturalcolor + reflectedColor

    and GetReflectionColor (thing : SceneObject ,pos,normal : Vector,rd : Vector,scene : Scene, depth : int) = 
        Color.Scale(thing.Surface.Reflect(pos), TraceRay ( { Start = pos; Dir = rd }, scene, depth + 1))
    
    and GetNaturalColor (thing, pos, norm, rd, scene) =
        let addLight col (light : Light) = 
            let ldis = light.Pos - pos
            let livec = Vector.Norm(ldis)
            let neatIsect = TestRay({Start = pos; Dir = livec}, scene)
            let isInShadow = match neatIsect with 
                             | None -> false 
                             | Some d -> not (d > Vector.Mag(ldis))
            if isInShadow
            then col
            else let illum = Vector.Dot(livec, norm)
                 let lcolor = if illum > 0.0
                              then Color.Scale(illum, light.Color)
                              else Color.DefaultColor
                 let specular = Vector.Dot(livec, Vector.Norm(rd))
                 let scolor = if specular > 0.0 
                              then Color.Scale(System.Math.Pow(specular, thing.Surface.Roughness), light.Color)
                              else Color.DefaultColor
                 col + thing.Surface.Diffuse(pos) * lcolor +
                       thing.Surface.Specular(pos) * scolor
        List.fold addLight
                       Color.DefaultColor
                       scene.Lights
    
    let GetPoint x y (camera:Camera) =
        let RecenterX x =  (float x - (float screenWidth / 2.0))  / (2.0 * float screenWidth)
        let RecenterY y = -(float y - (float screenHeight / 2.0)) / (2.0 * float screenHeight)
        Vector.Norm(camera.Forward + RecenterX(x) * camera.Right + RecenterY(y) * camera.Up)

    let rand = new Random()
    let numToHueShiftLookup = new System.Collections.Generic.Dictionary<int,double>()
                                                 
    member this.RenderSequential(scene, rgb : int[]) = 
        for y = 0 to  screenHeight - 1 do
            let stride = y * screenWidth
            for x = 0 to screenWidth - 1 do 
                let color = TraceRay ({Start = scene.Camera.Pos; Dir = GetPoint x y scene.Camera }, scene, 0)
                let intColor = color.ToInt ()
                rgb.[x + stride] <- intColor
                
    member this.RenderParallel(scene, rgb : int[], options) = 
        Parallel.For(0, screenHeight, options, fun y -> 
            let stride = y * screenWidth
            for x = 0 to screenWidth - 1 do 
                let color = TraceRay ({Start = scene.Camera.Pos; Dir = GetPoint x y scene.Camera }, scene, 0)
                let intColor = color.ToInt ()
                rgb.[x + stride] <- intColor)
        |> ignore

    member this.RenderParallelShowingThreads(scene, rgb : int[], options) = 
        let hueShift id = 
            let shift = ref 0.0
            lock numToHueShiftLookup (fun () -> 
                let exists = numToHueShiftLookup.TryGetValue(id, shift)
                if not exists 
                then shift := rand.NextDouble()
                     numToHueShiftLookup.Add(id,!shift)
            )
            !shift
        let id = ref 0
        Parallel.For(0, screenHeight, options, Func<float>(fun () -> hueShift(Interlocked.Increment(id))), (fun y state hue -> 
            let stride = y * screenWidth
            for x = 0 to screenWidth - 1 do 
                let color = TraceRay ({Start = scene.Camera.Pos; Dir = GetPoint x y scene.Camera }, scene, 0)
                let intColor = color.ShiftHue(hue).ToInt()
                rgb.[x + stride] <- intColor
            hue),
            Action<float>(fun hue -> 
                Interlocked.Decrement(id) 
                |> ignore))
        |> ignore