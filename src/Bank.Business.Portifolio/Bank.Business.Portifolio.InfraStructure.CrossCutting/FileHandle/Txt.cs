using System;
using System.IO;

namespace Bank.Business.Portifolio.InfraStructure.CrossCutting.FileHandle
{
    public class Txt
    {
        public string[] GetTxt(string endpoint)
        {
            try
            {
                using (var streamReader = File.OpenText(endpoint))
                {
                    return streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch(IOException ex)
            {
                throw ex;
            }
        }
    }
}
