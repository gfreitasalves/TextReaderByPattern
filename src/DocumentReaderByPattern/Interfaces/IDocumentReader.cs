namespace TextReaderByPattern
{
    public interface IDocumentReader<T>
    {
        T Run(string texto);
    }
}