using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;

namespace Bank.Business.Portifolio.InfraStructure.CrossCutting.FileHandle
{
    public class Pdf
    {
        public string[] GetTxt(string endpoint)
        {
            string[] str = Array.Empty<string>();

            try
            {
                using (PdfReader reader = new PdfReader(endpoint))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        str = PdfTextExtractor.GetTextFromPage(reader, i).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }

            return str;
        }
    }
}
