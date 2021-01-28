namespace Bank.Business.Portifolio.Domain.Interfaces.ICrossCutting
{
    public interface IFileHandle
    {
        string[] GetFileText(string endpoint);
    }
}
