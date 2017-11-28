namespace Services.NobePrizeWinnerServices
{
    using System.Collections.Generic;
    using System.IO;

    using Data.Models;

    public interface IFileDataConverter
    {
        IEnumerable<NobelPrizeWinner> Read(FileInfo fileInfo);
    }
}