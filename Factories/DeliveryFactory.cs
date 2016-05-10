using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class DeliveryFactory : RestSharpFactory
    {
        public DeliveryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.delivery Get(long DeliveryId)
        {
            RestRequest request = this.RequestForGet("deliveries", DeliveryId, "delivery");
            return this.Execute<Entities.delivery>(request);
        }

        public Entities.delivery Add(Entities.delivery Delivery)
        {
            long? idAux = Delivery.id;
            Delivery.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Delivery);
            RestRequest request = this.RequestForAdd("deliveries", Entities);
            Entities.delivery aux = this.Execute<Entities.delivery>(request);
            Delivery.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.delivery Delivery)
        {
            RestRequest request = this.RequestForUpdate("deliveries", Delivery.id, Delivery);
            this.Execute<Entities.delivery>(request);
        }

        public void Delete(long DeliveryId)
        {
            RestRequest request = this.RequestForDelete("deliveries", DeliveryId);
            this.Execute<Entities.delivery>(request);
            //System.IO.File.WriteAllText("D:\\prestasharp serialize.xml", doc.ToString());
        }

        // public void Delete(Entities.delivery Delivery)
        // {
        // this.Delete((long)Delivery.id);
        // }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("deliveries", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "delivery");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.delivery> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("deliveries", "full", Filter, Sort, Limit, "deliveries");
            return this.ExecuteForFilter<List<Entities.delivery>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("deliveries", "[id]", Filter, Sort, Limit, "deliveries");
            List<PrestaSharp.Entities.FilterEntities.delivery> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.delivery>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all deliveries.
        /// </summary>
        /// <returns>A list of deliveries</returns>
        public List<Entities.delivery> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of deliveries.
        /// </summary>
        /// <param name="deliveries"></param>
        /// <returns></returns>
        public List<Entities.delivery> AddList(List<Entities.delivery> Deliveries)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.delivery Delivery in Deliveries)
            {
                Delivery.id = null;
                Entities.Add(Delivery);
            }
            RestRequest request = this.RequestForAdd("deliveries", Entities);
            return this.Execute<List<Entities.delivery>>(request);
        }
    }
}
