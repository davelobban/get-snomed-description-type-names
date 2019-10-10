using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetSnomedRelationships.Domain
{
    internal class ConceptFactory
    {
        internal static async Task<Model.Concept> GetById(int id)
        {
            var client = new HttpClient();
            var url = $"https://browser.ihtsdotools.org/snowstorm/snomed-ct/v2/browser/MAIN/concepts/{id}";
            var responseTask = client.GetStringAsync(url);
            var response = await responseTask;

            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            return JsonSerializer.Deserialize<Model.Concept>(response, options);
        }
    }
}
