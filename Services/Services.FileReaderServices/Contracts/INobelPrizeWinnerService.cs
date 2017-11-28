namespace Services.NobePrizeWinnerServices
{
    using Data.Models;

    interface INobelPrizeWinnerService
    {
        void AddOrUpdate(NobelPrizeWinner nobelPrizeWinner);
    }
}