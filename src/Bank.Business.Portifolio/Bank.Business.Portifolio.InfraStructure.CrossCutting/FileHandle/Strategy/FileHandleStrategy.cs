using Bank.Business.Portifolio.Domain.Interfaces.ICrossCutting;
using System;
using System.IO;

namespace Bank.Business.Portifolio.InfraStructure.CrossCutting.FileHandle.Strategy
{
    public class FileHandleStrategy : IFileHandle
    {        
        public string[] GetFileText(string endpoint)
        {
            string[] str = Array.Empty<string>();
            if (endpoint.IndexOf("http://") != -1 || endpoint.IndexOf("https://") != -1)
            {
                Uri uri = new Uri();
                return uri.GetTxt(endpoint);
            }           

            switch (Path.GetExtension(endpoint.ToLower()))
            {
                case ".txt":
                    {
                        Txt txt = new Txt();
                        str = txt.GetTxt(endpoint);
                        break;
                    }
                case ".pdf":
                    {
                        Pdf pdf = new Pdf();
                        str = pdf.GetTxt(endpoint);
                        break;
                    }
                case ".doc":
                case ".docx":
                    {
                        Word word = new Word();
                        str = word.GetTxt(endpoint);
                        break;
                    }
                case ".xls":
                case ".xlsx":
                    {
                        Excel excel = new Excel();
                        str = excel.GetTxt(endpoint);
                        break;
                    }
                default:
                    str = new string[1] { "Arquivo não suportado pela aplicação" };
                    break;
            }
            return str;
        }
    }
}
