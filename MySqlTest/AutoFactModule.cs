using System;
using System.Reflection;
using Autofac;

namespace MySqlTest
{
	public class AutoFactModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder) {
			//builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).

			builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
			       .AssignableTo(typeof(IDynamicHandler)).AsImplementedInterfaces().SingleInstance();

			builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
			       .AssignableTo<IService>().AsImplementedInterfaces().SingleInstance();

			//builder.RegisterAssemblyModules<IDynamicHandler>(typeof(LogHandler).as)

			//builder.RegisterType<LogHandler>().As<IDynamicHandler>().SingleInstance();
			//builder.RegisterType<AuthHandler>().As<IDynamicHandler>().SingleInstance();
		}
	}
}
