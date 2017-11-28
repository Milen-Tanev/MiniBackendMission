namespace Services.NobePrizeWinnerServices
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;
    
    using Data.Models;
    using Data.Models.Enums;

    public class FileDataConverter : IFileDataConverter
    {
        public IEnumerable<NobelPrizeWinner> Read(FileInfo fileInfo)
        {
            var nobelPrizeWinners = new List<NobelPrizeWinner>();
            var excel = new ExcelPackage(fileInfo);

            // To do: Handle errors
            ExcelWorksheet workSheet = excel.Workbook.Worksheets.First();
            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var year = ushort.Parse(workSheet.Cells[rowNumber, 1].Text);
                var category = (Category)Enum.Parse(typeof(Category), workSheet.Cells[rowNumber, 2].Text);
                var name = workSheet.Cells[rowNumber, 3].Text;
                var birthDate = workSheet.Cells[rowNumber, 4].Text;
                var birthPlace = workSheet.Cells[rowNumber, 5].Text;
                var country = workSheet.Cells[rowNumber, 6].Text;
                var residence = workSheet.Cells[rowNumber, 7].Text;
                var fieldLanguage = (workSheet.Cells[rowNumber, 8].Text);
                var prizeName = workSheet.Cells[rowNumber, 9].Text;
                var motivation = workSheet.Cells[rowNumber, 10].Text;

                NobelPrizeWinner nobelPrizeWinner = new NobelPrizeWinner()
                {
                    Year = year,
                    Category = category,
                    Name = name,
                    BirthDate = birthDate,
                    BirthPlace = birthPlace,
                    Country = country,
                    Residence = residence,
                    FieldLanguage = fieldLanguage,
                    PrizeName = prizeName,
                    Motivation = motivation
                };

                nobelPrizeWinners.Add(nobelPrizeWinner);
            }
 
            return nobelPrizeWinners;
        }
    }
}
