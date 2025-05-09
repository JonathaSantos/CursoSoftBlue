﻿using RelatoriosTesteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport.OpenSource.HtmlExporter.Core;
using FastReport.OpenSource.HtmlExporter.Models;
using 

namespace RelatoriosTesteApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExportWithPdfSimple();
            ExportWithoutPdfSimple();
        }

        static void ExportWithPdfSimple()
        {
            var data = GenerateData();
            var fastReportGenerator = new FastReportGenerator<TestReportDataModel>(ReportUtils.DesignerPath, "test.frx");
            var report = fastReportGenerator.GenerateWithPDFSimplePlugin(data);
            ExportToFile(report, "testWithPdfSimple");
        }

        static void ExportWithoutPdfSimple()
        {
            var data = GenerateData();
            var fastReportGenerator = new FastReportGenerator<TestReportDataModel>(ReportUtils.DesignerPath, "test.frx");
            var report = fastReportGenerator.GeneratePdfFromHtml(data, PageSize.A4);
            ExportToFile(report, "testWithoutPdfSimple");
        }

        static void ExportToFile(byte[] report, string fileName)
        {
            fileName = System.IO.Path.Combine(ReportUtils.ExportPath, string.Format("{0}.pdf", fileName));
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllBytes(fileName, report);
        }

        static List<TestReportDataModel> GenerateData()
        {
            var data = new List<TestReportDataModel>();
            for (int i = 0; i < 1000; i++)
            {
                data.Add(new TestReportDataModel { Id = i });
            }
            return data;
        }

    }
}
