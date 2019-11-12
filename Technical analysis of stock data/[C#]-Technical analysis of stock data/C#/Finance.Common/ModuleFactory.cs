using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Finance.Interfaces;

namespace Finance.Common
{
	public static class ModuleFactory
	{
		public static IModule CreateModule(String assemblyName, String typeName)
		{
			Assembly assembly = Assembly.Load(assemblyName);

			if (null == assembly)
			{
				throw new ApplicationException("Assembly not found " + assemblyName);
			}

			LoggerFactory.AppLogger.Warn("[ModuleFactory.StartModule] Assembly loaded " + assemblyName);

			Type type = assembly.GetType(typeName);

			if (null == type)
			{
				throw new ApplicationException("Type not found " + typeName);
			}

			LoggerFactory.AppLogger.Warn("[ModuleFactory.StartModule] Type found " + typeName);

			Type[] interfaces = type.GetInterfaces();

			if (!interfaces.Contains(typeof(IModule)))
			{
				throw new ApplicationException("Type does not implement required interface " + typeName);
			}

			Object obj = Activator.CreateInstance(type);

			IModule module = (IModule)obj;

			return module;
		}
	}
}
