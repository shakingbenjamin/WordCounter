using System.Collections.Generic;
using TopTen.Api.Models;

namespace TopTen.Api.Data
{
    public interface IDataManager
    {
        IEnumerable<WordItem> GetListOfMatchingWords(string path, string delim);

        Dictionary<string, int> CompareWordsInString(string words, char delim);

        Dictionary<string, int> TopTenWords(Dictionary<string, int> dictionary);

        IEnumerable<WordItem> ConvertToWordItem(Dictionary<string, int> dictionary);
    }
}