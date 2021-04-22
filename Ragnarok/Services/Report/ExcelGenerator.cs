using ClosedXML.Excel;
using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report
{
    public class ExcelGenerator
    {
        public static class ArquivoExcelCotacoes
        {
            public static string GerarArquivo<T>(
                ExcelConfigurations configurations,
                ICollection<T> cotacoes)
            {
                try
                {
                    List<T> list = (List<T>)cotacoes;
                    DateTime now = DateTime.Now;
                    string caminhoArqCotacoes =
                        configurations.DiretorioGeracaoArqCotacoes +
                        $"Report {DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}.xlsx";
                    File.Copy(configurations.TemplateArqCotacoes, caminhoArqCotacoes);

                    using (var workbook = new XLWorkbook(caminhoArqCotacoes))
                    {
                        var worksheet = workbook.Worksheets.Worksheet("Sheet1");

                        switch (list[0].GetType().ToString())
                        {
                            case "Ragnarok.Models.SalesOrder":
                                for (int i = 0; i < list.Count; i++)
                                {
                                    SalesOrder obj = (SalesOrder)Convert.ChangeType(list[i], typeof(SalesOrder));
                                    if (i == 0)
                                    {
                                        worksheet.Cell("A" + (4 + i)).Value =
                                            "Id";
                                        worksheet.Cell("B" + (4 + i)).Value =
                                            "InsertDate";
                                        worksheet.Cell("C" + (4 + i)).Value =
                                            "ClientId";
                                        worksheet.Cell("D" + (4 + i)).Value =
                                            "Nome Cliente";
                                        worksheet.Cell("E" + (4 + i)).Value =
                                            "SaleBoxId";
                                        worksheet.Cell("F" + (4 + i)).Value =
                                            "PaymentId";
                                    }
                                    else
                                    {
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
                                }
                                break;                            
                        }
                        workbook.Save();
                    }

                    return caminhoArqCotacoes;
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }


            }
        }
    }
}
