using ClosedXML.Excel;
using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report.SpreadSheetCreator
{
    public class GeneratorProduct
    {
        public static string SheetsProduct(List<Product> list, string path, string fileName)
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
                        }
                        worksheet.Cell("A" + (2 + i)).Value =
                            obj.Id;
                        worksheet.Cell("B" + (2 + i)).Value =
                            obj.InsertDate;
                        worksheet.Cell("C" + (2 + i)).Value =
                            obj.Name;
                        worksheet.Cell("D" + (2 + i)).Value =
                            obj.BarCode;

                        worksheet.Cell("G" + (2 + i)).Value =
                            obj.Id;
                        worksheet.Cell("H" + (2 + i)).Value =
                            obj.InsertDate;
                        worksheet.Cell("I" + (2 + i)).Value =
                            obj.Name;
                        worksheet.Cell("J" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("K" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("L" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("M" + (2 + i)).Value =
                            obj.Id;
                        worksheet.Cell("N" + (2 + i)).Value =
                            obj.InsertDate;
                        worksheet.Cell("O" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("P" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("Q" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("R" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("S" + (2 + i)).Value =
                            obj.Id;
                        worksheet.Cell("T" + (2 + i)).Value =
                            obj.InsertDate;
                        worksheet.Cell("U" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("V" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("W" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("X" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("Y" + (2 + i)).Value =
                            obj.Id;
                        worksheet.Cell("Z" + (2 + i)).Value =
                            obj.InsertDate;
                        worksheet.Cell("AA" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("AB" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("AC" + (2 + i)).Value =
                            obj.BarCode;
                        worksheet.Cell("AD" + (2 + i)).Value =
                            obj.BarCode;

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
