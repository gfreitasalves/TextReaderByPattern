using System.Collections.Generic;
using System.Globalization;

namespace TextReaderByPattern
{
    public interface IPattern<T>
    {        
        string Regex { get; set; }        
        void PopulateValue(T entity, string text);        
    }
}