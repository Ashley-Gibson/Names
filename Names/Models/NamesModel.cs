using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Names.Models
{
    public class NamesModel
    {
        public IEnumerable<SelectListItem> OutputNames { get; set; }
        public IEnumerable<SelectListItem> OriginalNames { get; set; }
        public string GrandTotal { get; set; }
        public string HighestTotalScoringName { get; set; }
        public string HighestTotalScoringNamePosition { get; set; }
        public string LowestTotalScoringName { get; set; }
        public string LowestTotalScoringNamePosition { get; set; }

        public string HighestAlphabeticalValueName { get; set; }
        public string HighestAlphabeticalValue { get; set; }
    }
}
