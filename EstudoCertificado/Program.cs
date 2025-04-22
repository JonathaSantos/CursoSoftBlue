using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Font;
using System.Reflection.Metadata;
using System.Text;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Html2pdf.Attach.Impl;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Html;
using iText.StyledXmlParser.Node;
using iText.Html2pdf.Attach.Impl.Tags;
using iText.Kernel.XMP.Impl;
using iText.IO.Util;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using NLog;


namespace EstudoCertificado
{

    public static class Utils
    {
        public const int PageDivProperty = -10;
    }

    public class CustomPageTagWorker : DivTagWorker
    {
        public CustomPageTagWorker(IElementNode element, ProcessorContext context) : base(element, context)
        {
        }

        public override void ProcessEnd(IElementNode element, ProcessorContext context)
        {
            base.ProcessEnd(element, context);
            IPropertyContainer elementResult = GetElementResult();
            if (elementResult != null && !String.IsNullOrEmpty(element.GetAttribute(AttributeConstants.CLASS)) && element.GetAttribute(AttributeConstants.CLASS).StartsWith("frpage"))
            {
                elementResult.SetProperty(Utils.PageDivProperty, element.GetAttribute(AttributeConstants.CLASS));
            }
        }
    }
    public class CustomTagWorkerFactory : DefaultTagWorkerFactory
    {
        public override ITagWorker GetCustomTagWorker(IElementNode tag, ProcessorContext context)
        {
            if (TagConstants.DIV.Equals(tag.Name().ToLower()))
            {
                return new CustomPageTagWorker(tag, context);
            }
            return base.GetCustomTagWorker(tag, context);
        }
    }
    internal class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            try
            {
                Logger.Info("Iniciando conversão de HTML para PDF...");
                //ValidarCEPNET();
                NovoPDFGerar();
                //ValidarHtmlPDF();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Ocorreu um erro durante a conversão de HTML para PDF.");
            }
           

            Console.ReadKey();
        }

        private static void NovoPDFGerar()
        {
            // Caminho do arquivo HTML de origem
            //string caminhoHtml = @"C:\Users\jonat\Downloads\index (2).html";
            string caminhoHtml = @"D:\homologação psdd e nait e nip\_GERCAP09-NOVO_CAPA_PADRAO_AR_String_html_20241104_f1bd6d9d-f9f5-4e2d-a996-0af9518160c0.txt.html"; 
            string caminhoPdf = $@"D:\homologação psdd e nait e nip\NovoPDF_{DateTime.Now.ToString("yyyyMMdd")}_{Guid.NewGuid().ToString("N")}.pdf";
            try
            {
                if (string.IsNullOrEmpty(caminhoHtml))
                {
                    throw new Exception("O conteúdo do arquivo HTML está vazio ou o arquivo não foi encontrado.");
                }
                // Caminho de saída para o arquivo PDF


                string outputDirectory = System.IO.Path.GetDirectoryName(caminhoPdf);
                if (!Directory.Exists(outputDirectory))
                {
                    throw new DirectoryNotFoundException("O diretório de saída não existe.");
                }

                // Lê o conteúdo do arquivo HTML
                string htmlContent = File.ReadAllText(caminhoHtml);

                if (string.IsNullOrEmpty(htmlContent))
                {
                    throw new Exception("O conteúdo do arquivo HTML está vazio ou o arquivo não foi encontrado.");
                }

                // Cria um stream de saída para o PDF
                using (FileStream pdfStream = new FileStream(caminhoPdf, FileMode.Create, FileAccess.Write))
                {
                    var converterProperties = new ConverterProperties();

                    // Converte o HTML para PDF com propriedades de conversão
                    HtmlConverter.ConvertToPdf(htmlContent, pdfStream, converterProperties);

                    Console.WriteLine("Conversão concluída com sucesso!");
                }
                //using (FileStream pdfStream = new FileStream(caminhoPdf, FileMode.Create, FileAccess.Write))
                //{
                //    if (pdfStream == null)
                //    {
                //        throw new Exception("Não foi possível criar o stream de saída para o arquivo PDF.");
                //    }
                //    // Converte o HTML em PDF diretamente no stream de saída
                //    HtmlConverter.ConvertToPdf(htmlContent, pdfStream);

                //    Console.WriteLine("Conversão concluída com sucesso!");
                //}
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erro de referência nula: " + ex.Message);
                Console.WriteLine("Pilha de execução: " + ex.StackTrace);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Erro de permissão: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro de IO: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        private static string BuscarArquivo()
        {
            string conteudo = string.Empty;
            try
            {
                // Caminho completo do arquivo
                //string caminhoDoArquivo = @"D:\homologação psdd e nait e nip\_GERCAP09-NOVO_CAPA_PADRAO_AR_String_html_20241104_f1bd6d9d-f9f5-4e2d-a996-0af9518160c0.txt.html";
                string caminhoDoArquivo = @"C:\Users\jonat\Downloads\index (2).html";

                // Leitura do arquivo e conversão em string
                conteudo = File.ReadAllText(caminhoDoArquivo);

                // Exibe o conteúdo no console
                Console.WriteLine(conteudo);
                return conteudo;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Erro: O arquivo não foi encontrado.");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro: Problema ao acessar o arquivo.");
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Erro: Acesso não autorizado.");
                Console.WriteLine(ex.Message);
            }

            return conteudo;

        }

        private static void ValidarHtmlPDF()
        {
            var arquivo = BuscarArquivo();
            if (string.IsNullOrEmpty(arquivo))
            {
                throw new Exception("Problema no Arquivo");
            }
            try
            {
                var m2 = GerarPdf(arquivo, PageSize.A4, "ModeloHTMLLOCAL", "relatorio.NumeroAr1", "relatorio.NomePessoa", " relatorio.Cep");

                using (var stream = File.Create($@"D:\homologação psdd e nait e nip\_Testes_LOCAL_String_html_{DateTime.Now.ToString("yyyyMMdd")}_{Guid.NewGuid().ToString("N")}.pdf"))
                {
                    var temp2 = m2.ToArray();
                    stream.Write(temp2, 0, temp2.Length);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static byte[] GerarPdf(string reportHtml, PageSize pageSize, string modelo, string numeroAr1, string nomePessoa, string cep)
        {
            // Testando com uma simples string em uma fonte de código de barras
            string testeCodigoBarra = "<span style=\"font-family: 'Code-39-Logitogo'; font-size: 20pt;\">*123456789*</span>";
            //HtmlConverter.ConvertToPdf(testeCodigoBarra, pdfDocument, converterProperties);
            // reportHtml = testeCodigoBarra;

            using (var workStream = new MemoryStream())
            {
                using (var pdfWriter = new PdfWriter(workStream))
                {
                    // Definindo o provedor de fonte e adicionando ECTpostnet.ttf
                    //FontProvider fontProvider = new DefaultFontProvider(true, true, true);
                    FontProvider fontProvider = new DefaultFontProvider();
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ECTpostnet.ttf"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ECTSymbol.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/CALIBRI.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/CALIBRIB.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/CALIBRII.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/CALIBRIL.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/CALIBRILI.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/CALIBRIZ.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/TREBUC.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/TREBUCBD.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/TREBUCBI.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/TREBUCIT.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIAL.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIALBD.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIALBI.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIALI.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIALN.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIALNB.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIALNBI.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIALNI.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARIBLK.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/ARLRDBD.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/Code39AzaleaRegular3.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/3OF9_NEW.TTF"));
                    //fontProvider.AddFont(HttpContext.Current.Server.MapPath("~/fonts/Code-39-Logitogo.TTF"));
                    //fontProvider.AddFont(Current.Server.MapPath("~/fonts/Code-39-Logitogo.ttf"));
                    // Caminho absoluto para a fonte no sistema de arquivos local
                    string caminhoFonte = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", "Code-39-Logitogo.ttf");


                    fontProvider.AddFont(@"C:\Publicação_APP\documentoinfracao\Code-39-Logitogo.ttf");
                    fontProvider.AddFont(caminhoFonte);

                    bool fontCarregada = fontProvider.GetFontSet().GetFonts().Any(f => f.ToString().Contains("Code-39-Logitogo"));
                    Console.WriteLine("Fonte carregada: " + fontCarregada);


                    var converterProperties = new ConverterProperties();
                    converterProperties.SetTagWorkerFactory(new CustomTagWorkerFactory());
                    converterProperties.SetFontProvider(fontProvider);
                    var pdfDocument = new PdfDocument(pdfWriter);
                    pdfDocument.SetDefaultPageSize(pageSize);
                    // Definir propriedades do PDF
                    pdfDocument.GetDocumentInfo().SetTitle($"Documento: {modelo} - {Guid.NewGuid().ToString("N")}");
                    pdfDocument.GetDocumentInfo().SetAuthor($"Detran_{DateTime.Now.ToString("dd/MM/yyyy")}");
                    pdfDocument.GetDocumentInfo().SetSubject($"{nomePessoa}-{cep}-{numeroAr1}");//Assunto do Documento

                    var elements = HtmlConverter.ConvertToElements(reportHtml, converterProperties);

                    var document = new iText.Layout.Document(pdfDocument, pageSize);
                    document.SetMargins(0, 0, 0, 0);
                    int elementIndex = 0;
                    foreach (IElement element in elements)
                    {
                        if (element.HasProperty(Utils.PageDivProperty) && elementIndex > 0)
                        {
                            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                        }
                        document.Add((IBlockElement)element);
                        elementIndex++;
                    }
                    document.Close();
                    return workStream.ToArray();
                }
            }
        }

        private static void ValidarCEPNET()
        {
            string cep = "28107023";
            Console.WriteLine(34.40M);

            Console.WriteLine("informe o CEP");

            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                cep = input;
            }


            Console.WriteLine(cep);
            try
            {
                CEPNet cepNet = new CEPNet(cep);
                string resultado = cepNet.CalcularDigitoControle().ToString();
                Console.WriteLine(resultado);
                resultado = cepNet.GerarCEPNET();
                Console.WriteLine(resultado);
                Console.WriteLine("Dígito de Controle: " + cepNet.CalcularDigitoControle());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }



    public class CEPNet
    {
        private const int TotalDigits = 8; // Total de dígitos do CEP
        private const char StartDelimiter = '|'; // Delimitador inicial
        private const char StopDelimiter = '|'; // Delimitador final

        private string cep; // Armazenará o CEP (8 dígitos)

        public string CEP
        {
            get => cep;
            set
            {
                if (IsValidCEP(value))
                {
                    cep = value;
                }
                else
                {
                    throw new ArgumentException("CEP deve conter exatamente 8 dígitos numéricos.");
                }
            }
        }

        public CEPNet(string cep)
        {
            CEP = cep;
        }

        // Verifica se o CEP é válido (8 dígitos)
        private bool IsValidCEP(string cep)
        {
            return cep.Length == TotalDigits && long.TryParse(cep, out _);
        }

        // Calcula o dígito de controle
        public int CalcularDigitoControle()
        {
            int somaCEP = 0;

            foreach (char c in cep)
            {
                somaCEP += (int)char.GetNumericValue(c);
            }
            Console.WriteLine($"Soma do cep: {somaCEP}");
            int multiploDeDez = ((somaCEP / 10) + 1) * 10;
            int digitoControle = multiploDeDez - somaCEP;
            Console.WriteLine($"MultiplodeDEZ: {multiploDeDez} - digito controle: {digitoControle}");
            return digitoControle == 10 ? 0 : digitoControle;
        }

        // Gera a representação em barras do CEP
        public string GerarCEPNET()
        {
            int digitoControle = CalcularDigitoControle();
            string barras = StartDelimiter.ToString();

            // Adiciona cada dígito do CEP
            foreach (char c in cep)
            {
                barras += new string('-', (int)char.GetNumericValue(c) + 1) + " "; // 1 a 9 -> 2 a 10 barras
            }

            // Adiciona o dígito de controle
            barras += new string('-', digitoControle + 1) + StopDelimiter;

            return barras.Trim();
        }
    }




}
