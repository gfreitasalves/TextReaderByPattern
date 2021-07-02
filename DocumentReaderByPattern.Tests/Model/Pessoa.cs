using System.Collections.Generic;

namespace TextReaderByPattern.Tests
{
    public class Pessoa
    {
        public string Nome { get; set; }       

        public ICollection<Telefone> Telefones { get; set; }
    }
}