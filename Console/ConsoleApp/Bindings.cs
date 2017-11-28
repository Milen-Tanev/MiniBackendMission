namespace ConsoleApp
{
    using Data;
    using Data.Common;
    using Data.Models;
    using System.Data.Entity;

    using Ninject.Modules;

    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<MiniBackendMissionDbContext>().InSingletonScope();
            Bind<INobelPrizeWinnersDbRepository<NobelPrizeWinner>>().To<NobelPrizeWinnersDbRepository<NobelPrizeWinner>>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
