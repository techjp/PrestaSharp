using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class StockFactory : RestSharpFactory
    {
        public StockFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.stock Get(long StockId)
        {
            RestRequest request = this.RequestForGet("stocks", StockId, "stock");
            return this.Execute<Entities.stock>(request);
        }

        public Entities.stock Add(Entities.stock Stock)
        {
            long? idAux = Stock.id;
            Stock.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Stock);
            RestRequest request = this.RequestForAdd("stocks", Entities);
            Entities.stock aux = this.Execute<Entities.stock>(request);
            Stock.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.stock Stock)
        {
            RestRequest request = this.RequestForUpdate("stocks", Stock.id, Stock);
            this.Execute<Entities.stock>(request);
        }

        // For Update List Of Stock - Start
        public List<Entities.stock> UpdateList(List<Entities.stock> Stocks)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.stock Stock in Stocks)
            {
                Entities.Add(Stock);
            }
            RestRequest request = this.RequestForUpdateList("stocks", Entities);
            //Console.WriteLine(request);
            return this.Execute<List<Entities.stock>>(request);
        }
        // For Update List Of Stock - End

        public void Delete(long StockId)
        {
            RestRequest request = this.RequestForDelete("stocks", StockId);
            this.Execute<Entities.stock>(request);
        }

        public void Delete(Entities.stock Stock)
        {
            this.Delete((long)Stock.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("stocks", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "stock");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.stock> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("stocks", "full", Filter, Sort, Limit, "stocks");
            return this.ExecuteForFilter<List<Entities.stock>>(request);
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
            RestRequest request = this.RequestForFilter("stocks", "[id]", Filter, Sort, Limit, "stocks");
            List<PrestaSharp.Entities.FilterEntities.stock> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.stock>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all stocks.
        /// </summary>
        /// <returns>A list of stock for products</returns>
        public List<Entities.stock> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a stock data for a list of products
        /// </summary>
        /// <param name="Stocks"></param>
        /// <returns></returns>
        public List<Entities.stock> AddList(List<Entities.stock> Stocks)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.stock Stock in Stocks)
            {
                Stock.id = null;
                Entities.Add(Stock);
            }
            RestRequest request = this.RequestForAdd("stocks", Entities);
            return this.Execute<List<Entities.stock>>(request);
        }
    }
}
