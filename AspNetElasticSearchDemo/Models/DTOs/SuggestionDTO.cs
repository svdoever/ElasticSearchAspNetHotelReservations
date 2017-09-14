using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetElasticSearchDemo.Models.Documents;

namespace AspNetElasticSearchDemo.Models.DTOs
{
    public class SuggestionDTO
    {
        public SuggestionDTO()
        {

        }

        
        public string Suggestion { get; set; }
        public IEnumerable<string> Terms { get; set; }

        public static SuggestionDTO FromSuggestion (KeyValuePair<string, Suggest<RoomDocument>[]> suggestion)
        {
            return new SuggestionDTO
            {
                Suggestion = suggestion.Key,
                Terms = suggestion.Value.SelectMany(v => v.Options).Select(o => o.Text)
            };
        }
    }
}
