namespace Services.NobePrizeWinnerServices
{
    using System.Collections.Generic;

    using OfficeOpenXml;

    using Data.Models;

    public interface IFileDataConverter
    {
        IList<NobelPrizeWinner> Read(ExcelPackage excel);
    }
}
