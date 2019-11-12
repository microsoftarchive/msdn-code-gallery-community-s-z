using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Tasks.Show.Models;

namespace Tasks.Show.Helpers
{
    public static class Storage
    {
        public static TaskData Load()
        {
            if (File.Exists(getPath()))
            {
                try
                {
                    using (FileStream fs = new FileStream(getPath(), FileMode.Open))
                    {
                        return XmlHelper.Load(XmlReader.Create(fs));
                    }
                }
                catch (XmlException e)
                {
                    Debug.WriteLine(e);
                    backupFile();
                }
                catch (IOException e)
                {
                    Debug.WriteLine(e);
                    backupFile();
                }
                catch (NullReferenceException e)
                {
                    Debug.WriteLine(e);
                    backupFile();
                }
            }

            return new TaskData();
        }

        public static void Save(TaskData data)
        {
            using (FileStream fs = new FileStream(getPath(), FileMode.Create))
            {
                var writer = XmlWriter.Create(fs, new XmlWriterSettings() { Indent = true });
                XmlHelper.Save(data, writer);
                writer.Flush();
            }
        }

        private static void backupFile()
        {
            var newName = string.Format("{0}.{1}.backup", c_fileName, DateTime.Now.ToFileTime());
            newName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                newName);

            File.Move(getPath(), newName);
        }

        private static string getPath()
        {
            return Path.Combine(TasksDataFolder, c_fileName);
        }

        public static string TasksDataFolder
        {
            get
            {
                string applicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string tasksDataFolder = Path.Combine(applicationDataFolder, "Tasks.Show");

                // make sure folder exists
                if (!Directory.Exists(tasksDataFolder))
                {
                    Directory.CreateDirectory(tasksDataFolder);
                }

                return tasksDataFolder;
            }
        }

        private const string c_fileName = "TodoShowTasks.xml";


    }
}
