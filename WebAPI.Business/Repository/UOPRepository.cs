using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.OData.Query;
using NHibernate;
using NHibernate.Linq;
using NHibernate.OData;
using WebAPI.Business.Entites;

namespace WebAPI.Business.Repository
{
    public class UOPRepository : IDisposable
    {
        private readonly ISession _session;

        public UOPRepository()
        {
            _session = NHibernateManager.CreateSessionFactory().OpenSession();
        }
        public IQueryable<UOP> GetAll(ODataQueryOptions<UOP> queryOptions)
        {
            var queryStringParts = new Dictionary<string, string>
            {
                {"$filter", queryOptions.RawValues.Filter},
                {"$orderby", queryOptions.RawValues.OrderBy},
                {"$top", queryOptions.RawValues.Top},
                {"$skip", queryOptions.RawValues.Skip}
            };

            var filter = queryStringParts.Where(x => !String.IsNullOrEmpty(x.Value));
            return _session.ODataQuery<UOP>(filter, new ODataParserConfiguration { CaseSensitive = false }).List<UOP>().AsQueryable();
        }

        public IQueryable<UOP> GetById(int id)
        {
            return _session.Query<UOP>().Where(x=>x.Id == id);
        }

        public void Dispose()
        {
            _session.Clear();
            _session.Close();
        }
    }
}
