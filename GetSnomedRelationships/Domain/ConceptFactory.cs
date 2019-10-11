using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetSnomedRelationships.Domain
{
    internal class ConceptFactory
    {
        internal static async Task<Model.Concept> GetById(long id)
        {
            var client = new HttpClient();
            var url = $"https://browser.ihtsdotools.org/snowstorm/snomed-ct/v2/browser/MAIN/concepts/{id}";
            var responseTask = client.GetStringAsync(url);
            var response = await responseTask;
//            var rawResp = "{\"conceptId\":\"408729009\",\"fsn\":{\"term\":\"Finding context (attribute)\",\"lang\":\"en\"},\"pt\":{\"term\":\"Finding context\",\"lang\":\"en\"},\"active\":true,\"effectiveTime\":\"20110131\",\"released\":true,\"releasedEffectiveTime\":20110131,\"moduleId\":\"900000000000012004\",\"definitionStatus\":\"PRIMITIVE\",\"descriptions\":[{\"active\":true,\"released\":true,\"releasedEffectiveTime\":20170731,\"descriptionId\":\"2470590016\",\"term\":\"Finding context\",\"conceptId\":\"408729009\",\"moduleId\":\"900000000000012004\",\"typeId\":\"900000000000013009\",\"acceptabilityMap\":{\"900000000000509007\":\"PREFERRED\",\"900000000000508004\":\"PREFERRED\"},\"type\":\"SYNONYM\",\"caseSignificance\":\"CASE_INSENSITIVE\",\"lang\":\"en\",\"effectiveTime\":\"20170731\"},{\"active\":true,\"released\":true,\"releasedEffectiveTime\":20170731,\"descriptionId\":\"2464180013\",\"term\":\"Finding context (attribute)\",\"conceptId\":\"408729009\",\"moduleId\":\"900000000000012004\",\"typeId\":\"900000000000003001\",\"acceptabilityMap\":{\"900000000000509007\":\"PREFERRED\",\"900000000000508004\":\"PREFERRED\"},\"type\":\"FSN\",\"caseSignificance\":\"CASE_INSENSITIVE\",\"lang\":\"en\",\"effectiveTime\":\"20170731\"}],\"classAxioms\":[{\"axiomId\":\"549aca85-e958-439c-a14f-73af8a4387d5\",\"moduleId\":\"900000000000012004\",\"active\":true,\"released\":true,\"definitionStatusId\":\"900000000000074008\",\"relationships\":[{\"active\":true,\"released\":false,\"moduleId\":\"900000000000207008\",\"sourceId\":\"408729009\",\"destinationId\":\"762705008\",\"typeId\":\"116680003\",\"type\":{\"conceptId\":\"116680003\",\"fsn\":{\"term\":\"Is a (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Is a\",\"lang\":\"en\"},\"id\":\"116680003\"},\"target\":{\"conceptId\":\"762705008\",\"fsn\":{\"term\":\"Concept model object attribute (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Concept model object attribute\",\"lang\":\"en\"},\"id\":\"762705008\"},\"groupId\":0,\"modifier\":\"EXISTENTIAL\",\"characteristicType\":\"STATED_RELATIONSHIP\"}],\"definitionStatus\":\"PRIMITIVE\",\"id\":\"549aca85-e958-439c-a14f-73af8a4387d5\",\"effectiveTime\":20190731}],\"gciAxioms\":[],\"relationships\":[{\"active\":false,\"released\":true,\"releasedEffectiveTime\":20190731,\"relationshipId\":\"7978736020\",\"moduleId\":\"900000000000012004\",\"sourceId\":\"408729009\",\"destinationId\":\"762705008\",\"typeId\":\"116680003\",\"type\":{\"conceptId\":\"116680003\",\"fsn\":{\"term\":\"Is a (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Is a\",\"lang\":\"en\"},\"id\":\"116680003\"},\"target\":{\"conceptId\":\"762705008\",\"fsn\":{\"term\":\"Concept model object attribute (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Concept model object attribute\",\"lang\":\"en\"},\"id\":\"762705008\"},\"groupId\":0,\"modifier\":\"EXISTENTIAL\",\"characteristicType\":\"STATED_RELATIONSHIP\",\"effectiveTime\":\"20190731\",\"id\":\"7978736020\"},{\"active\":true,\"released\":true,\"releasedEffectiveTime\":20180131,\"relationshipId\":\"9059420020\",\"moduleId\":\"900000000000012004\",\"sourceId\":\"408729009\",\"destinationId\":\"762705008\",\"typeId\":\"116680003\",\"type\":{\"conceptId\":\"116680003\",\"fsn\":{\"term\":\"Is a (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Is a\",\"lang\":\"en\"},\"id\":\"116680003\"},\"target\":{\"conceptId\":\"762705008\",\"fsn\":{\"term\":\"Concept model object attribute (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Concept model object attribute\",\"lang\":\"en\"},\"id\":\"762705008\"},\"groupId\":0,\"modifier\":\"EXISTENTIAL\",\"characteristicType\":\"INFERRED_RELATIONSHIP\",\"effectiveTime\":\"20180131\",\"id\":\"9059420020\"},{\"active\":false,\"released\":true,\"releasedEffectiveTime\":20180131,\"relationshipId\":\"2540221024\",\"moduleId\":\"900000000000012004\",\"sourceId\":\"408729009\",\"destinationId\":\"410662002\",\"typeId\":\"116680003\",\"type\":{\"conceptId\":\"116680003\",\"fsn\":{\"term\":\"Is a (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Is a\",\"lang\":\"en\"},\"id\":\"116680003\"},\"target\":{\"conceptId\":\"410662002\",\"fsn\":{\"term\":\"Concept model attribute (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Concept model attribute\",\"lang\":\"en\"},\"id\":\"410662002\"},\"groupId\":0,\"modifier\":\"EXISTENTIAL\",\"characteristicType\":\"INFERRED_RELATIONSHIP\",\"effectiveTime\":\"20180131\",\"id\":\"2540221024\"},{\"active\":false,\"released\":true,\"releasedEffectiveTime\":20180131,\"relationshipId\":\"3952914027\",\"moduleId\":\"900000000000012004\",\"sourceId\":\"408729009\",\"destinationId\":\"410662002\",\"typeId\":\"116680003\",\"type\":{\"conceptId\":\"116680003\",\"fsn\":{\"term\":\"Is a (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Is a\",\"lang\":\"en\"},\"id\":\"116680003\"},\"target\":{\"conceptId\":\"410662002\",\"fsn\":{\"term\":\"Concept model attribute (attribute)\",\"lang\":\"en\"},\"definitionStatus\":\"PRIMITIVE\",\"pt\":{\"term\":\"Concept model attribute\",\"lang\":\"en\"},\"id\":\"410662002\"},\"groupId\":0,\"modifier\":\"EXISTENTIAL\",\"characteristicType\":\"STATED_RELATIONSHIP\",\"effectiveTime\":\"20180131\",\"id\":\"3952914027\"}]}";
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            try
            {
                var retval= JsonSerializer.Deserialize<Model.Concept>(response, options);
                return retval;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
