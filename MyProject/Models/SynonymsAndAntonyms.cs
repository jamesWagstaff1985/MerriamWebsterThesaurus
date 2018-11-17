using System;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace MyProject.Models
{
    public class SynonymsAndAntonyms
    {
        private string key = "b03a953f-cb43-40fd-9c3b-7cc8dbbe328e";
        public string query { get; set; }

        public (string, string) GetAssociatedWords()
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                try
                {
                    string UriToCall = String.Format("https://www.dictionaryapi.com/api/v3/references/ithesaurus/json/{0}?key={1}", query, key);
                    WebRequest request = WebRequest.Create(UriToCall);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream dataStream = response.GetResponseStream();

                    string responseFromServer;
                    using (StreamReader reader = new StreamReader(dataStream))
                    {

                        responseFromServer = reader.ReadToEnd();

                        reader.Close();
                    }

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseFromServer);

                    StringBuilder Synonyms = new StringBuilder();
                    foreach (var syn in item[0]["meta"]["syns"][0])
                    {
                        Synonyms.Append(String.Format("{0}, ", syn));
                    }

                    StringBuilder Antonyms = new StringBuilder();
                    foreach (var ant in item[0]["meta"]["ants"][0])
                    {
                        Antonyms.Append(String.Format("{0}, ", ant));
                    }
                    return (Synonyms.ToString(), Antonyms.ToString());
                }
                catch (Exception)
                {
                    return ("", "");
                }
            }
            else
            {
                return ("", "");
            }
        }
    }
}
