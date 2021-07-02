using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TextReaderByPattern.Tests
{
    public class TextReaderTest
    {
        private string Nome { get; set; }
        private string[] Telefones { get; set; }
        private string TextToExtract { get; set; }
        private string RegexNome { get; set; }
        private string RegexTelefone { get; set; }
        private Action<string, Pessoa> ActionNome { get; set; }
        private Action<string[], Pessoa> ActionTelefone { get; set; }

        [SetUp]
        public void Setup()
        {
            Nome = "Gilberto";
            Telefones = new string[] { "1111-1111", "1111-2222", "1111-3333" };
            TextToExtract = @$"Será obtido o que está nome:'{Nome}' entre aspas simples.{string.Join(" telefone:",Telefones)}";

            RegexNome = "(?<=nome\\:\\')(.*?)(?=\\')";
            RegexTelefone = "(?<=telefone\\:\\')(.*?)(?=\\')";

            ActionNome = (txt, p) => { p.Nome = txt; };
            ActionTelefone = (txts, p) =>
             {
                 p.Telefones = new List<Telefone>();
                 foreach (var txt in txts)
                 {
                     p.Telefones.Add(new Telefone() { Valor = txt });
                 }
             };
        }

        [Test]
        public void TestExtractPessoaNomeTelefones()
        {
            var patternNome = new Pattern<Pessoa>(RegexNome, ActionNome);
            var patternTelefone = new PatternList<Pessoa>(RegexTelefone, ActionTelefone);
            var documentReader = new DocumentReader<Pessoa>(patternNome, patternTelefone);

            var pessoa = documentReader.Run(TextToExtract);

            Assert.AreEqual(Nome, pessoa.Nome);
            Assert.IsTrue(pessoa.Telefones.All(t => Telefones.Contains(t.Valor)));
        }
    }
}