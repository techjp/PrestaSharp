using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class stock : PrestaShopEntity
    {
        public long? id { get; set; }

        public long? id_warehouse { get; set; }

        public long? id_product { get; set; }

        public long? id_product_attribute { get; set; }

        public long real_quantity { get; }

        public string reference { get; set; }

        public string ean13 { get; set; }

        public string upc { get; set; }

        /// <summary>
        /// Total physical quantity of current item available in this warehouse, including items not available for sale.
        /// </summary>
        public long physical_quantity { get; set; }

        /// <summary>
        /// Quantity available for sale in this warehouse.
        /// </summary>
        public long usable_quantity { get; set; }

        /// <summary>
        /// Unit price without stock for the current product. (te = tax excluded)
        /// </summary>
        public decimal price_te { get; set; }

        public stock()
        {
        }
    }
}