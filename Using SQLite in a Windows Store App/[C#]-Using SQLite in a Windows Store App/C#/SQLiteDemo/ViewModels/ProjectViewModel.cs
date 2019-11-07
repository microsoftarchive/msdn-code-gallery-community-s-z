using SQLiteDemo.Models;
using System;
using System.Linq;

namespace SQLiteDemo.ViewModels
{
    public class ProjectViewModel: ViewModelBase
    {
        #region Properties

        private int id = 0;
        public int Id
        {
            get
            { return id; }

            set
            {
                if (id == value)
                { return; }

                id = value;
                RaisePropertyChanged("Id");
            }
        }

        private int customerId = 0;
        public int CustomerId
        {
            get
            { return customerId; }

            set
            {
                if (customerId == value)
                { return; }

                customerId = value;
                RaisePropertyChanged("CustomerId");
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            { return name; }

            set
            {
                if (name == value)
                { return; }

                name = value;
                isDirty = true;
                RaisePropertyChanged("Name");
            }
        }

        private string description = string.Empty;
        public string Description
        {
            get
            { return description; }

            set
            {
                if (description == value)
                { return; }

                description = value;
                isDirty = true;
                RaisePropertyChanged("Description");
            }
        }

        private DateTime dateDue = System.DateTime.Today.AddDays(7);
        public DateTime DueDate
        {
            get
            { return dateDue; }

            set
            {
                if (dateDue == value)
                { return; }

                dateDue = value;
                isDirty = true;
                RaisePropertyChanged("DueDate");
            }
        }

        private bool isDirty = false;
        public bool IsDirty
        {
            get
            {
                return isDirty;
            }

            set
            {
                isDirty = value;
                RaisePropertyChanged("IsDirty");
            }
        }

        #endregion "Properties"

        public ProjectViewModel GetProject(int projectId)
        {
            var project = new ProjectViewModel();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var _project = (db.Table<Project>().Where(
                    c => c.Id == projectId)).Single();
                project.Id = _project.Id;
                project.CustomerId = _project.CustomerId;
                project.Name = _project.Name;
                project.Description = _project.Description;
                project.DueDate = _project.DueDate;
            }
            return project;
        }

        public string SaveProject(ProjectViewModel project)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                string change = string.Empty;
                try
                {
                    var existingProject = (db.Table<Project>().Where(
                        c => c.Id == project.Id)).SingleOrDefault();

                    if (existingProject != null)
                    {
                        existingProject.Name = project.Name;
                        existingProject.Description = project.Description;
                        existingProject.DueDate = project.DueDate;
                        int success = db.Update(existingProject);
                    }
                    else
                    {
                        int success = db.Insert(new Project()
                        {
                            CustomerId = project.CustomerId,
                            Name = project.Name,
                            Description = project.Description,
                            DueDate = project.DueDate
                        });
                    }
                    result = "Success";
                }
                catch
                {
                    result = "This project was not saved.";
                }
            }
            return result;
        }

        public string DeleteProject(int projectId)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var existingProject = (db.Table<Project>().Where(
                    c => c.Id == projectId)).Single();

                if (db.Delete(existingProject) > 0)
                {
                    result = "Success";
                }
                else
                {
                    result = "This project was not removed";
                }
            }
            return result;
        }

    }
}
