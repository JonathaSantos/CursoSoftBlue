using FastReport;
using System;
using System.IO;

namespace Fast.App
{
    public class Rep
    {
        public void GerarRelatorio()
        {

            try
            {
                var freport = new Report();
                freport.Report.Load(@"D:\modelos Nait & NIP\Nip.frx");

                //freport.Report.Save(reportFile);
                freport.Prepare();

                var pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();

                MemoryStream ms2 = new MemoryStream();
                pdfExport.Export(freport, ms2);
                ms2.Flush();
                //
                using (var stream2 = File.Create($@"D:\modelos Nait & NIP\_{Guid.NewGuid()}.pdf"))
                //using (var stream2 = File.Create($@"C:\Temp_v143\App\_{Guid.NewGuid()}.pdf"))
                {
                    var temp = ms2.ToArray();
                    stream2.Write(temp, 0, temp.Length);
                    var s2 = $"data:application/pdf;base64,{Convert.ToBase64String(temp)}";
                    stream2.Close();
                }
                ///
                //rep.Report.Load(@"D:\modelos Nait & NIP\Nip.frx");
                ////rep.Report.Load(@"C:\Temp_v143\App\Nip.frx");
                ////PDFExport export = new(); 
                ////rep.Export(@"D:\modelos Nait & NIP\teste1.pdf");
                //// save file in stream
                //rep.SetParameterValue("parm1", "Jonatha");
                //rep.SetParameterValue("parm1.n1", "Rafaela");
                //rep.SetParameterValue("parm1.n2", "Leite");
                //rep.Prepare();
                //var pdfExport = new PDFSimpleExport();

                //MemoryStream ms = new MemoryStream();
                //pdfExport.Export(rep, ms);
                //ms.Flush();

                //using (var stream2 = File.Create($@"D:\modelos Nait & NIP\_{Guid.NewGuid()}.pdf"))
                ////using (var stream2 = File.Create($@"C:\Temp_v143\App\_{Guid.NewGuid()}.pdf"))
                //{
                //    var temp = ms.ToArray();
                //    stream2.Write(temp, 0, temp.Length);
                //    var s2 = $"data:application/pdf;base64,{Convert.ToBase64String(temp)}";
                //    stream2.Close();
                //}

                //return (ms.ToArray(), "application/pdf");

            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}
