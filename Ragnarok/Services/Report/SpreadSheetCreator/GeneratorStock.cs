using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report.SpreadSheetCreator
{
    public class GeneratorStock
    {
        public static string SheetsStock(List<Models.Stock> list, string path, string fileName)
        {
            try
            {
                using (var workbook = new XLWorkbook(path))
                {
                    var worksheet = workbook.Worksheets.Worksheet("Sheet1");
                    int i = 0;
                    foreach (var obj in list)
                    {
                        if (i == 0)
                        {
                            worksheet.Cell("A" + (1 + i)).Value =
                                "Id";
                            worksheet.Cell("B" + (1 + i)).Value =
                                "InsertDate";
                            worksheet.Cell("C" + (1 + i)).Value =
                                "Produto";
                            worksheet.Cell("D" + (1 + i)).Value =
                                "Código de Barras";
                            worksheet.Cell("E" + (1 + i)).Value =
                                "Valor Venda";
                            worksheet.Cell("F" + (1 + i)).Value =
                                "Quantidade";
                        }
                        worksheet.Cell("A" + (2 + i)).Value =
                            obj.Id;
                        worksheet.Cell("B" + (2 + i)).Value =
                            obj.InsertDate;
                        worksheet.Cell("C" + (2 + i)).Value =
                            obj.Product.Name;
                        worksheet.Cell("D" + (2 + i)).Value =
                            obj.Product.BarCode;
                        worksheet.Cell("E" + (2 + i)).Value =
                            obj.SalesPrice;
                        worksheet.Cell("F" + (2 + i)).Value =
                            obj.Quantity;                        

                        i++;

                    }
                    workbook.Save();
                    return Path.Combine("/ReportSheets_Temp/", fileName);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
