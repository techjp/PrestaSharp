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
    public class weight_range : PrestaShopEntity
    {
        public long? id { get; set; }

        public long id_carrier { get; set; }

        public float delimiter1 { get; set; }
        /// <summary>
        /// delimiter1 is exclusive. For example, if delimiter1 is set to 100 then it is for values greater than 100.
        /// </summary>

        public float delimiter2 { get; set; }
        /// <summary>
        /// delimiter2 is inclusive. For example, if delimiter2 is set to 200 then it is for values up to and including 200.
        /// </summary>

        public weight_range()
        {
        }
    }
}