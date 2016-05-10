using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bukimedia.PrestaSharp.Lib;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class warehouse : PrestaShopEntity
    {
        public long? id { get; set; }

        public long? id_address { get; set; }

        public long? id_employee { get; set; }

        public long? id_currency { get; set; }

        /// <summary>
        /// Warehouse stock valuation. Read only.
        /// </summary>
        public decimal valuation { get; }

        /// <summary>
        /// It's a logical bool.
        /// </summary>
        public long deleted { get; set; }

        public string reference { get; set; }

        public string name { get; set; }

        public string management_type { get; set; }

        public AuxEntities.AssociationsWarehouse associations { get; set; }

        public warehouse()
        {
        }
    }
}
