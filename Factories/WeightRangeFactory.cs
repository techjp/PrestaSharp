using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class WeightRangeFactory : RestSharpFactory
    {
        public WeightRangeFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.weight_range Get(long WeightRangeId)
        {
            RestRequest request = this.RequestForGet("weight_ranges", WeightRangeId, "weight_range");
            return this.Execute<Entities.weight_range>(request);
        }

        public Entities.weight_range Add(Entities.weight_range WeightRange)
        {
            long? idAux = WeightRange.id;
            WeightRange.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(WeightRange);
            RestRequest request = this.RequestForAdd("weight_ranges", Entities);
            Entities.weight_range aux = this.Execute<Entities.weight_range>(request);
            WeightRange.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.weight_range WeightRange)
        {
            RestRequest request = this.RequestForUpdate("weight_ranges", WeightRange.id, WeightRange);
            this.Execute<Entities.weight_range>(request);
        }

        public void Delete(long WeightRangeId)
        {
            RestRequest request = this.RequestForDelete("weight_ranges", WeightRangeId);
            this.Execute<Entities.weight_range>(request);
        }

        public void Delete(Entities.weight_range WeightRange)
        {
            this.Delete((long)WeightRange.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("weight_ranges", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "weight_range");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.weight_range> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("weight_ranges", "full", Filter, Sort, Limit, "weight_ranges");
            return this.ExecuteForFilter<List<Entities.weight_range>>(request);
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
            RestRequest request = this.RequestForFilter("weight_ranges", "[id]", Filter, Sort, Limit, "weight_ranges");
            List<PrestaSharp.Entities.FilterEntities.weight_range> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.weight_range>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all weight ranges.
        /// </summary>
        /// <returns>A list of weight ranges</returns>
        public List<Entities.weight_range> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of weight ranges.
        /// </summary>
        /// <param name="WeightRange"></param>
        /// <returns></returns>
        public List<Entities.weight_range> AddList(List<Entities.weight_range> WeightRanges)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.weight_range WeightRange in WeightRanges)
            {
                WeightRange.id = null;
                Entities.Add(WeightRange);
            }
            RestRequest request = this.RequestForAdd("weight_ranges", Entities);
            return this.Execute<List<Entities.weight_range>>(request);
        }
    }
}
