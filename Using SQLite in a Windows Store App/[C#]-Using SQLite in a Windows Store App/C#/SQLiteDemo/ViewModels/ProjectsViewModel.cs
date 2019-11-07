using SQLiteDemo.Models;
using System.Collections.ObjectModel;

namespace SQLiteDemo.ViewModels
{
    public class ProjectsViewModel : ViewModelBase
    {
        private ObservableCollection<ProjectViewModel> projects;
        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                return projects;
            }

            set
            {
                projects = value;
                RaisePropertyChanged("Projects");
            }
        }

        public ObservableCollection<ProjectViewModel> GetProjects(int customerId)
        {
            projects = new ObservableCollection<ProjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var query = db.Table<Project>().Where(
                        p1 => p1.CustomerId == customerId).OrderBy(
                        p2 => p2.DueDate);
                foreach (var _project in query)
                {
                    var project = new ProjectViewModel()
                    {
                        Id = _project.Id,
                        CustomerId = _project.CustomerId,
                        Name = _project.Name,
                        Description = _project.Description,
                        DueDate = _project.DueDate
                    };
                    projects.Add(project);
                }
            }
            return projects;
        }

    }
}
