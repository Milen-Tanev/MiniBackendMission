namespace ConsoleApp
{
    using System;
    using System.Data.Entity;
    using System.IO;

    using Services.NobePrizeWinnerServices;
    using Data;
    using Data.Common;
    using Data.Models;

    class StartUp
    {
        static void Main()
        {
            var fileInfo = new FileInfo(@"C:\Users\Milen\Documents\Visual Studio 2017\Projects\MiniBackendMission\Files\Nobel Prize Winners.xlsx");

            var fileReader = new FileReader();
            var nobelPrizeWinners = fileReader.Read(fileInfo);

            DbContext context = new MiniBackendMissionDbContext();
            INobelPrizeWinnersDbRepository<NobelPrizeWinner> repository = new NobelPrizeWinnersDbRepository<NobelPrizeWinner>(context);
            IUnitOfWork unitOfWork = new UnitOfWork(context);

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
