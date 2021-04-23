using Ragnarok.Models;
using Ragnarok.Services.Report.SpreadSheetCreator;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report
{
    public class ExcelGenerator
    {
        public static class FileExcel
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
                            //client
                        case "Ragnarok.Models.ClientPhysical":
                            path = GeneratorClient.SheetsClient((List<Client>)(Object)list, caminhoArqCotacoes, name);
                            break;
                        case "Ragnarok.Models.ClientJuridical":
                            path = GeneratorClient.SheetsClient((List<Client>)(Object)list, caminhoArqCotacoes, name);
                            break;
                        //supplier
                        case "Ragnarok.Models.SupplierPhysical":
                            path = GeneratorSupplier.SheetsSupplier((List<Supplier>)(Object)list, caminhoArqCotacoes, name);
                            break;
                        case "Ragnarok.Models.SupplierJuridical":
                            path = GeneratorSupplier.SheetsSupplier((List<Supplier>)(Object)list, caminhoArqCotacoes, name);
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
