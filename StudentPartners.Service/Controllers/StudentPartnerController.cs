using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using StudentPartners.Service.DataObjects;
using StudentPartners.Service.Models;

namespace StudentPartners.Service.Controllers
{
    public class StudentPartnerController : TableController<StudentPartner>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<StudentPartner>(context, Request);
        }

        // GET tables/StudentPartner
        public IQueryable<StudentPartner> GetAllStudentPartner()
        {
            return Query(); 
        }

        // GET tables/StudentPartner/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<StudentPartner> GetStudentPartner(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/StudentPartner/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<StudentPartner> PatchStudentPartner(string id, Delta<StudentPartner> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/StudentPartner
        public async Task<IHttpActionResult> PostStudentPartner(StudentPartner item)
        {
            StudentPartner current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/StudentPartner/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteStudentPartner(string id)
        {
             return DeleteAsync(id);
        }
    }
}
