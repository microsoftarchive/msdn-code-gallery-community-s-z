
namespace WpfVTK.View_Model
{
    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;

    public class SceneTree : ViewModelBase
    {
        public ObservableCollection<ARenderable> RenderActors
        { 
            get; private set; 
        }

        /// <summary>
        /// Create the initial scene tree
        /// </summary>
        public SceneTree()
        {
            RenderActors = new ObservableCollection<ARenderable>();
            Sphere s = new Sphere(null);
            Cone c = new Cone(null);
            Sphere s1 = new Sphere(s);
            s.Children.Add(s1);
            Cone c1 = new Cone(s);
            s.Children.Add(c1);

            Sphere s2 = new Sphere(c);
            c.Children.Add(s2);
            Sphere s3 = new Sphere(c);
            c.Children.Add(s3);

            Cone c2 = new Cone(s3);
            s3.Children.Add(c2);

            RenderActors.Add(s);
            RenderActors.Add(c);
        }
    }
}