using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            
            var sentenceSeparator = new[] {'!', '?', '.', ';', ':', '(', ')'};
            // Все символы, кроме ' и букв
            var wordSeparator = text
                .Where(el => !char.IsLetter(el) && el != '\''  )
                .Distinct()
                .ToArray();
            
            var sentenceList = new List<string>();
            var sentences = text.Split(sentenceSeparator);
            foreach (var sentence in sentences)
            {
                sentenceList = sentence
                    .Split(wordSeparator) // Разделяем предложения
                    .Where(x => x != string.Empty) // Выбираем не пустые 
                    .Select(x => x.ToLower()) // Проиводим их к нижнему регистру 
                    .ToList();
                
                if (sentenceList.Count != 0) 
                    sentencesList.Add(sentenceList);
            }
            return sentencesList;
        }
    }
}