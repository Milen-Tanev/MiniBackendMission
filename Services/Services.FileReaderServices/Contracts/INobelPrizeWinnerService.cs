namespace Services.NobePrizeWinnerServices
{
    using Data.Models;

    public interface INobelPrizeWinnerService
    {
        void AddOrUpdate(NobelPrizeWinner nobelPrizeWinner);
    }
}