
namespace WpfVTK.View_Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Kitware.VTK;
    using System.Collections.ObjectModel;

    public class Cone : ARenderable
    {
        //  used to position spheres and cones at random positions
        protected static Random _random = new Random();

        vtkConeSource cone;
        vtkPolyDataMapper mapper;
        vtkTransform move;
        vtkTransformPolyDataFilter moveFilter;

        public Cone(ARenderable parent)
            : base(parent)
        {
            Name = "Cone";
            cone = vtkConeSource.New();
            cone.SetAngle(10);
            cone.SetRadius(0.2);
            cone.SetHeight(0.5);
            cone.SetResolution(20);

            move = vtkTransform.New();
            move.Translate(_random.NextDouble(), _random.NextDouble(), _random.NextDouble());
            moveFilter = vtkTransformPolyDataFilter.New();
            moveFilter.SetTransform(move);

            moveFilter.SetInputConnection(cone.GetOutputPort());
            mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(moveFilter.GetOutputPort());

            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            Actors = new ObservableCollection<vtkActor>();
            Actors.Add(actor);
        }
    }
}
