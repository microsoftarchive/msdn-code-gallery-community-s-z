
namespace WpfVTK.View_Model
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Kitware.VTK;
    using System.Collections.ObjectModel;

    public class Sphere : ARenderable
    {
        //  used to position spheres and cones at random positions
        protected static Random _random = new Random();

        vtkSphereSource sphere;
        vtkShrinkPolyData shrink;
        vtkPolyDataMapper mapper;
        vtkTransform move;
        vtkTransformPolyDataFilter moveFilter;

        public Sphere(ARenderable parent)
            : base(parent)
        {
            Name = "Sphere";
            sphere = vtkSphereSource.New();
            sphere.SetThetaResolution(8);
            sphere.SetPhiResolution(16);

            shrink = vtkShrinkPolyData.New();
            shrink.SetInputConnection(sphere.GetOutputPort());
            shrink.SetShrinkFactor(0.9);

            move = vtkTransform.New();
            move.Translate(_random.NextDouble(), _random.NextDouble(), _random.NextDouble());
            moveFilter = vtkTransformPolyDataFilter.New();
            moveFilter.SetTransform(move);

            moveFilter.SetInputConnection(shrink.GetOutputPort());

            mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(moveFilter.GetOutputPort());

            Actors = new ObservableCollection<vtkActor>();
            // The actor links the data pipeline to the rendering subsystem 
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetColor(1, 0, 0);
            Actors.Add(actor);
        }
    }

}
