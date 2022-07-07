using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Common.Dates;
using StructureMap;
using StructureMap.Graph;

namespace Cogensoft.SnippetManager.Specification.Common
{
    public static class IoC
    {
        public static IContainer Initialize(AppContext appContext)
        {
            ObjectFactory.Initialize(x =>
            {
                SetScanningPolicy(x);

                x.For<IDatabaseService>()
                    .Use(appContext.DatabaseService);

                x.For<INotificationService>()
                    .Use(appContext.InventoryService);

                x.For<IDateService>()
                    .Use(appContext.DateService);

            });

            return ObjectFactory.Container;
        }

        private static void SetScanningPolicy(IInitializationExpression x)
        {
            x.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory(
                    filter => filter.FullName.StartsWith("Cogensoft.SnippetManager"));

                scan.WithDefaultConventions();
            });
        }
    }
}
