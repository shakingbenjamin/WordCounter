using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TopTen.Api.Models;

namespace TopTen.Api.Data
{
    public class DataManager : IDataManager
    {
        public IEnumerable<WordItem> GetListOfMatchingWords(string path, string delim)
        {
            string text;
            var uri = new System.Uri(path);
            using (var client = new WebClient())
            {
                text = client.DownloadString(uri);
            }
            var wordsList = CompareWordsInString(text, Convert.ToChar(delim));
            return ConvertToWordItem(wordsList);
        }

        public Dictionary<string, int> CompareWordsInString(string words, char delim)
        {
            var list = words.Split(delim);
            var dictionary = new Dictionary<string, int>();

            for (var i = 0; list.Length > i; i++)
            {
                if (String.IsNullOrWhiteSpace(list[i]))
                {
                    continue;
                }
                if (dictionary.ContainsKey(list[i]))
                {
                    dictionary[list[i]]++;
                    continue;
                }
                dictionary.Add(list[i], 1);
            }
            return TopTenWords(dictionary);
        }

        public Dictionary<string, int> TopTenWords(Dictionary<string, int> dictionary)
        {
            return dictionary.OrderByDescending(x => x.Value).Take(10).ToDictionary(t => t.Key, t => t.Value);
        }

        public IEnumerable<WordItem> ConvertToWordItem(Dictionary<string, int> dictionary)
        {
            var wordItems = new List<WordItem>();

            foreach(var d in dictionary)
            {
                wordItems.Add(new WordItem { Total = d.Value, Word = d.Key });
            }

            return wordItems;
        }
    }
}