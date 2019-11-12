using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using Tasks.Show.Models;
using Tasks.Show.Utils;
using Tasks.Show.ViewModels;
using PixelLab.Wpf;
using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.ComponentModel;
using Tasks.Show.Controls;

namespace Tasks.Show.Views
{

    public partial class TasksView : UserControl
    {
		#region Constructors 

        public TasksView()
        {
            DataContextChanged += (sender, args) =>
            {
                Debug.Assert(args.OldValue == null, "DataContext shouldn't be changed more than once.");

                var tasks = args.NewValue as TaskListViewModel;
                if (tasks != null)
                {
                    Commands.MapCommand(tasks.DeleteTaskCommand, ApplicationCommands.Delete, this);
                }
            };

            InitializeComponent();
        }

		#endregion Constructors 

		#region Event Handlers 

        private void m_filteredList_ReorderBegin(object sender, System.Windows.RoutedEventArgs e)
        {
            m_scrollDecorator.IsDraggingEnabled = false;
        }

        private void m_filteredList_ReorderCancel(object sender, System.Windows.RoutedEventArgs e)
        {
            m_scrollDecorator.IsDraggingEnabled = true;
        }

        private void m_filteredList_ReorderRequested(object sender, ReorderEventArgs args)
        {
            var tasks = DataContext as TaskListViewModel;
            if (tasks != null)
            {
                var item = ((TaskViewModel)m_filteredList.ItemContainerGenerator.ItemFromContainer(args.ItemContainer)).Task;
                var toItem = ((TaskViewModel)m_filteredList.ItemContainerGenerator.ItemFromContainer(args.ToContainer)).Task;
                tasks.MoveTask(item, toItem);
            }
            m_scrollDecorator.IsDraggingEnabled = true;
        }

        private void m_scrollDecorator_RequiresScrollingChanged(object sender, RoutedEventArgs e)
        {
            if (m_scrollDecorator.RequiresScrolling)
            {
                RaiseShowScrollSliderEvent();
                Storyboard sb = this.Resources["ShowScrollSlider"] as Storyboard;
                this.BeginStoryboard(sb);
            }
            else
            {
                RaiseHideScrollSliderEvent();
                Storyboard sb = this.Resources["HideScrollSlider"] as Storyboard;
                this.BeginStoryboard(sb);
            }
        }

		#endregion Event Handlers 

        #region ShowScrollSliderEvent

        public static readonly RoutedEvent ShowScrollSliderEvent = EventManager.RegisterRoutedEvent("ShowScrollSlider", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TasksView));

        public event RoutedEventHandler ShowScrollSlider
        {
            add { AddHandler(ShowScrollSliderEvent, value); }
            remove { RemoveHandler(ShowScrollSliderEvent, value); }
        }

        void RaiseShowScrollSliderEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(TasksView.ShowScrollSliderEvent);
            RaiseEvent(newEventArgs);
        }

        #endregion

        #region HideScrollSliderEvent

        public static readonly RoutedEvent HideScrollSliderEvent = EventManager.RegisterRoutedEvent("HideScrollSlider", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TasksView));

        public event RoutedEventHandler HideScrollSlider
        {
            add { AddHandler(HideScrollSliderEvent, value); }
            remove { RemoveHandler(HideScrollSliderEvent, value); }
        }

        void RaiseHideScrollSliderEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(TasksView.HideScrollSliderEvent);
            RaiseEvent(newEventArgs);
        }

        #endregion
    }
}
