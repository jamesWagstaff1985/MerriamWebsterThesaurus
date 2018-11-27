using System;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace MyProject.Models
{
    public class SynonymsAndAntonyms
    {
        private string key = "*****API KEY*******";
        //public string Query { get; set; }
        private StringBuilder _synonyms;
        private StringBuilder _antonyms;
        private JavaScriptSerializer _serializer;

        public (string, string) GetAssociatedWords(string Query)
        {
                    _synonyms = new StringBuilder();
                    _antonyms = new StringBuilder();
                    _serializer = new JavaScriptSerializer();

            if (!string.IsNullOrWhiteSpace(Query))
            {
                try
                {
                    string UriToCall = string.Format("https://www.dictionaryapi.com/api/v3/references/ithesaurus/json/{0}?key={1}", Query, key);
                    WebRequest request = WebRequest.Create(UriToCall);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream dataStream = response.GetResponseStream();

                    string responseFromServer;
                    using (StreamReader reader = new StreamReader(dataStream))
                    {

                        responseFromServer = reader.ReadToEnd();

                        reader.Close();
                    }

                    dynamic item = _serializer.Deserialize<object>(responseFromServer);

                    foreach (var syn in item[0]["meta"]["syns"][0])
                    {
                        _synonyms.Append(string.Format("{0}, ", syn));
                    }

                    foreach (var ant in item[0]["meta"]["ants"][0])
                    {
                        _antonyms.Append(string.Format("{0}, ", ant));
                    }
                    return (_synonyms.ToString().Remove(_synonyms.Length - 2, 2), _antonyms.ToString().Remove(_antonyms.Length - 2, 2));
                }
                catch (Exception)
                {
                    return ("No Synonyms were found", "No Antonyms were found");
                }
            }
            else
            {
                return ("", "");
            }
        }
    }
}
