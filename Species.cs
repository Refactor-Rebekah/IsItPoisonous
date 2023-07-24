using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonousApp
{
    public class Species
    {
        public int TaxonID { get; set; }
        public string ScientificName { get; set; }
        public string AcceptedCommonName { get; set; }
        public string KingdomCommonName { get; set; }
        public string FamilyCommonName { get; set; }
        public string PestStatus { get; set; }
       
        public class SpeciesImage
        {
            public string URL { get; set; }
        }
    }
}
