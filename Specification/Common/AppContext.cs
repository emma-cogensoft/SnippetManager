using System;
using AutoMoq;
using Cogensoft.SnippetManager.Application.Interfaces;
using Cogensoft.SnippetManager.Common.Dates;
using StructureMap;

namespace Cogensoft.SnippetManager.Specification.Common
{
    public class AppContext
    {
        public AutoMoqer Mocker;
        public IContainer Container;
        public IDatabaseService DatabaseService;
        public INotificationService InventoryService;
        public IDateService DateService;

        public AppContext()
        {
            SetUpAutoMocker();

            SetUpMockDatabase();

            SetUpMockInventoryClient();

            SetUpMockDateService();

            SetUpIocContainer();
        }

        private void SetUpAutoMocker()
        {
            Mocker = new AutoMoqer();
        }

        public void SetUpMockDatabase()
        {
            var mockDatabase = Mocker.GetMock<IDatabaseService>();

            var intitializer = new DatabaseInitializer(mockDatabase);

            intitializer.Seed();

            DatabaseService = mockDatabase.Object;
        }

        private void SetUpMockInventoryClient()
        {
            InventoryService =  Mocker.GetMock<INotificationService>().Object;
        }

        private void SetUpMockDateService()
        {
            var mockDateService = Mocker.GetMock<IDateService>();

            mockDateService
                .Setup(p => p.GetDate())
                .Returns(DateTime.Now);

            DateService = mockDateService.Object;
        }

        private void SetUpIocContainer()
        {
            Container = IoC.Initialize(this);
        }
    }
}
