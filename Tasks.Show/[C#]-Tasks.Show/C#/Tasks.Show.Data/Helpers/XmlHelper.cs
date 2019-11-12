using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using PixelLab.Common;
using Tasks.Show.Models;

namespace Tasks.Show.Helpers
{
    public static class XmlHelper
    {
        public static void Save(TaskData data, XmlWriter writer)
        {
            data.ToXml().Save(writer);
        }

        public static TaskData Load(XmlReader reader)
        {
            return GetTaskData(XElement.Load(reader));
        }

        #region ToXml
        public static XElement ToXml(this TaskData taskData)
        {
            // get folders
            IDictionary<Folder, Guid> folderMap;
            var foldersXml = taskData.AllFolders.OfType<Folder>().ToXml(out folderMap);

            // get tasks
            var tasksXml = taskData.Tasks.ToXml(folder => folderMap[folder]);

            // get root element
            var rootXml = new XElement("TaskData");
            rootXml.Add(foldersXml);
            rootXml.Add(tasksXml);

            string currentFolderKey = null;
            if (taskData.CurrentFolder is SpecialFolder)
            {
                currentFolderKey = taskData.CurrentFolder.Name;
            }
            else
            {
                currentFolderKey = folderMap[(Folder)taskData.CurrentFolder].ToString();
            }
            writeAttribute(rootXml, "CurrentFolder", currentFolderKey);
            writeAttribute(rootXml, "Filter", taskData.Filter);

            return rootXml;
        }
        public static XElement ToXml(this IEnumerable<Folder> folders, out IDictionary<Folder, Guid> folderMap)
        {
            var element = new XElement("Folders");
            element.Add(new XAttribute(XNamespace.Xmlns + "x", c_XNamespace));

            var fm = new Dictionary<Folder, Guid>();
            Guid key;
            folders.ForEach(folder =>
            {
                element.Add(folder.ToXml(out key));
                fm[folder] = key;
            });

            folderMap = fm;
            return element;
        }

        public static XElement ToXml(this Folder folder, out Guid key)
        {
            var element = new XElement("Folder");

            element.Add(new XAttribute("Name", folder.Name));
            element.Add(new XAttribute("Color", folder.Color.ToString()));
            element.Add(new XAttribute(s_KeyName, key = Guid.NewGuid()));

            return element;
        }

        public static XElement ToXml(this IEnumerable<Task> tasks, Func<Folder, Guid> folderMapper)
        {
            var element = new XElement("Tasks");
            tasks.ForEach(task =>
            {
                element.Add(task.ToXml(folderMapper));
            });
            return element;
        }

        public static XElement ToXml(this Task task, Func<Folder, Guid> folderMapper)
        {
            var element = new XElement("Task");
            writeAttribute(element, "Completed", task.Completed);
            writeAttribute(element, "Description", task.Description);
            writeAttribute(element, "Due", task.Due);
            writeAttribute(element, "Folder", task.Folder == null ? (Guid?)null : folderMapper(task.Folder));
            writeAttribute(element, "Estimate", task.Estimate);
            writeAttribute(element, "IsImportant", task.IsImportant);
            return element;
        }
        #endregion

        #region FromXml
        public static TaskData GetTaskData(XElement element)
        {
            IDictionary<Guid, Folder> folderMapper;
            var folders = GetFolders(element.Element("Folders"), out folderMapper);
            var tasks = GetTasks(element.Element("Tasks"), guid => folderMapper[guid]);

            BaseFolder currentFolder = null;
            string folderKey;
            if (TryGetAttributeValue(element, "CurrentFolder", out folderKey))
            {
                if (folderKey == SpecialFolder.AllFolderName)
                {
                    currentFolder = SpecialFolder.AllFolder;
                }
                else if (folderKey == SpecialFolder.InboxFolderName)
                {
                    currentFolder = SpecialFolder.InboxFolder;
                }
                else if (folderKey != null)
                {
                    currentFolder = folderMapper[new Guid(folderKey)];
                }
            }

            string filter;
            TryGetAttributeValue(element, "Filter", out filter);

            return new TaskData(tasks, folders, currentFolder, filter);
        }

        public static IEnumerable<Task> GetTasks(XElement element, Func<Guid, Folder> folderMapper)
        {
            Util.Require(element.Name == "Tasks");
            foreach (var taskElement in element.Elements())
            {
                yield return GetTask(taskElement, folderMapper);
            }
        }

        public static Task GetTask(XElement element, Func<Guid, Folder> folderMapper)
        {
            Util.Require(element.Name == "Task");
            var task = new Task();
            string attrValue;
            if (TryGetAttributeValue(element, "Folder", out attrValue))
            {
                task.Folder = folderMapper(new Guid(attrValue));
            }
            if (TryGetAttributeValue(element, "Completed", out attrValue))
            {
                task.Completed = new DateTime(long.Parse(attrValue));
            }
            if (TryGetAttributeValue(element, "Description", out attrValue))
            {
                task.Description = attrValue;
            }
            if (TryGetAttributeValue(element, "Due", out attrValue))
            {
                task.Due = new DateTime(long.Parse(attrValue));
            }
            if (TryGetAttributeValue(element, "Estimate", out attrValue))
            {
                task.Estimate = TimeSpan.Parse(attrValue);
            }
            if (TryGetAttributeValue(element, "IsImportant", out attrValue))
            {
                task.IsImportant = bool.Parse(attrValue);
            }
            return task;
        }

        public static IEnumerable<Folder> GetFolders(XElement element, out IDictionary<Guid, Folder> folderMapper)
        {
            Util.Require(element.Name == "Folders");
            var list = new List<Folder>();
            Guid key;
            Folder folder;
            folderMapper = new Dictionary<Guid, Folder>();
            foreach (var folderElement in element.Elements())
            {
                list.Add(folder = GetFolder(folderElement, out key));
                folderMapper[key] = folder;
            }

            return list.ToReadOnlyCollection();
        }

        public static Folder GetFolder(XElement element, out Guid key)
        {
            Util.Require(element.Name == "Folder");
            var name = element.Attribute("Name").Value;
            var color = BOT.ParseHexColor(element.Attribute("Color").Value);
            key = new Guid(element.Attribute(s_KeyName).Value);
            return new Folder(name, color);
        }
        #endregion

        private static bool TryGetAttributeValue(XElement element, XName attributeName, out string value)
        {
            value = null;
            var attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                return false;
            }
            else
            {
                value = attribute.Value;
                return true;
            }
        }

        private static void writeAttribute(XElement parent, string name, object value)
        {
            if (value != null)
            {
                if (value is DateTime || value is DateTime?)
                {
                    DateTime dt = (DateTime)value;
                    value = dt.Ticks;
                }
                parent.Add(new XAttribute(name, value.ToString()));
            }
        }

        private static XName s_KeyName = XName.Get("Key", c_XNamespace);
        private const string c_XNamespace = "http://schemas.microsoft.com/winfx/2006/xaml";
    }
}
