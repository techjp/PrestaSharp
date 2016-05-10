using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsWarehouse : PrestaShopEntity
    {
        public List<AuxEntities.stock> stocks { get; set; }
        public List<AuxEntities.carrier> carriers { get; set; }
        public List<AuxEntities.combinations> combinations { get; set; }
        public List<AuxEntities.shop> shops { get; set; }

        public AssociationsWarehouse()
        {
            this.stocks = new List<stock>();
            this.carriers = new List<carrier>();
            this.shops = new List<shop>();
        }
    }
}
