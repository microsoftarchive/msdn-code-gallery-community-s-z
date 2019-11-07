#light
#nowarn "47"

open System
open System.Windows.Forms
open System.Drawing
open System.Drawing.Imaging
open System.Diagnostics
open System.Runtime.InteropServices
open System.Threading
open System.Threading.Tasks
open System.Collections.Concurrent
open Raytracer_FSharp

let mutable width = 400
let mutable height = 400

module Surfaces = 
    let Shiny = 
        { new Surface with 
            member s.Diffuse pos = Color(1.0,1.0,1.0) 
            member s.Specular pos = Color(0.5,0.5,0.5)
            member s.Reflect pos = 0.7
            member s.Roughness = 250.0 }
    let MatteShiny = 
        { new Surface with
            member s.Diffuse pos = Color(1.0,1.0,1.0)
            member s.Specular pos = Color(0.25,0.25,0.25)
            member s.Reflect pos = 0.7
            member s.Roughness = 250.0 }
    let Checkerboard = 
        { new Surface with 
            member s.Diffuse pos =
                if (int (System.Math.Floor(pos.Z) + System.Math.Floor(pos.X))) % 2 <> 0
                then Color(1.0,1.0,1.0)
                else Color(0.0,0.0,0.0);
            member s.Specular pos = Color(1.0,1.0,1.0);
            member s.Reflect pos =
                if (int (System.Math.Floor(pos.Z) + System.Math.Floor(pos.X))) % 2 <> 0
                then 0.1
                else 0.7;
            member s.Roughness = 150.0 }

let baseScene = 
    { Things = [ Plane( Vector(0.0,1.0,0.0), 0.0, Surfaces.Checkerboard);
                 Sphere( Vector(0.0,1.0,-0.25), 1.0, Surfaces.Shiny) ];
      Lights = [ { Pos = Vector(-2.0,2.5,0.0); Color = Color(0.5,0.45,0.41) };
                 { Pos = Vector(2.0,4.5,2.0); Color = Color(0.99,0.95,0.8) } ];
      Camera = Camera(Vector(2.75, 2.0, 3.75), Vector(-0.6, 0.5, 0.0)) }

type ObjectPool<'a>(valueSelector : unit -> 'a) = 
    let objects = new ConcurrentQueue<'a>() :> IProducerConsumerCollection<'a>
    member pool.GetObject () = 
        let b, item = objects.TryTake()
        if b then item else valueSelector ()
    member pool.PutObject o = 
        objects.TryAdd(o) |> ignore

type RayTracerForm() as this = 
    inherit Form(ClientSize = new Size(width + 95, height + 59),
                 Text = "RayTracer")
    let mutable bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb)
    let mutable buffers = ObjectPool(fun () -> Array.create (width * height) 0)
    let mutable rect = Rectangle(0,0,width,height)
    let mutable renderTask : Task = null
    let mutable isParallel = false
    let mutable showThreads = false
    let mutable degreeOfParallelism = Environment.ProcessorCount 
    let mutable cancellation : CancellationTokenSource = null
    
    let pictureBox = 
        new PictureBox(Location = Point(13,15), 
                       BackColor = Color.Black,
                       BorderStyle = BorderStyle.Fixed3D,
                       Size = Size(width+69, height),
                       SizeMode = PictureBoxSizeMode.CenterImage,
                       Anchor = (AnchorStyles.Left ||| AnchorStyles.Right ||| AnchorStyles.Top ||| AnchorStyles.Bottom),
                       Image = bitmap )
    let startStopButton = 
        new Button(Text = "Start",
                   Location = Point(14,height + 21),
                   Anchor = (AnchorStyles.Left ||| AnchorStyles.Bottom),
                   Size = Size(88,23))
    let isParallelCheckBox = 
        new CheckBox(Text = "Parallel",
                     AutoSize = true,
                     Anchor = (AnchorStyles.Left ||| AnchorStyles.Bottom),
                     Location = Point(108, height + 26),
                     UseVisualStyleBackColor = true,
                     Size = Size(60,17))
    let showThreadsCheckbox = 
        new CheckBox(Text = "Show Threads",
                     AutoSize = true,
                     Enabled = false,
                     Anchor = (AnchorStyles.Left ||| AnchorStyles.Bottom),
                     Location = Point(174, height + 26),
                     Size = Size(95,17))
    let numProcsLabel = 
        new Label(Text = string Environment.ProcessorCount,
                  Enabled = false,
                  Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0uy),
                  Anchor = (AnchorStyles.Right ||| AnchorStyles.Bottom),
                  Location = Point(295, height + 31),
                  Size = Size(14,13))
    let numProcsTrackBar = 
        new TrackBar(Value = Environment.ProcessorCount,
                     Maximum = Environment.ProcessorCount,
                     Minimum = 1,
                     Enabled = false,
                     Anchor = (AnchorStyles.Right ||| AnchorStyles.Bottom),
                     Location = Point(304, height + 21),
                     Size = Size(178,45))
    
    let sceneAtTime elapsedSecs = 
        let dy2 = 0.8 * abs (sin ((float elapsedSecs) * Math.PI / 3000.0))
        let sphere = Sphere( Vector(-0.5,0.5+dy2,1.5), 0.5, Surfaces.MatteShiny)
        { baseScene with Things = sphere :: baseScene.Things  }
        
    let configureImage () =
        if bitmap = null || (bitmap.Width <> pictureBox.Width) || (bitmap.Height <> pictureBox.Height)    
        then
            if bitmap <> null
            then
                pictureBox.Image <- null
                bitmap.Dispose()
            width <- Math.Min(pictureBox.Width, pictureBox.Height)
            height <- width
            buffers <- ObjectPool(fun () -> Array.create (width * height) 0)
            bitmap <- new Bitmap(width, height, PixelFormat.Format32bppRgb)
            rect <- Rectangle(0,0,width,height)
            pictureBox.Image <- bitmap
            
    let renderLoop () = async { 
        let raytracer = RayTracer(width,height)
        let totalElapsed = Stopwatch.StartNew()
        let renderingTime = Stopwatch()
        let frame = ref 0
        while true do
            let rgb = buffers.GetObject()
            
            renderingTime.Reset ()
            renderingTime.Start ()
            
            try 
                let parallelOptions = new ParallelOptions( MaxDegreeOfParallelism = degreeOfParallelism, CancellationToken = cancellation.Token)
                let scene = sceneAtTime totalElapsed.ElapsedMilliseconds
                if not isParallel then raytracer.RenderSequential(scene, rgb)
                else if showThreads then raytracer.RenderParallelShowingThreads(scene, rgb, parallelOptions)
                else raytracer.RenderParallel(scene, rgb, parallelOptions)
            with
            | :? OperationCanceledException -> ()
            
            renderingTime.Stop ()
            
            incr frame
            let framesPerSecond = 1000.0 / float renderingTime.ElapsedMilliseconds;
            
            this.BeginInvoke (Action< >(fun () -> 
                let bmpData = bitmap.LockBits(rect, Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat)
                Marshal.Copy(rgb, 0, bmpData.Scan0, rgb.Length)
                bitmap.UnlockBits bmpData
                buffers.PutObject(rgb) 
                pictureBox.Invalidate ()
                this.Text <- "RayTracer - FPS: " + framesPerSecond.ToString("F1") )) |> ignore
        }
    
    do isParallelCheckBox.CheckedChanged.Add(fun _ ->
        isParallel <- isParallelCheckBox.Checked
        numProcsLabel.Enabled <- isParallelCheckBox.Checked
        numProcsTrackBar.Enabled <- isParallelCheckBox.Checked
        showThreadsCheckbox.Enabled <- isParallelCheckBox.Checked
        )

    do numProcsTrackBar.ValueChanged.Add(fun _ ->
        numProcsLabel.Text <- string numProcsTrackBar.Value
        degreeOfParallelism <- numProcsTrackBar.Value 
        )

    do startStopButton.Click.Add(fun _ ->      
        if cancellation <> null 
        then
            startStopButton.Enabled <- false 
            Async.CancelDefaultToken()
        else
            configureImage()  
            showThreads <- showThreadsCheckbox.Checked
            cancellation <- new CancellationTokenSource()
            let sc = SynchronizationContext.Current
            let t = 
                async { do! renderLoop () }
                |> Async.StartAsTask
            t.ContinueWith(new Action<Task>(fun t -> 
                isParallelCheckBox.Enabled <- true
                showThreadsCheckbox.Enabled <- isParallelCheckBox.Checked
                numProcsLabel.Enabled <- true
                numProcsTrackBar.Enabled <- true
                startStopButton.Enabled <- true
                startStopButton.Text <- "Start"
                cancellation <- null), TaskScheduler.FromCurrentSynchronizationContext()) |> ignore
            isParallelCheckBox.Enabled <- false
            showThreadsCheckbox.Enabled <- true
            numProcsLabel.Enabled <- false
            numProcsTrackBar.Enabled <- false
            startStopButton.Text <- "Stop")
        
    do this.SuspendLayout()
    do this.AutoScaleDimensions <- new SizeF(6.0f,13.0f)
    do this.AutoScaleMode <- AutoScaleMode.Font
    do this.Controls.Add(pictureBox)
    do this.Controls.Add(startStopButton)
    do this.Controls.Add(isParallelCheckBox)
    do this.Controls.Add(showThreadsCheckbox)
    do this.Controls.Add(numProcsLabel)
    do this.Controls.Add(numProcsTrackBar)
    do this.ResumeLayout()
    
#if COMPILED
[<STAThread>]
do Application.EnableVisualStyles();
do Application.SetCompatibleTextRenderingDefault(false);
do Application.Run(new RayTracerForm())
#endif
