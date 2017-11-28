namespace Services.NobePrizeWinnerServices
{
    using System.Collections.Generic;
    using System.IO;

    using Data.Models;

    public interface IFileReader
    {
        IEnumerable<NobelPrizeWinner> Read(FileInfo fileInfo);
    }
}