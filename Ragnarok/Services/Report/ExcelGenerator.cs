using Ragnarok.Models;
using Ragnarok.Services.Report.SpreadSheetCreator;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report
{
    public class ExcelGenerator
    {
        public static class ArquivoExcelCotacoes
        {
            public static string GerarArquivo<T>(ExcelConfigurations configurations,List<T> list)
            {
                try
                {                    
                    DateTime now = DateTime.Now;

                    string name = KeyGenerator.KeyGenerator.GetUniqueKey(50) + $"Report {DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}.xlsx";
                    string caminhoArqCotacoes =
                        configurations.GenerationDirectory + name;
                        
                    File.Copy(configurations.SpreadsheetTemplate, caminhoArqCotacoes);
                    string path = "";
                    switch (list[0].GetType().ToString())
                    {
                        case "Ragnarok.Models.SalesOrder":
                            path = GeneratorSalesOrder.SheetsSalesOrder((List<SalesOrder>)(Object)list, caminhoArqCotacoes, name);                            
                            break;
                        case "Ragnarok.Models.Stock":
                            path = GeneratorStock.SheetsStock((List<Models.Stock>)(Object)list, caminhoArqCotacoes, name);
                            break;
                        case "Ragnarok.Models.Product":
                            path = GeneratorProduct.SheetsProduct((List<Product>)(Object)list, caminhoArqCotacoes, name);
                            break;
                    }
                    return path;
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
            
        }
    }
}
