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
using System.Text;
using System.Security.Cryptography;

namespace StudentPartners.Service.Controllers
{
    [MobileAppController]
    public class UserInfoController : ApiController
    {
        [Authorize]
        public async Task<StudentPartner> Get()
        {
            var user = User as ClaimsPrincipal;
            var credentials = await user.GetAppServiceIdentityAsync<AzureActiveDirectoryCredentials>(Request);

            var userId = credentials.UserId;
            var context = new Models.MobileServiceContext();
            var currentUser = context.StudentPartners.FirstOrDefault(u => u.Id == userId);

            // Student Partner does not exist.
            if (currentUser == null)
            {
                var firstName = credentials.UserClaims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
                var lastName = credentials.UserClaims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value ?? string.Empty;
                var email = credentials.UserClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;
                var photoUrl = ComputeGravatarUrl(email);

                currentUser = new StudentPartner
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhotoUrl = photoUrl
                };

                context.StudentPartners.Add(currentUser);
                await context.SaveChangesAsync();
            }

            return currentUser;
        }

        string ComputeGravatarUrl(string email)
        {
            if (string.IsNullOrEmpty(email))
                return "https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png";

            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(email);
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string.
                var stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2"));
                }

                return $"https://secure.gravatar.com/avatar/{stringBuilder.ToString()}";
            }
        }
    }
}