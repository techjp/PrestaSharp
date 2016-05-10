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
    public class delivery : PrestaShopEntity
    {
        public long? id { get; set; }

        public long id_carrier { get; set; }
        /// <summary>
        /// Unsigned. Required.
        /// </summary>



        // XmlIgnore means it is not directly serialized
        // We can't directly serialize this as a NULL value (empty XML tag) will cause an error
        //[XmlIgnore]
        //'public long? id_range_price { get; set; }
        public long? id_range_price { get; set; }
        /// <summary>
        /// Unsigned. Required. If NULL we send 0 as a NULL value or empty value causes the web service to return an error.
        /// </summary>


        //'[XmlElement("id_range_price")]
        //'public string _id_range_price_Surrogate
        //'{
        //'    get
        //'    {
        //'        return (id_range_price.HasValue) ? id_range_price.ToString() : "0";
        //'    }
        //'    set
        //'    {
        //'        if (!value.Equals(""))
        //'        {
        //'            id_range_price = long.Parse(value);
        //'        }
        //'    }
        //'}



        // XmlIgnore means it is not directly serialized
        // We can't directly serialize this as a NULL value (empty XML tag) will cause an error
        //[XmlIgnore]
        //public long? id_range_weight { get; set; }
        public long? id_range_weight { get; set; }
        /// <summary>
        /// Unsigned. Required. If NULL we send 0 as a NULL value or empty value causes the web service to return an error.
        /// </summary>


        //'[XmlElement("id_range_weight")]
        //'public string _id_range_weight_Surrogate
        //'{
        //'    get
        //'    {
        //'        // return (id_range_weight.HasValue) ? id_range_weight.ToString() : "<null/>";
        //'        return (id_range_weight.HasValue) ? id_range_weight.ToString() : "0";
        //'    }
        //'    set
        //'    {
        //'        if (!value.Equals(""))
        //'        {
        //'            id_range_weight = long.Parse(value);
        //'        }
        //'    }
        //'}



        public long id_zone { get; set; }
        /// <summary>
        /// Unsigned. Required.
        /// </summary>



        public long? id_shop { get; set; }
        /// public string id_shop { get; set; }
        /// <summary>
        /// Unsigned. Not required.
        /// </summary>

        public bool ShouldSerializeid_shop()
        {
            return id_shop.HasValue;
        }



        public long? id_shop_group { get; set; }
        /// public string id_shop_group { get; set; }
        /// <summary>
        /// Unsigned. Not required.
        /// </summary>

        public bool ShouldSerializeid_shop_group()
        {
            return id_shop_group.HasValue;
        }




        public decimal price { get; set; }
        /// <summary>
        /// Required.
        /// </summary>

        public delivery()
        {
        }
    }
}