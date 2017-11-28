namespace ConsoleApp
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Reflection;

    using Ninject;
    using OfficeOpenXml;

    using Data.Common;
    using Data.Models;
    using Services.NobePrizeWinnerServices;

    class StartUp
    {
        static void Main()
        {
            var fileInfo = new FileInfo("..\\..\\..\\..\\Files\\Nobel Prize Winners.xlsx");

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var context = kernel.Get<DbContext>();
            var repository = kernel.Get<INobelPrizeWinnersDbRepository<NobelPrizeWinner>>();
            var unitOfWork = kernel.Get<IUnitOfWork>();
            var service = kernel.Get<INobelPrizeWinnerService>();
            var fileDataConverter = kernel.Get<IFileDataConverter>();

            var excel = new ExcelPackage(fileInfo);
            var nobelPrizeWinners = fileDataConverter.Read(excel);

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
