using System.IO;

namespace Ragnarok.Services.Report
{
    public class ExcelConfigurations
    {
        public string SpreadsheetTemplate = Path.Combine(Directory.GetCurrentDirectory(), "Services/Report/Planilha.xlsx");// "C:\\Users\\Kling\\Desktop\\Project_Ragnarok\\Ragnarok\\Planilha.xlsx";
        public string GenerationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ReportSheets_Temp/"); //"C:\\Users\\Kling\\Desktop\\";
    }
}
