using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;

using StudentPartners.Service.DataObjects;

using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;

namespace StudentPartners.Service.Controllers
{
    [MobileAppController]
    public class UserInfoController : ApiController
    {
        [Authorize]
        public async Task<StudentPartner> Get()
        {
            var user = User as ClaimsPrincipal;
            var isAuthenticated = user.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var credentials = await user.GetAppServiceIdentityAsync<AzureActiveDirectoryCredentials>(Request);

            var userId = string.Empty;
            var firstName = string.Empty;
            var lastName = string.Empty;
            var email = string.Empty;
            var photoUrl = string.Empty;

            userId = credentials.UserId;
            firstName = credentials.UserClaims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
            lastName = credentials.UserClaims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value ?? string.Empty;
            email = credentials.UserClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            photoUrl = "https://secure.gravatar.com/avatar/62921d835f6d165597ff0dcd40fd2664?s=260&d=mm&r=g";

            var context = new Models.MobileServiceContext();
            var currentUser = context.StudentPartners.FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                currentUser = new StudentPartner
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhotoUrl = photoUrl
                };

                context.StudentPartners.Add(currentUser);
            }
            else
            {
                currentUser.FirstName = firstName;
                currentUser.LastName = lastName;
                currentUser.Email = email;
            }

            await context.SaveChangesAsync();

            return currentUser;
        }
    }
}
