using System;

namespace TextReaderByPattern
{
    public class DocumentReader<T> : IDocumentReader<T> where T : class, new()
    {
        private readonly IPattern<T>[] Patterns;

        public DocumentReader(params IPattern<T>[] patterns)
        {
            Patterns = patterns;
        }
        
        public T Run(string texto)
        {
            T entity = new T();

            foreach (var pattern in Patterns)
            {
                pattern.PopulateValue(entity, texto);
            }

            return entity;
        }
    }
}
