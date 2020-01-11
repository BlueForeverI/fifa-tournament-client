using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FifaTournamentClient.Services
{
    public class GraphHelper
    {
        private readonly string apiUrl = "https://fifa-tournament-graph-api.herokuapp.com/";
        private HttpClient httpClient;

        public GraphHelper(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<T> GetObject<T>(string query, string property)
        {
            var content = new StringContent($"{{\"query\":\"{{\\n{FormatQuery(query)}\\n}}\\n\"}}",
                Encoding.UTF8, "application/json");
            return ExecuteGraphRequest<T>(content, property);
        }

        public Task<T> ExecuteMutation<T>(string query, string property)
        {
            var content = new StringContent($"{{\"query\":\"\\n{FormatQuery(query)}\\n\"}}",
                Encoding.UTF8, "application/json");
            return ExecuteGraphRequest<T>(content, property);
        }

        private async Task<T> ExecuteGraphRequest<T>(HttpContent request, string dataProperty)
        {
            string resp = await (await httpClient.PostAsync(
                apiUrl,
                request)).Content.ReadAsStringAsync();
            var des = JsonConvert.DeserializeObject(resp);
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject((des as dynamic).data[dataProperty]));
        }

        private string FormatQuery(string original)
        {
            return Regex.Replace(original.Replace("\n", "\\n").Replace(" ", String.Empty), @"\t|\n|\r", "");
        }
    }
}
