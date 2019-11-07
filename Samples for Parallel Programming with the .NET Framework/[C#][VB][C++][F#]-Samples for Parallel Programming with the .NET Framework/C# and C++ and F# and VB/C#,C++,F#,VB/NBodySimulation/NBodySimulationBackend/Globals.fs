//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: globals.fs
//
//--------------------------------------------------------------------------

module Globals

open Microsoft.FSharp.Math

open System.Windows.Media
open System.ComponentModel
open System
open System.Threading.Tasks

let epsilonValue = 1.0e-2
let nominalMass=1.0e-9<SI.kg>          
let gravity = PhysicalConstants.G

let mutable gNumParticles = 128

let timeStepSize = 100.0<SI.s>

let drawParticleSizeScale = 0.2
let particleSystemCentroid = -1.0/1.0e8<SI.s> 

let defaultFocalColor = Colors.White

let mutable gNumCoresUsed = Environment.ProcessorCount
let op = new ParallelOptions()
op.MaxDegreeOfParallelism <- gNumCoresUsed 

let mutable rand = new System.Random(4)
let rd() = (rand.NextDouble()) 
let rs() = (2.0 * ((rand.NextDouble()) - 0.5))  // random number between -1, 1
let qPosRnd () =  rand.NextDouble()          
let qNegRnd () = -1.0 * rand.NextDouble()       // random number between -1, 0

type particle =     
    struct
        val mutable px: float<SI.m>
        val mutable py: float<SI.m>
        val mutable vx: float<SI.m/SI.s>
        val mutable vy: float<SI.m/SI.s>
        
        val mutable mass: float<SI.kg>        
        new(xpos:float<SI.m>, ypos:float<SI.m>, 
            xvel:float<SI.m/SI.s>, yvel:float<SI.m/SI.s>, 
            m:float<SI.kg>)
            = 
            { px = xpos; 
              py = ypos;
              vx = xvel; 
              vy = yvel; 
              mass = m }
    end
    
[<Struct>]
type point<[<Measure>]'u> =
    val mutable x: float<'u>    
    val mutable y: float<'u>
    new(newx,newy) = { x = newx; y = newy}
    static member (-) (p1:point<'u>, p2:point<'u>) = new point<'u>(p1.x-p2.x, p1.y-p2.y)

type quadrants = 
    | I = 0
    | II = 1
    | III = 2
    | IV = 3
    | Root = 4
    
/// Returns the enum quadrants values in an array
let enumeratedQuadrantsArray =
    seq { for i in 0..3 do yield enum<quadrants>(i)}
    |> Seq.toArray

let spawnUniformly quadrantNumber =
    let initVel = 0.0<SI.m/SI.s>
    match quadrantNumber with 
    | quadrants.I ->particle( qPosRnd()*1.0<SI.m>, qPosRnd()*1.0<SI.m>, initVel, initVel, (rd() + 0.0) * nominalMass * 50000.0 )
    | quadrants.II -> particle( qNegRnd()*1.0<SI.m>,qPosRnd()*1.0<SI.m>, initVel, initVel, (rd() + 0.0) * nominalMass * 50000.0 )
    | quadrants.III -> particle( qNegRnd()*1.0<SI.m>,qNegRnd()*1.0<SI.m>, initVel, initVel, (rd() + 0.0) * nominalMass * 50000.0 )
    | quadrants.IV -> particle( qPosRnd()*1.0<SI.m>,qNegRnd()*1.0<SI.m>, initVel, initVel, (rd() + 0.0) * nominalMass * 50000.0 )
    | _ -> failwithf "either you sent a root, or unknown quadrant matched"

let fillParticleArray i = 
    match i with 
    | x when x < gNumParticles/4 -> spawnUniformly quadrants.I
    | x when x < gNumParticles/2 -> spawnUniformly quadrants.II
    | x when x < (3*gNumParticles)/4 -> spawnUniformly quadrants.III  
    | x when x <= gNumParticles -> spawnUniformly quadrants.IV 

let mutable globalState = Array.init gNumParticles (fun i -> fillParticleArray i)

let restart() =     
    rand <- new System.Random(4)
    globalState <- Array.mapi( fun i ele -> fillParticleArray i) globalState
    
let changeNumberOfParticles newNumber = 
    rand <- new System.Random(4)
    gNumParticles <- newNumber    
    globalState <- Array.init newNumber (fun i -> fillParticleArray i)
    GC.Collect()
    
let globalParticleList (arr:particle array) =
    List.ofArray arr