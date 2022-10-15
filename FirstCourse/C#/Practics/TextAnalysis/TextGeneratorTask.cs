using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var phrase = phraseBeginning.Split(' ').ToList();
            for (var i = 0; i < wordsCount; i++)
            {
                if (phrase.Count >= 2 &&
                    nextWords.ContainsKey(phrase[phrase.Count - 2] + " " + phrase[phrase.Count - 1]))
                    phrase.Add(nextWords[phrase[phrase.Count - 2] + " " + phrase[phrase.Count - 1]]);
                else
                {
                    if (nextWords.ContainsKey(phrase[phrase.Count - 1]))
                        phrase.Add(nextWords[phrase[phrase.Count - 1]]);
                    else
                        break;
                }
            }
            return string.Join(" ", phrase);
        }
    }
}