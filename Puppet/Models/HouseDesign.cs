

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puppet.Models
{
    public class HouseDesign
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BuildingType { get; set; }
        public string Dimension { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}