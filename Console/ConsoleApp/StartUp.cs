namespace ConsoleApp
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Reflection;

    using Ninject;

    using Services.NobePrizeWinnerServices;
    using Data;
    using Data.Common;
    using Data.Models;

    class StartUp
    {
        static void Main()
        {
            var fileInfo = new FileInfo(@"C:\Users\Milen\Documents\Visual Studio 2017\Projects\MiniBackendMission\Files\Nobel Prize Winners.xlsx");

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var context = kernel.Get<DbContext>();
            var repository = kernel.Get<INobelPrizeWinnersDbRepository<NobelPrizeWinner>>();
            var unitOfWork = kernel.Get<IUnitOfWork>();

            var fileReader = new FileDataConverter();
            var nobelPrizeWinners = fileReader.Read(fileInfo);
                        
            var service = new NobelPrizeWinnerService(repository, unitOfWork);

            Console.Write("Extracting table");

            int counter = 1;
            foreach (var nobelPrizeWinner in nobelPrizeWinners)
            {
                service.AddOrUpdate(nobelPrizeWinner);
                if (counter % 10 == 0)
                {
                    Console.Write(".");
                }
                counter++;
            }
            Console.WriteLine("Extracting finished");
        }
    }
}
