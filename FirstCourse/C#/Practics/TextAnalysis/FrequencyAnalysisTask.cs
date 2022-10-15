using System;
using System.Linq;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var frequencyDictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                FillFrequencyDictionary(sentence, frequencyDictionary, 1);
                FillFrequencyDictionary(sentence, frequencyDictionary, 2);
            }

            return frequencyDictionary.Keys
                .ToDictionary(
                    key => key, 
                    key => frequencyDictionary[key]
                        .OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key.Replace('\'', ' '))
                        .First()
                        .Key);
        }

        //String.Compare(y, x)  Array.Sort(names, (x,y) => String.Compare(x.Name, y.Name));
        private static void FillFrequencyDictionary(
            List<string> sentence, 
            Dictionary<string, Dictionary<string, int>> frequencyDictionary, 
            int countAdjacentWords)
        {
            for (var i = 0; i < sentence.Count - countAdjacentWords; i++)
            {
                var adjacentWords = sentence[i];
                for (var j = 0; j < countAdjacentWords - 1; j++)
                {
                    adjacentWords += " " + sentence[i + j + 1];
                }

                if (frequencyDictionary.ContainsKey(adjacentWords))
                {
                    if (frequencyDictionary[adjacentWords].ContainsKey(sentence[i+countAdjacentWords]))
                        frequencyDictionary[adjacentWords][sentence[i + countAdjacentWords]]++;
                    else
                        frequencyDictionary[adjacentWords].Add(sentence[i+countAdjacentWords], 1);
                } else
                    frequencyDictionary.Add(
                        adjacentWords, 
                        new Dictionary<string, int>(){{sentence[i+countAdjacentWords], 1}}
                        );
            }
        }
   }
}