using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GetSnomedRelationships.Domain;
using System.Threading.Tasks;

namespace GetSnomedRelationships
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("This program gets the definitions of the relationship types from the Snomed site and, where the description is active, tries to find the attribute description. " +
                              "These are then bundled up into a SQL command that you can use to create a table variable in queries");

            var query = new StringBuilder("declare @RelationshipDescriptions table (id  bigint, Description varchar(1000)); insert into @RelationshipDescriptions (id, Description) ");
            var first = true;
            //from: select distinct(typeid) from dbo.relationships
            var ids = new List<long>
            {
                246075003, 408729009, 116676008, 116683001, 736474004, 718497002, 260669005, 309824003, 370134009,
                118169006, 363703001, 418775008, 736518005, 736475003, 367346004, 4075201000001103, 272741003,
                12223101000001108, 736472000, 704319004, 116678009, 738774007, 4074601000001102, 13088901000001108,
                736473005, 424244007, 736476002, 370131001, 260507000, 260858005, 10363001000001101, 127489000,
                363708005, 732947008, 363705008, 370130000, 424876005, 123005000, 410675002, 246456000, 763032000,
                255234002, 704327008, 246454002, 424361007, 4074901000001109, 8940601000001102, 4075401000001104,
                261583007, 4074801000001103, 246090004, 8941901000001101, 762949000, 84971000000100, 131195008,
                246112005, 733723002, 8653101000001104, 47429007, 370133003, 726542003, 246093002, 246075003, 732946004,
                363698007, 363702006, 405813007, 405816004, 116680003, 363701004, 732943007, 10546003,
                10362601000001103, 246100006, 704326004, 263535000, 4074701000001107, 260686004, 10362901000001105,
                246267002, 363704007, 363713009, 704321009, 733725009, 8652801000001103, 766952006, 363709002,
                118168003, 363589002, 9191701000001107, 10362701000001108, 408732007, 10362801000001104, 424226004,
                425391005, 704318007, 8941101000001104, 733724008, 263502005, 363710007, 42752001, 726633004, 371881003,
                246501002, 260870009, 719715003, 308489006, 370129005, 370135005, 732945000, 13088501000001100,
                116686009, 405814001, 8941301000001102, 419066007, 260908002, 370132008, 13089101000001102, 704324001,
                408730004, 13088401000001104, 370127007, 411116001, 8940001000001105, 12223201000001101, 258214002,
                733722007, 118170007, 246513007, 363699004, 408731000, 363714003, 13085501000001109, 732944001,
                13088701000001106, 363715002, 363700003, 405815000, 118171006, 12223501000001103
            };//{ 116680003, 408729009, 116676008, 116683001, 736474004};
            foreach (var id in ids)
            {
                var description = "(Could not be found)";
                
                
                try
                {
                    var concept = await ConceptFactory.GetById(id);
                    if (concept.Active)
                    {
                        var term = concept.Descriptions.First(descr => descr.Active && descr.Released).Term;
                        var attributeTerm = concept.Descriptions.FirstOrDefault(descr => descr.Active && descr.Released && descr.Term.Contains("(attribute)"))?.Term;
                        term = attributeTerm ?? term;
                        foreach (var description1 in concept.Descriptions.Where(descr => descr.Active && descr.Released))
                        {
                            
                            Console.WriteLine($"{id}: {description1.Term}");
                        }
                        Console.WriteLine($"{id} ** {term}");
                        description = term;
                    }
                    else
                    {
                        var term = concept.Descriptions.First().Term;
                        Console.WriteLine($"{id} is Inactive");
                        description = $"(Inactive) {term}";
                    }
                }
                catch (System.Net.Http.HttpRequestException ex)
                {
                    Console.WriteLine($"{id} EX: {ex.Message}");
                }

                query.Append(first ?"": " union ");
                
                var sql = $"select {id},'{description}' ";
                first = false;
                query.Append(sql);
            }
            Console.WriteLine(query);
        }
    }
}
