using Practic.Models.Models.BaseTables;
using System.Collections.Generic;

namespace Practic.Models
{
    public class Provider: BaseDictionary
    {
        public string ProviderCountry { get; set; }
        public ICollection<Material> Materials { get; }

        public Provider()
        {
            Materials = new List<Material>();
        }
    }
}
