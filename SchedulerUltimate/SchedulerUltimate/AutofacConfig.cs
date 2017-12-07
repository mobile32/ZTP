using Autofac;
using Serilog;
using System.IO;

namespace SchedulerUltimate
{
    class AutofacContainer
    {
        public static IContainer Configure(string logFolder)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Scheduler>().AsSelf();

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Logger(lc => lc
                .WriteTo.RollingFile(Path.Combine(logFolder, "{Date}.txt"))                )
            .WriteTo.Logger(lc => lc
                .WriteTo.Console())
            .CreateLogger();

            builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();

            return builder.Build();
        }
    }
}