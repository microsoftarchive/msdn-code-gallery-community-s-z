using System.Windows.Input;
using System.Windows.Media;
using PixelLab.Common;
using Tasks.Show.Models;

namespace Tasks.Show.ViewModels
{
    public class Folders
    {
        #region Fields

        private readonly CommandWrapper<Color> m_setCurrentColorCommand;
        private readonly CommandWrapper<BaseFolder> m_setCurrentCommand;
        private readonly TaskData m_taskData;

        #endregion Fields

        #region Constructors

        public Folders(TaskData taskData)
        {
            Util.RequireNotNull(taskData, "taskList");
            m_taskData = taskData;

            m_setCurrentCommand = new CommandWrapper<BaseFolder>(
                val => m_taskData.CurrentFolder = val,
                val => m_taskData.CurrentFolder != val);

            m_setCurrentColorCommand = new CommandWrapper<Color>(
                var => m_taskData.CurrentFolder.Color = var,
                var => IsCurrentUserFolder
            );
        }

        #endregion Constructors

        #region Properties

        public TaskData TaskData
        {
            get
            {
                return m_taskData;
            }
        }

        public bool IsCurrentUserFolder
        {
            get { return !m_taskData.CurrentFolder.IsSpecial; }
        }

        public ICommand SetCurrentColorCommand { get { return m_setCurrentColorCommand.Command; } }

        public ICommand SetCurrentCommand { get { return m_setCurrentCommand.Command; } }

        #endregion Properties
    }
}
