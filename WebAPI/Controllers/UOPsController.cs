using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using Microsoft.Data.OData;
using WebAPI.Business.Entites;
using WebAPI.Business.Repository;

namespace WebAPI.Controllers
{
    public class UOPsController : ODataController
    {
        private readonly UOPRepository _uopRepository = new UOPRepository();
        private static readonly ODataValidationSettings ValidationSettings = new ODataValidationSettings();

        // GET: odata/UOPs
        [EnableQuery]
        public IHttpActionResult GetUOPs(ODataQueryOptions<UOP> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(ValidationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(_uopRepository.GetAll(queryOptions));
        }

        // GET: odata/UOPs(5)
        [EnableQuery]
        public IHttpActionResult GetUOP([FromODataUri] int key, ODataQueryOptions<UOP> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(ValidationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(SingleResult.Create(_uopRepository.GetById(key)));
        }

        protected override void Dispose(bool disposing)
        {
            _uopRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}