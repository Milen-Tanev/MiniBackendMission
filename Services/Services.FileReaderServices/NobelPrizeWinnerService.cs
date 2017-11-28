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
            using (this.unitOfWork)
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
                    if (winner.CompareTo(nobelPrizeWinner) != 0)
                    {
                        winner.Category = nobelPrizeWinner.Category;
                        winner.BirthDate = nobelPrizeWinner.BirthDate;
                        winner.BirthPlace = nobelPrizeWinner.BirthPlace;
                        winner.Country = nobelPrizeWinner.Country;
                        winner.Residence = nobelPrizeWinner.Residence;
                        winner.FieldLanguage = nobelPrizeWinner.FieldLanguage;
                        winner.Motivation = nobelPrizeWinner.Motivation;

                        this.nobelPrizeWinners.Update(winner);
                    }
                }
                this.unitOfWork.Commit();
            }
        }
    }
}
