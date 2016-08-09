using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

using StudentPartners.Service.DataObjects;
using StudentPartners.Service.Helpers;
using StudentPartners.Service.Models;

using Microsoft.Azure.Mobile.Server;

namespace StudentPartners.Service.Controllers
{
    [Authorize]
    public class StudentPartnerController : TableController<StudentPartner>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<StudentPartner>(context, Request);
        }

        [ExpandProperty("Address")]
        public IQueryable<StudentPartner> GetAllStudentPartner()
        {
            return Query(); 
        }

        [ExpandProperty("Address")]
        public SingleResult<StudentPartner> GetStudentPartner(string id)
        {
            return Lookup(id);
        }
        
        public Task<StudentPartner> PatchStudentPartner(string id, Delta<StudentPartner> patch)
        {
             return UpdateAsync(id, patch);
        }
        
        public async Task<IHttpActionResult> PostStudentPartner(StudentPartner item)
        {
            StudentPartner current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
        
        public Task DeleteStudentPartner(string id)
        {
             return DeleteAsync(id);
        }
    }
}
