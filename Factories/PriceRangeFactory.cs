using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class PriceRangeFactory : RestSharpFactory
    {
        public PriceRangeFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.price_range Get(long PriceRangeId)
        {
            RestRequest request = this.RequestForGet("price_ranges", PriceRangeId, "price_range");
            return this.Execute<Entities.price_range>(request);
        }

        public Entities.price_range Add(Entities.price_range PriceRange)
        {
            long? idAux = PriceRange.id;
            PriceRange.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(PriceRange);
            RestRequest request = this.RequestForAdd("price_ranges", Entities);
            Entities.price_range aux = this.Execute<Entities.price_range>(request);
            PriceRange.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.price_range PriceRange)
        {
            RestRequest request = this.RequestForUpdate("price_ranges", PriceRange.id, PriceRange);
            this.Execute<Entities.price_range>(request);
        }

        public void Delete(long PriceRangeId)
        {
            RestRequest request = this.RequestForDelete("price_ranges", PriceRangeId);
            this.Execute<Entities.price_range>(request);
        }

        public void Delete(Entities.price_range PriceRange)
        {
            this.Delete((long)PriceRange.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("price_ranges", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "price_range");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.price_range> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("price_ranges", "full", Filter, Sort, Limit, "price_ranges");
            return this.ExecuteForFilter<List<Entities.price_range>>(request);
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
            RestRequest request = this.RequestForFilter("price_ranges", "[id]", Filter, Sort, Limit, "price_ranges");
            List<PrestaSharp.Entities.FilterEntities.price_range> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.price_range>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all price ranges.
        /// </summary>
        /// <returns>A list of price ranges</returns>
        public List<Entities.price_range> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of price ranges.
        /// </summary>
        /// <param name="PriceRanges"></param>
        /// <returns></returns>
        public List<Entities.price_range> AddList(List<Entities.price_range> PriceRanges)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.price_range PriceRange in PriceRanges)
            {
                PriceRange.id = null;
                Entities.Add(PriceRange);
            }
            RestRequest request = this.RequestForAdd("price_ranges", Entities);
            return this.Execute<List<Entities.price_range>>(request);
        }
    }
}
