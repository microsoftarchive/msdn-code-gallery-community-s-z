//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: NBodyParallelized.fs
//
//--------------------------------------------------------------------------

module NBodyParallelized

open Globals
open Microsoft.FSharp.Math
open System.Threading.Tasks

/// Helper function to compute the acceleration of a particle (Param: curParticle)
/// First three Params (mass, x and y component of exerting Particle)
/// Computes the force exerted on curParticle by the exerting particle)
/// Returns the new acceleration of the particle
let computeAcceleration exertingParticleMass exertingParticlePosX exertingParticlePosY (curParticle:particle) =
    
    let distanceBetweenParticles (dx:float<'u>) (dy:float<'u>) =
        sqrt((dx*dx) + (dy*dy))

    let dx = exertingParticlePosX - curParticle.px
    let dy = exertingParticlePosY - curParticle.py
    let r = distanceBetweenParticles dx dy

    if r = 0.0<_> then 
        new point<_>(0.0<_>,0.0<_>)
    else
        let massProduct = curParticle.mass * exertingParticleMass
        let r2 = r * r 
        let f = massProduct * gravity / (if (r2) < epsilonValue * 1.0<SI.m^2> then epsilonValue*1.0<SI.m^2> else r2)
        let ax = ( dx / r ) * f / curParticle.mass
        let ay = ( dy / r ) * f / curParticle.mass
        new point<_>(ax,ay)

        
// Computes the new velocity of a particle (Aggregate the force vectors and stores them into global velocity array)
// O(n) operation
let computeVelocity (step:float<SI.s>) index (ele:particle) =
    let mutable vel = new point<_>(0.0<SI.m/SI.s>,0.0<SI.m/SI.s>) 
    let mutable curIndex = 0
    while curIndex < gNumParticles do
        let ele2 = globalState.[curIndex]
        let accel = computeAcceleration ele2.mass ele2.px ele2.py ele 
        vel.x <- (step * accel.x) + (vel.x)
        vel.y <- (step * accel.y) + (vel.y)
        curIndex <- curIndex + 1
    globalState.[index].vx <- ele.vx + vel.x
    globalState.[index].vy <- ele.vy + vel.y


// uses a Parallel For to iterate across the particles to compute the new velocity of each particle
let UpdateParticlesParallelFor (step:float<SI.s>) (inParallel:bool) =            
    if inParallel then
        op.MaxDegreeOfParallelism <- gNumCoresUsed                
    else
        op.MaxDegreeOfParallelism <- 1
    let _= Parallel.For(0, gNumParticles, op,
            fun index ->
                computeVelocity step index globalState.[index] )
    ()
