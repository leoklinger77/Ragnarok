using ClosedXML.Excel;
using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report.SpreadSheetCreator
{
    public class GeneratorSalesOrder
    {
        public static string SheetsSalesOrder(List<SalesOrder> list, string path, string fileName)
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
                                "ClientId";
                            worksheet.Cell("D" + (1 + i)).Value =
                                "Nome Cliente";
                            worksheet.Cell("E" + (1 + i)).Value =
                                "Cliente CPF/CNPJ";
                            worksheet.Cell("F" + (1 + i)).Value =
                                "Vendedor";
                            worksheet.Cell("G" + (1 + i)).Value =
                                "valor Total Venda";
                            worksheet.Cell("H" + (1 + i)).Value =
                                "Produto";
                            worksheet.Cell("I" + (1 + i)).Value =
                                "Código de Barras";
                            worksheet.Cell("J" + (1 + i)).Value =
                                "Preço Venda";
                            worksheet.Cell("K" + (1 + i)).Value =
                                "Quantidade";
                        }

                        foreach (var item in obj.SalesItem)
                        {
                            worksheet.Cell("A" + (2 + i)).Value =
                                obj.Id;
                            worksheet.Cell("B" + (2 + i)).Value =
                                obj.InsertDate;
                            worksheet.Cell("C" + (2 + i)).Value =
                                obj.ClientId;
                            if (obj.Client is ClientJuridical)
                            {
                                ClientJuridical client = (ClientJuridical)obj.Client;
                                worksheet.Cell("D" + (2 + i)).Value =
                                client.CompanyName;
                                worksheet.Cell("E" + (2 + i)).Value =
                                client.CNPJ;
                            }
                            else
                            {
                                ClientPhysical client = (ClientPhysical)obj.Client;
                                worksheet.Cell("D" + (2 + i)).Value =
                                client.FullName;
                                worksheet.Cell("E" + (2 + i)).Value =
                                client.CPF;
                            }
                            worksheet.Cell("F" + (2 + i)).Value =
                                obj.SaleBox.RegisterSales.Name;
                            worksheet.Cell("G" + (2 + i)).Value =
                                obj.TotalSales();
                            //Item Produto
                            worksheet.Cell("H" + (2 + i)).Value =
                                item.Stock.Product.Name;
                            worksheet.Cell("I" + (2 + i)).Value =
                                item.Stock.Product.BarCode;
                            worksheet.Cell("J" + (2 + i)).Value =
                                item.Price;
                            worksheet.Cell("K" + (2 + i)).Value =
                                item.Quantity;

                            i++;
                        }
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
