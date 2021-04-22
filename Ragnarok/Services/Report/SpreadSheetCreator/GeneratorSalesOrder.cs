using ClosedXML.Excel;
using Ragnarok.Models;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report.SpreadSheetCreator
{
    public class GeneratorSalesOrder
    {
        public static string SheetsSalesOrder(List<SalesOrder> list, string path, string fileName)
        {
            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheets.Worksheet("Sheet1");

                for (int i = 0; i < list.Count; i++)
                {
                    SalesOrder obj = list[i];
                    if (i == 0)
                    {
                        worksheet.Cell("A" + (3 + i)).Value =
                            "Id";
                        worksheet.Cell("B" + (3 + i)).Value =
                            "InsertDate";
                        worksheet.Cell("C" + (3 + i)).Value =
                            "ClientId";
                        worksheet.Cell("D" + (3 + i)).Value =
                            "Nome Cliente";
                        worksheet.Cell("E" + (3 + i)).Value =
                            "SaleBoxId";
                        worksheet.Cell("F" + (3 + i)).Value =
                            "PaymentId";
                    }

                    worksheet.Cell("A" + (4 + i)).Value =
                        obj.Id;
                    worksheet.Cell("B" + (4 + i)).Value =
                        obj.InsertDate;
                    worksheet.Cell("C" + (4 + i)).Value =
                        obj.ClientId;
                    if (obj.Client is ClientJuridical)
                    {
                        ClientJuridical client = (ClientJuridical)obj.Client;
                        worksheet.Cell("D" + (4 + i)).Value =
                        client.CompanyName;
                    }
                    else
                    {
                        ClientPhysical client = (ClientPhysical)obj.Client;
                        worksheet.Cell("D" + (4 + i)).Value =
                        client.FullName;
                    }
                    worksheet.Cell("E" + (4 + i)).Value =
                        obj.SaleBoxId;
                    worksheet.Cell("F" + (4 + i)).Value =
                        obj.PaymentId;

                }

                workbook.Save();
            }

            

            return Path.Combine("/ReportSheets_Temp/", fileName); ;
        }
    }
}
