using System;
using System.IO;
using iText.Html2pdf;
using iText.Kernel.Pdf;

namespace EstudoCertificado
{
    public static class PDFNovo
    {
        private static void GeraPDFdoHTML()
        {
            // Caminho do arquivo HTML de origem
            string caminhoHtml = @"C:\caminho\para\seu\arquivo.html";

            // Caminho de saída para o arquivo PDF
            string caminhoPdf = @"C:\caminho\para\seu\arquivo.pdf";

            try
            {
                // Lê o conteúdo do arquivo HTML
                string htmlContent = File.ReadAllText(caminhoHtml);

                // Cria um stream de saída para o PDF
                using (FileStream pdfStream = new FileStream(caminhoPdf, FileMode.Create, FileAccess.Write))
                {
                    // Cria um escritor de PDF
                    PdfWriter writer = new PdfWriter(pdfStream);

                    // Cria um documento PDF
                    PdfDocument pdfDocument = new PdfDocument(writer);

                    // Converte o HTML em PDF
                    //HtmlConverter.ConvertToPdf(htmlContent, pdfDocument);

                    Console.WriteLine("Conversão concluída com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro durante a conversão: " + ex.Message);
            }
        }
    }
}
