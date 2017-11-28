namespace Services.NobePrizeWinnerServices
{
    using System.Linq;

    using Data.Common;
    using Data.Models;

    public class NobelPrizeWinnerService : INobelPrizeWinnerService
    {
        private INobelPrizeWinnersDbRepository<NobelPrizeWinner> nobelPrizeWinners;
        private IUnitOfWork unitOfWork;

        public NobelPrizeWinnerService(INobelPrizeWinnersDbRepository<NobelPrizeWinner> nobelPrizeWinners, IUnitOfWork unitOfWork)
        {
            this.nobelPrizeWinners = nobelPrizeWinners;
            this.unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(NobelPrizeWinner nobelPrizeWinner)
        {
            var winner = this.nobelPrizeWinners.All()
                .Where(w => w.Year == nobelPrizeWinner.Year
                    && w.Name == nobelPrizeWinner.Name
                    && w.PrizeName == nobelPrizeWinner.PrizeName)
                .FirstOrDefault();

            if (winner == null)
            {
                this.nobelPrizeWinners.Add(nobelPrizeWinner);
            }
            else
            {
                this.nobelPrizeWinners.Update(nobelPrizeWinner);
            }

            this.unitOfWork.Commit();
        }
    }
}
