using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextReaderByPattern
{
    public class Pattern<T> : IPattern<T>
    {
        public Pattern(string regex, Action<string, T> action)
        {
            Regex = regex;
            Action = action;
        }
        public string Regex { get; set; }
        public Action<string, T> Action { get; set; }        
        public void PopulateValue(T entity, string text)
        {
            //TODO: colocar regex
            var result = System.Text.RegularExpressions.Regex.Match(text, Regex).Value;


            Action(result, entity);
        }
    }
}