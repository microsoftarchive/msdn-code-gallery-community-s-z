using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Kitware.VTK;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace WpfVTK.View_Model
{
    public abstract class ARenderable : ViewModelBase
    {

        #region Properties

        /// <summary>
        /// The vtkActor objects representing this object
        /// </summary>
        public ObservableCollection<vtkActor> Actors { get; protected set; }

        private String _name;
        /// <summary>
        /// Name of the renderable object
        /// </summary>
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private ObservableCollection<ARenderable> _children;
        /// <summary>
        /// Children in the tree
        /// </summary>
        public ObservableCollection<ARenderable> Children
        {
            get { return _children; }
            private set { _children = value; }
        }

        private bool _render;
        /// <summary>
        /// If true, the object will be rendered
        /// </summary>
        public bool Render
        {
            get { return _render; }
            set
            {
                _render = value;
                RaisePropertyChanged("Render", !value, value, true);
            }
        }

        private bool _isSelected;
        /// <summary>
        /// Selected in the tree view
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        private bool _isExpanded;
        /// <summary>
        /// Expanded in the tree view
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    RaisePropertyChanged("IsExpanded");
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get { return _removeCommand ?? (_removeCommand = new RelayCommand(() => RemoveSource())); }
        }

        private void RemoveSource()
        {
            _parent.Remove(this);
        }
        
        private void Remove(ARenderable child)
        {
            SetRender(child, false);
            Children.Remove(child);
        }

        private static void SetRender(ARenderable a, bool value)
        {
            a.Render = value;
            foreach (ARenderable child in a.Children)
                SetRender(child, value);
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand<String>(s => AddSource(s))); }
        }

        private void AddSource(string s)
        {
            switch (s)
            {
                case "Sphere":
                    Children.Add(new Sphere(this));
                    break;
                case "Cone":
                    Children.Add(new Cone(this));
                    break;
                default:
                    break;
            }
            IsExpanded = true; // upon adding a child, set expanded true so the child is visible
        }
        #endregion

        private ARenderable _parent;
        public ARenderable(ARenderable parent)
        {
            _parent = parent;
            Children = new ObservableCollection<ARenderable>();
        }

    }
}
