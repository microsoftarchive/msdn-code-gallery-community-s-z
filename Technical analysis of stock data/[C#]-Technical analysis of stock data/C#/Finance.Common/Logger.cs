using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.Interfaces;
using NLog;

namespace Finance.Common
{
	public class FileLogger : ILogger
	{
		public FileLogger()
		{
			nlog = LogManager.GetLogger("file");
		}

		private static NLog.Logger nlog;

		#region ILogger Members

		public Boolean IsTraceEnabled
		{
			get
			{
				return nlog.IsTraceEnabled;
			}
		}

		public Boolean IsDebugEnabled
		{
			get
			{
				return nlog.IsTraceEnabled;
			}
		}

		public Boolean IsInfoEnabled
		{
			get
			{
				return nlog.IsInfoEnabled;
			}
		}

		public Boolean IsWarnEnabled
		{
			get
			{
				return nlog.IsWarnEnabled;
			}
		}

		public Boolean IsErrorEnabled
		{
			get
			{
				return nlog.IsErrorEnabled;
			}
		}

		public Boolean IsExceptionEnabled
		{
			get
			{
				return nlog.IsErrorEnabled;
			}
		}

		public void Trace(String message)
		{
			nlog.Trace(message);
		}

		public void Debug(String message)
		{
			nlog.Debug(message);
		}

		public void Info(String message)
		{
			nlog.Info(message);
		}

		public void Error(String message)
		{
			nlog.Error(message);
		}

		public void Warn(String message)
		{
			nlog.Warn(message);
		}

		public void Exception(String message, Exception ex)
		{
			nlog.ErrorException(message, ex);
		}

		#endregion
	}

	public class CompoundLogger : ILogger
	{
		private List<ILogger> loggers = new List<ILogger>();

		#region ILogger Members

		public Boolean IsTraceEnabled
		{
			get
			{
				loggers.Exists(delegate(ILogger logger)
				{
					return logger.IsTraceEnabled;
				});

				return false;
			}
		}

		public Boolean IsDebugEnabled
		{
			get
			{
				loggers.Exists(delegate(ILogger logger)
				{
					return logger.IsDebugEnabled;
				});

				return false;
			}
		}

		public Boolean IsInfoEnabled
		{
			get
			{
				loggers.Exists(delegate(ILogger logger)
				{
					return logger.IsInfoEnabled;
				});

				return false;
			}
		}

		public Boolean IsWarnEnabled
		{
			get
			{
				loggers.Exists(delegate(ILogger logger)
				{
					return logger.IsWarnEnabled;
				});

				return false;
			}
		}

		public Boolean IsErrorEnabled
		{
			get
			{
				loggers.Exists(delegate(ILogger logger)
				{
					return logger.IsErrorEnabled;
				});

				return false;
			}
		}

		public Boolean IsExceptionEnabled
		{
			get
			{
				loggers.Exists(delegate(ILogger logger)
				{
					return logger.IsExceptionEnabled;
				});

				return false;
			}
		}

		/// <summary>
		/// adds logger to the list
		/// </summary>
		/// <param name="logger">logger to add</param>
		public void AddLogger(ILogger logger)
		{
			if (null == logger)
			{
				throw new ArgumentNullException("logger");
			}

			if (loggers.Contains(logger))
			{
				throw new ArgumentException("logger already exists");
			}

			loggers.Add(logger);
		}

		public void Debug(String message)
		{
			loggers.ForEach(delegate(ILogger logger)
			{
				logger.Debug(message);
			});
		}

		public void Trace(String message)
		{
			loggers.ForEach(delegate(ILogger logger)
			{
				logger.Trace(message);
			});
		}

		public void Info(String message)
		{
			loggers.ForEach(delegate(ILogger logger)
			{
				logger.Info(message);
			});
		}

		public void Error(String message)
		{
			loggers.ForEach(delegate(ILogger logger)
			{
				logger.Error(message);
			});
		}

		public void Warn(String message)
		{
			loggers.ForEach(delegate(ILogger logger)
			{
				logger.Warn(message);
			});
		}

		public void Exception(String message, Exception ex)
		{
			loggers.ForEach(delegate(ILogger logger)
			{
				logger.Exception(message, ex);
			});

		}

		#endregion
	}

	public class LoggerFactory
	{
		private static CompoundLogger appLogger;

		public static ILogger AppLogger
		{
			get
			{
				if (null == appLogger)
				{
					appLogger = new CompoundLogger();

					appLogger.AddLogger(new FileLogger());
				}

				return appLogger;
			}
		}
	}
}
