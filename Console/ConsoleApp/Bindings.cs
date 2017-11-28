namespace ConsoleApp
{
    using System.Data.Entity;

    using Ninject.Modules;

    using Data;
    using Data.Common;
    using Data.Models;
    using Services.NobePrizeWinnerServices;

    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<MiniBackendMissionDbContext>().InSingletonScope();
            Bind<INobelPrizeWinnersDbRepository<NobelPrizeWinner>>().To<NobelPrizeWinnersDbRepository<NobelPrizeWinner>>();
            Bind<INobelPrizeWinnerService>().To<NobelPrizeWinnerService>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            Bind<IFileDataConverter>().To<FileDataConverter>();
        }
    }
}
