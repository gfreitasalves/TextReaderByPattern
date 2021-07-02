using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextReaderByPattern
{
    public class PatternList<T> : IPattern<T>
    {
        public PatternList(string regex, Action<string[], T> action)
        {
            Regex = regex;
            Action = action;
        }
        public string Regex { get; set; }
        public Action<string[], T> Action { get; set; }
        public void PopulateValue(T entity, string text)
        {
            //TODO: colocar regex
            var result = System.Text.RegularExpressions.Regex.Matches(text, Regex).Select(m=>m.Value).ToArray();

            Action(result, entity);
        }
    }
}