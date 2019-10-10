using System;
using System.Collections.Generic;
using System.Linq;
using GetSnomedRelationships.Domain;
using System.Threading.Tasks;

namespace GetSnomedRelationships
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ids = new List<int> {408729009, 116676008, 116683001, 736474004};
            foreach (var id in ids)
            {
                var concept = await ConceptFactory.GetById(id);
                var term = concept.Relationships.Single(concept => concept.Active).Type.Pt.Term;
                Console.WriteLine($"{id}: {term}");
            }
            Console.WriteLine("Hello World!");
        }
    }
}
