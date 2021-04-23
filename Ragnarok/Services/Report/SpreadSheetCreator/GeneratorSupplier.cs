using ClosedXML.Excel;
using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ragnarok.Services.Report.SpreadSheetCreator
{
    public class GeneratorSupplier
    {
        public static string SheetsSupplier(List<Supplier> list, string path, string fileName)
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
                                "Nome";
                            worksheet.Cell("D" + (1 + i)).Value =
                                "Razão Social";
                            worksheet.Cell("E" + (1 + i)).Value =
                                "Nome Fantasia";
                            worksheet.Cell("F" + (1 + i)).Value =
                                "Celular";
                            worksheet.Cell("G" + (1 + i)).Value =
                                "Tel Res/Com";
                            worksheet.Cell("H" + (1 + i)).Value =
                                "Email";
                            worksheet.Cell("I" + (1 + i)).Value =
                                "Sexo";
                            worksheet.Cell("J" + (1 + i)).Value =
                                "Situação";
                            worksheet.Cell("K" + (1 + i)).Value =
                                "Nascimento";
                            worksheet.Cell("L" + (1 + i)).Value =
                                "Data de Abertura";
                            worksheet.Cell("M" + (1 + i)).Value =
                                "Funcionario Cadastro";
                            worksheet.Cell("N" + (1 + i)).Value =
                                "Cep";
                            worksheet.Cell("O" + (1 + i)).Value =
                                "Logradouro";
                            worksheet.Cell("P" + (1 + i)).Value =
                                "Número";
                            worksheet.Cell("Q" + (1 + i)).Value =
                                "Complemento";
                            worksheet.Cell("R" + (1 + i)).Value =
                                "Referencia";
                            worksheet.Cell("S" + (1 + i)).Value =
                                "Bairro";
                            worksheet.Cell("T" + (1 + i)).Value =
                                "Cidade";
                            worksheet.Cell("U" + (1 + i)).Value =
                                "Estado";
                        }
                        worksheet.Cell("A" + (2 + i)).Value =
                               obj.Id;
                        worksheet.Cell("B" + (2 + i)).Value =
                            obj.InsertDate;

                        if (obj is SupplierPhysical)
                        {
                            SupplierPhysical client = (SupplierPhysical)obj;
                            worksheet.Cell("C" + (2 + i)).Value =
                           client.FullName;
                            worksheet.Cell("I" + (2 + i)).Value =
                           client.Sexo;
                            worksheet.Cell("K" + (2 + i)).Value =
                            client.BirthDay;
                        }
                        else
                        {
                            SupplierJuridical client = (SupplierJuridical)obj;
                            worksheet.Cell("D" + (2 + i)).Value =
                            client.CompanyName;
                            worksheet.Cell("E" + (2 + i)).Value =
                            client.FantasyName;
                            worksheet.Cell("L" + (2 + i)).Value =
                            client.OpeningDate;
                        }
                        foreach (var item in obj.Contacts)
                        {
                            if (item.TypeNumber == Models.Enums.TypeNumber.Celular)
                            {
                                worksheet.Cell("F" + (2 + i)).Value =
                                    item.DDD + " - " + item.Number;
                            }
                            if (item.TypeNumber == Models.Enums.TypeNumber.Residencial)
                            {
                                worksheet.Cell("G" + (2 + i)).Value =
                                item.DDD + " - " + item.Number;
                            }
                        }
                        worksheet.Cell("H" + (2 + i)).Value =
                           obj.Email;
                        worksheet.Cell("J" + (2 + i)).Value =
                           obj.Active;
                        worksheet.Cell("M" + (2 + i)).Value =
                             obj.RegisterEmployee.Name;
                        worksheet.Cell("N" + (2 + i)).Value =
                            obj.Address.ZipCode;
                        worksheet.Cell("O" + (2 + i)).Value =
                            obj.Address.Street;
                        worksheet.Cell("P" + (2 + i)).Value =
                            obj.Address.Number;
                        worksheet.Cell("Q" + (2 + i)).Value =
                            obj.Address.Complement;
                        worksheet.Cell("R" + (2 + i)).Value =
                            obj.Address.Reference;
                        worksheet.Cell("S" + (2 + i)).Value =
                            obj.Address.Neighborhood;
                        worksheet.Cell("T" + (2 + i)).Value =
                            obj.Address.City.Name;
                        worksheet.Cell("U" + (2 + i)).Value =
                            obj.Address.City.State.Name;
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
