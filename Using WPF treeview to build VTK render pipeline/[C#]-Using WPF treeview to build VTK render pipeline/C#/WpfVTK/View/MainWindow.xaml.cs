using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kitware.VTK;
using WpfVTK.View_Model;
using GalaSoft.MvvmLight.Messaging;
namespace WpfVTK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SceneTree _tree;

        public MainWindow()
        {
            InitializeComponent();

            // initialize the tree model & set the window data context to the tree model
            _tree = new SceneTree();
            base.DataContext = _tree;

            // register for changes on the "Render" property of Renderable objects
            Messenger.Default.Register<PropertyChangedMessage<bool>>(this, (pcm) => RouteMessage(pcm));
        }

        private void RouteMessage(PropertyChangedMessage<bool> pcm)
        {
            if (pcm.PropertyName == "Render")
            {
                if (pcm.Sender is ARenderable)
                    UpdateRenderPipeLine(pcm.Sender as ARenderable, pcm.NewValue);

                else
                    UpdateRenderPipeLine();
            }
        }

        /* if we know which renderable to enable or disable, then only change the associated actors */
        private void UpdateRenderPipeLine(ARenderable aRenderable, bool p)
        {
            vtkRenderer renderer = _renderControl.RenderWindow.GetRenderers().GetFirstRenderer();
            if (p == false) // remove all actors of renderable
            {
                foreach (vtkActor a in aRenderable.Actors)
                    renderer.RemoveActor(a);
            }
            else //add new actors
            {
                foreach (vtkActor a in aRenderable.Actors)
                    renderer.AddActor(a);
            }
            // render the new scene. Note that renderer.Render() does _NOT_ update the scene, you need to render the interactor.
            _renderControl.RenderWindow.GetInteractor().Render();
        }

        /* this is the brute force approach: all actors are renewed each time.*/
        private void UpdateRenderPipeLine()
        {
            vtkRenderer renderer = _renderControl.RenderWindow.GetRenderers().GetFirstRenderer();

            // remove all 'old' actors
            renderer.RemoveAllViewProps();

            // add all 'new' actors
            foreach(ARenderable r in _tree.RenderActors)
                AddActors(renderer, r);
            
            // tell the interactor to render the updated scene
            _renderControl.RenderWindow.GetInteractor().Render();
        }

        private void AddActors(vtkRenderer renderer, ARenderable obj)
        {
            if (obj.Render)
            {
                foreach (vtkActor actor in obj.Actors)
                    renderer.AddActor(actor);
            }

            foreach (ARenderable child in obj.Children)
                AddActors(renderer, child);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // "zoom out" to view the objects. This is a bit of a hack to see the objects without having to zoom out manually
            _renderControl.RenderWindow.GetRenderers().GetFirstRenderer().GetActiveCamera().SetPosition(0, 0, 10);
        }
    }
}
