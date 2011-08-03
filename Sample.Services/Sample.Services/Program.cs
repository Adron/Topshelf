using Topshelf;

namespace Sample.Services
{
    class Program
    {
        static void Main()
        {
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<StatusCheckIn>(
                    serviceConfigurator =>
                {
                    serviceConfigurator.SetServiceName("TS");
                    serviceConfigurator.ConstructUsing(
                        name => new StatusCheckIn());
                    serviceConfigurator.WhenStarted(tc => tc.Start());
                    serviceConfigurator.WhenStopped(tc => tc.Stop());
                });

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.SetDescription("Sample  Host");
                hostConfigurator.SetDisplayName("Display Name");
                hostConfigurator.SetServiceName("Topshelf Service");
            });
        }
    }
}
