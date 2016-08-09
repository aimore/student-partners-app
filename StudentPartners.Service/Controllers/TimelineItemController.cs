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
    public class TimelineItemController : TableController<TimelineItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<TimelineItem>(context, Request);
        }

        [ExpandProperty("Author,Comments")]
        public IQueryable<TimelineItem> GetAllTimelineItem()
        {
            return Query(); 
        }

        [ExpandProperty("Author,Comments")]
        public SingleResult<TimelineItem> GetTimelineItem(string id)
        {
            return Lookup(id);
        }
        
        public Task<TimelineItem> PatchTimelineItem(string id, Delta<TimelineItem> patch)
        {
             return UpdateAsync(id, patch);
        }
        
        public async Task<IHttpActionResult> PostTimelineItem(TimelineItem item)
        {
            TimelineItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
        
        public Task DeleteTimelineItem(string id)
        {
             return DeleteAsync(id);
        }
    }
}